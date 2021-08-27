using System;

namespace RegisterSPM.DataAccess.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    IStoreProcedureCall SpCall { get; }
    void Save();
  }
}