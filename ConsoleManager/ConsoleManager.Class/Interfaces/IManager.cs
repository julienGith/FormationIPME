using ConsoleManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.Data.Interfaces
{
    public interface IManager
    {

        Question AddMenuQuestion(Question question,Menu menu);
        Question RemoveMenuQuestion(Question question, Menu menu);
        Question UpdateMenuQuestion(Question question, Menu menu);
        bool IsAnswerValid(Question question,Answer answer);
        void ShowMenu(Menu menu);
        void WriteQuestion(Menu menu);
        Answer ReadUserEntry(string userEntry, Question question, Answer answer);

    }
}
