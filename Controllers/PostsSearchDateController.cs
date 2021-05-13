using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsSearchDateController : ControllerBase
    {
        private readonly IPost _allPosts;

        public PostsSearchDateController(IPost posts)
        {
            _allPosts = posts;
        }

        [HttpPut]
        public JsonResult Search(PostsSearchDateDTO searchDTO)
        {
            if (searchDTO.SearchString == null)
                return new JsonResult("Search string is empty");
            return new JsonResult(_allPosts.GetAll(searchDTO.SearchString, searchDTO.Date).Take(searchDTO.Number));
        }
    }
}