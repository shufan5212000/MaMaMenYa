using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class ArticleClassQuery : QueryBase
    {
        public string Name { get; set; }


        public int ParentId { get; set; }
    }


    public interface IArticleClassRepository : IRepository<ArticleClass>
    {

    }
}
