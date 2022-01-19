// See https://aka.ms/new-console-template for more information
using EventsAppConsole;

Console.WriteLine("Hello, World!");
var counter = new Counter();
counter.CounterEventHandler += (sender, e) =>
{
    CountDisplay();
};
counter.Count();
void CountDisplay(object)
{
    Console.WriteLine(counter.ToString());
}