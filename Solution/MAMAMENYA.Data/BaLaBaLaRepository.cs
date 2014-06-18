using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;

namespace MAMAMENYA.Data
{
    public class BaLaBaLaRepository : Repository<BaLaBaLa>, IBaLaBaLaRepository
    {
        #region IBaLaBaLaRepository 成员

        public BaLaBaLa GetByLoginName(string loginName)
        {
            var q = Query;
            return q.FirstOrDefault(c => c.LoginName == loginName);
        }

        #endregion
    }
}
