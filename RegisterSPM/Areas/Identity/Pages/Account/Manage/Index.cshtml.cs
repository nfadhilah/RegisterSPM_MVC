using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Identity.Pages.Account.Manage
{
  [Authorize]
  public partial class IndexModel : PageModel
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHost;

    public IndexModel(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      RoleManager<IdentityRole> roleManager,
      IUnitOfWork unitOfWork,
      IWebHostEnvironment webHost)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
      _unitOfWork = unitOfWork;
      _webHost = webHost;
    }

    public string Username { get; set; }

    [TempData]
    public string StatusMessage { get; set; }

    [BindProperty]
    public InputModel Input { get; set; }

    [BindProperty]
    public IFormFile Image { get; set; }

    public class InputModel
    {
      public string NIP { get; set; }
      [Phone]
      [Display(Name = "No. Telepon")]
      public string PhoneNumber { get; set; }

      [Required]
      public string Nama { get; set; }

      public string Jabatan { get; set; }
      [Required]
      public string Role { get; set; }
      public IEnumerable<SelectListItem> RoleList { get; set; }
    }

    private void Load(ApplicationUser user)
    {
      // var userName = await _userManager.GetUserNameAsync(user);
      // var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
      //
      Username = user.UserName;

      Input = new InputModel
      {
        NIP = user.NIP,
        PhoneNumber = user.PhoneNumber,
        Nama = user.Nama,
        Jabatan = user.Jabatan,
        Role = user.Role,
        RoleList = _roleManager.Roles.Select(x => new SelectListItem
        {
          Value = x.Name,
          Text = x.Name
        })
      };
    }

    public async Task<IActionResult> OnGetAsync(string userId)
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

      Load(user);
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

      Load(user);

      if (!ModelState.IsValid)
      {
        return Page();
      }

      //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
      //if (Input.PhoneNumber != phoneNumber)
      //{
      //  var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
      //  if (!setPhoneResult.Succeeded)
      //  {
      //    StatusMessage = "Unexpected error when trying to set phone number.";
      //    return RedirectToPage();
      //  }
      //}

      await _userManager.RemoveFromRoleAsync(user, user.Role);
      await _userManager.AddToRoleAsync(user, Input.Role);
      _unitOfWork.ApplicationUser.Update(user);

      var webRootPath = _webHost.WebRootPath;

      if (!string.IsNullOrWhiteSpace(user.ImageUrl))
      {
        var imagePath = Path.Combine(webRootPath, user.ImageUrl.TrimStart('\\')); 
        if (System.IO.File.Exists(imagePath))
        {
          System.IO.File.Delete(imagePath);
          user.ImageUrl = "";
        }
      }

      if (Image is {Length: > 0})
      {
        var fileName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
        var file = Path.Combine(_webHost.WebRootPath, "img", "avatars", fileName);
        await using var fileStream = new FileStream(file, FileMode.Create);
        await Image.CopyToAsync(fileStream);
        user.ImageUrl = Path.Combine("img", "avatars", fileName);
      }

      _unitOfWork.Save();

      if (User.FindFirstValue(ClaimTypes.NameIdentifier) == user.Id)
      {
        await _signInManager.RefreshSignInAsync(user);
      }
      StatusMessage = "Profil user berhasil diperbaharui";
      return RedirectToPage();
    }
  }
}