using System.Net;

namespace LocationAndWeatherFinder.Business.LogicCollections
{
    public class ApiResult
    {
        public HttpStatusCode StatusCode { get; set; }

        public string RawData { get; set; }
    }
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
}
