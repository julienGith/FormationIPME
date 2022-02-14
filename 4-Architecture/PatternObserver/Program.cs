// See https://aka.ms/new-console-template for more information
using PatternObserver;

Console.WriteLine("Hello, World!");

var movie = new Movie("Spider-man");
var movieObserver = new MovieObserver();
var movieLogic = new MovieLogic();
movieLogic.Attach(movieObserver);

movieLogic.AddNewMovie(movie);
Console.ReadLine();