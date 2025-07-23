using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Communication.Responses;
using MyFirstApi.Communication.Requests;

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
    public IActionResult CreateUser([FromBody] RequestRegisterUserJson request)
    {
        if (string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Name, Email, and Password are required.");
        }

        var response = new ResponseRegisterUserJson()
        {
            Id = 1,
            Name = request.Name
        };

        return Created(string.Empty, response);
    }

    [HttpPut]
    [Route("update/{id}")]
    [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult UpdateUser(int id, [FromBody] RequestRegisterUserJson request)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid user ID.");
        }
        var response = new ResponseRegisterUserJson()
        {
            Id = id,
            Name = request.Name
        };
        return Ok(response);
    }

    [HttpDelete]
    [Route("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult DeleteUser(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid user ID.");
        }

        return NoContent();
    }
}