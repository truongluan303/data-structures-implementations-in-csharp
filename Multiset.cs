using System;
using System.Collections.Generic;


namespace Multiset
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Multiset<char> ms = new Multiset<char>();

            ms.Add('a', 2);
            ms.Add('b');
            ms.Add('c', 10);
            ms.Add('d', 5);

            ms.Remove('a');
            ms.Remove('d', 5);

            foreach (char element in ms.GetElements())
            {
                Console.WriteLine($"{element}:{ms.QuantityOf(element)}");
            }
        }
    }



    public class Multiset<T>
    {
        public uint Count { get; private set; }

        private Dictionary<T, uint> _bag;


        
        public Multiset()
        {
            Count = 0;
            _bag = new Dictionary<T, uint>();
        }



        ///====================================================================
        ///<summary> Add new element(s) to the multiset </summary>
        ///
        ///<param name="element">   The element to be added         </param>
        ///<param name="quantity">  The quantity of the new element </param>
        ///
        public void Add(T element, uint quantity = 1)
        {
            if (quantity == 0)
            {
                throw new ArgumentException("Quantity must be positive");
            }
            if (!_bag.ContainsKey(element))
            {
                _bag[element] = 0;
            }
            _bag[element] += quantity;
            Count += quantity;
        }



        ///====================================================================
        ///<summary> Remove element(s) from the multiset  </summary>
        ///
        ///<param name="element">   The element to be removed   </param>
        ///<param name="quantity">  The quantity of the element </param>
        ///
        ///<returns> True if the function call changed the multiset </returns>
        ///
        public bool Remove(T element, uint quantity = 1)
        {
            if (quantity == 0)
            {
                throw new ArgumentException("Quantity must be positive");
            }
            if (!_bag.ContainsKey(element))
            {
                return false;
            }
            if (_bag[element] <= quantity)
            {
                _bag.Remove(element);
            }
            else
            {
                _bag[element] -= quantity;
            }
            return true;
        }



        ///====================================================================
        ///<summary> Check if the multiset contains an element </summary>
        ///
        ///<param name="element"> The element to be checked if exists </param>
        ///
        ///<returns> True if the element exists in the multiset </returns>
        ///
        public bool Contains(T element)
        {
            return _bag.ContainsKey(element);
        }



        ///====================================================================
        ///<summary> Get the quantity of an element </summary>
        ///
        ///<param name="element"> The element to get quantity from </param>
        ///
        ///<returns> The quantity of the given element </returns>
        public uint QuantityOf(T element)
        {
            if (!_bag.ContainsKey(element))
            {
                return 0;
            }
            return _bag[element];
        }


        ///====================================================================
        ///<summary> Get a list of elements in the multiset </summary>
        ///
        ///<returns> The list representation of the elements </returns>
        ///
        public List<T> GetElements()
        {
            return new List<T>(_bag.Keys);
        }
    }
}
