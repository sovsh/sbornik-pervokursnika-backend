using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SbornikBackend.Interfaces;
using SbornikBackend.Repositories;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFaculty _allFaculties;

        public FacultyController(IFaculty iFaculty)
        {
            _allFaculties = iFaculty;
        }
        [HttpGet]
        public JsonResult AllFacultiesList()
        {
            List<Faculty> f = new List<Faculty>
            {
                new Faculty
                {
                    Id = 1, Name = "истфак", Info = "Замечательный исторический факультет!",
                    HashtagsId = new List<int> {11, 22}
                },
                new Faculty
                {
                    Id = 12, Name = "не истфак", Info = "Замечательный не исторический факультет!",
                    HashtagsId = new List<int> {121, 222}
                }
            };
            return new JsonResult(f);
        }
    }
}