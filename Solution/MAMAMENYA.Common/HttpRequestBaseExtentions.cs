using System;
using System.Runtime.InteropServices;
using System.Web;
using System.Linq;

namespace MAMAMENYA
{
    public static class HttpRequestBaseExtentions
    {
        public static bool IsXmlRequest(this HttpRequestBase req)
        {
            return !string.IsNullOrEmpty(req.Headers["IsXml"]);

        }
        public static bool IsJson(this HttpRequestBase req)
        {
            return req.AcceptTypes.Contains("application/json");
        }




        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        private static extern int SendARP(int DestIP, int SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        /// <summary>
        /// 获取请求机的mac地址
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetMac(this HttpRequestBase request)
        {
            // IPAddress.Parse(request.UserHostAddress).Address
            Int32 ldest = inet_addr(request.UserHostAddress);//目的地的ip
            Int32 lhost = 0;//本地的ip
            try
            {
                Byte[] macinfo = new Byte[6];
                uint length = 6;

                int ii = SendARP(ldest, lhost, macinfo, ref length);
                string strmac = "";

                foreach (var item in macinfo)
                {
                    strmac += item.ToString("X2");
                }
                return strmac;
            }
            catch (Exception err)
            {
                return "";
            }
        }
    }
}