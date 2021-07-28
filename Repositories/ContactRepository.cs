using System.Collections.Generic;
using System.Data.Common;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;
using System.Linq;
using SbornikBackend.DTOs;

namespace SbornikBackend.Repositories
{
    public class ContactRepository : IContact
    {
        private readonly ApplicationContext _context;

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Contacts.Any(f => f.Id == id);

        public List<string> GetAllTypes()
        {
            var result = new List<string>();
            result.Add("Дирекция");
            result.Add("Студсовет");
            result.Add("Другое");
            return result;
        }

        public string GetType(int type)
        {
            return type switch
            {
                0 => "Дирекция",
                1 => "Студсовет",
                2 => "Другое",
                _ => "Error"
            };
        }

        public ContactDTO CreateContactDTO(Contact contact)
        {
            var links = new List<string>();
            foreach (var link in contact.Links)
                links.Add(link);
            var type = GetType((int) contact.Type);
            return new ContactDTO
            {
                Id = contact.Id, Type = type, Name = contact.Name, Position = contact.Position, Links = links,
                PhoneNumber = contact.PhoneNumber,
                Photo = contact.Photo
            };
        }

        public List<ContactDTO> CreateContactDTOs(List<Contact> contacts)
        {
            var result = new List<ContactDTO>();
            foreach (var contact in contacts)
                result.Add(CreateContactDTO(contact));
            return result;
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public IEnumerable<Contact> GetAll() => _context.Contacts.OrderBy(e => e.Id).ToList();

        public Contact Get(int id) => _context.Contacts.First(c => c.Id == id);

        public void Update(Contact contact)
        {
            var dbContact = _context.Contacts.First(e => e.Id == contact.Id);
            dbContact.FacultyId = contact.FacultyId;
            dbContact.Name = contact.Name;
            dbContact.Position = contact.Position;
            dbContact.PhoneNumber = contact.PhoneNumber;
            dbContact.Links.Clear();
            foreach (var link in contact.Links)
                dbContact.Links.Add(link);
            dbContact.Photo = contact.Photo;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var contact = Get(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }
}