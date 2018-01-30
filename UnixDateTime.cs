using System;

namespace Esece
{
    public class UnixDateTime
    {
        static readonly DateTime UnixStartDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

        double _value;

        public UnixDateTime(double value)
        {
            _value = value;
        }

        public static UnixDateTime FromDateTime(DateTime dateTime)
        {
            return new UnixDateTime((dateTime.ToUniversalTime() - UnixStartDateTime).TotalMilliseconds);
        }

        public static implicit operator double(UnixDateTime unixTime)
        {
            return unixTime._value;
        }

        public static implicit operator long(UnixDateTime unixTime)
        {
            return (long)unixTime._value;
        }

        public DateTime ToDateTime()
        {
            return UnixStartDateTime.AddMilliseconds(_value);
        }
    }
}
