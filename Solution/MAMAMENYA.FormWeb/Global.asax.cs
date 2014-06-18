﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using MAMAMENYA.Data.NHibernateMaps;
using MAMAMENYA.Nhibernate;
using SharpArch.Data.NHibernate;

namespace MAMAMENYA.FormWeb
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            NHibernateInitializer.Instance().InitializeNHibernateOnce(InitializeNHibernateSession);
        }

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

     


        public override void Init()
        {
            base.Init();
            // The WebSessionStorage must be created during the Init() to tie in HttpApplication events
            _webSessionStorage = new WebAndStaticSessionStorage(this);

        }


        private void InitializeNHibernateSession()
        {
            NHibernateSession.Init(
                _webSessionStorage,
                new string[] { Server.MapPath("~/bin/MAMAMENYA.Data.dll") },
                new AutoPersistenceModelGenerator().Generate(),
                Server.MapPath("~/NHibernate.config"));
        }

        private ISessionStorage _webSessionStorage;
    }
}
