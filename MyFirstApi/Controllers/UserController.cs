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
        var response = new ResponseRegisterUserJson()
        {
            Id = 1,
            Name = request.Name
        };

        return Created(string.Empty, response);
    }
}