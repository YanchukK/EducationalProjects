using System;

namespace SourseControlTest
{
    sealed class Node
    {
        public object Item { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(object item)
        {
            if (item != null)
            {
                Item = item;
            }
        }
    }

    interface IDoublyLinkedList
    {
        void Add(object item);
        void AddFirst(object item);
        void Remove(object item);
        void RemoveLast();
        void Clear();
        bool Contains(object item);
        object[] ToArray();
    }
    class LinkedList : IDoublyLinkedList
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
                if (value >= 0)
                {
                    сount = value;
                }
            }
        }

        public Node First { get; private set; }

        public Node Last { get; private set; }

        public void Add(object item)
        {
            Node node = new Node(item);

            if (First == null)
            {
                First = node;
                Last = First;
            }
            else if(Count == 1)
            {
                First.Next = node;
                node.Previous = First;
                Last = node;
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
                Last = node;
            }

            Count++;
        }

        public void AddFirst(object item)
        {
            Node node = new Node(item);

            if (First == null)
            {
                First = node;
                Last = First;
            }
            else
            {
                node.Next = First;
                First.Previous = node;
                First = node;
            }

            Count++;
        }

        public void RemoveLast()
        {
            Last = Last.Previous;
            Last.Next = null;
            Count--;
        }

        public bool Contains(object item)
        {
            bool result = false;

            Node node = First;

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

        public void Remove(object item)
        {
            if(Contains(item))
            {
                if(First.Item.Equals(item))
                {
                    First = First.Next;
                    First.Previous = null;
                }
                else
                {
                    Node node = GetNode(item);

                    node.Previous.Next = node.Next;
                    node.Next.Previous = node.Previous;
                }
            }

            Count--;
        }

        private Node GetNode(object item)
        {
            Node node = First.Next;

            for (int i = 0; i < Count; i++)
            {
                if (node.Item.Equals(item))
                {
                    return node;
                }
                else
                {
                    node = node.Next;
                }
            }

            return node;
        }

        public void Clear()
        {
            First = null;
            Last = null;

            Count = 0;
        }

        public object[] ToArray() // возвращает массив объектов значений
        {
            object[] result = new object[Count];

            Node node = First;

            for (int i = 0; i < Count; i++)
            {
                result[i] = node.Item;
                node = node.Next;
            }

            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.AddFirst(4);

            list.Remove(2);      

            object[] vs = list.ToArray();

            list.Clear();
        }
    }
}
