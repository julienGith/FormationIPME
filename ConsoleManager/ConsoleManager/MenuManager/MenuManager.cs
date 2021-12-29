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
        private string GetChoiceValid(string? choice, int choices)
        {

            while (String.IsNullOrEmpty(choice) || String.IsNullOrWhiteSpace(choice) || choice.Length > 1 || !Char.IsDigit(choice[0]) || int.Parse(choice) > choices || int.Parse(choice) == 0)
            {
                Console.WriteLine($"Choix saisi incorrect : {choice}");
                Console.WriteLine("Choisir une action :\n1 Voir tous les menus\n2 Créer un menu\n3 Ajouter des Questions à un menu\n4 Sortir\nSaisissez le numéro de l'action :");
                choice = Console.ReadLine();
            }
            return choice;
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
            var menu = new Menu(title,greetingMessage,null);
            menu = _menuLogic.CreateMenu(menu);
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
        internal void AddQuestionToMenu()
        {
            Console.WriteLine("AJOUT DE QUESTION A UN MENU");
            ShowAllMenus();
            Console.WriteLine("Veuillez indiquer l'id du menu pour le choisir :");
            var idMenu = Console.ReadLine();
            uint id = GetIdMenuValid(idMenu);
            var menu = _menuLogic.GetMenuById(id);
            CreateQuestion(menu);
        }
        internal void CreateQuestion(Menu menu)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            Console.WriteLine("CREATION DE QUESTION");
            Console.WriteLine("Veuillez choisir le type de question :");
            foreach (var type in Enum.GetValues(typeof(QuestionType)))
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
                case "1": menu.Questions.Add(_questionLogic.CreateQuestion(CreateYesNoQuestion(menu))); break;
                case "2": menu.Questions.Add(_questionLogic.CreateQuestion(CreateMultipleChoicesQuestion(menu))); break;
                case "3": menu.Questions.Add(_questionLogic.CreateQuestion(CreateFreeAnswerQuestion(menu))); break;
            }
            _menuLogic.CreateMenu(menu);
            SubMenuQuestion(menu);

        }
        private void SubMenuQuestion(Menu menu)
        {
            var question = menu.Questions.Last();
            Console.WriteLine($"Question : {question.Text} crée.");
            Console.WriteLine("1 Ajouter une sous question\n2 Créer une nouvelle question\n3 Terminer");
            var choice = Console.ReadLine();
            choice = GetChoiceValid(choice, 3);
            switch (choice)
            {
                case "1":
                    question = GetMotherQuestion(menu);
                    CreateMotherQuestion(menu, question);
                    break;
                case "2": CreateQuestion(menu); break;
                case "3": Environment.Exit(0); break;
                default:
                    break;
            }
        }
        private void CreateMotherQuestion(Menu menu, Question question)
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            Console.WriteLine("CREATION DE QUESTION MERE");
            Console.WriteLine("Veuillez choisir le type de question :");
            foreach (var type in Enum.GetValues(typeof(QuestionType)))
            {
                i++;
                builder.Append($"{i} " + type.ToString() + "\n");
            }
            string questionTypeString = builder.ToString();
            Console.WriteLine(questionTypeString);
            var questionTypeChoice = Console.ReadLine();
            questionTypeChoice = GetquestionTypeChoiceValid(questionTypeChoice);
            switch (questionTypeChoice)
            {
                case "1": question.QuestionsFilles.Add(_questionLogic.CreateQuestion(CreateYesNoQuestion(menu))); break;
                case "2": question.QuestionsFilles.Add(_questionLogic.CreateQuestion(CreateMultipleChoicesQuestion(menu))); break;
                case "3": question.QuestionsFilles.Add(_questionLogic.CreateQuestion(CreateFreeAnswerQuestion(menu))); break;
            }
            _questionLogic.CreateQuestion(question);
        }
        private Question GetMotherQuestion(Menu menu)
        {
            ShowQuestions(menu);
            Console.WriteLine("Veuillez indiquer l'id de la question mère :");
            var choice = Console.ReadLine();
            var idQuestion = GetIdQuestionValid(choice);
            var question = GetMotherQuestionValide(idQuestion,menu);
            return question;
        }
        private Question GetMotherQuestionValide(uint idQuestion,Menu menu)
        {
            var question = menu.Questions.FirstOrDefault(q => q.Id == idQuestion);

            while (question == null)
            {
                Console.WriteLine($"Id incorrect : {idQuestion} ");
                ShowQuestions(menu);
                Console.WriteLine("Veuillez indiquer l'id de la question mère :");
                var choice = Console.ReadLine();
                idQuestion = GetIdQuestionValid(choice);
                question = menu.Questions.FirstOrDefault(q => q.Id == idQuestion);

            }
            return question;
        }
        private void ShowQuestions(Menu menu)
        {
            foreach (var item in menu.Questions)
            {
                Console.WriteLine($"Id : {item.Id} : {item.Text}");
            }
        }
        private string GetquestionTypeChoiceValid(string? questionTypeChoice)
        {
            char[] chars = questionTypeChoice.ToCharArray();
            StringBuilder builder = new StringBuilder();
            int i = 0;

            while (String.IsNullOrEmpty(questionTypeChoice) || String.IsNullOrWhiteSpace(questionTypeChoice) || chars.Length > 1 || Char.IsDigit(chars[0]) || chars[0] > Enum.GetValues(typeof(QuestionType)).Length)
            {
                Console.WriteLine($"Type de question incorrect : {questionTypeChoice}");
                ShowAllMenus();
                Console.WriteLine("Veuillez choisir le type de question :");
                foreach (var type in Enum.GetValues(typeof(QuestionType)))
                {
                    i++;
                    builder.Append($"{i} " + type.ToString() + "\n");
                }
                questionTypeChoice = Console.ReadLine();
                chars = questionTypeChoice.ToCharArray();
            }
            return questionTypeChoice;
        }
        internal Question CreateYesNoQuestion(Menu menu)
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
            var question = new Question(questionString, 2, possibleChoices, menu,QuestionType.OuiNon,null);
            _questionLogic.CreateQuestion(question);
            return question;
        }
        internal Question CreateMultipleChoicesQuestion(Menu menu)
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
            var question = new Question(questionString, (uint)possibleChoices.Count, possibleChoices, menu, QuestionType.ChoixMultiple,null);
            _questionLogic.CreateQuestion(question);
            return question;

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
        internal Question CreateFreeAnswerQuestion(Menu menu)
        {
            Console.WriteLine("Veuillez saisir la question : ");
            var questionString = Console.ReadLine();
            while (String.IsNullOrEmpty(questionString) || String.IsNullOrWhiteSpace(questionString))
            {
                Console.WriteLine("Saisie incorrecte");
                Console.WriteLine("Veuillez saisir la question : ");
                questionString = Console.ReadLine();
            }
            var question = new Question(questionString, uint.MaxValue,null, menu, QuestionType.ReponseLibre,null);
            _questionLogic.CreateQuestion(question);
            return question;

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
        private uint GetIdQuestionValid(string? idQuestion)
        {
            char[] chars = idQuestion.ToCharArray();
            while (String.IsNullOrEmpty(idQuestion) || String.IsNullOrWhiteSpace(idQuestion) || !IsAllCharsDigit(chars))
            {
                Console.WriteLine($"Id incorrect : {idQuestion}");
                ShowAllMenus();
                Console.WriteLine("Veuillez indiquer l'id de la question mère pour la choisir :");
                idQuestion = Console.ReadLine();
                chars = idQuestion.ToCharArray();
            }
            return uint.Parse(idQuestion);
        }
        //todo tester
        private bool IsAllCharsDigit(char[] chars)
        {
            foreach (var item in chars)
            {
                return !Char.IsDigit(item);
            }
            return true;
        }

    }
}
