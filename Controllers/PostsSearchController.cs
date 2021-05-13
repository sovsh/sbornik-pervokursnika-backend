using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsSearchController : ControllerBase
    {
        private readonly IPost _allPosts;

        public PostsSearchController(IPost posts)
        {
            _allPosts = posts;
        }
       [HttpGet("{searchString}")]
        public JsonResult Search(string searchString)
        {
            if (searchString == null)
                return new JsonResult("Search string is empty");
            return new JsonResult(_allPosts.GetAll(searchString));
        }
    }
}