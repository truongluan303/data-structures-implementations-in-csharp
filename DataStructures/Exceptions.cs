namespace DataStructures
{
    [Serializable]
    public class IndexOutOfRange : Exception
    {
        private const string DEFAULT_MESSAGE = "Given index is out of range!";
        public IndexOutOfRange(string message = DEFAULT_MESSAGE) : base(message) { }
    }

    public class EmptyStack : Exception
    {
        private const string DEFAULT_MESSAGE = "Attempted to retrieve data from an empty stack!";
        public EmptyStack(string message = DEFAULT_MESSAGE) : base(message) { }
    }

    public class EmptyQueue : Exception
    {
        private const string DEFAULT_MESSAGE = "Attempted to retrieve data from an empty queue!";
        public EmptyQueue(string message = DEFAULT_MESSAGE) : base(message) { }
    }
}
