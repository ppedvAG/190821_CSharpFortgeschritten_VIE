using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class ObjectStack
    {
        public ObjectStack() : this(4) { }
        public ObjectStack(int capacity)
        {
            pointer = 0;
            data = new object[capacity]; // Standardgröße im .NET Framework
        }

        private object[] data;
        private int pointer;

        public void Push(object item)
        {
            if (pointer == data.Length)
            {
                var newData = new object[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            data[pointer] = item;
            pointer++;
        }
        public object Pop()
        {
            if (pointer > 0)
            {
                pointer--;
                var result = data[pointer];
                data[pointer] = null;
                return result;
            }
            else
                throw new InvalidOperationException("Stack ist leer");
        }

    }
}
