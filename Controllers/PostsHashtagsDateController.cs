using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsHashtagsDateController
    {
        private readonly IPost _allPosts;
        private readonly IHashtag _allHashtags;
        public PostsHashtagsDateController(IPost posts,  IHashtag hashtags)
        {
            _allPosts = posts;
            _allHashtags = hashtags;
        }
        [HttpPut]
        public JsonResult Get(PostHashtagsDateDTO postHashtagsDateDTO)
        {
            return new JsonResult(_allPosts.GetAll(_allHashtags.GetListOfHashtagsIds(postHashtagsDateDTO.Hashtags),postHashtagsDateDTO.Date).Take(postHashtagsDateDTO.Number));
        }
    }
}