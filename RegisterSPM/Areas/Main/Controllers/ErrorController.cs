using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RegisterSPM.Areas.Main.Controllers
{
  [Area("Main")]
  public class ErrorController : Controller
  {
    public IActionResult Index(int? code)
    {
      return View(code);
    }
  }
}