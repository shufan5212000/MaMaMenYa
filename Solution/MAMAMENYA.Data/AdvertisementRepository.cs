using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;

namespace MAMAMENYA.Data
{
    public class AdvertisementRepository : Repository<Advertisement>, IAdvertisementRepository
    {
    }

    public class AdsClassRepository : Repository<AdsClass>, IAdsClassRepository
    {

    }
}
