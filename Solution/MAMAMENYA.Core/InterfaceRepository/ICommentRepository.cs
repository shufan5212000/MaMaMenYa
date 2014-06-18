using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class CommentQuery:QueryBase
    {
        public CommentType? CommentType { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }


        public int? ItemId { get; set; }
    }

    public interface ICommentRepository : IRepository<Comment>
    {

    }
}
