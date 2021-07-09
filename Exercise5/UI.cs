using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class UI : IUI
    {
        public string GetUserInputString(string customPrompt, bool clearScreenBetweenTries)
        {
            if (clearScreenBetweenTries)
            {
                ClearScreen();
            }

            Write(customPrompt);

            return GetUserInputString();
        }

        public string GetUserInputString()
        {
            string input = "";

            while (true)
            {
                try
                {
                    input = ReadLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    input = "<INVALID>"; // Value to provoke invalid option below
                }

                return input;

            }
        }

        public int GetUserInputInteger(string customPrompt, int minimumValue, int maximumValue)
        {
            string input = "";

            while (true)
            {
                try
                {
                    ClearScreen();
                    Write(customPrompt);
                    input = ReadLine();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    input = "<INVALID>"; // Value to provoke invalid option below
                }

                int inputInt;

                if (!int.TryParse(input, out inputInt))
                {
                    inputInt = minimumValue - 1;
                }

                if (inputInt < minimumValue || inputInt > maximumValue)
                {
                    ClearScreen();
                    WaitForKey($"Valid input is {minimumValue} - {maximumValue}, press any key to try again.");
                }
                else
                {
                    return inputInt;
                }
            }
        }

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

        internal string ReadLine()
        {
            return Console.ReadLine();
        }

        internal void ClearScreen()
        {
            Console.Clear();
        }

        internal void WaitForKey()
        {
            Console.ReadKey();
        }

        internal void WaitForKey(string customPrompt)
        {
            Write(" ");
            Write(customPrompt);
            WaitForKey();
        }
    }
}
