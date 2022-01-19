using AutoFixture;

namespace DemoBinding.Persistance
{
    public class FakeGenericRepository<T> : IGenericRepository<T> where T : class,new()
    {

        private readonly List<T> _listEntity = new List<T>();
        private readonly Fixture _fixture = new Fixture();

        public FakeGenericRepository()
        {
            _listEntity = _fixture.CreateMany<T>(15).ToList(); 
        }

        public IEnumerable<T> GetAll()
        {
            return _listEntity; 
        }

        public void Add(T entity)
        {
            _listEntity.Add(entity);
        }
    }
}