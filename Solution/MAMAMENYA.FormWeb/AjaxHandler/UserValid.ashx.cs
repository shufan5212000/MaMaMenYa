using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MAMAMENYA.Core.InterfaceRepository;
using MAMAMENYA.Data;

namespace MAMAMENYA.FormWeb.AjaxHandler
{
    /// <summary>
    /// UserValid 的摘要说明
    /// </summary>
    public class UserValid : IHttpHandler
    {
        IUserRepository userRepository = new UserRepository();

        public void ProcessRequest(HttpContext context)
        {
            var loginName = context.Request.QueryString["LoginName"];
            var user = userRepository.HasExistUser(loginName);
            string result = user == null ? "Success" : "Error";

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}