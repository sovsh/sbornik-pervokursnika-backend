using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersBotRolesController : ControllerBase
    {
        private readonly IUserBot _all;

        public UsersBotRolesController(IUserBot users)
        {
            _all = users;
        }
        
        [Authorize(Roles = "Bot")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_all.GetRole(id));
        }
    }
}