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
        public string GetType(int type)
        {
            return type switch
            {
                0 => "Подразделение",
                1 => "Факультет",
                2 => "Академия",
                3 => "Институт",
                _ => "Ошибка"
            };
        }

        public FacultyDTO CreateFacultyDTO(Faculty faculty)
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            foreach (var contact in _context.Contacts.Where(c => c.FacultyId == faculty.Id))
            {
                var links = new List<string>();
                foreach (var link in contact.Links)
                    links.Add(link);
                contacts.Add(new ContactDTO
                {
                    Id = contact.Id, Name = contact.Name, Position = contact.Position, Links = links,
                    PhoneNumber = contact.PhoneNumber,
                    Photo = contact.Photo
                });

            }

            string type = GetType((int)faculty.Type);
            string deanery = _context.DeaneryTypesRelation.First(e => e.Type == faculty.Type).DeaneryName;
            
            return new FacultyDTO
            {
                Id = faculty.Id, Name = faculty.Name, Abbreviation = faculty.Abbreviation, Type = type, Deanery = deanery, Info = faculty.Info, Picture = faculty.Picture,
                Contacts = contacts
            };

        }

        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public IEnumerable<Faculty> GetAll() => _context.Faculties.OrderBy(e => e.Id).ToList();

        public Faculty Get(int id) => _context.Faculties.First(f => f.Id == id);

        public FacultyDTO GetDTO(int id)
        {
            var faculty = _context.Faculties.First(f => f.Id == id);
            return CreateFacultyDTO(faculty);
        }

        public FacultyDTO GetDTO(string name)
        {
            var faculty = _context.Faculties.First(f => f.Name.Equals(name));
            return CreateFacultyDTO(faculty);
        }

        public void Update(Faculty faculty)
        {
            var dbFaculty = _context.Faculties.First(e => e.Id == faculty.Id);
            dbFaculty.Name = faculty.Name;
            dbFaculty.Abbreviation = faculty.Abbreviation;
            dbFaculty.Type = faculty.Type;
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
