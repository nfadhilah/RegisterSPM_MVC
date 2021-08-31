using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models
{
    public class Tahun
    {
      [Key]
      public int Id { get; set; }
      [Required] 
      [Display(Name = "No. Urut")]
      public string SeqNo { get; set; }
      [Required]
      public string Label { get; set; }
    }
}
