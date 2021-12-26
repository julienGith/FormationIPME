using ConsoleManager.Data.Models;
using ConsoleManager.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleManager.MenuManager
{
    internal class MenuManager
    {
        private MenuLogic _menuLogic;
        private QuestionLogic _questionLogic;
        private AnswerLogic _answerLogic;

        public MenuManager()
        {
            _menuLogic = new MenuLogic();
            _questionLogic = new QuestionLogic();
            _answerLogic = new AnswerLogic();
        }
        internal void ExecuteMenu()
        {

        }
        internal void StartMenuManager()
        {
            Console.WriteLine("BIENVENUE DANS LE GESTIONNAIRE DE MENU");
            Console.WriteLine("Choisir une action :\n1 Voir tous les menus\n2 Créer un menu\n3 Ajouter des Questions à un menu\n4 Sortir\nSaisissez le numéro de l'action :");
            var choice = Console.ReadLine();
            choice = GetChoiceValid(choice,4);
            switch (choice)
            {
                case "1": ShowAllMenus(); break;
                case "2": CreateMenu(); break;
                case "3": AddQuestionToMenu(); break;
                case "4": Environment.Exit(0); break;
                default:
                    break;
            }
        }

        private void ShowAllMenus()
        {
            var menus = _menuLogic.GetAllMenus();
            if (menus==null||menus.Count==0)
            {
                Console.WriteLine("Aucun menu disponible");
                return;
            }
            foreach (var menu in menus)
            {
                Console.WriteLine($"Menu id : {menu.Id} Titre : {menu.Title}");
            }
        }


        internal void CreateMenu()
        {
            Console.WriteLine("CREATION D'UN MENU");
            Console.WriteLine("Veuillez indiquer le titre du menu");
            var title = Console.ReadLine();
            title = GetTitleEntryValid(title);
            Console.WriteLine("Veuillez indiquer le message d'accueil du menu");
            var greetingMessage = Console.ReadLine();
            greetingMessage = GetGreetingMessageEntryValid(greetingMessage);
            var menu = _menuLogic.CreateMenu(title, greetingMessage,null);
        }
        internal Question CreateQuestion(uint idMenu)
        {
            var menu = _menuLogic.GetMenuById(idMenu);
            StringBuilder builder = new StringBuilder();
            int i = 0;
            Console.WriteLine("CREATION DE QUESTION");
            Console.WriteLine("Veuillez choisir le type de question :");
            foreach (var type in Enum.GetValues(typeof(Const.QuestionType)))
            {
                i++;
                builder.Append($"{i} "+type.ToString()+"\n");
            }
            string questionTypeString = builder.ToString(); 
            Console.WriteLine(questionTypeString);
            var questionTypeChoice = Console.ReadLine();
            questionTypeChoice = GetquestionTypeChoiceValid(questionTypeChoice);
            switch (questionTypeChoice)
            {
                case "1": return _questionLogic.CreateQuestion(CreateYesNoQuestion());
                case "2": return _questionLogic.CreateQuestion(CreateMultipleChoicesQuestion());
                case "3": return _questionLogic.CreateQuestion(CreateFreeAnswerQuestion());
            }
            return null;
        }

        internal Question CreateMultipleChoicesQuestion()
        {
            var possibleChoices = new List<string>();
            Console.WriteLine("Veuillez saisir la question : ");
            var questionString = Console.ReadLine();
            while (String.IsNullOrEmpty(questionString) || String.IsNullOrWhiteSpace(questionString))
            {
                Console.WriteLine("Saisie incorrecte");
                Console.WriteLine("Veuillez saisir la question : ");
                questionString = Console.ReadLine();
            }
            var possibleChoice = CreatePossibleChoice();
            possibleChoices.Add(possibleChoice);
            possibleChoices = CreateAnotherPossibleChoice(possibleChoices);
            var question = new Question(questionString, (uint)possibleChoices.Count, possibleChoices);
            return question;

        }

        private List<string> CreateAnotherPossibleChoice(List<string> possibleChoices)
        {
            Console.WriteLine("Souhaitez vous ajouter un choix possible supplémentaire ?");
            Console.WriteLine("1 Oui\n2 non");
            var choix = Console.ReadLine();
            choix = GetChoiceValid(choix,3);
            switch (choix)
            {
                case "1":
                    possibleChoices.Add(CreatePossibleChoice());
                    CreateAnotherPossibleChoice(possibleChoices);
                    break;
                case "2":
                    return possibleChoices;
            }
            return possibleChoices;

        }

        private string CreatePossibleChoice()
        {
            Console.WriteLine("AJOUT D'UN CHOIX");
            Console.WriteLine("Veuillez saisir le choix : ");
            var possibleChoice = Console.ReadLine();
            while (String.IsNullOrEmpty(possibleChoice) || String.IsNullOrWhiteSpace(possibleChoice))
            {
                Console.WriteLine("Saisie incorrecte");
                Console.WriteLine("Veuillez saisir le choix : ");
                possibleChoice = Console.ReadLine();
            }
            Console.WriteLine($"Choix : {possibleChoice} ajouté.");
            return possibleChoice;
        }

        internal Question CreateFreeAnswerQuestion()
        {
            Console.WriteLine("Veuillez saisir la question : ");
            var questionString = Console.ReadLine();
            while (String.IsNullOrEmpty(questionString) || String.IsNullOrWhiteSpace(questionString))
            {
                Console.WriteLine("Saisie incorrecte");
                Console.WriteLine("Veuillez saisir la question : ");
                questionString = Console.ReadLine();
            }
            var question = new Question(questionString, 0,null);
            return question;

        }

        internal Question CreateYesNoQuestion()
        {
            Console.WriteLine("Veuillez saisir la question : ");
            var questionString = Console.ReadLine();
            while (String.IsNullOrEmpty(questionString) || String.IsNullOrWhiteSpace(questionString))
            {
                Console.WriteLine("Saisie incorrecte");
                Console.WriteLine("Veuillez saisir la question : ");
                questionString = Console.ReadLine();
            }
            var possibleChoices = new List<string>();
            possibleChoices.Add("Oui");
            possibleChoices.Add("Non");
            var question = new Question(questionString, 2, possibleChoices);
            return question;
        }

        internal void AddQuestionToMenu()
        {
            Console.WriteLine("AJOUT DE QUESTION A UN MENU");
            ShowAllMenus();
            Console.WriteLine("Veuillez indiquer l'id du menu pour le choisir :");
            var idMenu = Console.ReadLine();
            uint id = GetIdMenuValid(idMenu);
            CreateQuestion(id);
        }
        private string GetquestionTypeChoiceValid(string? questionTypeChoice)
        {
            char[] chars = questionTypeChoice.ToCharArray();
            StringBuilder builder = new StringBuilder();
            int i = 0;

            while (String.IsNullOrEmpty(questionTypeChoice) || String.IsNullOrWhiteSpace(questionTypeChoice) || chars.Length > 1 || Char.IsDigit(chars[0]) || chars[0] > Enum.GetValues(typeof(Const.QuestionType)).Length)
            {
                Console.WriteLine($"Type de question incorrect : {questionTypeChoice}");
                ShowAllMenus();
                Console.WriteLine("Veuillez choisir le type de question :");
                foreach (var type in Enum.GetValues(typeof(Const.QuestionType)))
                {
                    i++;
                    builder.Append($"{i} " + type.ToString() + "\n");
                }
                questionTypeChoice = Console.ReadLine();
                chars = questionTypeChoice.ToCharArray();
            }
            return questionTypeChoice;
        }
        private uint GetIdMenuValid(string? idMenu)
        {
            char[] chars = idMenu.ToCharArray();
            while (String.IsNullOrEmpty(idMenu) || String.IsNullOrWhiteSpace(idMenu) || !IsAllCharsDigit(chars))
            {
                Console.WriteLine($"Id incorrect : {idMenu}");
                ShowAllMenus();
                Console.WriteLine("Veuillez indiquer l'id du menu pour le choisir :");
                idMenu = Console.ReadLine();
                chars = idMenu.ToCharArray();
            }
            return uint.Parse(idMenu);
        }
        private bool IsAllCharsDigit(char[] chars)
        {
            foreach (var item in chars)
            {
                return !Char.IsDigit(item);
            }
            return true;
        }
        private string GetGreetingMessageEntryValid(string? greetingMessage)
        {
            while (String.IsNullOrEmpty(greetingMessage) || String.IsNullOrWhiteSpace(greetingMessage))
            {
                Console.WriteLine("Saisie du message d'accueil incorrecte");
                Console.WriteLine("Veuillez indiquer le message d'accueil du menu");
                greetingMessage = Console.ReadLine();
            }
            return greetingMessage;
        }
        private string GetTitleEntryValid(string? title)
        {
            while (String.IsNullOrEmpty(title) || String.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Saisie du titre incorrecte");
                Console.WriteLine("Veuillez indiquer le titre du menu");
                title = Console.ReadLine();
            }
            return title;
        }
        private string GetChoiceValid(string? choice, int choices)
        {

            while (String.IsNullOrEmpty(choice) || String.IsNullOrWhiteSpace(choice) || choice.Length>1 || !Char.IsDigit(choice[0]) || int.Parse(choice) > choices || int.Parse(choice) == 0)
            {
                Console.WriteLine($"Choix saisi incorrect : {choice}");
                Console.WriteLine("Choisir une action :\n1 Voir tous les menus\n2 Créer un menu\nSaisissez le numéro de l'action :");
                choice = Console.ReadLine();
            }
            return choice;
        }

    }
}
