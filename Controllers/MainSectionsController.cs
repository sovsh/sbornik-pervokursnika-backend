using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainSectionsController : ControllerBase
    {
        private readonly IGuideSection _allSections;

        public MainSectionsController(IGuideSection sections)
        {
            _allSections = sections;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_allSections.GetAllMainSection());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_allSections.GetAllArticles(id));
        }
    }
}