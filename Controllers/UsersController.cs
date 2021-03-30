using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUser _all;
        public UsersController(IUser users)
        {
            _all = users;
        }
        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user == null) 
                return BadRequest();
            if (_all.IsTableHasId(user.Id)) 
                return BadRequest();
            _all.Add(user);
            return Ok(user);
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAll());
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_all.Get(id));
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            if (user == null) 
                return BadRequest();
            if (!_all.IsTableHasId(user.Id)) 
                return BadRequest();
            _all.Update(user);
            return Ok(user);
        }

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