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
            ConsoleColor consoleColor = ConsoleColor.Green;

            ShowAlert(customPrompt, consoleColor);

        }

        internal void DisplayWarning(string customPrompt)
        {
            ConsoleColor consoleColor = ConsoleColor.DarkYellow;

            ShowAlert(customPrompt, consoleColor);

        }

        internal void DisplayFailure(string customPrompt)
        {
            ConsoleColor consoleColor = ConsoleColor.Red;

            ShowAlert(customPrompt, consoleColor);

        }

        internal void ShowAlert(string customPrompt, ConsoleColor consoleColor)
        {

            Console.ForegroundColor = consoleColor;

            Console.Write("┌");
            for (int i = 0; i < customPrompt.Length + 2; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┐");

            Console.Write("│ ");
            Console.Write(customPrompt);
            Console.WriteLine(" │");

            Console.Write("└");
            for (int i = 0; i < customPrompt.Length + 2; i++)
            {
                Console.Write("─");
            }
            Console.WriteLine("┘");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" ");

            WaitForKey("Press any key to continue...");
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
