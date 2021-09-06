using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterSPM.Utility
{
  public static class SD
  {
    #region Role

    public const string RoleSA = "SA";
    public const string RoleAdmin = "Admin";
    public const string RoleRegistrator = "Registrator";
    public const string RoleVerifikator = "Verifikator";
    public const string RoleApprover = "Approver";

    #endregion

    #region Session

    public const string SsTahun = "x-tahun";

    #endregion

    #region Status

    public const int Registered = 1;
    public const int Verified = 2;
    public const int Approved = 3;
    public const int Rejected = 4;

    #endregion
  }
}