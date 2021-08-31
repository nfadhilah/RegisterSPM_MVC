using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegisterSPM.Models;

namespace RegisterSPM.DataAccess.IRepository
{
  public interface IApplicationUserRepository : IRepositoryAsync<ApplicationUser>
  {
    void Update(ApplicationUser user);
  }
}