using ConsoleManager.Data.Models;
using ConsoleManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManage.Manager
{
    public class Manager
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
        public Answer ReadUserEntry(Question question)
        {
            var correctUserEntry = "";
            var userEntry = Console.ReadLine();
            while (String.IsNullOrEmpty(userEntry) || String.IsNullOrWhiteSpace(userEntry))
            {
                Console.WriteLine($"Saisie incorrecte : {userEntry}");
                Console.WriteLine("Veuillez ressaisir :");
                userEntry = Console.ReadLine();
            }
            var result = uint.TryParse(userEntry, out uint choice);
            switch (question.QuestionType)
            {
                case QuestionType.OuiNon:

                    while (!result || choice == 0 || choice > 2)
                    {
                        Console.WriteLine($"Saisie incorrecte : {userEntry}");
                        Console.WriteLine("Veuillez ressaisir :");
                        ReadUserEntry(question);
                    }
                    break;
                case QuestionType.ChoixMultiple:
                    userEntry = GetValidUserEntryMultipleChoice(userEntry, question);
                    choice = uint.Parse(userEntry);
                    break;
                case QuestionType.Numerique:
                    userEntry = GetValidUserEntryNumeric(userEntry);
                    choice = uint.Parse(userEntry);
                    break;
                case QuestionType.ReponseLibre:
                    choice = 0;
                    break;
                default:
                    break;
            }
            Answer answer = new Answer(userEntry, choice, question);
            question.Answers.Add(answer);
            return answer;
        }

        private string GetValidUserEntryNumeric(string userEntry)
        {
            uint choice = 0;
            var result = uint.TryParse(userEntry, out choice);
            while (String.IsNullOrEmpty(userEntry) || String.IsNullOrWhiteSpace(userEntry) || !result || choice == 0 )
            {
                Console.WriteLine($"Saisie incorrecte : {userEntry}");
                Console.WriteLine("Veuillez ressaisir :");
                userEntry = Console.ReadLine();
                result = uint.TryParse(userEntry, out choice);
            }
            return userEntry;
        }

        private string GetValidUserEntryMultipleChoice(string userEntry, Question question)
        {
            uint choice = 0;
            var result = uint.TryParse(userEntry, out choice);
            while (String.IsNullOrEmpty(userEntry) || String.IsNullOrWhiteSpace(userEntry) || !result || choice == 0 || choice > question.PossibleChoices)
            {
                Console.WriteLine($"Saisie incorrecte : {userEntry}");
                Console.WriteLine("Veuillez ressaisir :");
                userEntry = Console.ReadLine();
                result = uint.TryParse(userEntry, out choice);
            }
            return userEntry;
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
                    //foreach (var possibleResponse in question.PossibleResponses)
                    //{
                    //    i++;
                    //    Console.WriteLine($"{i} : {possibleResponse}");
                    //}
                    break;
                case QuestionType.ChoixMultiple:
                    Console.WriteLine(question.Text);
                    //foreach (var possibleResponse in question.PossibleResponses)
                    //{
                    //    i++;
                    //    Console.WriteLine($"{i} : {possibleResponse}");
                    //}
                    break;
                case QuestionType.ReponseLibre:
                    Console.WriteLine(question.Text);
                    break;
                case QuestionType.Numerique:
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
