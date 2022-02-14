using AutoMapper;
using System.Net.Http.Json; 

namespace DemoBinding.ApiData
{
    public abstract class ApiDataManager<TModel, TDto> : IDataManager<TModel, TDto> where TModel : class where TDto : class
    {
        private HttpClient HttpClient { get; }
        private IMapper Mapper { get; }
        private string ServerUrl { get; }
        private string ResourceUrl { get; }

        private Uri Uri { get; }

        public ApiDataManager(HttpClient client, IMapper mapper, string serverUrl, string resourceUrl)
        {
            HttpClient = client;
            Mapper = mapper;
            ServerUrl = serverUrl;
            ResourceUrl = resourceUrl;
            Uri = new Uri(ServerUrl + ResourceUrl); 
        }


        public async Task<IEnumerable<TModel>> GetAll()
        {
            var result = await HttpClient.GetFromJsonAsync<IEnumerable<TDto>>(Uri);
            return Mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task Add(TModel model)
        {
            var dto = Mapper.Map<TDto>(model); 
            await HttpClient.PostAsJsonAsync(Uri,dto);
        }
    }
}