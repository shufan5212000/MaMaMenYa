using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class AdvertisementQuery : QueryBase
    {
        public int? ClassId { get; set; }
    }

    public interface IAdvertisementRepository : IRepository<Advertisement>
    {
    }


    public class AdsClassQuery:QueryBase
    {
        
    }

    public interface IAdsClassRepository:IRepository<AdsClass>
    {
        
    }
}
