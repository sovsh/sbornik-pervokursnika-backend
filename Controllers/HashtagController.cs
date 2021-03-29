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
    public class HashtagController : ControllerBase
    {
        private readonly IHashtag _allHashtags;

        public HashtagController(IHashtag hastags)
        {
            _allHashtags = hastags;
        }
        [HttpGet]
        public JsonResult GetAllHashtagsList()
        {
            return new JsonResult(_allHashtags.GetAll());
        }
        
        [HttpGet("{id}")]
        public JsonResult GetHashtag(int id)
        {
            return new JsonResult(_allHashtags.Get(id));
        }
    }
}