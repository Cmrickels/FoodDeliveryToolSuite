#nullable enable

namespace ApiGateway.Util
{
    class DeliveryOrgApi: IApi
    {
        public DeliveryOrgApi(string baseUrl, string?[] headers)
        {
            BaseUrl = baseUrl;
            Headers = headers;
        }
    }
}