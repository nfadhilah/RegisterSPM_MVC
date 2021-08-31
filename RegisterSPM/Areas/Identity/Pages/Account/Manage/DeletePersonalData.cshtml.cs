using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Identity.Pages.Account.Manage
{
  public class DeletePersonalDataModel : PageModel
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<DeletePersonalDataModel> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHost;

    public DeletePersonalDataModel(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      ILogger<DeletePersonalDataModel> logger,
      IUnitOfWork unitOfWork,
      IWebHostEnvironment webHost)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _logger = logger;
      _unitOfWork = unitOfWork;
      _webHost = webHost;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
      [Required]
      [DataType(DataType.Password)]
      public string Password { get; set; }
    }

    public bool RequirePassword { get; set; }

    public async Task<IActionResult> OnGet(string userId)
    {
      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
      }

      // RequirePassword = await _userManager.HasPasswordAsync(user);
      RequirePassword = false;
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(string userId)
    {
      ApplicationUser user;
      if ((User.IsInRole(SD.RoleSA) || User.IsInRole(SD.RoleAdmin)) && !string.IsNullOrWhiteSpace(userId))
      {
        user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userId);
      }
      else
      {
        user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x =>
          x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
      }

      if (user == null)
      {
        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
      }

      // RequirePassword = await _userManager.HasPasswordAsync(user);
      // if (RequirePassword)
      // {
      //   if (!await _userManager.CheckPasswordAsync(user, Input.Password))
      //   {
      //     ModelState.AddModelError(string.Empty, "Incorrect password.");
      //     return Page();
      //   }
      // }

      var result = await _userManager.DeleteAsync(user);
      // // var userId = await _userManager.GetUserIdAsync(user);
      if (!result.Succeeded)
      {
        throw new InvalidOperationException($"Gagal menghapus user dengan ID '{userId}'.");
      }

      var webRootPath = _webHost.WebRootPath;
      var imagePath = Path.Combine(webRootPath, user.ImageUrl.TrimStart('\\'));

      if (System.IO.File.Exists(imagePath))
      {
        System.IO.File.Delete(imagePath);
      }

      if (User.FindFirstValue(ClaimTypes.NameIdentifier) == userId)
      {
        await _signInManager.SignOutAsync();

        _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

        return Redirect("~/");
      }

      return Redirect("~/Admin/User");
    }
  }
}