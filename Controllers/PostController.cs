using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SbornikBackend.Interfaces;
using SbornikBackend.Repositories;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPost _allPosts;

        public PostController(IPost posts)
        {
            _allPosts = posts;
        }
        [HttpGet]
        public JsonResult GetAllpostsList()
        {
            return new JsonResult(_allPosts.GetAll());
        }
    }
}