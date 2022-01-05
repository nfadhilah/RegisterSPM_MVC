using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Models.ViewModels
{
    public class SPMApprovalViewModel
    {
        public SPM SPM { get; set; }
        public bool IsRejected { get; set; }
    }
}
