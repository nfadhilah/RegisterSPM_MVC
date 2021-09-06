using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RegisterSPM.Models.ViewModels
{
  public class SPMDetailViewModel
  {
    public SPM SPM { get; set; }
    [Required]
    public List<SelectListItem> Checklist { get; set; }
  }
}