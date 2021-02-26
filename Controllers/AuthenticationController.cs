using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using ApiGateway.Services;
using ApiGateway.Models.Requests;
using ApiGateway.Presenters;

namespace ApiGateway.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticationController: ControllerBase
  {
    private readonly IConfiguration _configuration;
    private readonly AuthenticationService _authService;
    private LoginPresenter _loginPresenter;

    public AuthenticationController(IConfiguration configuration, AuthenticationService authService, LoginPresenter loginPresenter)
    {
      _configuration = configuration;
      _authService = authService;
      _loginPresenter = loginPresenter;
    }
  
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {

      await _authService.FetchAndAuthenticate(request, _loginPresenter);
      Console.WriteLine(_loginPresenter.Status);
      
      if(_loginPresenter.Success) {
        return Ok(_loginPresenter.ToJson());
      } else {
        return Unauthorized(_loginPresenter.Message);
      }
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest model)
    {

      _authService.Register();

      // var userExists = await _userManager.FindByNameAsync(model.Username);
      // if (userExists != null)
      // {
      //   return StatusCode(StatusCodes.Status500InternalServerError);
      // }

      // User user = new User()
      // {
      //   Email = model.Email,
      //   SecurityStamp = Guid.NewGuid().ToString(),
      //   UserName = model.Username
      // };

      // var result = await _userManager.CreateAsync(user, model.Password);
      // if (!result.Succeeded)
      // {
      //   return StatusCode(StatusCodes.Status500InternalServerError);
      // }

      // return Ok();
    }
  }
}