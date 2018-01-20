using System;
using S78;

namespace S78.Extensions
{
    public static class ObjectExtensions
    {
        public static T ShallowCopy<T>(this object source)
        {
            var newInstance = Activator.CreateInstance<T>();
            return new ObjectMapper().ShallowCopy(source, newInstance);
        }

        public static T2 ShallowCopy<T1, T2>(this T1 source, T2 destination)
        {
            return new S78.ObjectMapper().ShallowCopy(source, destination);
        }
    }
}
