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
    public class TahunRepository : RepositoryAsync<Tahun>, ITahunRepository
    {
      public TahunRepository(ApplicationDbContext db) : base(db)
      {
      }

      public void Update(Tahun tahun)
      {
        Db.Tahun.Update(tahun);
      }
    }
}
