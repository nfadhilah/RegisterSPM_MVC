using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models.ViewModels
{
  public class LookupSPMRptViewModel
  {
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "No. SPM harus diisi")]
    public string NoSPM { get; set; }
  }
}