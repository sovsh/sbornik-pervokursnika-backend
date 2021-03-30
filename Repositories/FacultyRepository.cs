using System.Collections.Generic;
using System.Linq;
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

        public bool IsTableHasId(int id) => _context.Faculties.Any(f => f.Id == id);

        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public IEnumerable<Faculty> GetAll() => _context.Faculties.ToList();
        
        public Faculty Get(int id) => _context.Faculties.First(f => f.Id == id);

        public void Update(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var faculty = _context.Faculties.First(f => f.Id == id);
            _context.Faculties.Remove(faculty);
            _context.SaveChanges();
        }
    }
}
