using ConsoleManager.Data.Functions;
using ConsoleManager.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Logic
{
    public class MenuLogic
    {
        private IMenu _menu;
        public MenuLogic()
        {
            _menu = new MenuFunctions();
        }
    }
}
