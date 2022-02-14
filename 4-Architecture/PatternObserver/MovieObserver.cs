namespace PatternObserver
{
    public class MovieObserver : IObserver
    {
        public void Update(Movie movie)
        {
            Console.WriteLine($"le film {movie.Title}");
        }
    }
}
