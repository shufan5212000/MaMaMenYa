using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class UserQuery : QueryBase
    {
        public string UserLoginName { get; set; }

        public string Tel { get; set; }
    }


    public interface IUserRepository : IRepository<User>
    {
        User HasExistUser(string loginName);
    }
}
