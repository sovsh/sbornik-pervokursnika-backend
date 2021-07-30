using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeaneriesTypesRelationsController : ControllerBase
    {
        private readonly IDeaneryTypeRelation _all;
        public DeaneriesTypesRelationsController(IDeaneryTypeRelation relations)
        {
            _all = relations;
        }
        
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post(DeaneryTypeRelation relation)
        {
            if (relation == null) 
                return BadRequest();
            if (_all.IsTableHasId(relation.Id)) 
                return BadRequest();
            _all.Add(relation);
            return Ok(relation);
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
        public IActionResult Put(DeaneryTypeRelation relation)
        {
            if (relation == null) 
                return BadRequest();
            if (!_all.IsTableHasId(relation.Id)) 
                return BadRequest();
            _all.Update(relation);
            return Ok(relation);
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