using MyCustomCollections.Interfaces;

namespace MyCustomCollections.Models
{
    public class SmartArray<T> : ISmartArray<T> where T : struct, IComparable<T>
    {
        private class Node
        {
            public T Value;
            public Node Next;

            public Node(T value, Node next = null)
            {
                Value = value;
                Next = next;
            }
        }

        private Node _head;
        private int _length;

        public int Length => _length;

        public SmartArray(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Array length must be positive.");

            _length = length;
            Node current = null;

            for (int i = 0; i < length; i++)
            {
                var newNode = new Node(default);
                if (_head == null)
                {
                    _head = newNode;
                    current = _head;
                }
                else
                {
                    current.Next = newNode;
                    current = current.Next;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return GetNode(index).Value;
            }
            set
            {
                ValidateIndex(index);
                if (value.CompareTo(default(T)) < 0)
                    throw new ArgumentException("Negative values are not allowed.");

                GetNode(index).Value = value;
            }
        }

        private Node GetNode(int index)
        {
            Node current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _length)
                throw new IndexOutOfRangeException($"Index {index} is out of bounds.");
        }
    }
}
