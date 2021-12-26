using ConsoleManager.Data.Interfaces;
using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Functions
{
    public class MenuFunctions : IMenu
    {
        public Menu CreateMenu(string title, string greetingMessage, List<Question>? questions)
        {
            throw new NotImplementedException();
        }

        public Menu DeleteMenuById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Menu> GetAllMenus()
        {
            throw new NotImplementedException();
        }

        public Menu GetMenuById(uint id)
        {
            throw new NotImplementedException();
        }

        public Menu GetMenuByName(string title)
        {
            throw new NotImplementedException();
        }

        public Menu UpdateMenu(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
