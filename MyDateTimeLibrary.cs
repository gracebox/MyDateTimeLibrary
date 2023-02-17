using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MyDateTimeLibrary
{
    [Serializable]
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class DateTimeFunctions
    {
        public DateTimeFunctions(){}

        public DateTime UnixTimeToDateTime(int unixTimeInSeconds)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTimeInSeconds).UtcDateTime;
        }

        public long DateTimeUtcToUnixTime(DateTime utcDateTime)
        {
            return new DateTimeOffset(utcDateTime, TimeSpan.Zero).ToUnixTimeSeconds();
        }

        public DateTime UtcToLocal(DateTime utcDateTime)
        {
            return utcDateTime.ToLocalTime();
        }

        public DateTime LocalToUtc(DateTime localDateTime)
        {
            return localDateTime.ToUniversalTime();
        }

        public DateTime TZSpecificDateTimeToUTC(DateTime sourceDateTime, string sourceTimeZoneId)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(sourceTimeZoneId);
            return TimeZoneInfo.ConvertTimeToUtc(sourceDateTime, tzi);
        }

        public DateTime UTCToTZSpecificDateTime(DateTime utcDateTime, string destinationTimeZoneId)
        {
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(destinationTimeZoneId);
            return TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tzi);
        }
    }
}
