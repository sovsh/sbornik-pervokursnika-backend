using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersDesktopController : ControllerBase
    {
        private readonly IUserDesktop _all;

        public UsersDesktopController(IUserDesktop users)
        {
            _all = users;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post(UserDesktop user)
        {
            if (user == null)
                return BadRequest();
            if (_all.IsTableHasLogin(user.Login))
                return BadRequest();
            _all.Add(user);
            return Ok(user);
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAll());
        }

        [Authorize(Roles = "User")]
        [HttpGet("{login}")]
        public JsonResult Get(string login)
        {
            return new JsonResult(_all.Get(login));
        }

        [Authorize(Roles = "User")]
        [HttpPut]
        public IActionResult Put(UserDesktopPutDTO user)
        {
            if (user == null)
                return BadRequest();
            if (!_all.IsTableHasLogin(user.Login))
                return BadRequest();
            if (!_all.ArePasswordsMatch(user.Login, user.OldPassword))
                return BadRequest("Passwords don't match");
            _all.Update(user);
            return Ok(user);
        }

        [Authorize(Roles = "User")]
        [HttpDelete("{login}")]
        public IActionResult Delete(string login)
        {
            if (!_all.IsTableHasLogin(login))
                return BadRequest();
            _all.Delete(login);
            return Ok(login);
        }
    }
}