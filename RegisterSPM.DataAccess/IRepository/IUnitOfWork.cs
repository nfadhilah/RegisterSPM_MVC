using System;

namespace RegisterSPM.DataAccess.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    ITahunRepository Tahun { get; }
    IChecklistRepository Checklist { get; }
    IApplicationUserRepository ApplicationUser { get; }
    ISPMRepository SPM { get; }
    void Save();
  }
}