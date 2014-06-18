using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAMAMENYA.Core.InterfaceRepository
{
    public class QuestionQuery : QueryBase
    {
        public QuestionClass QuestionClass { get; set; }

        public User User { get; set; }
    }

    public interface IQuestionRepository : IRepository<Question>
    {
        RecordList<Question> GetAllByClass(int questionId);
    }
}
