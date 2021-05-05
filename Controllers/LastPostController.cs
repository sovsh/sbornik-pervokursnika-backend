using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LastPostController:ControllerBase
    {
        private readonly IPost _allPosts;
        private readonly IHashtag _allHashtags;
        public LastPostController(IPost posts, IHashtag hashtags)
        {
            _allPosts = posts;
            _allHashtags = hashtags;
        }

        [HttpPut]
        public JsonResult Get(List<string>hashtags)
        {
            List<int> hashtagsId = new List<int>();
            foreach (var hashtag in hashtags)
            {
                int id = _allHashtags.Find(hashtag);
                if (id != -1)
                    hashtagsId.Add(id);
            }
            return new JsonResult(_allPosts.GetLast(hashtagsId));
        }
    }
}