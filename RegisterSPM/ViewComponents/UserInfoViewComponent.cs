using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Utility;

namespace RegisterSPM.ViewComponents
{
  public class UserInfoViewComponent : ViewComponent
  {
    private readonly IUnitOfWork _unitOfWork;

    public UserInfoViewComponent(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
      var claims = (ClaimsIdentity) User.Identity;
      var userClaims = claims?.FindFirst(ClaimTypes.NameIdentifier);
      var user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userClaims.Value);
      return View(user);
    }
  }
}