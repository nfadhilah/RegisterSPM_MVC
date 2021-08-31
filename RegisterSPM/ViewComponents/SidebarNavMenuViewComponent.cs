using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RegisterSPM.ViewComponents
{
    public class SidebarNavMenuViewComponent : ViewComponent
    {
      public IViewComponentResult Invoke()
      {
        return View();
      }
    }
}
