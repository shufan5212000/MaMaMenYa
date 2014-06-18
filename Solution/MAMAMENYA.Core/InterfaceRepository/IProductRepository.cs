using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class ProductQuery : QueryBase
    {
        public Plantform? Plantform { get; set; }


        public CreditRating? CreditRating { get; set; }
    }


    public interface IProductRepository : IRepository<Product>
    {
    }
}
