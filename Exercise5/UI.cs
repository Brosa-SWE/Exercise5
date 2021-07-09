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

        public int GetUserInputInt(string customPrompt, bool clearScreenBetweenTries, int minimumValue, int maximumValue)
        {
            if (clearScreenBetweenTries)
            {
                ClearScreen();
            }

            Write(customPrompt);

            return GetUserInputInt(minimumValue, maximumValue);
        }

        public int GetUserInputInt(int minimumValue, int maximumValue)
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

        internal void DisplaySuccess(string customPrompt)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);

            List<string> outputFrame = GetFrame(customPrompt);

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (string lineToWrite in outputFrame)
            {
                Write(lineToWrite);
            }
            Console.ForegroundColor = ConsoleColor.White;

            WaitForKey("Press any key to continue...");
        }
        internal void ShowResult(string customPrompt)
        {
            string frame = new String('=', customPrompt.Length + 4);

            Console.ForegroundColor = ConsoleColor.Green;
            Write(" ");
            Write(frame);
            Write($"= { customPrompt} =");
            Write(frame);
            Console.ForegroundColor = ConsoleColor.White;

            WaitForKey("Press any key to continue...");
        }

        internal List<string> GetFrame(string customPrompt)
        {
            List<string> result = new List<string>();

            int topleft = 218;
            int hline = 196;
            int topright = 191;
            int vline = 179;
            int bottomleft = 192;
            int bottomright = 217;

            result.Add(topleft + new String((char)hline, customPrompt.Length + 4) + topright);
            result.Add((char)vline + " " + customPrompt + " " + (char)vline);
            result.Add(bottomleft + new String((char)hline, customPrompt.Length + 4) + bottomright);

            return result;
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

        internal void ExitApplication()
        {
            Environment.Exit(0);
        }
    }
}
