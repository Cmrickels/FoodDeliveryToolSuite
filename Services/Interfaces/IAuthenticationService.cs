using System.Threading.Tasks;

using ApiGateway.Models.Entities;
using ApiGateway.Presenters;
using ApiGateway.Models.Requests;
using ApiGateway.Models.Dto;

namespace ApiGateway.Services.Interfaces
{
    interface IAuthenticationService
    {
        // fetch entity that represents user. Check that credentials are valid and call auth protocol
        Task FetchAndAuthenticate(LoginRequest request, LoginPresenter outputPort);

        // Agnostically perform whatver auth action required (JWT, SESSION)
        Task<JwtToken> PerformAuthProtocol(User user);

        Task Register(RegisterRequest request, RegisterPresenter registerPresenter);
        
    }
}