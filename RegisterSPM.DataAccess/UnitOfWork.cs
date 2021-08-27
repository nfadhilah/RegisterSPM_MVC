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

    public IStoreProcedureCall SpCall => new StoreProcedureCall(_db);

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