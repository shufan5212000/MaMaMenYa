﻿<%@ WebHandler Language="C#" Class="UploadHandler" %>   
  
using System;   
using System.Web;   
  
public class UploadHandler : IHttpHandler {   
       
    public void ProcessRequest (HttpContext context)    
    {   
        UploadFile uploadfile = TestUploadFile.CreateUploadFile();   
        context.Response.ContentType = "text/plain";   
        context.Response.Charset = "utf-8";   
           
        HttpPostedFile file = context.Request.Files["Filedata"];   
        string uploadPath = HttpContext.Current.Server.MapPath(@context.Request["folder"]) + "\\";   
        if (file != null)   
        {   
            if (!System.IO.Directory.Exists(uploadPath))   
            {   
                System.IO.Directory.CreateDirectory(uploadPath);   
            }   
            file.SaveAs(uploadPath + file.FileName);   
  
            TestUploadFile.CloseUploadFile(uploadfile);   
            //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失   
            context.Response.Write("1");   
        }   
        else  
        {   
            context.Response.Write("0");   
        }     
  
    }   
    
    public bool IsReusable {   
        get {   
            return false;   
        }   
    }   
  
}  
