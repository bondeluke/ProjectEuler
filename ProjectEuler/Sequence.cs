using System.Collections.Generic;
namespace ProjectEuler
{
    public abstract class Sequence
    {
        public Sequence()
        {
            Reset();
        }

        public abstract long Next();

        public abstract void Reset();

        public virtual IEnumerable<long> UpTo(long end)
        {
            long value;
            while ((value = Next()) < end)
                yield return value;
        }
    }
}