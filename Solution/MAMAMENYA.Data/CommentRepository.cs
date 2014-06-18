using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;

namespace MAMAMENYA.Data
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        protected override IQueryable<Comment> LoadQuery<TQ>(TQ query)
        {
            var cq = query as CommentQuery;
            var q = Query;
            if (cq.CommentType.HasValue)
            {
                q = q.Where(c => c.CommentType == cq.CommentType);
            }
            if (cq.ItemId.HasValue)
            {
                q = q.Where(c => c.ItemId == cq.ItemId);
            }
            if (cq.StartTime.HasValue)
            {
                q = q.Where(c => c.AddTime >= cq.StartTime);

            }
            if (cq.EndTime.HasValue)
            {
                q = q.Where(c => c.AddTime <= cq.EndTime);
            }
            return q;
        }
    }
}
