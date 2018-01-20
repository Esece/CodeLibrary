using System;
using System.Collections.Generic;

namespace Esece.Collections
{
    public class TupleList<T1, T2> : List<Tuple<T1, T2>>
    {
        public void Add(T1 a, T2 b)
        {
            Add(Tuple.Create(a, b));
        }

        public void Add(T1 a)
        {
            Add(Tuple.Create(a, default(T2)));
        }
    }
}
