using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Dictionary.CLient.Blazor.WebApi.Infrastructure;

public class HttpService : IHttpService
{
    private readonly HttpClient client;

    public HttpService(HttpClient client)
    {
        this.client = client;
    }
    public async Task<T> GetAsync<T>(string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
    }

    public async Task<TResult> PostAsync<T, TResult>(string url, T request)
        where T : class
        where TResult : class
    {

        StringContent stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync(url, stringContent);
        TResult result = null;
        if (response.IsSuccessStatusCode)
            result = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
        return result;
    }

    public async Task<TResult> PutAsync<T, TResult>(string url, T request)
       where T : class
       where TResult : class
    {

        StringContent stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, stringContent);
        TResult result = null;
        if (response.IsSuccessStatusCode)
            result = JsonConvert.DeserializeObject<TResult>(await response.Content.ReadAsStringAsync());
        return result;
    }
    public async Task<bool> PutAsync<T>(string url, T request)
       where T : class
     
    {

        StringContent stringContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PutAsync(url, stringContent);

        return response.IsSuccessStatusCode;
         
    }
    public async Task<bool> DeleteAsync<T>(string url, T request)
       where T : class
    {
        var jsonContent = JsonConvert.SerializeObject(request);
        var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

        var response=await client.SendAsync(new HttpRequestMessage { 
        Method = HttpMethod.Delete,
        Content=content,
        RequestUri=new Uri(url)
        });
        return response.IsSuccessStatusCode;


    }
} 
