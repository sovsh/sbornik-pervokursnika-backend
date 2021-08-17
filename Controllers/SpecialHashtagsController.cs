using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpecialHashtagsController : ControllerBase
    {
        private readonly IHashtag _all;

        public SpecialHashtagsController(IHashtag hashtags)
        {
            _all = hashtags;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAllSpecial());
        }
    }
}