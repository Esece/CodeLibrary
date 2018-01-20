using System;

namespace S78.Extensions
{
    public static class TypeExtensions
    {
        public static object GetDefaultValue(this Type type)
        {
            return (type.IsValueType ? Activator.CreateInstance(type) : null);
        }
    }
}
