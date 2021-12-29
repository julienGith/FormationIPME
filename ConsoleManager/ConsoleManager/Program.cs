// See https://aka.ms/new-console-template for more information

using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ConsoleManager.MenuManager;

Console.WriteLine("Hello, World!");
//IManager reader = new Manager();
IManager manager;
manager.ReadUserEntry();
Manager Writer = new Writer();
MenuManager menuManager = new MenuManager();
menuManager.StartMenuManager();
