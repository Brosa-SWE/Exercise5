using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class MenuItem
    {
        public string OptionKey { get; set; }
        public string OptionLabel { get; set; }

        public MenuItem(string optionKey, string optionLabel)
        {
            OptionKey = optionKey;
            OptionLabel = optionLabel;
        }
    }
}
