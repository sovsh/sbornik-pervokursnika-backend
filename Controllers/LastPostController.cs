using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LastPostController:ControllerBase
    {
        private readonly IPost _allPosts;
        public LastPostController(IPost posts)
        {
            _allPosts = posts;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_allPosts.GetLast());
        }
    }
}