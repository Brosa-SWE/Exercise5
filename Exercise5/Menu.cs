using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class Menu
    {
        private UI UI;
        private string MenuHeadline;

        private List<string> ValidOptions = new List<string>();
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public Menu(UI ui, string menuHeadline)
        {
            UI = ui;
            MenuHeadline = menuHeadline;
        }

        public string DisplayAndGetUserInput()
        {
            Display();
            return GetUserInput();
        }

        public void Display()
        {
          // List<string> ValidOptions = new List<string> { "1", "2", "3", "0" };

            UI.ClearScreen();

            UI.Write(MenuHeadline);
            UI.Write(new String('=', MenuHeadline.Length));

            foreach (MenuItem menuItem in MenuItems)
            {
                UI.Write($"{menuItem.OptionKey}\t{menuItem.OptionLabel}");
            }
        }

        public string GetUserInput()
        {
            string input = "";

            while (true)
            {
                try
                {
                    char v = Console.ReadLine()[0];
                    input = v.ToString(); //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    input = "9999"; // Value to provoke invalid option below
                }

                if (ValidOptions.Contains(input))
                {
                    return input;
                }
                else
                {
                    UI.ClearScreen();
                    UI.WaitForKey($"Please enter a valid input ({String.Join(", ", ValidOptions)})");
                }

            }
        }

        public void AddItem(string optionKey, string optionLabel)
        {
            if (optionKey == "" || optionLabel == "")
            {
                throw new ApplicationException("OptionKey and OptionLabel cannot be empty. To insert empty line in Menu, use AddEmptyLine()");
            }

            MenuItem MenuItem = new MenuItem(optionKey, optionLabel);
            MenuItems.Add(MenuItem);

            ValidOptions.Add(optionKey);
        }

        public void AddEmptyLine()
        {
            MenuItem MenuItem = new MenuItem("", " ");
            MenuItems.Add(MenuItem);
        }
    }
}
