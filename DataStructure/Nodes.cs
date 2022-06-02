namespace DataStructures
{
    internal class SinglyLinkedNode <T> where T : notnull
    {
        public T Value { get; set; }
        public SinglyLinkedNode<T>? Next { get; set; }


        public SinglyLinkedNode(T value, SinglyLinkedNode<T>? next = null)
        {
            Value = value;
            Next = next;
        }
    }


    internal class DoublyLinkedNode <T> where T : notnull
    {
        public T Value { get; set; }
        public DoublyLinkedNode<T>? Previous { get; set; }
        public DoublyLinkedNode<T>? Next { get; set; }


        public DoublyLinkedNode(T value, DoublyLinkedNode<T>? previous = null, 
                                DoublyLinkedNode<T>? next = null)
        {
            Value = value;
            Previous = previous;
            Next = next;
        }
    }


    internal class BinaryNode <T> where T : notnull
    {
        public T Value { get; set; }
        public BinaryNode<T>? Left { get; set; }
        public BinaryNode<T>? Right { get; set; }


        public BinaryNode(T value, BinaryNode<T>? left = null,
                          BinaryNode<T>? right = null)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
