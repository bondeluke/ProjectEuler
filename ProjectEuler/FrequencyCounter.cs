using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler
{
    public class FrequencyCounter<T1>
    {
        private readonly Dictionary<T1, int> _dictionary;

        public FrequencyCounter()
        {
            _dictionary = new Dictionary<T1, int>();
        }

        public int this[T1 key]
        {
            get => _dictionary.ContainsKey(key) ? _dictionary[key] : 0;
            set
            {
                if (!_dictionary.ContainsKey(key))
                {
                    _dictionary.Add(key, 0);
                }

                _dictionary[key] = value;
            }
        }

        public ItemFrequency<T1>[] GetItemFrequencies()
        {
            return _dictionary
                .Select(p => new ItemFrequency<T1>(p.Key, p.Value))
                .ToArray();
        }
    }

    public class ItemFrequency<T1>
    {
        public ItemFrequency(T1 item, int count)
        {
            Item = item;
            Count = count;
        }

        public T1 Item { get; }
        public int Count { get; }
    }
}
