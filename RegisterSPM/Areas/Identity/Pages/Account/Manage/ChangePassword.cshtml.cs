using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RegisterSPM.DataAccess;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Identity.Pages.Account.Manage
{
  public class ChangePasswordModel : PageModel
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly ILogger<ChangePasswordModel> _logger;

    public ChangePasswordModel(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      ILogger<ChangePasswordModel> logger)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _logger = logger;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    public bool RequiredCurrentPassword { get; set; }

    public class InputModel
    {
      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Password Lama")]
      public string OldPassword { get; set; }

      [Required]
      [StringLength(100, ErrorMessage = "Panjang {0} minimal {2} dan max {1} karakter.",
        MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Password Baru")]
      public string NewPassword { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Konfirmasi Password Baru")]
      [Compare("NewPassword", ErrorMessage = "Password dan Konfirmasi Password Tidak Sama.")]
      public string ConfirmPassword { get; set; }
    }

    public async Task<IActionResult> OnGetAsync(string userId)
    {
      IdentityUser user;

      if (User.IsInRole(SD.RoleSA) || User.IsInRole(SD.RoleAdmin))
      {
        user = await _userManager.FindByIdAsync(userId);
        RequiredCurrentPassword = false;
      }
      else
      {
        user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        RequiredCurrentPassword = true;
      }

      if (user == null)
      {
        return NotFound($"User dengan ID: {_userManager.GetUserId(User)} tidak ditemukan.");
      }

      //var hasPassword = await _userManager.HasPasswordAsync(user);
      //if (!hasPassword)
      //{
      //  return RedirectToPage("./SetPassword");
      //}

      return Page();
    }

    public async Task<IActionResult> OnPostAsync(string userId)
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      IdentityUser user;

      if (User.IsInRole(SD.RoleSA) || User.IsInRole(SD.RoleAdmin))
      {
        user = await _userManager.FindByIdAsync(userId);
        var removePasswordResult = await _userManager.RemovePasswordAsync(user);
        
        if (!removePasswordResult.Succeeded)
        {
          foreach (var error in removePasswordResult.Errors)
          {
            ModelState.AddModelError(string.Empty, error.Description);
          }
        }

        var setPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);

        if (!setPasswordResult.Succeeded)
        {
          foreach (var error in setPasswordResult.Errors)
          {
            ModelState.AddModelError(string.Empty, error.Description);
          }
        }
      }
      else
      {
        user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)); 
        
        var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);

        if (!changePasswordResult.Succeeded)
        {
          foreach (var error in changePasswordResult.Errors)
          {
            ModelState.AddModelError(string.Empty, error.Description);
          }

          return Page();
        }
      }

      if (user == null)
      {
        return NotFound($"User dengan ID: {_userManager.GetUserId(User)} tidak ditemukan.");
      }

      if (user.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
      {
        await _signInManager.RefreshSignInAsync(user);
      }

      _logger.LogInformation("User changed their password successfully.");
      StatusMessage = "Password berhasil dirubah.";

      return RedirectToPage();
    }
  }
}