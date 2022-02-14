namespace PatternObserver
{
    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(Movie movie);
    }
}
