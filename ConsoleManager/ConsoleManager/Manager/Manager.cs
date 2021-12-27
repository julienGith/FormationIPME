using ConsoleManager.Data.Models;
using ConsoleManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    internal class Manager : IManager
    {
        private QuestionLogic _questionLogic;
        private MenuLogic _menuLogic;
        private AnswerLogic _answerLogic;
        public Manager()
        {
            _answerLogic = new AnswerLogic();
            _menuLogic = new MenuLogic();
            _questionLogic = new QuestionLogic();
        }
        //Reader
        public virtual bool IsAnswerValid(Question question, Answer answer)
        {
            throw new NotImplementedException();
        }
        public virtual void ReadUserEntry(Question question)
        {
            var userEntry = Console.ReadLine();
            while (String.IsNullOrEmpty(userEntry) || String.IsNullOrWhiteSpace(userEntry))
            {
                Console.WriteLine($"Saisie incorrecte : {userEntry}");
                Console.WriteLine("Veuillez resaisir :");
                userEntry = Console.ReadLine();
            }
            uint.TryParse(userEntry, out uint choice);
            Answer answer = new Answer(userEntry, choice, question);
            IsAnswerValid(question, answer);
        }
        //Writer
        public virtual void ShowMenu(Menu menu)
        {
            
        }
        public virtual void ShowMenus()
        {
            var menus = _menuLogic.GetAllMenus();
            if (menus.Count==0)
            {
                Console.WriteLine("Aucun menu trouvé.");
                return;
            }
            Console.WriteLine("Liste des menus :");
            foreach (var item in menus)
            {
                Console.WriteLine($"Id menu : {item.Id} // Titre : {item.Title}");
            }
        }
        public virtual void WriteQuestion(Question question)
        {
            Console.WriteLine(question.Text);
        }
    }
}
