using LocationAndWeatherFinder.Business.LogicCollections;
using Newtonsoft.Json;
using System.Net;

namespace LocationAndWeatherFinder.Service
{
    public class HttpClientWrapperMain : IHttpClientWrapper
    {
        public ApiResult<TReturn> Get<T, TReturn>(T data)
        {
            using var client = new WebClient();
            var response = client.DownloadString(data.ToString());
            return ProcessRequest<TReturn>(response);
        }
        private static ApiResult<TReturn> ProcessRequest<TReturn>(string response)
        {
            var result = new ApiResult<TReturn>();
            if (!string.IsNullOrEmpty(response))
            {
                result.Data = JsonConvert.DeserializeObject<TReturn>(response);
                result.StatusCode = HttpStatusCode.OK;
            }
            else
            {
                result.RawData = response;
                result.StatusCode = HttpStatusCode.NotFound;
            }
            return result;
        }
    }
}
