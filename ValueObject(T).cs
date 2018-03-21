using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Esece
{
    public abstract class ValueObject<T>
    {
        static Func<T, T, bool> EqualsCache;
        static Func<T, int> GetHashCodeCache;

        int num = 0;

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            return Equals(a, b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !Equals(a, b);
        }

        public virtual bool Equals(T obj)
        {
            var num = 123;

            num.ToString();

            var type = typeof(T);

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Func<T, T, bool> func = EqualsCache;

            if (func == null)
            {
                var param_objs = new[] { Expression.Parameter(type), Expression.Parameter(type) };
                var lines = new List<Expression>();
                var method = (((Expression<Func<bool>>)(() => Object.Equals((object)null, (object)null))).Body as MethodCallExpression).Method;
                Expression line = null;

                foreach (var prop in type.GetProperties())
                {
                    var args = param_objs.Select(v => (Expression)Expression.Property(v, prop.Name));

                    if (prop.PropertyType.IsValueType)
                    {
                        args = args.Select(a => Expression.Convert(a, typeof(object)));
                    }

                    line = (line == null ? Expression.Call(method, args) : (Expression)Expression.AndAlso(line, Expression.Call(method, args)));
                }

                lines.Add(line);

                func = Expression.Lambda<Func<T, T, bool>>(Expression.Block(lines), param_objs).Compile();
                EqualsCache = func;
            }

            return func((T)(object)this, obj);
        }

        public override bool Equals(object obj)
        {
            return this.Equals((T)obj);
        }

        public override int GetHashCode()
        {
            var type = typeof(T);
            Func<T, int> func = GetHashCodeCache;

            if (func == null)
            {
                var param_t = Expression.Parameter(type);
                var var_hashcode = Expression.Variable(typeof(int));
                var lines = new List<Expression>();

                foreach (var prop in type.GetProperties())
                {
                    var arg1 = Expression.Property(param_t, prop.Name);
                    Expression exp = Expression.Assign(var_hashcode, Expression.ExclusiveOr(var_hashcode, Expression.Call(arg1, prop.PropertyType.GetMethod("GetHashCode"))));

                    if (!prop.PropertyType.IsValueType)
                    {
                        exp = Expression.IfThen(Expression.NotEqual(arg1, Expression.Constant(null)), exp);
                    }

                    lines.Add(exp);
                }

                lines.Add(var_hashcode);

                func = Expression.Lambda<Func<T, int>>(Expression.Block(new[] { var_hashcode }, lines), param_t).Compile();
                GetHashCodeCache = func;
            }

            return func((T)(object)this);
        }
    }
}
