using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RegisterSPM.Models;

namespace RegisterSPM.Utility
{
  public static class SeederExtensions
  {
    public static void SeedRole(this ModelBuilder builder)
    {
      builder.Entity<IdentityRole>().HasData(
        new IdentityRole
        {
          Name = "Admin", NormalizedName = "ADMIN"
        }, new IdentityRole {Name = "SA", NormalizedName = "SA"},
        new IdentityRole {Name = "Registrator", NormalizedName = "REGISTRATOR"},
        new IdentityRole {Name = "Verifikator", NormalizedName = "VERIFIKATOR"},
        new IdentityRole {Name = "Approver", NormalizedName = "APPROVER"});
    }

    public static void SeedChecklist(this ModelBuilder builder)
    {
      builder.Entity<Checklist>().HasData(
        new Checklist {Id= 1, SeqNo = "00001", Uraian = "Penelitian Kelengkapan Dokumen SPP - UP/GU/TU/LS (Cheklist)"},
        new Checklist {Id= 2, SeqNo = "00002", Uraian = "Surat Pengantar SPP - UP/GU/TU/LS" },
        new Checklist {Id= 3, SeqNo = "00003", Uraian = "Ringkasan SPP - UP/GU/TU/LS " },
        new Checklist {Id= 4, SeqNo = "00004", Uraian = "Rincian SPP - UP/GU/TU/LS" },
        new Checklist {Id= 5, SeqNo = "00005", Uraian = "Surat Perintah Membayar (SPM)" },
        new Checklist {Id= 6, SeqNo = "00006", Uraian = "Kuitansi Dinas" },
        new Checklist {Id= 7, SeqNo = "00007", Uraian = "Surat Pernyataan Pengajuan SPP -UP/GU/TU/LS" },
        new Checklist {Id= 8, SeqNo = "00008", Uraian = "Surat Pernyataan Tanggung jawab yang ditandatangani oleh PA/KPA" },
        new Checklist {Id= 9, SeqNo = "00009", Uraian = "Faktur Pajak/SSP" },
        new Checklist {Id= 10, SeqNo = "00010", Uraian = "Salinan SPD" },
        new Checklist {Id= 11, SeqNo = "00011", Uraian = "Foto Copy Buku Rekening Bank / Referensi Bank" }
      );
    }

    public static void SeedTahun(this ModelBuilder builder)
    {
      builder.Entity<Tahun>().HasData(new Tahun {Id = 1, SeqNo = "00001", Label = "2021"});
    }
  }
}