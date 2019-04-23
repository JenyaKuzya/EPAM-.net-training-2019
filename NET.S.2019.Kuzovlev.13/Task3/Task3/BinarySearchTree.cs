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

        public BinarySearchTree(Comparison<T> compareFunction)
        {
            _root = null;
            _compareFunction = compareFunction;
        }

        public void Add(T Value)
        {
            BinaryTreeNode child = new BinaryTreeNode
            {
                Data = Value
            };

            if (_root == null)
            {
                _root = child;
            }
            else
            {
                BinaryTreeNode iterator = _root;
                while (true)
                {
                    int compareResult = _compareFunction(Value, iterator.Data);

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

        public bool IsContain(T Value)
        {
            BinaryTreeNode iterator = _root;
            while (iterator != null)
            {
                int compareResult = _compareFunction(Value, iterator.Data);

                if (compareResult == 0)
                    return true;
                else if (compareResult < 0)
                    iterator = iterator.Left;
                else
                    iterator = iterator.Right;
            }
            return false;
        }        

        public IEnumerator<T> InOrderTraversal()
        {
            if (_root != null)
            {
                // Стек для сохранения пропущенных узлов.
                Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();

                BinaryTreeNode current = _root;

                // Когда мы избавляемся от рекурсии, нам необходимо
                // запоминать, в какую стороны мы должны двигаться.
                bool goLeftNext = true;

                // Кладем в стек корень.
                stack.Push(current);

                while (stack.Count > 0)
                {
                    // Если мы идем налево...
                    if (goLeftNext)
                    {
                        // Кладем все, кроме самого левого узла на стек.
                        // Крайний левый узел мы вернем с помощю yield.
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    // Префиксный порядок: left->yield->right.
                    yield return current.Data;

                    // Если мы можем пойти направо, идем.
                    if (current.Right != null)
                    {
                        current = current.Right;

                        // После того, как мы пошли направо один раз,
                        // мы должным снова пойти налево.
                        goLeftNext = true;
                    }
                    else
                    {
                        // Если мы не можем пойти направо, мы должны достать родительский узел
                        // со стека, обработать его и идти в его правого ребенка.
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> PreOrderTraversal()
        {
            if (_root != null)
            {
                Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();

                BinaryTreeNode current = _root;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            yield return current.Data;
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        yield return current.Data;
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public IEnumerator<T> PostOrderTraversal()
        {
            if (_root != null)
            {
                Stack<BinaryTreeNode> stack = new Stack<BinaryTreeNode>();

                BinaryTreeNode current = _root;

                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Data;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        yield return current.Data;
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        public void Clear()
        {
            _root = null;
        }
    }
}
