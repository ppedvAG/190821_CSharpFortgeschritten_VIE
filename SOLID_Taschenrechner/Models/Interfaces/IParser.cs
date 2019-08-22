using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IParser
    {
        Formula Parse(string input);
    }
}
