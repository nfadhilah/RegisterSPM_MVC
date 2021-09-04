using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Models.ViewModels;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Main.Controllers
{
  [Area("Main")]
  [AllowAnonymous]
  [Authorize]
  public class SPMController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStoreProcedureCall _spCall;
    private readonly ICompositeViewEngine _viewEngine;

    public SPMController(IUnitOfWork unitOfWork, IStoreProcedureCall spCall, ICompositeViewEngine viewEngine)
    {
      _unitOfWork = unitOfWork;
      _spCall = spCall;
      _viewEngine = viewEngine;
    }

    [HttpGet]
    public IActionResult Index()
    {

      return BadRequest();
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

    public IActionResult Add(string unitKey, string noSpm)
    {
      var spm = _spCall.OneRecord<LookupSPMViewModel>("Usp_SPM_Get_Single",
        new DynamicParameters(new {UnitKey = unitKey, NoSPM = noSpm}));

      if (spm == null) return NotFound();

      var model = new SPM
      {
        OPD = spm.OPD,
        NoSPM = spm.NoSpm,
        TglSPM = spm.TglSpm,
        Keperluan = spm.Keperluan
      };

      return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(SPM model)
    {
      if (!ModelState.IsValid) return View(model);

      await _unitOfWork.SPM.AddAsync(model);
      _unitOfWork.Save();

      return RedirectToAction(nameof(Index));
    }

    #region API CALLS

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _unitOfWork.SPM.GetAllAsync();
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