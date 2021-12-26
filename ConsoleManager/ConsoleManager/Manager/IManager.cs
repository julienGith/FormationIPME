using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    internal interface IManager
    {
        internal bool IsAnswerValid(Question question, Answer answer);
        internal void ShowMenu(Menu menu);
        internal void WriteQuestion(Menu menu);
        internal Answer ReadUserEntry(string userEntry, Question question, Answer answer);

    }
}
