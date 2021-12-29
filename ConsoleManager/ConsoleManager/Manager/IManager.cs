using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    public interface IManager
    {
        //Reader
        Answer ReadUserEntry(Question question);
        //Writer
        void ShowMenu(uint idMenu);
        void ShowMenus();
        void WriteQuestion(Question question);
    }
}
