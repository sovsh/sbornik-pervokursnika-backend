using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;
using SbornikBackend.Services;

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

        [Authorize(Roles = "Bot")]
        [HttpPost]
        public IActionResult Post(PostDTO_int postDTO)
        {
            if (postDTO == null)
                return BadRequest();
            var post = _allPosts.CreatePost(postDTO);
            _allPosts.Add(post);
            /*if (postDTO.IsShared == false && postDTO.Hashtags.Count > 0)
                PostNotificationService.SendNotifications(_allPosts.Get(post.Id));*/
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

        [Authorize(Roles = "Bot")]
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

        [Authorize(Roles = "Bot")]
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