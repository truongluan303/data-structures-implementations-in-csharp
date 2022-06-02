using System.Collections;


namespace DataStructures
{
    public class LinkedList<T> : IEnumerable<T> where T : notnull
    {
        public int Count { get; private set; }
        private SinglyLinkedNode<T>? _head;
        private SinglyLinkedNode<T>? _tail;

        public LinkedList()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// Add a new value to the beginning of the list.
        /// </summary>
        /// <param name="value">The new value to be added.</param>
        public void Prepend(T value)
        {
            SinglyLinkedNode<T> newSinglyLinkedNode = new(value);

            if (Count == 0)
            {
                _head = newSinglyLinkedNode;
                _tail = newSinglyLinkedNode;
            }
            else
            {
                newSinglyLinkedNode.Next = _head;
                _head = newSinglyLinkedNode;
            }
            Count++;
        }

        /// <summary>
        /// Add a new value to the end of the list.
        /// </summary>
        /// <param name="value">The new value to be added.</param>
        public void Append(T value)
        {
            SinglyLinkedNode<T> newSinglyLinkedNode = new(value);

            if (_head == null || _tail == null)
            {
                _head = newSinglyLinkedNode;
                _tail = newSinglyLinkedNode;
            }
            else
            {
                _tail.Next = newSinglyLinkedNode;
                _tail = _tail.Next;
            }
            Count++;
        }

        /// <summary>
        /// Add a new value after a given index.
        /// </summary>
        /// <param name="idx">The index to insert the value after.</param>
        /// <param name="value">The new value to be added.</param>
        /// <exception cref="IndexOutOfRangeException">Raised when the given index is out of range.</exception>
        public void InsertAfter(int idx, T value)
        {
            if (_head == null || idx <= 0 || idx > Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (idx == Count)
            {
                Append(value);
            }
            else
            {
                SinglyLinkedNode<T> newSinglyLinkedNode = new(value);

                SinglyLinkedNode<T> current = _head;

#pragma warning disable CS8602, CS8600      // current cannot be null inside this block of code

                for (int i = 0; i < idx - 1; i++)
                {
                    current = current.Next;
                }

                newSinglyLinkedNode.Next = current.Next;
                current.Next = newSinglyLinkedNode;

#pragma warning restore CS8602, CS8600
            }
        }

        /// <summary>
        /// Add a new value before a given index.
        /// </summary>
        /// <param name="idx">The index to insert the value before.</param>
        /// <param name="value">The new value to be added.</param>
        /// <exception cref="IndexOutOfRangeException">Raised when the given index is out of range.</exception>
        public void InsertBefore(int idx, T value)
        {
            if (_head == null || idx <= 0 || idx > Count)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (idx == 1)
            {
                Prepend(value);
            }
            else
            {
                SinglyLinkedNode<T> newSinglyLinkedNode = new(value);
                SinglyLinkedNode<T> current = _head;
                SinglyLinkedNode<T>? prev = null;

#pragma warning disable CS8602, CS8600      // current and prev cannot be null inside this block of code

                for (int i = 0; i < idx - 1; i++)
                {
                    prev = current;
                    current = current.Next;
                }

                prev.Next = newSinglyLinkedNode;
                newSinglyLinkedNode.Next = current;

#pragma warning restore CS8602, CS8600
            }
        }

        /// <summary>
        /// Remove the first element in the list.
        /// </summary>
        public void RemoveHead()
        {
            if (_head == null || _tail == null)
            {
                return;
            }
            _head = _head.Next;
            Count--;
        }

        /// <summary>
        /// Remove the last element in the list.
        /// </summary>
        public void RemoveTail()
        {
            if (_head == null || _tail == null)
            {
                return;
            }
            if (Count == 1)
            {
                RemoveHead();
                return;
            }
            SinglyLinkedNode<T> current = _head;
            SinglyLinkedNode<T>? prev = null;

#pragma warning disable CS8602, CS8600      // current and prev cannot be null inside this block of code

            for (int i = 0; i < Count - 1; i++)
            {
                prev = current;
                current = current.Next;
            }
            prev.Next = null;
            _tail = prev;

#pragma warning restore CS8602, CS8600
        }

        /*
        public bool Remove(T value)
        {
            SinglyLinkedNode current = _head;

            SinglyLinkedNode prev = null;

            while (current != null)
            {
                if (current.Value == value)
                {

                }
            }
        }
        */

        /// <summary>
        /// Convert the linked list into an array.
        /// </summary>
        /// <returns>The array representation of the linked list</returns>
        public T[] ToArray()
        {
            T[] arr = new T[Count];
            SinglyLinkedNode<T>? current = _head;

            uint i = 0;
            while (current != null)
            {
                arr[i++] = current.Value;
                current = current.Next;
            }
            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
