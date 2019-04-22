using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class QueueEnumerator<T> : IEnumerator<T>
    {
        private readonly Node<T> _headNode;
        private Node<T> _currentNode;

        public QueueEnumerator(Node<T> headNode)
        {
            _headNode = headNode;
            _currentNode = headNode;
        }

        public T Current
        {
            get
            {
                return _currentNode.Data;
            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public bool MoveNext()
        {
            if (_currentNode.Next != null)
            {
                _currentNode = _currentNode.Next;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _currentNode = _headNode;
        }

        public void Dispose() { }
    }
}
