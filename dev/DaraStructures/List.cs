using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourseControlTest
{
    class DynamicArr
    {
        private object[] inner;

        public DynamicArr()
        { }

        public DynamicArr(int size)
        {
            inner = new object[size];
        }

        public int Length()
        {
            return inner.Length;
        }

        public void Add(object item)
        {
            if(inner == null)
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

        public void Insert(int index, object item)
        {
            if(inner == null || inner.Length < index || index < 0)
            {
                Console.WriteLine("Ошибка");
            }
            else
            {
                object[] newinner = new object[inner.Length + 1];

                int i = 0;
                while (i != index - 1)
                {
                    newinner[i] = inner[i];
                    i++;
                }

                newinner[index - 1] = item;

                i = index - 1;
                while (i < newinner.Length - 1)
                {
                    newinner[i + 1] = inner[i];
                    i++;
                }

                inner = newinner;
            }
        }

        public void Remove(object item)
        {
            if (IndexOf(item) != -1)
            {
                RemoveAt(IndexOf(item));
            }
        }

        public void RemoveAt(int index)
        {
            object[] newinner = new object[inner.Length - 1];

            int i = 0;
            while (i != index)
            {
                newinner[i] = inner[i];
                i++;
            }

            i = index;
            while (i < newinner.Length)
            {
                newinner[i] = inner[i + 1];
                i++;
            }

            inner = newinner;
        }

        public int IndexOf(object item)
        {
            int index = -1;

            for (int j = 0; j < inner.Length; j++)
            {
                if (inner[j].Equals(item))
                {
                    index = j;
                    j = inner.Length;
                }
            }

            return index;
        }

        public void Clear()
        {
            object[] newinner = new object[0];

            inner = newinner;
        }

        public bool Contains(object item)
        {
            bool result = false;

            for (int i = 0; i < inner.Length; i++)
            {
                if(inner[i].Equals(item))
                {
                    result = true;
                }
            }

            return result;
        }
   
    }

    class Program
    {
        static void Main(string[] args)
        {
            DynamicArr dynamicArr = new DynamicArr();
            dynamicArr.Add(1);
            dynamicArr.Insert(1, 5);
            dynamicArr.Insert(2, 10);

            dynamicArr.Clear();

            Console.WriteLine(dynamicArr.Length());
        }
    }
}
