using System;

namespace SourseControlTest
{
    sealed class Node
    {
        public object Item { get; set; }
        public Node Next { get; set; }

        public Node(object item)
        {
            if (item != null)
            {
                Item = item;
            }
        }
    }

    interface ILinkedList
    { 
        void Add(object item);
        void AddFirst(object item);
        void Insert(Node node, object item);
        void Clear();
        bool Contains(object item);
        object[] ToArray();
    }



    class LinkedList : ILinkedList
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


        public Node First { get; private set; }

        public Node Last { get; private set; }

        public void Add(object item)
        {
            Node node = new Node(item);

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

        public void AddFirst(object item)
        {
            Node node = new Node(item);

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

        public void Insert(Node node, object item)
        {
            Node newnode = new Node(item);

            if(Contains(node.Item))
            {
                Node previous = PreviousNode(node);

                previous.Next = newnode;
                newnode.Next = node;
            }

            Count++;
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

        private Node PreviousNode(Node node)
        {
            if(First.Equals(node))
            {
                return node;
            }
            else
            {
                Node result = First;

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

        //public object[] ToArray() // возвращает массив объектов классов
        //{
        //    object[] result = new object[Count];

        //    Node node = First;

        //    for (int i = 0; i < Count; i++)
        //    {
        //        result[i] = node;
        //        node = node.Next;
        //    }

        //    return result;
        //}

    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.Add(1);
            list.Add(2);
            list.AddFirst(3);

            if (list.Contains(2))
            {
                Console.WriteLine("Содержит");
            }

            if (!list.Contains(4))
            {
                Console.WriteLine("Не содержит");
            }

            list.Insert(list.First.Next, 5);

            object[] vs = list.ToArray();

        }
    }
}
