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
    public class ChecklistRepository : RepositoryAsync<Checklist>, IChecklistRepository
    {
      public ChecklistRepository(ApplicationDbContext db) : base(db)
      {
      }

      public void Update(Checklist checklist)
      {
        Db.Checklist.Update(checklist);
      }
    }
}
