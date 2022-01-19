namespace DemoBinding.Persistance
{
    public interface IGenericRepository<T> where T : class,new()
    {
        IEnumerable<T> GetAll(); 

        void Add(T entity);
    }
}