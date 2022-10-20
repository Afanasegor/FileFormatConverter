using System;
using System.Collections.Generic;
using System.Text;

namespace FileFormatConverter.Core.Utils
{
    public static class DateTimeExtensions
    {
        /// <returns>Converts time to full string format (ex.: "2102022_61538437")</returns>
        public static string ToFullString(this DateTime dateTime) 
        {
            var result =    dateTime.Day.ToString() +
                            dateTime.Month.ToString() +
                            dateTime.Year.ToString() +
                            "_" +
                            dateTime.Hour.ToString() +
                            dateTime.Minute.ToString() +
                            dateTime.Second.ToString() +
                            dateTime.Millisecond.ToString();

            return result;
        }
    }
}
