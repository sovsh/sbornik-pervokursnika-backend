﻿using Microsoft.AspNetCore.Mvc;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacultiesInfoController : ControllerBase
    {
        private readonly IFaculty _all;

        public FacultiesInfoController(IFaculty faculties)
        {
            _all = faculties;
        }

        [HttpPut]
        public JsonResult Get(StringDTO name)
        {
            return new JsonResult(_all.GetDTO(name.Name));
        }
    }
}