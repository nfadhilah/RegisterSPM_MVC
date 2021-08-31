using Microsoft.AspNetCore.Mvc.Filters;
using RegisterSPM.Utility;

namespace RegisterSPM.Filters
{
  public class SessionExpirationFilter : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (!string.IsNullOrWhiteSpace(context.HttpContext.Session.GetObject<string>(SD.SsTahun))) return;
      context.HttpContext.Response.Redirect("/Identity/Account/Login");
      base.OnActionExecuting(context);
    }
  }
}