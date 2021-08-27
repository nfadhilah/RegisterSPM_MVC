using Common.DAL.Data;
using Common.DAL.IRepository;

namespace Common.DAL
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