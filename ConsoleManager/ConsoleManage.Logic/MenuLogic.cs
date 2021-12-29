using ConsoleManager.Data.Functions;
using ConsoleManager.Data.Interfaces;
using ConsoleManager.Data.Models;
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

        public Menu CreateMenu(Menu menu)
        {
            return _menu.CreateMenu(menu);
        }
        public Menu UpdateMenu(Menu menu)
        {
            return _menu.UpdateMenu(menu);
        }
        public bool DeleteMenuById(int id)
        {
            return _menu.DeleteMenuById(id);
        }
        public List<Menu> GetAllMenus()
        {
            return _menu.GetAllMenus();
        }
        public Menu GetMenuById(uint id)
        {
            return GetMenuById(id);
        }
        Menu GetMenuByName(string title)
        {
            return _menu.GetMenuByName(title);
        }
    }
}
