using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
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

        public IEnumerable<Faculty> GetAll() => _context.Faculties.OrderBy(e=>e.Id).ToList();

        public Faculty Get(int id) => _context.Faculties.First(f => f.Id == id);

        public FacultyDTO GetDTO(string name)
        {
            var faculty = _context.Faculties.First(f => f.Name.Equals(name));
            List<ContactDTO> contacts = new List<ContactDTO>();
            foreach (var contact in _context.Contacts.Where(c => c.FacultyId == faculty.Id))
            {
                var links = new List<string>();
                foreach (var link in contact.Links)
                    links.Add(link);
                contacts.Add(new ContactDTO
                {
                    Name = contact.Name, Position = contact.Position, Links = links, PhoneNumber = contact.PhoneNumber,
                    Photo = contact.Photo
                });

            }

            return new FacultyDTO {Name = name, Info = faculty.Info, Picture = faculty.Picture, Contacts = contacts};
        }

        public void Update(Faculty faculty)
        {
            var dbFaculty = _context.Faculties.First(e => e.Id == faculty.Id);
            dbFaculty.Name = faculty.Name;
            dbFaculty.Info = faculty.Info;
            dbFaculty.Picture = faculty.Picture;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var faculty = Get(id);
            _context.Faculties.Remove(faculty);
            _context.SaveChanges();
        }
    }
}
