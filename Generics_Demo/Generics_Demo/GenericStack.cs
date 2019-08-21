using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class GenericStack<T>
    {
        public GenericStack() : this(4) { }
        public GenericStack(int capacity)
        {
            pointer = 0;
            data = new T[capacity]; // Standardgröße im .NET Framework
        }

        private T[] data;
        private int pointer;

        public void Push(T item)
        {
            if (pointer == data.Length)
            {
                var newData = new T[data.Length * 2];
                Array.Copy(data, newData, data.Length);
                data = newData;
            }

            data[pointer] = item;
            pointer++;
        }
        public T Pop()
        {
            if (pointer > 0)
            {
                pointer--;
                var result = data[pointer];
                data[pointer] = default; // Standardwert für diesen Datentypen
                return result;
            }
            else
                throw new InvalidOperationException("Stack ist leer");
        }

        public override string ToString()
        {
            return $"Generischer Stack für den Datentyp '{typeof(T).ToString()}'";
        }
    }
}
