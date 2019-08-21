using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Button
    {
        // Variante "Lang"
        //private Action ClickAction;
        //public event Action ClickEvent
        //{
        //    add
        //    {
        //        ClickAction += value;
        //    }
        //    remove
        //    {
        //        ClickAction -= value;
        //    }
        //}

        // "Autoproperty" für Events
        public event Action ClickEvent;

        public void Click()
        {
            // Logik

            // Null-Conditional Operator (C# 6)
            ClickEvent?.Invoke();

            // if(Person != null && Person.GanzerName != null && Person.GanzerName.Vorname != null)
            // if(Person?.GanzerName?.Vorname != null)
        }
    }
}
