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

        public string UnitKey { get; set; }
        public string OPD { get; set; }

        [Display(Name = "No. SPM")]
        public string NoSPM { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Tgl. SPM")]
        public DateTime TglSPM { get; set; }

        public string Keperluan { get; set; }
        [Display(Name = "Petugas Registrasi")]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Tgl. Registrasi")]
        public DateTime? CreatedDate { get; set; }

        public string VerifiedBy { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RejectedBy { get; set; }
        public DateTime? RejectedDate { get; set; }
        [Display(Name = "Alasan Penolakan")]
        public string AlasanPenolakan { get; set; }
        public decimal Nilai { get; set; }
        public int? DocStatus { get; set; }
        public ICollection<ChecklistSPM> ListChecklistSPM { get; set; }
    }
}