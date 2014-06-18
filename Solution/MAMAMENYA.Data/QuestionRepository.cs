using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;

namespace MAMAMENYA.Data
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        #region IQuestionRepository 成员

        public RecordList<Question> GetAllByClass(int questionId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
