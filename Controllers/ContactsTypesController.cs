using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsTypesController : ControllerBase
    {
        private readonly IContact _all;

        public ContactsTypesController(IContact contacts)
        {
            _all = contacts;
        }

        [HttpGet("{facultyId}")]
        public JsonResult Get(int facultyId)
        {
            return new JsonResult(_all.GetAllTypes(facultyId));
        }
    }
}