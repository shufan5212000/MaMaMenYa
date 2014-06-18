using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class ActivityQuery : QueryBase
    {
        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }

    public interface IActivityRepository : IRepository<Activity>
    {

    }
}
