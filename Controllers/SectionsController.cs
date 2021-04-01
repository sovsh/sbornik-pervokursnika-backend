using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionsController : ControllerBase
    {
        private readonly ISection _all;
        public SectionsController(ISection sections)
        {
            _all = sections;
        }
        [HttpPost]
        public IActionResult Post(Section section)
        {
            if (section == null) 
                return BadRequest();
            if ((int) section.Type != 2)
                return BadRequest();
            if (_all.IsTableHasId(section.Id)) 
                return BadRequest();
            _all.Add(section);
            return Ok(section);
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
        public IActionResult Put(Section section)
        {
            if (section == null) 
                return BadRequest();
            if ((int) section.Type != 2)
                return BadRequest();
            if (!_all.IsTableHasId(section.Id)) 
                return BadRequest();
            _all.Update(section);
            return Ok(section);
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