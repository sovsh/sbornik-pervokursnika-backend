using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LastPostController : ControllerBase
    {
        private readonly IPost _allPosts;
        private readonly IHashtag _allHashtags;

        public LastPostController(IPost posts, IHashtag hashtags)
        {
            _allPosts = posts;
            _allHashtags = hashtags;
        }

        [HttpPut]
        public JsonResult Get(List<string> hashtags)
        {
            if (hashtags.Count == 0)
                return new JsonResult(_allPosts.GetLast());
            return new JsonResult(_allPosts.GetLast(_allHashtags.GetListOfHashtagsIds(hashtags)));
        }
    }
}