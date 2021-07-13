using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsHashtagsController
    {
        private readonly IPost _allPosts;
        private readonly IHashtag _allHashtags;

        public PostsHashtagsController(IPost posts, IHashtag hashtags)
        {
            _allPosts = posts;
            _allHashtags = hashtags;
        }

        [HttpPut]
        public JsonResult Get(PostHashtagsDTO postHashtagsDTO)
        {
            if (postHashtagsDTO.Hashtags.Count == 0)
                return new JsonResult(_allPosts.GetAll().Take(postHashtagsDTO.Number));
            return new JsonResult(_allPosts.GetAll(_allHashtags.GetListOfHashtagsIds(postHashtagsDTO.Hashtags))
                .Take(postHashtagsDTO.Number));
        }
    }
}