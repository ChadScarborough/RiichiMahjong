using System;

namespace RMU.Globals.DataStructures
{
    public class DoublyLinkedList<T>
    {
        public class Node
        {
            private readonly T _value;
            private Node _nextNode;
            private Node _prevNode;

            public Node(T value)
            {
                this._value = value;
            }

            public Node GetNext()
            {
                return this._nextNode;
            }

            public Node GetPrev()
            {
                return this._prevNode;
            }

            public void SetNext(Node nextNode)
            {
                this._nextNode = nextNode;
            }

            public void SetPrev(Node prevNode)
            {
                this._prevNode = prevNode;
            }

            public T GetValue()
            {
                return this._value;
            }
        }

        private Node _head;
        private Node _tail;
        private int _size;

        public DoublyLinkedList()
        {
            this._head = null;
            this._tail = null;
        }

        public bool IsEmpty()
        {
            return _size == 0;
        }

        private void AddFirstElement(T value)
        {
            _head = new Node(value);
            _tail = _head;
            _size++;
        }

        public void AddHead(T value)
        {
            if(IsEmpty())
            {
                AddFirstElement(value);
                return;
            }
            Node node = new Node(value);
            node.SetNext(_head);
            node.SetPrev(null);
            _head.SetPrev(node);
            _head = node;
            _size++;
        }

        public void AddTail(T value)
        {
            if(IsEmpty())
            {
                AddFirstElement(value);
                return;
            }
            Node node = new Node(value);
            node.SetPrev(_tail);
            node.SetNext(null);
            _tail.SetNext(node);
            _tail = node;
            _size++;
        }

        public T RemoveHead()
        {
            if (!IsEmpty())
            {
                if (GetSize() == 1)
                {
                    Node temp = GetHead();
                    _head = null;
                    _tail = null;
                    _size--;
                    return temp.GetValue();
                }
                Node tempNode = _head;
                _head = tempNode.GetNext();
                tempNode.SetNext(null);
                _size--;
                return tempNode.GetValue();
            }
            throw new IndexOutOfRangeException("Tried to remove an element from an empty list");
        }

        public T RemoveTail()
        {
            if (!IsEmpty())
            {
                if(GetSize() > 1)
                {
                    Node temp = _tail;
                    _tail = temp.GetPrev();
                    temp.SetPrev(null);
                    _size--;
                    return temp.GetValue();
                }
                Node tempNode = _tail;
                _tail = null;
                _head = null;
                _size--;
                return tempNode.GetValue();
            }
            throw new IndexOutOfRangeException("Tried to remove an element from an empty list");
        }

        public Node GetHead()
        {
            return _head;
        }

        public Node GetTail()
        {
            return _tail;
        }

        public int GetSize()
        {
            return _size;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            _size = 0;
        }
    }
}
