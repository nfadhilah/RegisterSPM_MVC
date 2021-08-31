using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Admin.Controllers
{
  [Area("Admin")]
  [Authorize(Roles = SD.RoleSA)]
  public class RoleController : Controller
  {
    private readonly RoleManager<IdentityRole> _roleManager;

    public RoleController(RoleManager<IdentityRole> roleManager)
    {
      _roleManager = roleManager;
    }

    public IActionResult Index()
    {
      return View();
    }

    #region API CALLS

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var result = await _roleManager.Roles.ToListAsync();
      return Json(result);
    }
    

    #endregion
  }
}