using Microsoft.AspNetCore.Mvc;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuideSectionsController : ControllerBase
    {
        private readonly IGuideSection _allGuideSections;

        public GuideSectionsController(IGuideSection guideSections)
        {
            _allGuideSections = guideSections;
        }

        [HttpPost]
        public IActionResult Post(GuideSection guideSection)
        {
            if (guideSection == null)
                return BadRequest();
            if (_allGuideSections.IsTableHasId(guideSection.Id))
                return BadRequest();
            _allGuideSections.Add(guideSection);
            return Ok(guideSection);
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_allGuideSections.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_allGuideSections.Get(id));
        }

        [HttpPut]
        public IActionResult Put(GuideSection guideSection)
        {
            if (guideSection == null)
                return BadRequest();
            if (!_allGuideSections.IsTableHasId(guideSection.Id))
                return BadRequest();
            _allGuideSections.Update(guideSection);
            return Ok(guideSection);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_allGuideSections.IsTableHasId(id))
                return BadRequest();
            _allGuideSections.Delete(id);
            return Ok(id);
        }
    }
}