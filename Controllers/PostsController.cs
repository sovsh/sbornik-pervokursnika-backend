using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPost _all;
        private readonly IContent _allContents;
        private readonly IHashtag _allHashtags;
        public PostsController(IPost posts, IContent contents, IHashtag hashtags)
        {
            _all = posts;
            _allContents = contents;
            _allHashtags = hashtags;
        }
        [HttpPost]
        public IActionResult Post(PostDTO postDTO)
        {
            if (postDTO == null) 
                return BadRequest();
            var postContents = postDTO.Contents;
            var listOfContents = new List<int>();
            foreach (var postContent in postContents)
            {
                var uri = postContent.Uri;
                var ext = uri.Split('/').Last().Split('.').Skip(1).First().Split('?').First();
                var filename = $@"Files\{System.Guid.NewGuid()}.{ext}";
                using (var client = new WebClient())
                {
                    client.DownloadFile(uri,filename);
                }
                var content = new Content {Path = filename, Type = postContent.Type};
                _allContents.Add(content);
                listOfContents.Add(content.Id);
            }
            var postHashtags = postDTO.Hashtags;
            var listOfHashtags = new List<int>();
            foreach (var postHashtag in postHashtags)
            {
                var found = _allHashtags.Find(postHashtag);
                if (found == -1)
                {
                    var hashtag = new Hashtag {Name = postHashtag};
                    _allHashtags.Add(hashtag);
                    listOfHashtags.Add(hashtag.Id);
                }
                else
                {
                    var hashtag = _allHashtags.Get(found);
                    listOfHashtags.Add(hashtag.Id);
                }

            }
            var post = new Post
            {
                Date = postDTO.Date, Author = postDTO.Author, Text = postDTO.Text, ContentsId = listOfContents,
                HashtagsId = listOfHashtags
            };
            _all.Add(post);
            return Ok(post);
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_all.GetAll());
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_all.Get(id));
        }

        [HttpPut]
        public IActionResult Put(Post post)
        {
            if (post == null) 
                return BadRequest();
            if (!_all.IsTableHasId(post.Id)) 
                return BadRequest();
            _all.Update(post);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_all.IsTableHasId(id)) 
                return BadRequest();
            _all.Delete(id);
            return Ok(id);
        }
    }
}