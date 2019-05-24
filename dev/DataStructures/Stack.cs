using System;

namespace SourseControlTest
{
    interface IStack
    {
        void Clear();
        bool Contains(object item);
        object Peek(); // просто возвращает первый элемент из стека без его удаления
        object[] ToArray();
        void Push(object item); // добавляет элемент в стек на первое место
        object Pop(); // извлекает и возвращает первый элемент из стека
    }

    class Stack : IStack
    {
        private object[] inner = new object[0];

        public void Clear()
        {
            inner = new object[0];
        }

        public bool Contains(object item)
        {
            bool result = false;

            for (int i = 0; i < inner.Length; i++)
            {
                if (inner[i].Equals(item))
                {
                    result = true;
                }
            }

            return result;
        }

        public object Peek() // просто возвращает первый элемент из стека без его удаления
        {
            if (inner.Length > 0)
            {
                return inner[inner.Length - 1];
            }
            else
            {
                return -1;
            }
        }

        public object Pop() // извлекает и возвращает первый элемент из стека
        {
            object result = Peek();

            object[] newinner = new object[inner.Length - 1];

            int i = 0;
            while (i < newinner.Length)
            {
                newinner[i] = inner[i];
                i++;
            }

            inner = newinner;

            return result;
        }

        public void Push(object item) // добавляет элемент в стек на первое место
        {
            if (inner == null)
            {
                inner = new object[] { item };
            }
            else
            {
                object[] newinner = new object[inner.Length + 1];

                int i = 0;
                while (i != (newinner.Length - 1))
                {
                    newinner[i] = inner[i];
                    i++;
                }

                newinner[newinner.Length - 1] = item;

                inner = newinner;
            }
        }

        public object[] ToArray()
        {
            object[] result = new object[inner.Length];

            for (int i = 0; i < inner.Length; i++)
            {
                result[i] = inner[i];
            }

            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            object o = stack.Peek();
            stack.Pop();
        }
    }
}
