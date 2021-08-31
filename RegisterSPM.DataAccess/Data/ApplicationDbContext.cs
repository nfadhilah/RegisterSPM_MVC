using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegisterSPM.Models;
using RegisterSPM.Utility;

namespace RegisterSPM.DataAccess.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tahun> Tahun { get; set; }
    public DbSet<Checklist> Checklist { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<Tahun>()
        .HasIndex(x => new { x.SeqNo, x.Label }).IsUnique();

      builder.Entity<SPM>()
        .HasIndex(x => new {x.OPD, x.NoSPM}).IsUnique();

      builder.SeedRole();
      builder.SeedTahun();
      builder.SeedChecklist();
    }
  }
}
