using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;


[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public IActionResult GetUser()
    {
        var response = new Response
        {
            Name = "Taylor",
            Age = "35"
        };

        return Ok(response);
    }
}