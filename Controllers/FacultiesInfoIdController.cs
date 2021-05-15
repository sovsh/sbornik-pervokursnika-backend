using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesInfoIdController : ControllerBase
    {
        private readonly IFaculty _all;

        public FacultiesInfoIdController(IFaculty faculties)
        {
            _all = faculties;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_all.GetDTO(id));
        }
    }
}