using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContact _all;

        public ContactsController(IContact contacts)
        {
            _all = contacts;
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            if (contact == null)
                return BadRequest();
            if (_all.IsTableHasId(contact.Id))
                return BadRequest();
            _all.Add(contact);
            return Ok(contact);
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
        public IActionResult Put(Contact contact)
        {
            if (contact == null)
                return BadRequest();
            if (!_all.IsTableHasId(contact.Id))
                return BadRequest();
            _all.Update(contact);
            return Ok(contact);
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