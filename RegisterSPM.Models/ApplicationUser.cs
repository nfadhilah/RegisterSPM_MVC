using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RegisterSPM.Models
{
    public class ApplicationUser : IdentityUser
    {
      public string NIP { get; set; }
      [Required]
      public string Nama { get; set; }
      public string Jabatan { get; set; }
      public string ImageUrl { get; set; }
      public string Role { get; set; }
    }
}
