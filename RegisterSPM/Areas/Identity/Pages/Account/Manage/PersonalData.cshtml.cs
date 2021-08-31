using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RegisterSPM.Areas.Identity.Pages.Account.Manage
{
  public class PersonalDataModel : PageModel
  {
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ILogger<PersonalDataModel> _logger;

    public string UserId { get; set; }

    public PersonalDataModel(
      UserManager<IdentityUser> userManager,
      ILogger<PersonalDataModel> logger)
    {
      _userManager = userManager;
      _logger = logger;
    }

    public async Task<IActionResult> OnGet(string userId)
    {
      UserId = userId;
      var user = await _userManager.FindByIdAsync(userId);
      if (user == null)
      {
        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
      }

      return Page();
    }
  }
}