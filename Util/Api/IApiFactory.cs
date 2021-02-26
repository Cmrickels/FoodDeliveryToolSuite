using ApiGateway.Util;

namespace ApiGateway.Util
{
    interface IApiFactory
    {
        IApi GetApi(string Type);
    }
}