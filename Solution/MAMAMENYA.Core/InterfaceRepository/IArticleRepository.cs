using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class ArticleQuery : QueryBase
    {
        public int? ClassId { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
    public interface IArticleRepository : IRepository<Article>
    {

    }
}
