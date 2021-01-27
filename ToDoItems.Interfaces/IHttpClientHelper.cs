using System.Net.Http;
using System.Threading.Tasks;

namespace ToDoItems.Interfaces
{
    public interface IHttpClientHelper
    {
        Task<HttpClient> GetHttpClientAsync();
        string GetApiUrl(string key);
        HttpClient GetHttpClientForAnonymousUser();
    }
}
