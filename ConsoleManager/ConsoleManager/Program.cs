// See https://aka.ms/new-console-template for more information

using ConsoleManage.Manager;
using ConsoleManager.Data.Models;
using ConsoleManager.MenuManager;

Console.WriteLine("Hello, World!");
//IManager reader = new Manager();
IManager manager;
Manager reader = new Reader();
Manager writer = new Writer();
reader.
MenuManager menuManager = new MenuManager();
menuManager.StartMenuManager();
