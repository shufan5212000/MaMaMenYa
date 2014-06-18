using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAMAMENYA.Core;
using MAMAMENYA.Core.InterfaceRepository;
using NHibernate;

namespace MAMAMENYA.Data
{
    public class SettingRepository : RepositoryWithTypedId<Setting, string>, ISettingRepository
    {


        public static Dictionary<Type, object> list = new Dictionary<Type, object>();

        private IEnumerable<Setting> GetList<T>()
        {
            var q = Query; 
            return q.Where(c => c.Type == typeof(T).FullName).ToArray();
        }

        public void Delete<T>()
        {
           
            Session.Delete("from MAMAMENYA.Core.Setting  where Type =?", typeof(T).FullName, NHibernateUtil.String);
            var tp = typeof(T);
            list.Remove(tp);
            //Session.CreateSQLQuery("delete from Settings where Type = '" + typeof(T).FullName + "'").ExecuteUpdate();//, typeof(T).FullName, NHibernateUtil.String);
           
        }

        #region ISettingRepository 成员

        public T Get<T>() where T : new()
        {
            var tp = typeof(T);

            object obj;

            if (list.TryGetValue(tp, out obj))
            {
                return (T)obj;
            }

            var entity = new T();
            var startindex = tp.FullName.Length;
            foreach (var item in GetList<T>())
            {
                tp.SetValue(entity, item.Id.Substring(startindex + 1), item.Value);
            }
            list[tp] = entity;
            return entity;
        }



        public void Save<T>(T setting) where T : new()
        {
            Session.Transaction.Begin();
            var tp = typeof(T);
            string tpname = tp.FullName;
            Delete<T>();
            foreach (var p in tp.GetProperties())
            {
                if (!p.CanWrite) continue;

                var item = new Setting() { Type = tpname, Value = p.GetValue(setting, null).ToString() };
                item.SetAssignedIdTo(tpname + "." + p.Name);
                Session.Save(item);
                
            }
            list[tp] = setting;
            Session.Transaction.Commit();
        }

        #endregion
    }
}
