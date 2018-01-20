using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Esece
{
    public class ObjectMapper
    {
        static ConcurrentDictionary<Tuple<Type, Type>, Tuple<SrcDest<PropertyInfo>[], SrcDest<FieldInfo>[]>> DynamicMethodsReflection;

        static ObjectMapper()
        {
            DynamicMethodsReflection = new ConcurrentDictionary<Tuple<Type, Type>, Tuple<SrcDest<PropertyInfo>[], SrcDest<FieldInfo>[]>>();
        }

        public T2 ShallowCopy<T1, T2>(T1 source, T2 destination)
        {
            var key = Tuple.Create(source.GetType(), destination.GetType());
            Tuple<SrcDest<PropertyInfo>[], SrcDest<FieldInfo>[]> cache;

            if (!DynamicMethodsReflection.TryGetValue(key, out cache))
            {
                var properties = new List<SrcDest<PropertyInfo>>();
                var fields = new List<SrcDest<FieldInfo>>();
                var bindingFlags = BindingFlags.Public | BindingFlags.Instance;

                foreach (var property in source.GetType().GetProperties(bindingFlags))
                {
                    var newProp = destination.GetType().GetProperty(property.Name);

                    if (newProp != null && newProp.PropertyType == property.PropertyType)
                    {
                        properties.Add(new SrcDest<PropertyInfo> { Source = property, Destination = newProp });
                    }
                }

                foreach (var field in source.GetType().GetFields(bindingFlags))
                {
                    var newField = destination.GetType().GetField(field.Name);

                    if (newField != null && newField.FieldType == field.FieldType)
                    {
                        fields.Add(new SrcDest<FieldInfo> { Source = field, Destination = newField });
                    }
                }

                cache = Tuple.Create(properties.ToArray(), fields.ToArray());
                DynamicMethodsReflection.TryAdd(key, cache);
            }

            foreach (var property in cache.Item1)
            {
                property.Destination.SetValue(destination, property.Source.GetValue(source));
            }

            foreach (var field in cache.Item2)
            {
                field.Destination.SetValue(destination, field.Source.GetValue(source));
            }

            return destination;
        }

        class SrcDest<T>
        {
            public T Source;
            public T Destination;
        }
    }
}
