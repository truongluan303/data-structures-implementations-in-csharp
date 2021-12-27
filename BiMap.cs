using System;
using System.Collections.Generic;


namespace BiMap
{
    public class Test
    {
        public static void Main(string[] args)
        {
            BiMap<int, char> bm = new BiMap<int, char>();

            bm.Add(0, 'a');
            bm.Add(1, 'b');
            bm.Add(2, 'c');

            Console.WriteLine(bm.GetCorrespondingValue(0));
            Console.WriteLine(bm.GetCorrespondingValue('c'));
        }
    }



    public class BiMap<T, K>
    {
        public int Count { get; set; }

        private Dictionary<T, K> _firstWay;

        private Dictionary<K, T> _secondWay;


        public BiMap()
        {
            Count = 0;
            _firstWay = new Dictionary<T, K>();
            _secondWay = new Dictionary<K, T>();
        }


        public void Add(T firstVal, K secondVal)
        {
            _firstWay[firstVal] = secondVal;
            _secondWay[secondVal] = firstVal;
            Count++;
        }


        public void Remove(T value)
        {
            if (!_firstWay.ContainsKey(value))
            {
                return;
            }
            _firstWay.Remove(value);
            Count--;
        }


        public void Remove(K value)
        {
            if (!_secondWay.ContainsKey(value))
            {
                return;
            }
            _secondWay.Remove(value);
            Count--;
        }


        public K GetCorrespondingValue(T value)
        {
            if (!_firstWay.ContainsKey(value))
            {
                throw new ArgumentException("The given value does not exist");
            }
            return _firstWay[value];
        }


        public T GetCorrespondingValue(K value)
        {
            if (!_secondWay.ContainsKey(value))
            {
                throw new ArgumentException("The given value does not exist");
            }
            return _secondWay[value];
        }
    }
}
