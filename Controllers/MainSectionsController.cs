using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainSectionsController : ControllerBase
    {
        private readonly IGuideSection _allSections;

        public MainSectionsController(IGuideSection sections)
        {
            _allSections = sections;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_allSections.GetAllMainSections());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var articles = _allSections.GetChildrenArticles(id);
            if (!articles.Any())
                return new JsonResult("Error");
            if (articles.Count() == 1)
                return new JsonResult(new ArticleDTO {Data = articles.First()});
            return new JsonResult(_allSections.GetSection(articles));
        }
    }
}