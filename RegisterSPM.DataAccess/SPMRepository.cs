using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterSPM.DataAccess.Data;
using RegisterSPM.DataAccess.IRepository;
using RegisterSPM.Models;

namespace RegisterSPM.DataAccess
{
  public class SPMRepository : RepositoryAsync<SPM>, ISPMRepository
  {
    public SPMRepository(ApplicationDbContext db) : base(db)
    {
    }

    public void Update(SPM entity)
    {
      Db.Update(entity);
    }
  }
}