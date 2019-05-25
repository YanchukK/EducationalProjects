using System;

namespace SourseControlTest
{
    sealed class Node<T> : IComparable<T> where T : IComparable<T>
    {
        public T Item { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> ParentNode { get; set; }

        public Node(T item)
        {
            if (item != null)
            {
                Item = item;
            }
        }

        public int CompareTo(T other)
        {
            return Item.CompareTo(other);
        }
    }

    interface IBinaryTree<T>
    {
        void Add(T item);
        bool Contains(T item);
        void Clear();
        T[] ToArray();
    }

    class BinaryTree<T> : IBinaryTree<T> where T : IComparable<T>
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

        public Node<T> Root { get; private set; }

        public void Add(T item)
        {
            Node<T> currentNode = new Node<T>(item);

            if (Root == null)
            {
                Root = currentNode;
            }

            Node<T> node = Root;

            while(currentNode.ParentNode == null)
            {
                // Когда новый ключ меньше ключа в текущем узле, движемся в левую сторону
                if (currentNode.Item.CompareTo(node.Item) > 0)
                {
                    // Если левое поддерево уже есть, применяем алгоритм к его корню
                    if (node.Left != null)
                    {
                        node = node.Left;
                    }
                    // Левого поддерева нет, новый узел становится левым поддеревом
                    else
                    {
                        node.Left = currentNode;
                        currentNode.ParentNode = node.Left;
                        break;
                    }
                }
                // Когда новый ключ больше ключа в текущем узле, движемся в правую сторону
                else
                {
                    // Если правое поддерево уже есть, применяем алгоритм к его корню
                    if (pCurrent­ > m_pRight)
                        pCurrent = pCurrent­ > m_pRight;
else
{
                        // Правого поддерева нет, новый узел становится правым поддеревом
                        BSTree::Node* pNewNode = BSTreeCreateNode(_key);
pNewNode­ > m_pParent = pCurrent;
pCurrent­ > m_pRight = pNewNode;
return;
}
                    
                }

            }


            Count++;
        }






        public bool Contains(T item)
        {
            bool result = false;

            Node<T> node = Root;

            //for (int i = 0; i < Count; i++)
            //{
            //    if ((node.Item).Equals(item))
            //    {
            //        result = true;
            //        i = Count;
            //    }
            //    else
            //    {
            //        node = node.Next;
            //    }
            //}

            return result;
        }

        public void Clear()
        {
            //First = null;
            //Last = null;
        }

        public T[] ToArray() // возвращает массив объектов значений
        {
            T[] result = new T[Count];

            //Node node = First;

            //for (int i = 0; i < Count; i++)
            //{
            //    result[i] = node.Item;
            //    node = node.Next;
            //}

            return result;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(1);
            tree.Add(-1);
            tree.Add(2);
            tree.Add(-10);
            tree.Add(12);
            tree.Add(4);
        }
    }
}
