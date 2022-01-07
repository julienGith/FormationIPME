// See https://aka.ms/new-console-template for more information
using PatternComposite.Class;

Console.WriteLine("Hello, World!");
Inventory inventory = new Inventory();

inventory.Add(new Knife("monCouteau",10));
inventory.Add(new Knife("monCouteau", 100));
inventory.Add(new Knife("monCouteau", 10));
inventory.Add(new Potion("lifePot"));
inventory.Add(new Potion("manaPot"));
var consumables = inventory.GetConsumables();
inventory.Display();
Console.ReadLine();
//inventory.Remove(couteau.Id);