using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore.Query.Internal;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Models.ViewModels;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Main.Controllers
{
  [Area("Main")]
  [Authorize]
  public class SPMController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStoreProcedureCall _spCall;
    private readonly ICompositeViewEngine _viewEngine;
    private readonly IMapper _mapper;

    public SPMController(IUnitOfWork unitOfWork, IStoreProcedureCall spCall, ICompositeViewEngine viewEngine,
      IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _spCall = spCall;
      _viewEngine = viewEngine;
      _mapper = mapper;
    }

    public IActionResult Index()
    {
      return View();
    }

    public async Task<IActionResult> Detail(int id)
    {
      var spm = await _unitOfWork.SPM.GetFirstOrDefaultAsync(x => x.Id == id, "ListChecklistSPM");
      var checklist = await _unitOfWork.Checklist.GetAllAsync();

      if (spm == null) return NotFound();
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userId);
      spm.VerifiedBy = user.Nama;
      spm.VerifiedDate = DateTime.Now;
      spm.DocStatus = SD.Verified;

      var joinedItems = checklist.GroupJoin(spm.ListChecklistSPM, c => c.Id, l => l.ChecklistId, (c, l) => new {c, l})
        .SelectMany(x => x.l.DefaultIfEmpty(), (c, l) => new {c, l});

      var model = new SPMDetailViewModel
      {
        SPM = spm,
        Checklist = joinedItems.Select(x => new SelectListItem
        {
          Value = x.c.c.Id.ToString(),
          Text = x.c.c.Uraian,
          Selected = x.l != null,
        }).ToList()
      };

      return View(model);
    }


    [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin + "," + SD.RoleVerifikator)]
    public async Task<IActionResult> Verify(int id)
    {
      var spm = await _unitOfWork.SPM.GetFirstOrDefaultAsync(x => x.Id == id, "ListChecklistSPM");
      var checklist = await _unitOfWork.Checklist.GetAllAsync();

      if (spm == null) return NotFound();
     
      spm.DocStatus = SD.Verified;
      spm.VerifiedDate = DateTime.Now;

      var joinedItems = checklist.GroupJoin(spm.ListChecklistSPM, c => c.Id, l => l.ChecklistId, (c, l) => new {c, l})
        .SelectMany(x => x.l.DefaultIfEmpty(), (c, l) => new {c, l});

      var model = new SPMDetailViewModel
      {
        SPM = spm,
        Checklist = joinedItems.Select(x => new SelectListItem
        {
          Value = x.c.c.Id.ToString(),
          Text = x.c.c.Uraian,
          Selected = x.l != null,
        }).ToList()
      };

      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin + "," + SD.RoleVerifikator)]
    public async Task<IActionResult> Verify(SPMDetailViewModel model)
    {
      if (model.SPM.VerifiedDate < model.SPM.CreatedDate)
        ModelState.AddModelError("bad-date", "Tanggal Verifikasi tidak boleh kurang dari tanggal registrasi.");

      if (!ModelState.IsValid) return View(model);

      var existing = await _unitOfWork.SPM.GetFirstOrDefaultAsync(x => x.Id == model.SPM.Id, "ListChecklistSPM");

      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userId);

      existing.Id = model.SPM.Id;
      existing.UnitKey = model.SPM.UnitKey;
      existing.OPD = model.SPM.OPD;
      existing.NoSPM = model.SPM.NoSPM;
      existing.TglSPM = model.SPM.TglSPM;
      existing.Keperluan = model.SPM.Keperluan;
      existing.CreatedBy = model.SPM.CreatedBy;
      existing.CreatedDate = model.SPM.CreatedDate;
      existing.VerifiedBy = user.Nama;
      existing.VerifiedDate = model.SPM.VerifiedDate;
      existing.ApprovedBy = model.SPM.ApprovedBy;
      existing.ApprovedDate = model.SPM.ApprovedDate;
      existing.RejectedBy = model.SPM.RejectedBy;
      existing.RejectedDate = model.SPM.RejectedDate;
      existing.Nilai = model.SPM.Nilai;
      existing.DocStatus = model.SPM.DocStatus;

      if (existing.ListChecklistSPM.Any())
        existing.ListChecklistSPM = new List<ChecklistSPM>();

      if (!existing.ListChecklistSPM.Any())
      {
        model.Checklist.ForEach(x =>
        {
          if (x.Selected)
          {
            existing.ListChecklistSPM.Add(new ChecklistSPM
            {
              SPMId = model.SPM.Id,
              ChecklistId = int.Parse(x.Value)
            });
          }
        });
      }

      _unitOfWork.Save();
      _spCall.Execute("Usp_SPM_LOG_Update",
        new DynamicParameters(new {model.SPM.UnitKey, model.SPM.NoSPM, Status = SD.Verified}));
      return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin + "," + SD.RoleApprover)]
    public async Task<IActionResult> Approve(int id)
    {
      var spm = await _unitOfWork.SPM.GetFirstOrDefaultAsync(x => x.Id == id, "ListChecklistSPM");

      if (spm == null) return NotFound();
      spm.ApprovedDate = DateTime.Now;
      spm.DocStatus = SD.Approved;

      return View(spm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin + "," + SD.RoleApprover)]
    public async Task<IActionResult> Approve(SPM model)
    {
      if (model.ApprovedDate < model.VerifiedDate)
        ModelState.AddModelError("bad-date", "Tanggal persetujuan tidak boleh kurang dari tanggal verifikasi.");

      if (!ModelState.IsValid) return View(model);

      if (!ModelState.IsValid) return View(model);

      var existing = await _unitOfWork.SPM.GetFirstOrDefaultAsync(x => x.Id == model.Id);
      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userId);

      existing.Id = model.Id;
      existing.UnitKey = model.UnitKey;
      existing.OPD = model.OPD;
      existing.NoSPM = model.NoSPM;
      existing.TglSPM = model.TglSPM;
      existing.Keperluan = model.Keperluan;
      existing.CreatedBy = model.CreatedBy;
      existing.CreatedDate = model.CreatedDate;
      existing.VerifiedBy = model.VerifiedBy;
      existing.VerifiedDate = model.VerifiedDate;
      existing.ApprovedBy = user.Nama;
      existing.ApprovedDate = model.ApprovedDate;
      existing.RejectedBy = model.RejectedBy;
      existing.RejectedDate = model.RejectedDate;
      existing.Nilai = model.Nilai;
      existing.DocStatus = model.DocStatus;

      _unitOfWork.Save();

      _spCall.Execute("Usp_SPM_LOG_Update",
        new DynamicParameters(new {model.UnitKey, model.NoSPM, Status = SD.Approved}));

      return RedirectToAction(nameof(Index));
    }

    public IActionResult LookUp()
    {
      return View();
    }

    public IActionResult GetForm()
    {
      var model = new TestModel();

      return PartialView("_SPMForm", model);
    }

    [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin + "," + SD.RoleRegistrator)]
    public async Task<IActionResult> Add(string unitKey, string noSpm)
    {
      var spm = _spCall.OneRecord<LookupSPMViewModel>("Usp_SPM_Get_Single",
        new DynamicParameters(new {UnitKey = unitKey, NoSPM = noSpm}));

      if (spm == null) return NotFound();

      var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      var user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userId);

      var model = new SPM
      {
        UnitKey = spm.UnitKey,
        OPD = spm.OPD,
        NoSPM = spm.NoSpm,
        TglSPM = spm.TglSpm,
        Keperluan = spm.Keperluan,
        DocStatus = SD.Registered,
        CreatedDate = DateTime.Now,
        CreatedBy = user.Nama,
        Nilai = spm.Nilai
      };

      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin + "," + SD.RoleRegistrator)]
    public async Task<IActionResult> Add(SPM model)
    {
      if (!ModelState.IsValid) return View(model);

      await _unitOfWork.SPM.AddAsync(model);
      _unitOfWork.Save();

      _spCall.Execute("Usp_SPM_LOG_Insert",
        new DynamicParameters(new {model.UnitKey, model.NoSPM, Status = model.DocStatus}));

      return RedirectToAction(nameof(Index));
    }

    #region API CALLS

    [HttpGet]
    public async Task<IActionResult> GetAll(int? status)
    {
      IEnumerable<SPM> result;

      switch (status)
      {
        case SD.Registered:
          result = await _unitOfWork.SPM.GetAllAsync(x => x.DocStatus == SD.Registered);
          break;
        case SD.Verified:
          result = await _unitOfWork.SPM.GetAllAsync(x => x.DocStatus == SD.Verified);
          break;
        case SD.Approved:
          result = await _unitOfWork.SPM.GetAllAsync(x => x.DocStatus == SD.Approved);
          break;
        case SD.Rejected:
          result = await _unitOfWork.SPM.GetAllAsync(x => x.DocStatus == SD.Rejected);
          break;
        default:
          result = await _unitOfWork.SPM.GetAllAsync();
          break;
      }

      return Json(result);
    }

    [HttpGet]
    public IActionResult LookUpAll()
    {
      var result = _spCall.List<LookupSPMViewModel>("Usp_SPM_GetAll");
      return Json(result);
    }

    #endregion
  }

  public class TestModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
  }
}