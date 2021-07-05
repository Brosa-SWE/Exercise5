using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class UI : IUI
    {
        public void Write(string messageToWrite)
        {
            Console.WriteLine(messageToWrite);
        }
    }
}
