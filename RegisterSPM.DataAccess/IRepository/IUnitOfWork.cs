using System;

namespace RegisterSPM.DataAccess.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    IStoreProcedureCall SpCall { get; }
    ITahunRepository Tahun { get; }
    IChecklistRepository Checklist { get; }
    IApplicationUserRepository ApplicationUser { get; }
    void Save();
  }
}