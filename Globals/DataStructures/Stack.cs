using System.Collections.Generic;

namespace RMU.Globals.DataStructures
{
    public class Stack<T>
    {
        private readonly List<T> _stack;

        public Stack()
        {
            _stack = new List<T>();
        }

        public bool IsEmpty()
        {
            return (_stack.Count == 0);
        }

        public void Push(T value)
        {
            _stack.Add(value);
        }

        public T Pop()
        {
            T t = _stack[^1];
            _stack.RemoveAt(_stack.Count - 1);
            return t;
        }

        public int GetSize()
        {
            return _stack.Count;
        }

        public void Clear()
        {
            _stack.Clear();
        }
    }
}
