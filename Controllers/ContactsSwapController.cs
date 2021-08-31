using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsSwapController : ControllerBase
    {
        private readonly IContact _all;

        public ContactsSwapController(IContact contacts)
        {
            _all = contacts;
        }

        [Authorize(Roles = "User")]
        [HttpPut("{id1}/{id2}")]
        public IActionResult Put(int id1, int id2)
        {
            if (!_all.IsTableHasId(id1))
                return BadRequest();
            if (!_all.IsTableHasId(id2))
                return BadRequest();
            _all.Swap(id1, id2);
            return Ok();
        }
    }
}