using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersBotController : ControllerBase
    {
        private readonly IUserBot _all;

        public UsersBotController(IUserBot users)
        {
            _all = users;
        }

        [Authorize(Roles = "Bot")]
        [HttpPost]
        public IActionResult Post(UserBot user)
        {
            if (user == null)
                return BadRequest();
            if (_all.IsTableHasId(user.IdVk))
                return BadRequest();
            _all.Add(user);
            return Ok(user);
        }

        [Authorize(Roles = "Bot")]
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAll());
        }

        [Authorize(Roles = "Bot")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_all.Get(id));
        }

        [Authorize(Roles = "Bot")]
        [HttpPut]
        public IActionResult Put(UserBot user)
        {
            if (user == null)
                return BadRequest();
            if (!_all.IsTableHasId(user.IdVk))
                return BadRequest();
            _all.Update(user);
            return Ok(user);
        }

        [Authorize(Roles = "Bot")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_all.IsTableHasId(id))
                return BadRequest();
            _all.Delete(id);
            return Ok(id);
        }
    }
}