using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models.ViewModels
{
  public enum ReportType
  {
    Pdf = 1,
    Word = 2,
    Excel = 3
  }

  public class ReportParam
  {
    [Required]
    public string ReportName { get; set; }

    [Required]
    public ReportType FormatType { get; set; }

    public Dictionary<string, object> Parameters { get; set; }
  }
}