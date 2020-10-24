using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [HttpGet("list")]
        public List<User> Get()
        {
            return new List<User>
            {
                new User(1, "Bob"),
                new User(2, "Steven"),
                new User(3, "Henry")
            };
        }
    }
}
