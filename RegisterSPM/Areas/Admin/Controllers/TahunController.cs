using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = SD.RoleAdmin + "," + SD.RoleSA)]
  public class TahunController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public TahunController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    public async Task<IActionResult> Index()
    {
      var result = await _unitOfWork.Tahun.GetAllAsync();
      return View(result);
    }

    public async Task<IActionResult> Upsert(int? id)
    {
      var tahun = new Tahun();
      if (id.HasValue)
      {
        tahun = await _unitOfWork.Tahun.GetAsync(id.Value);
        if (tahun == null) return NotFound();
      }
      return View(tahun);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Upsert(Tahun tahun)
    {
      if (ModelState.IsValid)
      {
        if (tahun.Id == 0)
        {
          await _unitOfWork.Tahun.AddAsync(tahun);
        }
        else
        {
          _unitOfWork.Tahun.Update(tahun);
        }
        _unitOfWork.Save();
        return RedirectToAction(nameof(Index));
      }

      return View(tahun);
    }

    #region API CALLS

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _unitOfWork.Tahun.GetAllAsync();
      return Json(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
      var existing = await _unitOfWork.Tahun.GetAsync(id);
      if (existing == null) return Json(new {Success = false, Message = "Gagal menghapus data"});
      await _unitOfWork.Tahun.RemoveAsync(existing);
      _unitOfWork.Save();
      return Json(new {Success = true, Message = "Hapus data berhasil"});
    }

    #endregion
  }
}