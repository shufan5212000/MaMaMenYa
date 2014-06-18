using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MAMAMENYA
{
    public static class StringExtentions
    {
        public static Encoding chnEncoding = Encoding.GetEncoding("GB2312");

        public static string ToHtmlFormat(this string str)
        {
            return str.Replace("\r\n", "<br />");
        }

        public static bool NotNullAndEmpty(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        public static bool IsNull(this string str)
        {
            return str == null;
        }
        public static bool IsEmpty(this string str)
        {
            return str == string.Empty;
        }
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static int GetByteLen(this string str)
        {
            return chnEncoding.GetByteCount(str);
        }
        public static bool IsRelativeToDefaultPath(this string file)
        {
            return !(file.StartsWith("~", StringComparison.Ordinal) ||
                file.StartsWith("../", StringComparison.Ordinal) ||
                file.StartsWith("/", StringComparison.Ordinal) ||
                file.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                file.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
        }

        public static string Left(this string str, int len)
        {
            if (str.Length <= len) return str;
            return str.Substring(0, len);
        }
        public static string Right(this string str,int len)
        {
            if (str.Length <= len) return str;
            return str.Substring(str.Length - len);
        }

        public static string LeftBytes(this string s, int l)
        {
            return s.LeftBytes(l, string.Empty);
        }
        public static string LeftBytes(this string s, int l,string end)
        {
            string temp = s;
            if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l+end.GetByteLen())
            {
                return temp;
            }
            for (int i = temp.Length; i >= 0; i--)
            {
                temp = temp.Substring(0, i);
                if (Regex.Replace(temp, "[\u4e00-\u9fa5]", "zz", RegexOptions.IgnoreCase).Length <= l)
                {
                    return temp+end;
                }
            }
            return "";
        }

    }


    public static class BooleanExtentions
    {

        public static string ToString(this Boolean @bool, string @true, string @false)
        {
            return @bool ? @true : @false;
        }

        public static string ToZhString(this Boolean @bool)
        {
            return ToString(@bool, "是", "否");
        }
    }
}
