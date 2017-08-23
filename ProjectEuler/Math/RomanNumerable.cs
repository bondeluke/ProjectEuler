using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Math
{
    public static class RomanNumerable
    {
        static RomanNumerable()
        {
            _allMappings = new Isomorphism<string, int>();

            foreach (var tuple in _base10Mappings.Concat(_base5Mappings))
            {
                _allMappings.Add(tuple);
            }
        }

        private static readonly Isomorphism<string, int> _allMappings;

        private static readonly Isomorphism<string, int> _base10Mappings = new Isomorphism<string, int>
        {
            {"I", 1},
            {"X", 10},
            {"C", 100},
            {"M", 1000}
        };

        private static readonly Isomorphism<string, int> _base5Mappings = new Isomorphism<string, int>
        {
            {"V", 5},
            {"L", 50},
            {"D", 500}
        };

        private static readonly Dictionary<string, string> _groupingLookup = new Dictionary<string, string>
        {
            {"I", "V"},
            {"X", "L"},
            {"C", "D"}
        };

        private static readonly string[] _validSubractivePairs = {
            "IV",
            "IX",
            "XL",
            "XC",
            "CD",
            "CM"
        };

        public static string ToRoman(this int number)
        {
            var freq = new FrequencyCounter<string>();
            foreach (var mapping in _base10Mappings.OrderByDescending(m => m.Item2))
            {
                if (number < 1)
                    break;

                var result = number.DivideBy(mapping.Item2);
                number = result.Remainder;

                freq[mapping.Item1] = result.Quotient;
            }

            var output = new StringBuilder();

            foreach (var result in freq.GetItemFrequencies())
            {
                if (result.Count == 0) continue;

                if (result.Count == 4 && _groupingLookup.ContainsKey(result.Item))
                {
                    output.Append(result.Item + _groupingLookup[result.Item]);
                    continue;
                }

                if (result.Count == 9 && _base10Mappings[_base10Mappings[result.Item] * 10] != null)
                {
                    output.Append(result.Item + _base10Mappings[_base10Mappings[result.Item] * 10]);
                    continue;
                }

                if (result.Count > 4 && _groupingLookup.ContainsKey(result.Item)) // 5, 6, 7, 8
                {
                    output.Append(_groupingLookup[result.Item] + result.Item.Repeat(result.Count - 5));
                    continue;
                }

                output.Append(result.Item.Repeat(result.Count));
            }

            return output.ToString();
        }

        public static int GetRomanValue(this string roman)
        {
            var value = 0;

            foreach (var pair in _validSubractivePairs)
            {
                if (!roman.Contains(pair)) continue;

                value += GetSubtractivePairValue(pair);
                roman = roman.Replace(pair, string.Empty);
            }

            var freq = new FrequencyCounter<string>();

            foreach (var mapping in _allMappings)
            {
                freq[mapping.Item1] = roman.Count(c => c.ToString() == mapping.Item1);
            }

            return value + freq.GetItemFrequencies().Sum(result => result.Count * _allMappings[result.Item]); ;
        }

        private static int GetSubtractivePairValue(string pair)
        {
            var value1 = pair[0].ToString();
            var value2 = pair[1].ToString();

            return _allMappings[value2] - _allMappings[value1];
        }
    }
}
