using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class ProductClassQuery:QueryBase
    {
        public string Name { get; set; }

        public ProductStatus? Status { get; set; }


        public Plantform Plantform { get; set; }


        public string ProductNo { get; set; }


        public int? ClassId { get; set; }

    }
    public interface IProductClassRepository : IRepository<ProductClass>
    {
    }
}
