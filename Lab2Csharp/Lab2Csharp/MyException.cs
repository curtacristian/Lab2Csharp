﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Csharp
{
    class MyException :Exception
    {
        
        public MyException(string msg) : base(msg){}
    }
}
