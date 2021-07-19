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
        private readonly IPost _allPosts;

        public PostsController(IPost posts)
        {
            _allPosts = posts;
        }

        [HttpPost]
        public IActionResult Post(PostDTO postDTO)
        {
            if (postDTO == null)
                return BadRequest();
            var post = _allPosts.CreatePost(postDTO);
            _allPosts.Add(post);
            return Ok(post);
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_allPosts.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_allPosts.Get(id));
        }

        [HttpPut]
        public IActionResult Put(Post post)
        {
            if (post == null)
                return BadRequest();
            if (!_allPosts.IsTableHasId(post.Id))
                return BadRequest();
            _allPosts.Update(post);
            return Ok(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_allPosts.IsTableHasId(id))
                return BadRequest();
            _allPosts.Delete(id);
            return Ok(id);
        }

    }
}