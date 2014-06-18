using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class BuyOrderQuery : QueryBase
    {
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }


    public interface IBuyOrderRepository : IRepository<BuyOrder>
    {
    }
}
