using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesInfoController : ControllerBase
    {
        private readonly IFaculty _all;

        public FacultiesInfoController(IFaculty faculties)
        {
            _all = faculties;
        }

        [HttpGet("{name}")]
        public JsonResult Get(string name)
        {
            return new JsonResult(_all.GetDTO(name));
        }
        /*[HttpPut]
        public JsonResult Get(string name)
        {
            return new JsonResult(_all.GetDTO(name));
        }*/

    }
}