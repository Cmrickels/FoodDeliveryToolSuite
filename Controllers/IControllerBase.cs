using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
  interface IControllerBase
  {
    // Catch all proxy routes must be implemented
    IActionResult RouteGetToService(string routeName);
    IActionResult RoutePostToService(string routeName, object payload);
    IActionResult RoutePutToService(string routeName, object payload);
    IActionResult RouteDeleteToService(string routeName);
  }
}