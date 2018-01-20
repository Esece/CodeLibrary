using System;
using System.Collections.Generic;

namespace S78.Collections
{
    public class TupleList<T1, T2, T3> : List<Tuple<T1, T2, T3>>
    {
        public void Add(T1 a, T2 b, T3 c)
        {
            Add(Tuple.Create(a, b, c));
        }

        public void Add(T1 a, T2 b)
        {
            Add(Tuple.Create(a, b, default(T3)));
        }

        public void Add(T1 a)
        {
            Add(Tuple.Create(a, default(T2), default(T3)));
        }
    }
}
