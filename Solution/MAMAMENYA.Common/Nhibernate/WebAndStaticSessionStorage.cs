using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Web.NHibernate;

namespace MAMAMENYA.Nhibernate
{
    public class WebAndStaticSessionStorage : ISessionStorage
    {

        private WebSessionStorage webStorage;
        private ThreadSessionStorage threadStorage;
        public WebAndStaticSessionStorage(HttpApplication app)
        {
            webStorage = new WebSessionStorage(app);
            threadStorage = new ThreadSessionStorage();
        }



        #region ISessionStorage 成员

        public IEnumerable<ISession> GetAllSessions()
        {
            if (HttpContext.Current != null)
            {
                return webStorage.GetAllSessions();
            }
            return threadStorage.GetAllSessions();
        }

        public ISession GetSessionForKey(string factoryKey)
        {
            if (HttpContext.Current != null)
            {
                return webStorage.GetSessionForKey(factoryKey);
            }
            return threadStorage.GetSessionForKey(factoryKey);
        }

        public void SetSessionForKey(string factoryKey, ISession session)
        {
            if (HttpContext.Current != null)
            {
                webStorage.SetSessionForKey(factoryKey, session);
            }
            else
                threadStorage.SetSessionForKey(factoryKey, session);
        }

        #endregion
    }
}
