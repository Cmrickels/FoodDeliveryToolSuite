#nullable enable

using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiGateway.Util
{
    abstract class IApi
    {
        public string BaseUrl;
        public string?[] Headers;

    }
}