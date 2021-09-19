using LocationAndWeatherFinder.Business.LogicCollections;

namespace LocationAndWeatherFinder.Service
{
    public interface IHttpClientWrapper
    {
        ApiResult<TReturn> Get<T, TReturn>(T data);
    }
}
