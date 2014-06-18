using System;

namespace MAMAMENYA
{
    public static class DateTimeExtentions
    {

        /// <summary>
        /// 本日的起始时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DayStart(DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day);
        }
        /// <summary>
        /// 本日的结束时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime DayEnd(DateTime dt)
        {
            //return new DateTime(dt.Year, dt.Month, dt.Day !=31 ?dt.Day+ 1:dt.Day).AddSeconds(-1);
            return dt.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            //return dt.Date.AddHours(-dt.Hour).AddMinutes(-dt.Minute).AddSeconds(-dt.Second + 1).AddDays(1);

        }

        /// <summary>
        /// 这周周一日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekStart(this DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return dt.Date.AddDays(-6);
            }
            return dt.Date.AddDays(-((int)dt.DayOfWeek - 1));
        }

        /// <summary>
        /// 返回这周周日的日期
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime WeekEnd(this DateTime dt)
        {
            if (dt.DayOfWeek == DayOfWeek.Sunday)
            {
                return dt.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            }
            return dt.Date.AddDays(7 - (int)dt.DayOfWeek).AddHours(23).AddMinutes(59).AddSeconds(59); ;
        }

        /// <summary>
        /// 返回这月的第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime MonthStart(this DateTime? dt)
        {
            if (dt.HasValue)
            {
                return MonthStart(dt.Value);
            }
            return DateTime.MinValue;

        }

        /// <summary>
        /// 返回这月的第一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime MonthStart(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
        /// <summary>
        /// 返回这月的最后一天
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime MonthEnd(this DateTime dt)
        {
            return dt.AddMonths(1).AddDays(-1).Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        /// <summary>
        /// 每季的开始
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime SeasonStart(this DateTime dt)
        {
            int imouth = 0;
            if (dt.Month < 4)
            {
                imouth = 1;
            }
            else if (dt.Month < 7)
            {
                imouth = 4;
            }
            else if (dt.Month < 10)
            {
                imouth = 7;
            }
            else
            {
                imouth = 10;
            }
            return new DateTime(dt.Year, imouth, 1);
        }
        /// <summary>
        /// 每季的结束
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DateTime SeasonEnd(this DateTime dt)
        {
            return SeasonStart(dt).AddMonths(3).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public static DateTime YearStart(this  DateTime dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }
        public static bool MonthEquals(this DateTime dt, DateTime date)
        {
            return dt.Year == date.Year && dt.Month == date.Month;

        }
    }
}
