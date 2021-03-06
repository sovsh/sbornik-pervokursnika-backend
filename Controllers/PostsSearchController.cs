﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsSearchController : ControllerBase
    {
        private readonly IPost _allPosts;

        public PostsSearchController(IPost posts)
        {
            _allPosts = posts;
        }

        [HttpPut]
        public JsonResult Search(PostsSearchDTO searchDTO)
        {
            if (searchDTO.SearchString == null)
                return new JsonResult("Search string is empty");
            return new JsonResult(_allPosts.GetAll(searchDTO.SearchString).Take(searchDTO.Number));
        }
    }
}