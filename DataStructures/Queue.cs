using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.DataStructures
{
    public class Queue<T>
    {
        private DoublyLinkedList<T> _queue;

        public Queue()
        {
            _queue = new DoublyLinkedList<T>();
        }

        public void Enqueue(T value)
        {
            _queue.AddTail(value);
        }

        public T Dequeue()
        {
            return _queue.RemoveHead();
        }

        public T Peek()
        {
            return _queue.GetHead().GetValue();
        }

        public int GetSize()
        {
            return _queue.GetSize();
        }

        public bool IsEmpty()
        {
            return GetSize() == 0;
        }

        public void Clear()
        {
            _queue.Clear();
        }
    }
}
