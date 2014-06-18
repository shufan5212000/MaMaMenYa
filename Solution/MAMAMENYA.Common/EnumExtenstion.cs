using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace MAMAMENYA
{
    public static class EnumExtenstion
    {
        public static IEnumerable<SelectListItem> GetEnumList<T>(object selectval)
        {
            IEnumerable<SelectListItem> selectList = null;
            var tp = typeof(T).GetRealType();
            if (tp.IsEnum)
            {

                selectList = from T e in Enum.GetValues(tp)
                             select new SelectListItem
                             {
                                 Value = Enum.Format(tp, e, "d"),
                                 Text = e.ToString(),
                                 Selected = (e.Equals(selectval))
                             };

                
            }
            return selectList;
        }
    }
}
