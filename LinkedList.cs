using System;


namespace LinkedList
{
    public class Test
    {
        public static void Main(string[] args)
        {
            LinkedList<int> llist = new LinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                llist.Append(i);
            }
            for (int i = 0; i < 10; i++)
            {
                llist.Prepend(i); 
            }

            llist.InsertAfter(3, 10);

            int[] arr = llist.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
    }
    
    
    

    public class LinkedList<T>
    {
        public int Count { get; private set; }
        
        private Node _head;

        private Node _tail;


        public LinkedList()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }



        public void Prepend(T value)
        {
            Node newNode = new Node(value);

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head = newNode;
            }
            Count++;
        }


        
        public void Append(T value)
        {
            Node newNode = new Node(value);

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



       public void InsertAfter(int idx, T value)
       {
            if (idx < 1 || idx > Count)
            {
                throw new ArgumentException("Index out of range");
            }
            
            if (idx == Count)
            {
                Append(value);
            }
            else
            {
                Node newNode = new Node(value);

                Node current = _head;

                for (int i = 0; i < idx - 1; i++)
                {
                    current = current.Next;
                }
                
                newNode.Next = current.Next;
                current.Next = newNode;
            }
       } 



        public InsertBefore(int idx, T value)
        {
            if (idx < 1 || idx > Count)
            {
                throw new ArgumentException("Index out of range");
            }

            if (idx == 1)
            {
                Prepend(value);
            }
            else
            {
                Node newNode = new Node(value);

                Node current = _head;
                Node prev = null;

                for (int i = 0; i < idx - 1; i++)
                {
                    prev = current;
                    current = current.Next;
                }

                prev.Next = newNode;
                newNode.Next = current;
            }
        }



        public void RemoveHead()
        {
            if (Count == 0)
            {
                return;
            }
            _head = _head.Next;
        }



        public void RemoveTail()
        {
            if (Count == 0)
            {
                return;
            }

            Node current = _head;
            Node prev = null;

            for (int i = 0; i < Count - 1; i++)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = null;
            _tail = prev;
        }



        public bool Remove(T value)
        {
            Node current = _head;

            Node prev = null;

            while (current != null)
            {
                if (current.Value == value)
                {
                    
                }
            }
        }



        public T[] ToArray()
        {
            T[] arr = new T[Count];

            Node current = _head;
            
            for (int i = 0; i < Count; i++)
            {
                arr[i] = current.Value;
                current = current.Next;
            }
            return arr;
        }



        public class Node
        {
            public T Value { get; set; }

            public Node Next { get; set; }


            public Node(T value, Node next = null)
            {
                Value = value;
                Next = next;
            }    
        }
    }
}
