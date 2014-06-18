using System;   
using System.Collections;   
using System.Configuration;   
using System.Data;    
using System.Web;   
using System.Web.Security;   
using System.Web.UI;   
using System.Web.UI.HtmlControls;   
using System.Web.UI.WebControls;   
using System.Web.UI.WebControls.WebParts;
using System.Xml;    
using System.Text;   
using System.Collections.Generic; 

public partial class OnComplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string name = HttpUtility.UrlDecode(Request.QueryString["name"], Encoding.UTF8);
        string finish = Request.QueryString["finish"];
        //如果有name 说明是 单文件 调用 可能是 单文件上传成功 或 失败   
        if (!string.IsNullOrEmpty(name))
        {
            UploadFile File1 = new UploadFile();
            string res = Request.QueryString["res"];
            //如果有res 说明是上传成功 没有则上传失败   
            if (string.IsNullOrEmpty(res))
            {
                try
                {
                    string strRes = "";
                    string type = Request.QueryString["type"];
                    if (type == "File Size") strRes = "失败：文件体积太大";
                    else
                        if (type == "HTTP") strRes = "失败：网络阻塞" + Request.QueryString["status"];
                        else strRes = "失败，未知错误";
                    File1.Name = name;
                    File1.Type = name.Substring(name.LastIndexOf('.') + 1);
                    File1.Size = Request.QueryString["size"];
                    File1.Speed = "0";
                    File1.Res = strRes;
                }
                catch (Exception e1)
                {
                    Response.Write("传入的数据出错！" + e1.Message);
                }
            }
            else
            {
                try
                {
                    File1.Name = name;
                    File1.Type = name.Substring(name.LastIndexOf('.') + 1);
                    File1.Size = Request.QueryString["size"];
                    File1.Speed = Request.QueryString["speed"];
                    File1.Res = Request.QueryString["res"];
                    // File1.ClassName = (string)Session["choseclass"];   
                    File1.Fid = (string)Session["fid"];
                    File1.Count = Request.QueryString["filecount"];
                    File1.Time = DateTime.Now.ToString();
                }
                catch (Exception e1)
                {
                    Response.Write("传入的数据出错！" + e1.Message);
                }
            }
            IList<UploadFile> FileList = new List<UploadFile>();
            if (Session["FileList"] == null)
            {

                Session["FileList"] = FileList;
            }
            FileList = (IList<UploadFile>)Session["FileList"];
            FileList.Add(File1);
            Session["FileList"] = FileList;
        }
        //如果有finish说明是上传完成   
        else if (!string.IsNullOrEmpty(finish))
        {
            //ImageButton1.Visible = true;
            //显示结果   
            if (Label2.Text != "false")
            {
                IList<UploadFile> FileList = new List<UploadFile>();
                FileList = (IList<UploadFile>)Session["FileList"];
                GridView1.DataSource = FileList;
                GridView1.DataBind();
                Label2.Text = "false";

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string name1 = FileList[i].Name;
                    if (name1.Length > 13) name1 = name1.Substring(0, 13) + "...";
                    ((Label)GridView1.Rows[i].FindControl("Label1")).Text = name1;
                    if (FileList[i].Res != "成功")
                        ((DropDownList)GridView1.Rows[i].FindControl("DropDownList3")).Enabled = false;
                }
            }
            Response.Write("成功上传：" + Request.QueryString["succeed"] + "个；   上传失败：" + Request.QueryString["error"] + "个  </br>");


        }

    } 
  
}
