using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPost _all;
        public PostsController(IPost posts)
        {
            _all = posts;
        }
        [HttpPost]
        public IActionResult Post(Post post)
        {
            if (post == null) 
                return BadRequest();
            if (_all.IsTableHasId(post.Id)) 
                return BadRequest();
            _all.Add(post);
            return Ok(post);
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
        public IActionResult Put(Post post)
        {
            if (post == null) 
                return BadRequest();
            if (!_all.IsTableHasId(post.Id)) 
                return BadRequest();
            _all.Update(post);
            return Ok(post);
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