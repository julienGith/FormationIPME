namespace DemoBinding.ApiData
{
    public interface IDataManager<TModel,TDto> where TModel : class 
                                                where TDto : class
    {

        Task<IEnumerable<TModel>> GetAll();   

        Task Add(TModel model);
    }
}