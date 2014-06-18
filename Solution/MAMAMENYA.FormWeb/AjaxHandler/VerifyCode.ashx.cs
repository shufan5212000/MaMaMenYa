using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Web;

namespace Smart_Clicker.Web.Content.ajaxHandler
{
    /// <summary>
    /// VerifyCode 的摘要说明
    /// </summary>
    public class VerifyCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            CreateCheckCodeImage(GenerateCheckCode());
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
        }
        private string GenerateCheckCode()
        {
            string[] source = { "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            int number;
            //创建字符型变量
            string code = "";
            //创建字符串变量并初始化为空
            string verifyCode = String.Empty;
            //创建Random对象
            Random random = new Random();
            //使用For循环生成5个数字
            for (int i = 0; i < 5; i++)
            {
                verifyCode += source[random.Next(0, source.Length)];
            }
            //将生成的随机数添加到Cookies中
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("verifyCode", verifyCode));
            //返回字符串
            return verifyCode;
        }

        private void CreateCheckCodeImage(string verifyCode)
        {
            if (verifyCode == null || verifyCode.Trim() == String.Empty)
            {
                return;
            }
            Bitmap image = new Bitmap((int)Math.Ceiling((verifyCode.Length * 14.0)), 27);
            Graphics g = Graphics.FromImage(image);

            try
            {
                //生成随机生成器
                Random random = new Random();

                //清空图片背景色
                g.Clear(Color.White);
                for (int i = 0; i < 2; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Black), x1, y1, x2, y2);
                }
                var font = new Font("Arial", 13, (FontStyle.Bold));
                var brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Black, Color.Black, 1.2f, true);
                g.DrawString(verifyCode, font, brush, 2, 3);
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.LightSteelBlue), 0, 0, image.Width - 1, image.Height - 1);
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            }
            finally
            {
                g.Dispose();
                image.Dispose();
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
}