using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class BinarySearchTree<T>
    {
        private class BinaryTreeNode
        {
            public BinaryTreeNode Left;
            public BinaryTreeNode Right;
            public BinaryTreeNode Parent;
            public T Data;

            public BinaryTreeNode()
            {
                Left = null;
                Right = null;
                Parent = null;
            }
        }

        private BinaryTreeNode _root;
        private readonly Comparison<T> _compareFunction;

        public bool IsEmpty { get { return _root == null; } }

        public BinarySearchTree(Comparison<T> compareFunction)
        {
            _root = null;
            if (compareFunction != null)
                _compareFunction = compareFunction;
            else
                _compareFunction = Comparer<T>.Default.Compare;
        }

        public BinarySearchTree() : this((Comparison<T>)null)
        {
        }

        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            BinaryTreeNode child = new BinaryTreeNode
            {
                Data = value
            };

            if (IsEmpty)
            {
                _root = child;
            }
            else
            {
                BinaryTreeNode iterator = _root;
                while (true)
                {
                    int compareResult = _compareFunction(value, iterator.Data);

                    if (compareResult <= 0)
                        if (iterator.Left != null)
                        {
                            iterator = iterator.Left;
                            continue;
                        }
                        else
                        {
                            iterator.Left = child;
                            child.Parent = iterator;
                            break;
                        }

                    if (compareResult > 0)
                        if (iterator.Right != null)
                        {
                            iterator = iterator.Right;
                            continue;
                        }
                        else
                        {
                            iterator.Right = child;
                            child.Parent = iterator;
                            break;
                        }
                }
            }
        }

        public void Add(IEnumerable<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException();

            foreach (T value in elements)
            {
                if (value == null)
                    throw new ArgumentNullException();

                Add(value);
            }
        }

        public bool IsContain(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            if (!IsEmpty)
            {
                BinaryTreeNode iterator = _root;
                while (iterator != null)
                {
                    int compareResult = _compareFunction(value, iterator.Data);

                    if (compareResult == 0)
                        return true;
                    else if (compareResult < 0)
                        iterator = iterator.Left;
                    else
                        iterator = iterator.Right;
                }
            }
           
            return false;
        }        

        public void Clear()
        {
            _root = null;
        }

        private IEnumerable<T> Inorder(BinaryTreeNode node)
        {
            if (node.Left != null)
                foreach (T currValue in Inorder(node.Left))
                    yield return currValue;

            yield return node.Data;
            if (node.Right != null)
                foreach (T currValue in Inorder(node.Right))
                    yield return currValue;
        }

        private IEnumerable<T> Preorder(BinaryTreeNode node)
        {
            yield return node.Data;
            if (node.Left != null)
                foreach (T currValue in Preorder(node.Left))
                    yield return currValue;

            if (node.Right != null)
                foreach (T currValue in Preorder(node.Right))
                    yield return currValue;
        }

        private IEnumerable<T> Postorder(BinaryTreeNode node)
        {
            if (node.Left != null)
                foreach (T currValue in Postorder(node.Left))
                    yield return currValue;

            if (node.Right != null)
                foreach (T currValue in Postorder(node.Right))
                    yield return currValue;

            yield return node.Data;
        }

        public IEnumerable<T> InorderTraversal()
        {
            if (_root == null)
                throw new NullReferenceException();

            return Inorder(_root);
        }

        public IEnumerable<T> PreorderTraversal()
        {
            if (_root == null)
                throw new NullReferenceException();

            return Preorder(_root);
        }

        public IEnumerable<T> PostorderTraversal()
        {
            if (_root == null)
                throw new NullReferenceException();

            return Postorder(_root);
        }
    }
}
