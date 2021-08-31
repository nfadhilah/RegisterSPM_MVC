using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = SD.RoleAdmin + "," + SD.RoleSA)]
  public class UserController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
      return View();
    }

    #region API CALLS

    public async Task<IActionResult> GetAll()
    {
      var result = await _unitOfWork.ApplicationUser.GetAllAsync();
      return Json(result);
    }

    #endregion
  }
}