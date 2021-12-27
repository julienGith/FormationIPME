using ConsoleManager.Data.Models;
using ConsoleManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    internal class Manager
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
        public virtual Answer GetAnswerValid(Question question, Answer answer)
        {
            switch (question.QuestionType)
            {
                case QuestionType.OuiNon:
                    while (answer.Choice==0 || answer.Choice>2)
                    {
                        Console.WriteLine($"Saisie incorrecte : {answer.Choice}");
                        Console.WriteLine("Veuillez ressaisir :");
                        var userEntry = Console.ReadLine();
                        uint.TryParse(userEntry, out uint choice);
                        answer.Choice = choice;
                    }
                    break;
                case QuestionType.ChoixMultiple:
                    while (answer.Choice == 0 || answer.Choice > question.PossibleChoices)
                    {
                        Console.WriteLine($"Saisie incorrecte : {answer.Choice}");
                        Console.WriteLine("Veuillez ressaisir :");
                        var userEntry = Console.ReadLine();
                        uint.TryParse(userEntry, out uint choice);
                        answer.Choice = choice;
                    }
                    break;
                default:
                    break;
            }
            return answer;
        }
        public virtual Answer ReadUserEntry(Question question)
        {
            var userEntry = Console.ReadLine();
            while (String.IsNullOrEmpty(userEntry) || String.IsNullOrWhiteSpace(userEntry))
            {
                Console.WriteLine($"Saisie incorrecte : {userEntry}");
                Console.WriteLine("Veuillez ressaisir :");
                userEntry = Console.ReadLine();
            }
            uint.TryParse(userEntry, out uint choice);
            Answer answer = new Answer(userEntry, choice, question);
            return GetAnswerValid(question, answer);
        }
        //Writer
        public virtual void ShowMenu(uint idMenu)
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
