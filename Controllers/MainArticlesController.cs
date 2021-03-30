using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainArticlesController : ControllerBase
    {
        private readonly IMainArticle _all;
        public MainArticlesController(IMainArticle articles)
        {
            _all = articles;
        }
        [HttpPost]
        public IActionResult Post(MainArticle article)
        {
            if (article == null) 
                return BadRequest();
            if (_all.IsTableHasId(article.Id)) 
                return BadRequest();
            _all.Add(article);
            return Ok(article);
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
        public IActionResult Put(MainArticle article)
        {
            if (article == null) 
                return BadRequest();
            if (!_all.IsTableHasId(article.Id)) 
                return BadRequest();
            _all.Update(article);
            return Ok(article);
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