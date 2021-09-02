using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace RegisterSPM.Utility
{
    public static class PartialViewToString
    {
    public static string ConvertViewToString(ControllerContext controllerContext, PartialViewResult pvr, ICompositeViewEngine viewEngine)
    {
      using var writer = new StringWriter();
      var vResult = viewEngine.FindView(controllerContext, pvr.ViewName, false);
      var viewContext = new ViewContext(controllerContext, vResult.View, pvr.ViewData, pvr.TempData, writer, new HtmlHelperOptions());

      vResult.View.RenderAsync(viewContext);

      return writer.GetStringBuilder().ToString();
    }
  }
}
