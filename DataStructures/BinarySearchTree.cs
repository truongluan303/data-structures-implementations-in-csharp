namespace DataStructures
{
    internal class BinarySearchTree<T> where T : notnull, IComparable
    {
        public int Count { get; private set; }
        public BinaryNode<T>? _root;

        public BinarySearchTree()
        {
            Count = 0;
            _root = null;
        }

        /// <summary>
        /// Add a value to the tree.
        /// </summary>
        /// <param name="value">The value to be added.</param>
        public void Insert(T value)
        {
            BinaryNode<T> newNode = new(value);

            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                BinaryNode<T>? current = _root;
                while (true)
                {
                    if (current.Value.CompareTo(value) <= 0)
                    {
                        if (current.Left == null)
                        {
                            current.Left = newNode;
                            break;
                        }
                        current = current.Left;
                    }
                    else
                    {
                        if (current.Right == null)
                        {
                            current.Right = newNode;
                            break;
                        }
                        current = current.Right;
                    }
                }
            }
            Count++;
        }

        /// <summary>
        /// Get the values of the tree in the order of level-order traversal
        /// </summary>
        /// <returns>A list of list where the inner lists are the values of the tree in each level</returns>
        public List<List<T>> LevelOrderTraversal()
        {
            List<List<T>> result = new();
            if (_root == null)
            {
                // return an empty nested list if root is null
                return result;
            }
            Queue<BinaryNode<T>> queue = new();
            queue.Enqueue(_root);

            while (queue.Count > 0)
            {
                int level_size = queue.Count;
                List<T> level = new(level_size);

                for (int i = 0; i < level_size; i++)
                {
                    BinaryNode<T> current = queue.Dequeue();
                    if (current.Left != null)
                    {
                        queue.Enqueue(current.Left);
                    }
                    if (current.Right != null)
                    {
                        queue.Enqueue(current.Right);
                    }
                    level[i] = current.Value;
                }
                result.Add(level);
            }
            return result;
        }

        /// <summary>
        /// Get the values of the tree in the order of inorder traversal.
        /// </summary>
        /// <returns>A list of values in the tree retrieved after an inorder traversal.</returns>
        public List<T> InorderTraversal()
        {
            List<T> result = new();
            InorderTraversal(_root, result);
            return result;
        }

        /// <summary>
        /// A helper function for `InorderTraversal`
        /// </summary>
        /// <param name="root">The root node</param>
        /// <param name="result">The list to be modified in-place</param>
        private void InorderTraversal(BinaryNode<T>? root, List<T> result)
        {
            if (root == null)
            {
                return;
            }
            InorderTraversal(root.Left, result);
            result.Add(root.Value);
            InorderTraversal(root.Right, result);
        }

        /// <summary>
        /// Get the values of the tree in the order of preorder traversal.
        /// </summary>
        /// <returns>A list of values in the tree retrieved after an preorder traversal.</returns>
        public List<T> PreorderTraversal()
        {
            List<T> result = new();
            InorderTraversal(_root, result);
            return result;
        }

        /// <summary>
        /// A helper function for `PreorderTraversal`
        /// </summary>
        /// <param name="root">The root node</param>
        /// <param name="result">THe list to be modified in-place</param>
        private void PreorderTraversal(BinaryNode<T>? root, List<T> result)
        {
            if (root == null)
            {
                return;
            }
            result.Add(root.Value);
            PreorderTraversal(root.Left, result);
            PreorderTraversal(root.Right, result);
        }

        /// <summary>
        /// Get the values of the tree in the order of postorder traversal.
        /// </summary>
        /// <returns>A list of values in the tree retrieved after an postorder traversal.</returns>
        public List<T> PostorderTraversal()
        {
            List<T> result = new();
            PostorderTraversal(_root, result);
            return result;
        }

        /// <summary>
        /// A helper function for `PostorderTraversal`
        /// </summary>
        /// <param name="root">The root node</param>
        /// <param name="result">The list to be modified in-place</param>
        private void PostorderTraversal(BinaryNode<T>? root, List<T> result)
        {
            if (root == null)
            {
                return;
            }
            result.Add(root.Value);
            PostorderTraversal(root.Left, result);
            PostorderTraversal(root.Right, result);
        }
    }
}
