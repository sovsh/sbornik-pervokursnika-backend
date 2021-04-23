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
        public PostsHashtagsController(IPost posts,  IHashtag hashtags)
        {
            _allPosts = posts;
            _allHashtags = hashtags;
        }
        [HttpPut]
        public JsonResult Get(PostHashtagsDTO postHashtagsDTO)
        {
            List<int> hashtagsId = new List<int>();
            foreach (var hashtag in postHashtagsDTO.Hashtags)
            {
                int id = _allHashtags.Find(hashtag);
                if (id != -1)
                    hashtagsId.Add(id);
            }
            return new JsonResult(_allPosts.GetAll(hashtagsId).Take(postHashtagsDTO.Number));
        }
        /*[HttpPut("{number}, {date}")]
        public JsonResult Get(int number, DateTime date, List<string>hashtags)
        {
            List<int> hashtagsId = new List<int>();
            foreach (var hashtag in hashtags)
            {
                int id = _allHashtags.Find(hashtag);
                if (id != -1)
                    hashtagsId.Add(id);
            }
            return new JsonResult(_allPosts.GetAll(hashtagsId, date).Take(number));
        }*/
    }
}