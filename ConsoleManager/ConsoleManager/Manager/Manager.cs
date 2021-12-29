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
        public virtual Answer ReadUserEntry(Question question)
        {

        }
        //Writer
        public virtual void ShowMenu(uint idMenu)
        {
            
        }
        public virtual void WriteQuestion(Question question)
        {
            int i = 0;
            switch (question.QuestionType)
            {
                case QuestionType.OuiNon:
                    Console.WriteLine(question.Text);
                    foreach (var possibleResponse in question.PossibleResponses)
                    {
                        i++;
                        Console.WriteLine($"{i} : {possibleResponse}");
                    }
                    break;
                case QuestionType.ChoixMultiple:
                    Console.WriteLine(question.Text);
                    foreach (var possibleResponse in question.PossibleResponses)
                    {
                        i++;
                        Console.WriteLine($"{i} : {possibleResponse}");
                    }
                    break;
                case QuestionType.ReponseLibre:
                    Console.WriteLine(question.Text);
                    break;
                default:
                    break;
            }
        }
        public virtual void ShowMenus()
        {
            var menus = _menuLogic.GetAllMenus();
            if (menus.Count == 0)
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

    }
}
