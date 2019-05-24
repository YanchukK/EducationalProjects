using System;

namespace SourseControlTest
{
    interface IQueue
    {
        void Enqueue(object item); // добавляет элемент в конец очереди
        object Dequeue(); // извлекает и возвращает первый элемент очереди
        object Peek(); // просто возвращает первый элемент из начала очереди без его удаления
        void Clear();
        bool Contains(object item);
        object[] ToArray();
    }

    class Queue : IQueue
    {
        private object[] inner = new object[0];
        public int Count
        {
            get
            {
                return inner.Length;
            }
            private set
            {
                Count = inner.Length;
            }
        }

        public void Enqueue(object item) // добавляет элемент в конец очереди
        {
            if(Count == 0)
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

        public object Dequeue() // извлекает и возвращает первый элемент очереди
        {
            object result = inner[0];

            if (Count != 0)
            {
                object[] newinner = new object[inner.Length - 1];

                int i = 0;
                while (i < newinner.Length)
                {
                    newinner[i] = inner[i + 1];
                    i++;
                }

                inner = newinner;
            }

            return result;
        }
               
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
               
        public object Peek() // просто возвращает первый элемент из начала очереди без его удаления
        {
            return inner[0];
        }

        public object[] ToArray()
        {
            object[] result = new object[this.Count];

            for (int i = 0; i < this.Count; i++)
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
            Queue queue = new Queue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            object i = queue.Dequeue();
        }
    }
}
