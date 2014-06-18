using System;   
using System.Data;   
using System.Configuration;     
using System.Web;   
using System.Web.Security;   
using System.Web.UI;   
using System.Web.UI.HtmlControls;   
using System.Web.UI.WebControls;   
using System.Web.UI.WebControls.WebParts;
using System.Xml;
   
  
/// <summary>   
///TestUploadFile 的摘要说明   
/// </summary>   
public class TestUploadFile   
{   
    public TestUploadFile()   
    {   
        //   
        //TODO: 在此处添加构造函数逻辑   
        //   
    }   
    private static UploadFile[] Files = new UploadFile[5] { new UploadFile(), new UploadFile(), new UploadFile(), new UploadFile(), new UploadFile()};   
  
    /// <summary>   
    /// 返回空闲的上传对象   
    /// </summary>   
    /// <returns></returns>   
    public static UploadFile CreateUploadFile()   
    {   
    xx:   
        int i = 0;   
        foreach (UploadFile Fi in Files)   
        {   
            i++;   
            lock (Fi)   
            {   
                if (Fi.Enable)   
                {   
                    Fi.Enable = false;   
                    return Fi;   
                }   
            }   
        }   
  
        //如果没有空闲连接，则重新申请   
        System.Threading.Thread.Sleep(50);   
        goto xx;   
    }   
  
    /// <summary>   
    /// 关闭文件对象   
    /// </summary>   
    /// <param name="cn"></param>   
    public static void CloseUploadFile(UploadFile uploadfile)   
    {   
        foreach (UploadFile file in Files)   
        {   
            if (file == uploadfile)   
            {   
                lock (uploadfile)   
                {   
                    uploadfile.Enable = true;   
                    return;   
                }   
            }   
        }   
    }   
    /// <summary>   
    /// 根据文件名，查找文件对象   
    /// </summary>   
    /// <param name="Name"></param>   
    /// <returns></returns>   
    public static UploadFile FindUoloadFile(string Name)   
    {   
        //循环10次--最多查找两秒钟 因为有时候大文件上传有延时。   
        //可能客户端显示上传完成，但是服务器还没来得及生成文件   
        for (int i = 0; i < 10; i++)   
        {   
            foreach (UploadFile file in Files)   
            {   
                if (file.Name == Name)   
                {   
                    return file;   
                }   
            }   
            System.Threading.Thread.Sleep(200);   
        }   
         return null;   
    }   
}  
