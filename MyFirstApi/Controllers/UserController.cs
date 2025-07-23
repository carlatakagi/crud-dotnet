using Microsoft.AspNetCore.Mvc;

namespace MyFirstApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetUserById(int id)
    {
        var response = new Response
        {
            Id = 1,
            Name = "Taylor",
            Age = "35"
        };

        return Ok(response);
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult CreateUser([FromBody] Response user)
    {
        if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Age))
        {
            return BadRequest("Invalid user data.");
        }

        return Created();
    }
}