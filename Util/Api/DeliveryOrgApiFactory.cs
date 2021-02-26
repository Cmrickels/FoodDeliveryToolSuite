#nullable enable

namespace ApiGateway.Util
{
    class DeliveryOrgApiFactory : IApiFactory
    {
        public string BaseUrl { get; set;}
        public string?[] Headers { get; set;}

        public DeliveryOrgApiFactory(string url, string?[] headers)
        {
            BaseUrl = url;
            Headers = headers != null ? headers : new string[]{};
        }

        public IApi GetApi(string Type)
        {
            return new DeliveryOrgApi(BaseUrl, Headers);
        }
    }   
}