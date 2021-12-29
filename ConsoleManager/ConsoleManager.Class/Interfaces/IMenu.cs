using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Interfaces
{
    public interface IMenu
    {
        Menu CreateMenu(Menu menu);
        Menu UpdateMenu(Menu menu);
        bool DeleteMenuById(int id);
        List<Menu> GetAllMenus();
        Menu GetMenuById(uint id);
        Menu GetMenuByName(string title);
    }
}
