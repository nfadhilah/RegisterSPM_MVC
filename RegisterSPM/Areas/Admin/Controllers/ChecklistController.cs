using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = SD.RoleAdmin + "," + SD.RoleSA)]
  public class ChecklistController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public ChecklistController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
      var result = await _unitOfWork.Checklist.GetAllAsync();
      return View(result);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
      var checklist = new Checklist();
      if (id.HasValue)
      {
        checklist = await _unitOfWork.Checklist.GetAsync(id.Value);
        if (checklist == null) return NotFound();
      }
      return View(checklist);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Checklist checklist)
    {
      if (ModelState.IsValid)
      {
        if (checklist.Id == 0)
        {
          await _unitOfWork.Checklist.AddAsync(checklist);
        }
        else
        {
          _unitOfWork.Checklist.Update(checklist);
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }

      return View(checklist);
    }

    #region API CALLS

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _unitOfWork.Checklist.GetAllAsync();
      return Json(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
      var existing = await _unitOfWork.Checklist.GetAsync(id);
      if (existing == null) return Json(new { Success = false, Message = "Gagal menghapus data" });
      await _unitOfWork.Checklist.RemoveAsync(existing);
      _unitOfWork.Save();
      return Json(new { Success = true, Message = "Hapus data berhasil" });
    }

    #endregion
  }
}