using System;


namespace Queue
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();

            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(q.Dequeue());
            }
        }
    }
    


    public class Queue<T>
    {
        public int Count { get; private set; }

        private LinkedNode _head;

        private LinkedNode _tail;


        public Queue()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }



        public void Enqueue(T value)
        {
            LinkedNode newNode = new LinkedNode(value);

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = _tail.Next;
            }
            Count++;
        }



        public T Dequeue()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Cannot dequeue an empty queue");
            }

            T result = _head.Value;

            _head = _head.Next;

            return result;
        }




        public class LinkedNode
        {
            public T Value { get; set; }

            public LinkedNode Next { get; set; }


            public LinkedNode(T value, LinkedNode next = null)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
