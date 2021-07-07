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
        internal void WriteWarning(string messageToWrite)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(messageToWrite);
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal void WriteError(string messageToWrite)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(messageToWrite);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
