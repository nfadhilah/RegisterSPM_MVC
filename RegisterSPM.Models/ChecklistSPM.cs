using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models
{
    public class ChecklistSPM
    {
      public int SPMId { get; set; }
      public SPM SPM { get; set; }
      public int ChecklistId { get; set; }
      public Checklist Checklist { get; set; }
    }
}
