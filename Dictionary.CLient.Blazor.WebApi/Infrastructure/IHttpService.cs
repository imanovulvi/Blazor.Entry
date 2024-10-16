
namespace Dictionary.CLient.Blazor.WebApi.Infrastructure
{
    public interface IHttpService
    {
        Task<bool> DeleteAsync<T>(string url, T request) where T : class;
        Task<T> GetAsync<T>(string url);
        Task<TResult> PostAsync<T, TResult>(string url, T request)
            where T : class
            where TResult : class;
        Task<TResult> PutAsync<T, TResult>(string url, T request)
            where T : class
            where TResult : class;
    }
}