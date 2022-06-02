namespace DataStructures
{
    public class Queue<T> where T : notnull
    {
        public int Count { get; private set; }

        private SinglyLinkedNode<T>? _head;

        private SinglyLinkedNode<T>? _tail;



        public Queue()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }



        /// <summary>
        /// Add a new value to the end of the queue
        /// </summary>
        /// 
        /// <param name="value"> the value to be added </param>
        /// 
        public void Enqueue(T value)
        {
            SinglyLinkedNode<T> newNode = new(value);

            if (_head == null || _tail == null)
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



        /// <summary>
        /// Remove and return the element on top of the queue
        /// </summary>
        /// 
        /// <returns> the value of the element on top of the queue </returns>
        /// 
        /// <exception cref="InvalidOperationException"> thrown if queue is empty </exception>
        /// 
        public T Dequeue()
        {
            if (_head == null || _tail == null)
            {
                throw new EmptyQueue();
            }

            T result = _head.Value;

            _head = _head.Next;

            Count--;

            return result;
        }



        public T Peek()
        {
            if (_head == null || _tail == null)
            {
                throw new EmptyQueue();
            }
            return _head.Value;
        }



        /// <summary>
        /// Remove the first occurence of the element with the given value
        /// </summary>
        /// 
        /// <param name="value"> value to be remove </param>
        /// 
        /// <returns> true if there was an element removed </returns>
        /// 
        public bool Remove(T value)
        {
            if (_head == null)
            {
                return false;
            }

            if (_head.Value.Equals(value))
            {
                _ = Dequeue();
                return true;
            }

            SinglyLinkedNode<T> prev = _head;
            SinglyLinkedNode<T>? current = _head.Next;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    prev.Next = current.Next;
                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }



        public bool RemoveAll(T value)
        {
            if (_head == null || _tail == null)
            {
                return false;
            }
            if (_head.Value.Equals(value))
            {
                Dequeue();
                return true;
            }

            SinglyLinkedNode<T> current = _head;
            
            while (current.Next != null)
            {
                if (current.Value.Equals(value))
                {
                    current.Next = current.Next.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            return false;
        }



        public bool Contains(T value)
        {
            if (_head == null)
            {
                return false;
            }
            if (Count == 1)
            {
                return _head.Value.Equals(value);
            }

            SinglyLinkedNode<T>? current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }



        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
    }
}
