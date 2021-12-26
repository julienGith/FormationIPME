using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Logic
{
    internal class Manager
    {
        private IManager _manager;

        public ManagerLogic()
        {
            _manager = new Manager();
        }
        bool IsAnswerValid(Question question, Answer answer)
        {
            return _manager.IsAnswerValid(question, answer);
        }
        void ShowMenu(Menu menu)
        {
            _manager.ShowMenu(menu);
        }
        void WriteQuestion(Menu menu)
        {
            _manager.WriteQuestion(menu);
        }
        Answer ReadUserEntry(string userEntry, Question question, Answer answer)
        {
            return _manager.ReadUserEntry(userEntry, question, answer);
        }
    }
}
