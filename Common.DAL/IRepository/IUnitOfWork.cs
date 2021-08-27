using System;

namespace Common.DAL.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    IStoreProcedureCall SpCall { get; }
    void Save();
  }
}