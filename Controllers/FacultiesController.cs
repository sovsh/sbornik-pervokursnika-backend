using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesController : ControllerBase
    {
        private readonly IFaculty _all;
        public FacultiesController(IFaculty faculties)
        {
            _all = faculties;
        }
        
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post(Faculty faculty)
        {
            if (faculty == null) 
                return BadRequest();
            if (_all.IsTableHasId(faculty.Id)) 
                return BadRequest();
            _all.Add(faculty);
            return Ok(faculty);
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
        
        [Authorize(Roles = "User")]
        [HttpPut]
        public IActionResult Put(Faculty faculty)
        {
            if (faculty == null) 
                return BadRequest();
            if (!_all.IsTableHasId(faculty.Id)) 
                return BadRequest();
            _all.Update(faculty);
            return Ok(faculty);
        }

        [Authorize(Roles = "User")]
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