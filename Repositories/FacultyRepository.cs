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
        private readonly ApplicationContext _context;
        public FacultyRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Faculty> GetAll() => _context.Faculties.ToList();
    }
}
