using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Csharp
{
    class StackException:Exception
    {
        public StackException(string msg) : base(msg){}
    }
}
