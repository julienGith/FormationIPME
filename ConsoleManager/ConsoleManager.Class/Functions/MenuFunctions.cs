using ConsoleManager.Data.Interfaces;
using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleManager.Data.Functions
{
    public class MenuFunctions : IMenu
    {
        public Menu CreateMenu(string title, string greetingMessage, List<Question>? questions)
        {
            Menu menu = new Menu(title, greetingMessage, questions);
            List<Menu> menus = new List<Menu>();
            if (!File.Exists(@"menu.txt"))
            {
                using (FileStream fs = File.Create(@"menu.txt"))
                {
                    menus.Add(menu);

                    var jsonString = JsonConvert.SerializeObject(menus);
                    File.WriteAllText(@"menu.txt", jsonString);
                    fs.Close();
                }
                menus = GetAllMenus();
                return menu;
            }
            
            return menu;
        }

        public bool DeleteMenuById(int id)
        {
            List<Menu> menus = new List<Menu>();
            menus = GetAllMenus();
            var menu = menus.FirstOrDefault(m=>m.Id==id);
            if (menu != null)
            {
                menus.Remove(menu);
            }
            using (FileStream fs = File.OpenRead(@"menu.txt"))
            {
                var jsonString = JsonConvert.SerializeObject(menus);
                File.WriteAllText(@"menu.txt", jsonString);
                fs.Close();
            }
            return false;
        }

        public List<Menu> GetAllMenus()
        {
            List<Menu> menus = new List<Menu>();
            using (FileStream fs = File.OpenRead(@"menu.txt"))
            {
                menus = JsonConvert.DeserializeObject<List<Menu>>(@"menu.txt");
                fs.Close();
            }
            return menus;
        }

        public Menu GetMenuById(uint id)
        {
            var menus = GetAllMenus();
            var menu = menus.FirstOrDefault(m=>m.Id==id);
            return menu;
        }

        public Menu GetMenuByName(string title)
        {
            var menus = GetAllMenus();
            var menu = menus.FirstOrDefault(m => m.Title.Contains(title));
            return menu;
        }

        public Menu UpdateMenu(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
