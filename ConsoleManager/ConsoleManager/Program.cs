// See https://aka.ms/new-console-template for more information

using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ConsoleManager.MenuManager;

Console.WriteLine("Hello, World!");
//IManager reader = new Manager();
var manager = new Manager();
var question = new Question("indiquer film :",0,null,null,QuestionType.ReponseLibre,null);
manager.WriteQuestion(question);
var result = manager.ReadUserEntry(question);
Console.WriteLine(result.Text);


