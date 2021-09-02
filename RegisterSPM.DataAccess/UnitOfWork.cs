using Microsoft.EntityFrameworkCore;
using RegisterSPM.DataAccess.Data;
using RegisterSPM.DataAccess.IRepository;

namespace RegisterSPM.DataAccess
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _db;

    public UnitOfWork(ApplicationDbContext db)
    {
      _db = db;
    }

    public ITahunRepository Tahun => new TahunRepository(_db);
    public IChecklistRepository Checklist => new ChecklistRepository(_db);
    public IApplicationUserRepository ApplicationUser => new ApplicationUserRepository(_db);
    public ISPMRepository SPM => new SPMRepository(_db);

    public void Dispose()
    {
      _db.Dispose();
    }

    public void Save()
    {
      _db.SaveChanges();
    }
  }
}