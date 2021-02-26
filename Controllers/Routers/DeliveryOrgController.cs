using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ApiGateway.Models.Entities;

namespace ApiGateway.Controllers
{
  [Route("api/org")]
  [ApiController]
  public class DeliveryOrgController: CustomControllerBase, IControllerBase
  {
    private readonly UserManager<User> userManager;

    public DeliveryOrgController(UserManager<User> userManager)
    {
      this.userManager = userManager;
    }

    [HttpGet("{routeName:alpha}")]
    public IActionResult RouteGetToService(string routeName)
    {
      return Ok("Default get achieved");
    }

    [HttpPost("{routeName:alpha}")]
    public IActionResult RoutePostToService(string routeName, object payload)
    {
      return Ok("Default post chieved");
    }

    [HttpPut("{routeName:alpha}")]
    public IActionResult RoutePutToService(string routeName, object payload)
    {
      return Ok("Default put chieved");
    }

    [HttpDelete("{routeName:alpha}")]
    public IActionResult RouteDeleteToService(string routeName)
    {
      return Ok("Default delete chieved");
    }

  }
}