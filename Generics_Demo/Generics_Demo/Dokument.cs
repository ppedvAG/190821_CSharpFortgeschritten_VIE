using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Dokument
    {
        public string Text { get; set; }

        // indexer + TAB + TAB
        public string this[int index]
        {
            get
            {
                var words = Text.Split(); // Standardfall: leerzeichen
                return words[index];
            }
            set
            {
                var words = Text.Split(); // Standardfall: leerzeichen
                words[index] = value;
                Text = string.Join(" ", words);
            }
        }

    }
}
