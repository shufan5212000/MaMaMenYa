<%@ WebHandler Language="c#" Class="File_WebHandler" Debug="true" %>

using System;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;

public class File_WebHandler : IHttpHandler
{
    
    
    public void ProcessRequest(HttpContext context)
    {
        HttpFileCollection files = context.Request.Files;
        if (files.Count > 0)
        {
            Random rnd = new Random();
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];

                if (file.ContentLength > 0)
                {
                    string fileName = file.FileName;
                    string extension = Path.GetExtension(fileName);
                    int num = rnd.Next(5000, 10000000);
                    string path = "/UploadFile/" + num.ToString() + extension;
                    file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path));
                    context.Response.Write(path);
                }
            }
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}