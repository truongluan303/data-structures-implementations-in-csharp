namespace DataStructures
{
    public class Stack<T> where T : notnull
    {
        private readonly List<T> _list;
        public int Count => _list.Count;


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
            if (Count == 0)
            {
                throw new EmptyStack();
            }
            T result = _list[^1];
            _list.RemoveAt(_list.Count - 1);
            return result;
        }


        public T Peek()
        {
            if (Count == 0)
            {
                throw new EmptyStack();
            }
            return _list[^1];
        }


        public bool Contains(T value)
        {
            return _list.Contains(value);
        }


        public bool Remove(T value)
        {
            return _list.Remove(value);
        }


        public bool RemoveAll(T value)
        {
            int originalCount = Count;
            _list.RemoveAll(delegate (T val) { return val.Equals(value); });
            return Count != originalCount;
        }


        public void Clear()
        {
            _list.Clear();
        }
    }
}
