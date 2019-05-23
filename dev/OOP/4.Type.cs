using System;

namespace Millionaire
{
    // 4. decimal, Type, Class, Struct, Enum, Variable, Method, int
    // 4. decimal, Class, Struct, Enum, Variable, Method


    class Type
    {
        // типы могут быть значимыми и ссылочными, пользовательскими и встроеными

        public int Size { get; set; }

        public bool IsValue { get; set; }

        public bool IsCustom { get; set; }

        public Type()
        {
        }
    }

    class Int : Type
    {
        public int Value
        {
            get
            {
                return Value;
            }
            set
            {
                if(!(Int32.TryParse(value.ToString(), out value)))
                {
                    Value = value;
                }
            }
        }

        public Int(int Value) : base()
        {
            this.Value = Value;
            this.Size = 32; // Signed 32-bit integer
            this.IsValue = true;
            this.IsCustom = false;
        }

        public void Display()
        {
            Console.WriteLine(Value);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
