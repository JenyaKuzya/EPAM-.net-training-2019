using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Node<T> Next { get; set; }
    }

    public class Queue<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail; 

        public int Count { get; private set; }
        public bool IsEmpty { get { return Count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
       
        public void Enqueue(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (Count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            Count++;
        }
        
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            Count--;
            return output;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(head);
        }

        private IEnumerator GetEnumerator1()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator1();
        }

    }
}
