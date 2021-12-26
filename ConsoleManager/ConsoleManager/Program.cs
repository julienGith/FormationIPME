// See https://aka.ms/new-console-template for more information

using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ConsoleManager.MenuManager;

Console.WriteLine("Hello, World!");
Manager Manager = new Manager();
MenuManager menuManager = new MenuManager();
menuManager.StartMenuManager();