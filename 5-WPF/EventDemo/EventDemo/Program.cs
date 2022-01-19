// See https://aka.ms/new-console-template for more information


using EventDemo;

var counter = new Counter();

counter.CounterEvent += CountDiplay;
counter.CounterEvent += CountDiplay; 

counter.CounterEvent -= CountDiplay;
counter.CounterEvent2 += (number) => { Console.WriteLine($"Count {number}"); }; 
counter.Count();

Console.ReadLine();

void CountDiplay(object sender, CounterEventArgs e)
{
    
    Console.WriteLine($"Count {e.CounterNumber}");
}

Console.WriteLine("Hello, World!");
