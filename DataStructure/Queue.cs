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
        /// <returns> the value of the element on top of the queue</returns>
        /// 
        /// <exception cref="InvalidOperationException"> thrown if queue is empty</exception>
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

        /// <summary>
        /// Get the value at the front of the queue
        /// </summary>
        /// <returns>The value at the front of the queue</returns>
        /// <exception cref="EmptyQueue">Raised when the queue is empty</exception>
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

        /// <summary>
        /// Remove all the elements in the queue with the given value
        /// </summary>
        /// <param name="value">The value to be removed</param>
        /// <returns>True if any removal was performed, false otherwise</returns>
        public bool RemoveAll(T value)
        {
            bool removed = false;
            while (_head != null && _head.Value.Equals(value))
            {
                Dequeue();
                removed = true;
            }
            SinglyLinkedNode<T>? current = _head;
            SinglyLinkedNode<T>? prev = null;
            while (current != null)
            {
                if (current.Value.Equals(value) && prev != null)
                {
                    prev.Next = current.Next;
                    removed = true;
                    Count--;
                }
                else
                {
                    prev = current;
                }
                current = current.Next;
            }
            return removed;
        }

        /// <summary>
        /// Check if the queue contains any element with the given value
        /// </summary>
        /// <param name="value">The value to be checked</param>
        /// <returns>True if the element with the given value found, false otherwise</returns>
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

        /// <summary>
        /// Remove all elements in the queue
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }
    }
}
