using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math
{
    public class Isomorphism<T1, T2> : List<Tuple<T1, T2>>
    {
        public T1 this[T2 key]
        {
            get { return this.First(m => m.Item2.Equals(key)).Item1; }
        }

        public T2 this[T1 key]
        {
            get { return this.First(m => m.Item1.Equals(key)).Item2; }
        }

        public void Add(T1 item1, T2 item2)
        {
            Add(new Tuple<T1, T2>( item1, item2 ));
        }
    }
}
