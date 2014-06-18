using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class AnswerQuery : QueryBase
    {
        public int QuestionId { get; set; }
    }

    public interface IAnswerRepository : IRepository<Answer>
    {

    }
}
