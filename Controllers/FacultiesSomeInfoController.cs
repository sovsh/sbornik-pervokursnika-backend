using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesSomeInfoController : ControllerBase
    {
        private readonly IFaculty _all;

        public FacultiesSomeInfoController(IFaculty faculties)
        {
            _all = faculties;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAllSomeInfoDTOs());
        }
    }
}