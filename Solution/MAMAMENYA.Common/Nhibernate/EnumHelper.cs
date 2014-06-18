using System;
using System.Collections.Generic;
using System.Reflection;

namespace MAMAMENYA
{
    public static class EnumHelper
    {
        public static List<EnumItem<T>> GetList<T>()
        {
            Type type = typeof(T);

            FieldInfo[] fis = type.GetFields();
            List<EnumItem<T>> list = new List<EnumItem<T>>();
            foreach (FieldInfo fi in fis)
            {
                if (fi.IsLiteral)
                {
                    EnumItem<T> ei = new EnumItem<T>() { Code = (T)fi.GetValue(type), Name = fi.Name };
                    list.Add(ei);
                }

            }
            return list;
        }

        public static List<EnumItem> GetList(Type type)
        {


            FieldInfo[] fis = type.GetFields();
            List<EnumItem> list = new List<EnumItem>();
            foreach (FieldInfo fi in fis)
            {
                if (fi.IsLiteral)
                {
                    EnumItem ei = new EnumItem() { Code = fi.GetValue(type), Name = fi.Name };
                    list.Add(ei);
                }

            }
            return list;
        }

        
    }

    public class EnumItem
    {
        public EnumItem()
        {

        }

        public object Code { get; set; }
        public string Name { get; set; }
    }
    public class EnumItem<T>
    {
        public EnumItem()
        {

        }

        public T Code { get; set; }
        public string Name { get; set; }
    }
}
