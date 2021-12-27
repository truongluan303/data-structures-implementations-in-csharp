using System;
using System.Collections.Generic;


namespace Stack
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            while (stack.Count() != 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }



    public class Stack<T>
    {
        private List<T> _list;


        public Stack()
        {
            _list = new List<T>();
        }


        public void Push(T value)
        {
            _list.Add(value);
        }


        public T Pop()
        {
            T result = _list[_list.Count - 1];
            _list.RemoveAt(_list.Count - 1);
            return result;
        }


        public int Count()
        {
            return _list.Count;
        }
    }
}
