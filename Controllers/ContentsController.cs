using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentsController : ControllerBase
    {
        private readonly IContent _all;

        public ContentsController(IContent contents)
        {
            _all = contents;
        }

        [HttpPost]
        public IActionResult Post(Content content)
        {
            if (content == null)
                return BadRequest();
            if (_all.IsTableHasId(content.Id))
                return BadRequest();
            _all.Add(content);
            return Ok(content);
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
        public IActionResult Put(Content content)
        {
            if (content == null)
                return BadRequest();
            if (!_all.IsTableHasId(content.Id))
                return BadRequest();
            _all.Update(content);
            return Ok(content);
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