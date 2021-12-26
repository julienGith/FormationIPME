using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Interfaces
{
    internal interface IMenu
    {
        Menu CreateMenu(string title, string greetingMessage, List<Question>? questions);
        Menu UpdateMenu(Menu menu);
        Menu DeleteMenuById(int id);
        List<Menu> GetAllMenus();
        Menu GetMenuById(uint id);
        Menu GetMenuByName(string title);
    }
}
