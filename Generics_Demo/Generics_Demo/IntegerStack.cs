using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class IntegerStack
    {
        public IntegerStack() : this(4) { }
        public IntegerStack(int capacity)
        {
            pointer = 0;
            data = new int[capacity]; // Standardgröße im .NET Framework
        }

        private int[] data;
        private int pointer;

        public void Push(int item)
        {
            if (pointer == data.Length)
            {
                var newData = new int[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            data[pointer] = item;
            pointer++;
        }
        public int Pop()
        {
            if (pointer > 0)
            {
                pointer--;
                var result = data[pointer];
                data[pointer] = 0;
                return result;
            }
            else
                throw new InvalidOperationException("Stack ist leer");
        }

    }
}
