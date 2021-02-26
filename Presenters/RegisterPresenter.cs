#nullable enable

using ApiGateway.Models.Entities;
using Newtonsoft.Json;

namespace ApiGateway.Presenters
{
    public class RegisterPresenter : IPresenter<RegisterResponse>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public User Entity { get; set; }

        public void Handle(RegisterResponse response)
        {
            Status = response.Status;
            Message = response.Message;
            Success = response.Status == 200 ? true : false;
            Entity = response.created;    
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}