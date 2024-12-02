using MyCustomCollections.Interfaces;

namespace MyCustomCollections.Models
{
    public class SmartArray<T> : ISmartArray<T> where T : struct, IComparable<T>
    {
        private readonly T[] _array;

        public SmartArray(int length)
        {
            if (length <= 0)
                throw new ArgumentException("Array length must be positive.");
            _array = new T[length];
        }

        public int Length => _array.Length;

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return _array[index];
            }
            set
            {
                ValidateIndex(index);
                if (value.CompareTo(default(T)) < 0)
                    throw new ArgumentException("Negative values are not allowed.");
                _array[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= _array.Length)
                throw new IndexOutOfRangeException($"Index {index} is out of bounds.");
        }
    }
}
