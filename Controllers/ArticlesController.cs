﻿using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController:ControllerBase
    {
        private readonly IGuideSection _allSections;

        public ArticlesController(IGuideSection sections)
        {
            _allSections = sections;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_allSections.Get(id));
        }
    }
}