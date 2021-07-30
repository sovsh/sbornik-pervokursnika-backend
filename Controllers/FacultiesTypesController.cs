using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesTypesController : ControllerBase
    {
        private readonly IDeaneryTypeRelation _all;
        public FacultiesTypesController(IDeaneryTypeRelation relations)
        {
            _all = relations;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAllDivisionsTypes());
        }
    }
}