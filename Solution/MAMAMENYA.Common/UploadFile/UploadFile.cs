using System;   
using System.Data;   
using System.Configuration;     
using System.Web;   
using System.Web.Security;   
using System.Web.UI;   
using System.Web.UI.HtmlControls;   
using System.Web.UI.WebControls;   
using System.Web.UI.WebControls.WebParts;   

/// <summary>   
///UploadFile 的摘要说明   
///文件上传的实体类   
/// </summary>   
public class UploadFile   
{   
    public UploadFile()   
    {   
        //   
        //TODO: 在此处添加构造函数逻辑   
        //   
    }   
    private string _count = "";   
    /// <summary>   
    /// 剩余文件数   
    /// </summary>   
    public string Count   
    {   
        get { return _count; }   
        set { _count = value; }   
    }   
  
       
    private  bool _Enable = true;   
    //上传是否可用--同时最多5文件上传   
    public  bool Enable   
    {   
        get  
        {   
            return _Enable;   
        }   
        set  
        {   
            _Enable = value;   
        }   
    }   
    private string _name = "";   
    /// <summary>   
    /// 文件名   
    /// </summary>   
    public string Name   
    {   
        get { return _name; }   
        set { _name = value; }   
    }   
    private string _size = "";   
    /// <summary>   
    /// 文件大小 kb 、mb自适应   
    /// </summary>   
    public string Size   
    {   
        get { return _size; }   
        set  
        {   
            double n = double.Parse(value);   
            if (n < 1024) _size = n + "Bytes";   
            else if (n < 1048576) _size = (n / 1024).ToString("0.00") + "KB";   
            else if (n < 1073741824) _size = (n / 1024 / 1024).ToString("0.00") + "MB";   
            else _size = (n / 1024 / 1024 / 1024).ToString("0.00") + "GB";    
        }   
    }   
    private string _type = "";   
    /// <summary>   
    /// 文件类型   
    /// </summary>   
    public string Type   
    {   
        get { return _type; }   
        set { _type = value; }   
    }   
    private string _classname = "";   
    /// <summary>   
    /// 课程名   
    /// </summary>   
    public string ClassName   
    {   
        get { return _classname; }   
        set { _classname = value; }   
    }   
    private string _fid = "";   
    /// <summary>   
    /// 所在文件名   
    /// </summary>   
    public string Fid   
    {   
        get { return _fid; }   
        set { _fid = value; }   
    }   
    private string _speed = "";   
    /// <summary>   
    /// 速度   
    /// </summary>   
    public string Speed   
    {   
        get { return _speed; }   
        set    
        {   
            if (value=="null") _speed = _size + "/s";   
            else  
            {   
                double n = double.Parse(value);   
                if (n < 1024) _speed = (n ).ToString("0.00") + "Bytes/s";   
                else if (n < 1048576 ) _speed = (n / 1024).ToString("0.00") + "KB/s";   
                else if (n < (double)1073741824) _speed = (n / 1024 / 1024).ToString("0.00") + "MB/s";   
                else _speed = (n / 1024 / 1024 / 1024).ToString("0.00") + "GB/s";   
            }   
        }   
    }   
    private string _res = "";   
    /// <summary>   
    /// 上传结果   
    /// </summary>   
    public string Res   
    {   
        get { return _res; }   
        set {   
            if (value == "1") _res = "成功";   
            else if (value == "0") _res = "失败";   
            else _res = value;   
        }   
    }   
    private string _time = "";   
    /// <summary>   
    /// 上传时间   
    /// </summary>   
    public string Time   
    {   
        get { return _time; }   
        set { _time = value; }   
    }   
    private string _lanmu = "";   
    /// <summary>   

    /// </summary>   
    public string Lanmu   
    {   
        get { return _lanmu; }   
        set { _lanmu = value; }   
    }   
  
  
}  
