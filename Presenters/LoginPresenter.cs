#nullable enable

using ApiGateway.Models.Responses;
using Newtonsoft.Json;

namespace ApiGateway.Presenters
{
    class LoginPresenter : IPresenter<LoginResponse>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public string? JwtToken { get; set; }

        public void Handle(LoginResponse response)
        {
            Status = response.Status;
            Message = response.Message;
            Success = response.Status == 200 ? true : false;
            JwtToken = response.Token;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}