using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models.ViewModels
{
    public class LookupSPMViewModel
    {
      public string UnitKey { get; set; }
      public string OPD { get; set; }
      public string NoSpm { get; set; }
      public DateTime TglSpm { get; set; }
      public string Keperluan { get; set; }
    }
}
