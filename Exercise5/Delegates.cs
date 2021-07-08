using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Delegates
    {
        public delegate void UIwriteDelegate(string message);

        public delegate void UIwriteErrorDelegate(string message);

        public delegate void UIwriteWarningDelegate(string message);

    }
}
