﻿using System.Collections.Generic;
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

        public FacultyController(IFaculty faculties)
        {
            _allFaculties = faculties;
        }
        [HttpGet]
        public JsonResult GetAllFacultiesList()
        {
            return new JsonResult(_allFaculties.GetAll());
        }
    }
}