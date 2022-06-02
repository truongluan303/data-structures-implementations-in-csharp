namespace DataStructures
{
    /// <summary>
    /// A bi-directional hashed map. A normal hash map would only map a key to a value
    /// and not vice versa. A bi-directional hash map enables us to map in 2 ways. So
    /// as long as we know one element in the pair, we can get the another in constant
    /// time.
    /// </summary>
    /// <typeparam name="T">Generic type for the first element</typeparam>
    /// <typeparam name="K">Generic type for the second element</typeparam>
    public class BiMap<T, K> 
        where T : notnull
        where K : notnull
    {
        private readonly Dictionary<T, K> _firstWay;
        private readonly Dictionary<K, T> _secondWay;
        public int Count => _firstWay.Count;

        public BiMap()
        {
            _firstWay = new Dictionary<T, K>();
            _secondWay = new Dictionary<K, T>();
        }

        /// <summary>
        /// Add a new pair of elements to the map.
        /// </summary>
        /// <param name="firstVal">The value of the first element</param>
        /// <param name="secondVal">The value of the second element</param>
        public void Add(T firstVal, K secondVal)
        {
            _firstWay[firstVal] = secondVal;
            _secondWay[secondVal] = firstVal;
        }

        /// <summary>
        /// Remove a pair from the map
        /// </summary>
        /// <param name="value">The value of one of the elements in the pair.</param>
        public void Remove(T value)
        {
            if (!_firstWay.ContainsKey(value))
            {
                return;
            }
            _firstWay.Remove(value);
        }

        /// <summary>
        /// Remove a pair from the map.
        /// </summary>
        /// <param name="value">The value of one of the elements in the pair.</param>
        public void Remove(K value)
        {
            if (!_secondWay.ContainsKey(value))
            {
                return;
            }
            _secondWay.Remove(value);
        }

        /// <summary>
        /// Get the other value in the pair.
        /// </summary>
        /// <param name="value">The value of one of the elements in a pair.</param>
        /// <returns>The value of the other element in the pair found.</returns>
        /// <exception cref="ArgumentException">Raised when the given value can't be found.</exception>
        public K Get(T value)
        {
            if (!_firstWay.ContainsKey(value))
            {
                throw new ArgumentException("The given value does not exist");
            }
            return _firstWay[value];
        }

        /// <summary>
        /// Get the other value in the pair.
        /// </summary>
        /// <param name="value">The value of one of the elements in a pair.</param>
        /// <returns>The value of the other element in the pair found.</returns>
        /// <exception cref="ArgumentException">Raised when the given value can't be found.</exception>
        public T Get(K value)
        {
            if (!_secondWay.ContainsKey(value))
            {
                throw new ArgumentException("The given value does not exist");
            }
            return _secondWay[value];
        }

        /// <summary>
        /// Set the value for the other element.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to be set</param>
        public void Set(T key, K value)
        {
            _firstWay[key] = value;
        }

        /// <summary>
        /// Set the value for the other element.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value to be set</param>
        public void Set(K key, T value)
        {
            _secondWay[key] = value;
        }

        public K this[T key]
        {
            get { return _firstWay[key]; }
            set { _firstWay[key] = value; }
        }

        public T this [K key]
        {
            get { return _secondWay[key]; }
            set { _secondWay[key] = value; }
        }
    }
}
