using System;
using System.Collections.Generic;
using System.Text;

namespace RMU.DataStructures
{
    public class Stack<T>
    {
        private int _size = 0;
        private T[] _stack;

        public Stack(int maxCapacity)
        {
            _stack = new T[maxCapacity];
        }

        public bool IsEmpty()
        {
            return (_size == 0);
        }

        public void Push(T value)
        {
            _stack[_size++] = value;
        }

        public T Pop()
        {
            return _stack[--_size];
        }

        public int GetSize()
        {
            return _size;
        }

        public void Clear()
        {
            _size = 0;
        }
    }
}
