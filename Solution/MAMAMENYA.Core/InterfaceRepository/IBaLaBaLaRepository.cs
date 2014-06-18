using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class BaLaBaLaQuery : QueryBase
    {
        public string LoginName { get; set; }


    }


    public interface IBaLaBaLaRepository : IRepository<BaLaBaLa>
    {
        BaLaBaLa GetByLoginName(string loginName);
    }
}
