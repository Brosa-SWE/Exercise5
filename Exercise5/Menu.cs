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

        private Dictionary<string, string> Dictionary = new Dictionary<string, string>();
        private bool UseDictionary;

        public Menu(UI ui, string menuHeadline)
        {
            UI = ui;
            MenuHeadline = menuHeadline;
        }

        public bool UseCurrentMenuAsDictionaryForInput
        {
            get => UseDictionary;
 
            set => UseDictionary = value;
            
        }

        // Translates user selected Menu Option to a custom return value
        public void UseCustomDictionaryForUserInput(Dictionary<string, string> dictionary)
        {
            Dictionary = dictionary;
            UseDictionary = true;
        }

        // Translates user selected Menu Option to menu label value
        public string DisplayAndGetUserInput()
        {
            DisplayMenu();

            string userSelection = GetUserMenuSelection();

            if (UseDictionary)
            {
                if (userSelection == "")
                {
                    return "";
                }

                return (Dictionary[userSelection]);
            }

            return userSelection;
        }

        public void DisplayMenu()
        {
          // List<string> ValidOptions = new List<string> { "1", "2", "3", "0" };

            UI.ClearScreen();

            UI.Write(MenuHeadline);
            UI.Write(new String('=', MenuHeadline.Length));

            foreach (MenuItem menuItem in MenuItems)
            {
                UI.Write($"{menuItem.OptionKey}\t{menuItem.OptionLabel}");
            }

            UI.Write(" ");
        }

        public string GetUserMenuSelection()
        {
            string input = "";

            while (true)
            {
                try
                {
                    input = UI.GetUserInputString();
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    input = "<INVALID>"; // Value to provoke invalid option below
                }

                if (ValidOptions.Contains(input))
                {
                    return input;
                }
                else
                {
                    UI.DisplayWarning($"Please enter a valid input ({String.Join(", ", ValidOptions)})");
                    return "";
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

            Dictionary.Add(optionKey, optionLabel);
        }

        public void AddEmptyLine()
        {
            MenuItem MenuItem = new MenuItem("", " ");
            MenuItems.Add(MenuItem);
        }
    }
}
