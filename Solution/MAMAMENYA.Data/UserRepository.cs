using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;

namespace MAMAMENYA.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        #region IUserRepository 成员

        public User HasExistUser(string loginName)
        {
            var q = Query;
            return Query.FirstOrDefault(c => c.LoginName == loginName);
        }

        #endregion
    }
}
