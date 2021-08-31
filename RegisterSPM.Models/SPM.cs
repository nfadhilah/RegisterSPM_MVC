using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models
{
    public class SPM
    {
      [Key]
      public int Id { get; set; }

      public string OPD { get; set; }
      public string NoSPM { get; set; }
      public DateTime TglSPM { get; set; }
      public string Keperluan { get; set; }
      public string CreatedBy { get; set; }
      public string CreatedDate { get; set; }
      public string VerifiedBy { get; set; }
      public string VerifiedDate { get; set; }
      public string ApprovedBy { get; set; }
      public string ApprovedDate { get; set; }
      public int DocStatus { get; set; }
    }
}
