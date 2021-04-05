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
    public class PostsHashtagsController
    {
        private readonly IPost _allPosts;
        private readonly IHashtag _allHashtags;
        public PostsHashtagsController(IPost posts,  IHashtag hashtags)
        {
            _allPosts = posts;
            _allHashtags = hashtags;
        }
        /*[HttpGet("{postDTO}")]
        public JsonResult Get(PostHashtagsDTO postDTO)
        {
            int n = postDTO.Number;
            List<int> hashtags = new List<int>();
            foreach (var hashtag in postDTO.Hashtags)
            {
                int id = _allHashtags.Find(hashtag);
                if (id != -1)
                    hashtags.Add(id);
            }
            return new JsonResult(_allPosts.GetAll(hashtags).Take(postDTO.Number));
        }
        [HttpGet("{postDateDTO}")]
        public JsonResult Get(PostHashtagDateDTO postDateDTO)
        {
            int n = postDateDTO.Number;
            List<int> hashtags = new List<int>();
            foreach (var hashtag in postDateDTO.Hashtags)
            {
                int id = _allHashtags.Find(hashtag);
                if (id != -1)
                    hashtags.Add(id);
            }
            return new JsonResult(_allPosts.GetAll(hashtags, postDateDTO.Date).Take(postDateDTO.Number));
        }*/
        [HttpPut("{number}")]
        public JsonResult Get(int number, List<string>hashtags)
        {
            List<int> hashtagsId = new List<int>();
            foreach (var hashtag in hashtags)
            {
                int id = _allHashtags.Find(hashtag);
                if (id != -1)
                    hashtagsId.Add(id);
            }
            return new JsonResult(_allPosts.GetAll(hashtagsId).Take(number));
        }
        [HttpPut("{number}, {date}")]
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
        }
    }
}