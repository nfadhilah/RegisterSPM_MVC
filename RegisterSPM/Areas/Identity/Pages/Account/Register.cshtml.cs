﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;
using RegisterSPM.Utility;

namespace RegisterSPM.Areas.Identity.Pages.Account
{
  [Authorize(Roles = SD.RoleSA + "," + SD.RoleAdmin)]
  public class RegisterModel : PageModel
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<RegisterModel> _logger;
    private readonly IWebHostEnvironment _hostEnvironment;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterModel(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      RoleManager<IdentityRole> roleManager,
      ILogger<RegisterModel> logger,
      IWebHostEnvironment hostEnvironment,
      IUnitOfWork unitOfWork)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _roleManager = roleManager;
      _logger = logger;
      _hostEnvironment = hostEnvironment;
      _unitOfWork = unitOfWork;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    [BindProperty]
    // [Required]
    public IFormFile Image { get; set; }

    public string ReturnUrl { get; set; }

    public IList<AuthenticationScheme> ExternalLogins { get; set; }

    public class InputModel
    {
      [Required]
      [EmailAddress]
      [Display(Name = "Email")]
      public string Email { get; set; }

      [Required]
      [StringLength(100, ErrorMessage = "Panjang {0} minimal {2} dan max {1} karakter.",
        MinimumLength = 6)]
      [DataType(DataType.Password)]
      [Display(Name = "Password")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Konfirmasi Password")]
      [Compare("Password", ErrorMessage = "Password dan Konfirmasi Password Tidak Sama.")]
      public string ConfirmPassword { get; set; }

      public string NIP { get; set; }
      [Display(Name = "No. Telepon")]
      public string PhoneNumber { get; set; }

      [Required]
      public string Nama { get; set; }

      public string Jabatan { get; set; }
      [Required]
      public string Role { get; set; }
      public IEnumerable<SelectListItem> RoleList { get; set; }
    }

    public async Task OnGetAsync(string userId, string returnUrl = null)
    {
      ReturnUrl = returnUrl;
      Input = new InputModel
      {
        RoleList = _roleManager.Roles.Select(x => new SelectListItem
        {
          Value = x.Name,
          Text = x.Name,
        })
      };

      if (!string.IsNullOrWhiteSpace(userId))
      {
        var user = await _unitOfWork.ApplicationUser.GetFirstOrDefaultAsync(x => x.Id == userId);
        if (user != null)
        {
          Input.Email = user.Email;
          Input.Nama = user.Nama;
          Input.NIP = user.NIP;
          Input.Jabatan = user.Jabatan;
          Input.Role = user.Role;
        }
      }
      ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
      returnUrl ??= Url.Content("~/");
      ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

      if (ModelState.IsValid)
      {
        var user = new ApplicationUser
        {
          UserName = Input.Email, 
          Email = Input.Email, 
          NIP = Input.NIP, 
          Nama = Input.Nama, 
          Jabatan = Input.Jabatan,
          Role = Input.Role,
          PhoneNumber = Input.PhoneNumber
        };

        if (Image is {Length: > 0})
        {
          var fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
          var file = Path.Combine(_hostEnvironment.WebRootPath, "img", "avatars", fileName);
          await using var fileStream = new FileStream(file, FileMode.Create);
          await Image.CopyToAsync(fileStream);
          user.ImageUrl = Path.Combine("img", "avatars", fileName);
        }

        var result = await _userManager.CreateAsync(user, Input.Password);
        if (result.Succeeded)
        {

          await _userManager.AddToRoleAsync(user, user.Role);
          _logger.LogInformation("User created a new account with password.");

          var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
          code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
          var callbackUrl = Url.Page(
            "/Account/ConfirmEmail",
            pageHandler: null,
            values: new {area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl},
            protocol: Request.Scheme);

          // await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
          //     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

          if (_userManager.Options.SignIn.RequireConfirmedAccount)
          {
            return RedirectToPage("RegisterConfirmation", new {email = Input.Email, returnUrl = returnUrl});
          }

          // await _signInManager.SignInAsync(user, false);
          return LocalRedirect(returnUrl);
        }

        foreach (var error in result.Errors)
        {
          ModelState.AddModelError(string.Empty, error.Description);
        }
      }

      Input = new InputModel
      {
        RoleList = _roleManager.Roles.Select(x => new SelectListItem
        {
          Value = x.Name,
          Text = x.Name,
        })
      };

      // If we got this far, something failed, redisplay form
      return Page();
    }

    public IActionResult OnGetCancel(string returnUrl = null)
    {
      if (string.IsNullOrWhiteSpace(returnUrl))
      {
        Input = new InputModel
        {
          RoleList = _roleManager.Roles.Select(x => new SelectListItem
          {
            Value = x.Name,
            Text = x.Name,
          })
        };
        return Page();
      };
      return Redirect(returnUrl);
    }
  }
}