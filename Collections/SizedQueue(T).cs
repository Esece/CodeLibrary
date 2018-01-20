using System;
using System.Collections.Generic;

namespace Esece.Collections
{
    public class SizedQueue<T> : Queue<T>
    {
        public int Limit
        {
            get;
            protected set;
        }

        public SizedQueue(int limit) : base(limit)
        {
            Limit = limit;
        }

        public new void Enqueue(T item)
        {
            if (Count == Limit)
            {
                Dequeue();
            }

            base.Enqueue(item);
        }
    }
}
