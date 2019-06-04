using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painting
{
    class ListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> currentNode;
        private Node<T> first;

        public ListEnumerator(Node<T> first)
        {
            this.first = first;
        }

        public object Current => currentNode.Item;

        object IEnumerator.Current => Current;

        T IEnumerator<T>.Current => currentNode.Item;

        public bool MoveNext()
        {
            if(currentNode == null)
            {
                currentNode = first;
            }
            else
            {
                currentNode = currentNode.Next;
            }
            return currentNode.Next != null;
        }

        public void Reset()
        {
            currentNode = null;
        }

        public void Dispose()
        { }
    }


    sealed class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T item)
        {
            if (item != null)
            {
                Item = item;
            }
        }
    }

    interface ILinkedList<T>
    {
        void Add(T item);
        void AddFirst(T item);
        void Insert(Node<T> node, T item);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }



    class LinkedList<T> : ILinkedList<T>, IEnumerable<T>
    {
        private int сount;
        public int Count
        {
            get
            {
                return сount;
            }
            private set
            {
                if (value > 0)
                {
                    сount = value;
                }
            }
        }


        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }

            Count++;
        }

        public void AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);

            if (First == null)
            {
                First = node;
                Last = node;
            }
            else
            {
                node.Next = First;
                First = node;
            }

            Count++;
        }

        public void Insert(Node<T> node, T item)
        {
            Node<T> newnode = new Node<T>(item);

            if (Contains(node.Item))
            {
                Node<T> previous = PreviousNode(node);

                previous.Next = newnode;
                newnode.Next = node;
            }

            Count++;
        }

        public bool Contains(T item)
        {
            bool result = false;

            Node<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                if ((node.Item).Equals(item))
                {
                    result = true;
                    i = Count;
                }
                else
                {
                    node = node.Next;
                }
            }

            return result;
        }

        private Node<T> PreviousNode(Node<T> node)
        {
            if (First.Equals(node))
            {
                return node;
            }
            else
            {
                Node<T> result = First;

                for (int i = 0; i < Count; i++)
                {
                    if ((result.Next).Equals(node))
                    {
                        return result;
                    }
                    else
                    {
                        result = result.Next;
                    }
                }

                return result;
            }
        }

        public void Clear()
        {
            First = null;
            Last = null;
        }

        public T[] ToArray() // возвращает массив объектов значений
        {
            T[] result = new T[Count];

            Node<T> node = First;

            for (int i = 0; i < Count; i++)
            {
                result[i] = node.Item;
                node = node.Next;
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(First);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
