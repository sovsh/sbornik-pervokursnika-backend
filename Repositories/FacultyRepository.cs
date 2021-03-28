using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class FacultyRepository : IFaculty
    {
        private readonly ApplicationContext Context;
        private IEnumerable<Faculty> _getAllFaculties;

        public FacultyRepository(ApplicationContext context)
        {
            Context = context;
        }

        public IEnumerable<Faculty> GetAllFaculties => Context.Set<Faculty>().ToList();
        /*{
            return Context.Set<Faculty>().ToList();
        }*/
    }
}
