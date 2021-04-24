using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HashtagsController : ControllerBase
    {
        private readonly IHashtag _all;
        public HashtagsController(IHashtag hashtags)
        {
            _all = hashtags;
        }

        [HttpPost]
        public IActionResult Post(Hashtag hashtag)
        {
            if (hashtag == null)
                return BadRequest();
            if (_all.IsTableHasHashtag(hashtag.Id, hashtag.Name))
                return BadRequest();
            _all.Add(hashtag);
            return Ok(hashtag);
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
        public IActionResult Put(Hashtag hashtag)
        {
            if (hashtag == null) 
                return BadRequest();
            if (!_all.IsTableHasId(hashtag.Id)) 
                return BadRequest();
            _all.Update(hashtag);
            return Ok(hashtag);
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