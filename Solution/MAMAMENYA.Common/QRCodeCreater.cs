using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using ThoughtWorks.QRCode.Codec;

namespace MAMAMENYA.Common
{
    /// <summary>
    /// 二维码生成器，支持带图片的二维码
    /// </summary>
    public static class QrCodeCreater
    {
        /// <summary>
        /// 生成不带图片的二维码
        /// </summary>
        /// <param name="data">二维码的文本数据</param>
        public static void CreateNoPic(string data)
        {
            var qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 5;
            qrCodeEncoder.QRCodeBackgroundColor = Color.Aqua;
            qrCodeEncoder.QRCodeForegroundColor = Color.Gold;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //String data = data;

            Bitmap image = qrCodeEncoder.Encode(data);
            var mStream = new System.IO.MemoryStream();
            image.Save(mStream, System.Drawing.Imaging.ImageFormat.Gif);

            var fs = System.IO.File.Create("");
            fs.Write(mStream.ToArray(), 0, mStream.ToArray().Length);
            fs.Close();
        }

        /// <summary>
        /// 生成带图片的二维码
        /// </summary>
        /// <param name="data"></param>
        /// <param name="picUrl">二维码附加图片</param>
        public static void CreateWithPic(string data, string picUrl)
        {
            System.Drawing.Image image = GCode(data); ;
            var mStream = new System.IO.MemoryStream();
            image.Save(mStream, System.Drawing.Imaging.ImageFormat.Gif);
            var mStream2 = new System.IO.MemoryStream();
            var aa = CombinImage(image, picUrl);
            aa.Save(mStream2, System.Drawing.Imaging.ImageFormat.Gif);
            //Response.ClearContent();
            //Response.ContentType = "image/Gif";

            //Response.BinaryWrite(MStream2.ToArray());
        }

        private static Image GCode(String data)
        {
            var qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 5;
            qrCodeEncoder.QRCodeVersion = 7;
            qrCodeEncoder.QRCodeBackgroundColor = Color.Aqua;
            qrCodeEncoder.QRCodeForegroundColor = Color.Gold;

            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            var pbImg = qrCodeEncoder.Encode(data, System.Text.Encoding.UTF8);
            var width = pbImg.Width / 10;
            var dwidth = width * 2;
            Bitmap bmp = new Bitmap(pbImg.Width + dwidth, pbImg.Height + dwidth);
            Graphics g = Graphics.FromImage(bmp);
            var c = System.Drawing.Color.White;
            g.FillRectangle(new SolidBrush(c), 0, 0, pbImg.Width + dwidth, pbImg.Height + dwidth);
            g.DrawImage(pbImg, width, width);
            g.Dispose();
            return bmp;
        }  
        /// <summary>  
        /// 调用此函数后使此两种图片合并，类似相册，有个  
        /// 背景图，中间贴自己的目标图片  
        /// </summary>
        /// <param name="imgBack">源图片</param>
        /// <param name="destImg">粘贴的目标图片</param>  
        private static Image CombinImage(Image imgBack, string destImg)
        {

            System.Drawing.Image img = System.Drawing.Image.FromFile(destImg);        //照片图片    
            if (img.Height != 50 || img.Width != 50)
            {
                img = KiResizeImage(img, 50, 50, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);   

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框  

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);  

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }


        /// <summary>  
        /// Resize图片  
        /// </summary>  
        /// <param name="bmp">原始Bitmap</param>  
        /// <param name="newW">新的宽度</param>  
        /// <param name="newH">新的高度</param>  
        /// <param name="Mode">保留着，暂时未用</param>  
        /// <returns>处理以后的图片</returns>  
        private static Image KiResizeImage(Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                System.Drawing.Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量  
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}
