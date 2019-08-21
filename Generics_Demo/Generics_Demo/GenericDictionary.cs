using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class GenericDictionary<TKey, TValue>
        where TKey : class
        where TValue : struct
    {
        public GenericDictionary() : this(4) { }
        public GenericDictionary(int capacity)
        {
            pointer = 0;
            keys = new TKey[capacity];
            values = new TValue[capacity];
        }

        private TKey[] keys;
        private TValue[] values;
        private int pointer;


        public void Add(TKey key, TValue value)
        {
            if (pointer == keys.Length)
            {
                var newKeys = new TKey[keys.Length * 2];
                var newValues = new TValue[values.Length * 2];
                Array.Copy(keys, newKeys, keys.Length);
                Array.Copy(values, newValues, values.Length);
                keys = newKeys;
                values = newValues;
            }

            if (keys.Contains(key))
                throw new InvalidOperationException($"Objekt mit Key '{key}' existiert bereits.");

            keys[pointer] = key;
            values[pointer] = value;
            pointer++;
        }


        public TValue this[TKey key]
        {
            get
            {
                int index = Array.IndexOf(keys, key);
                if (index >= 0)
                {
                    return values[index];
                }
                else
                    throw new InvalidOperationException("Objekt nicht gefunden.");
            }
            set
            {
                if (keys.Contains(key))
                    values[Array.IndexOf(keys, key)] = value;
                else
                    Add(key, value);
            }
        }

    }
}