using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate;

namespace MAMAMENYA.Nhibernate
{
    public class RandomOrder : Order
    {
        public RandomOrder() : base("", true) { }
        public override SqlString ToSqlString(ICriteria criteria, ICriteriaQuery criteriaQuery)
        {
            return new SqlString("newid()");
        }
    }
}
