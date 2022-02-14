namespace PatternObserver
{
    public class MovieLogic : ISubject
    {
        private readonly IMovie _movie;
        private List<IObserver> _observers = new List<IObserver>();
        public MovieLogic()
        {
            _movie = new MovieFunction();
        }
        public Movie AddNewMovie(Movie movie)
        {
            Notify(movie);
            return _movie.AddNewMovie(movie);
        }

        public void Attach(IObserver observer)
        {
            Console.WriteLine("MovieLogic : Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("MovieLogic: Detached an observer.");
        }

        public void Notify(Movie movie)
        {
            foreach (var observer in _observers)
            {
                observer.Update(movie);
            }
        }
    }
}
