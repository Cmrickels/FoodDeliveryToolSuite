#nullable enable

namespace ApiGateway.Models.Responses
{
  public class LoginResponse : IResponse
  {
    public int Status { get; set; }
    public string Message { get; set; }
    public string? Token { get; set; }

    public LoginResponse(int status, string message, string? token = null)
    {
      Status = status;
      Message = message;
      Token = token;
    }
  }
}