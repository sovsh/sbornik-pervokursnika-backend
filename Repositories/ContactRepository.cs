using System;
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
        public string GetDeaneryType(int facultyId)
        {
            var faculty = new FacultyRepository(_context).Get(facultyId);
            return _context.DeaneryTypesRelation.First(e => e.Type == faculty.Type).DeaneryName;
        }

        public List<string> GetAllTypes(int facultyId)
        {
            var result = new List<string>();
            result.Add(GetDeaneryType(facultyId));
            result.Add("Студсовет");
            result.Add("Другое");
            return result;
        }

        public string GetType(Contact contact)
        {
            return (int)contact.Type switch
            {
                0 => GetDeaneryType(contact.FacultyId),
                1 => "Студсовет",
                2 => "Другое",
                _ => "Error"
            };
        }

        public int GetType(string type)
        {
            return type switch
            {
                "Руководство подразделения" => 0,
                "Деканат" => 0,
                "Дирекция" => 0,
                "Студсовет" => 1,
                "Другое" => 2,
                _ => throw new Exception("Wrong string contact type")
            };
        }

        public ContactDTO CreateContactDTO(Contact contact)
        {
            var links = new List<string>();
            foreach (var link in contact.Links)
                links.Add(link);
            var type = GetType(contact);
            return new ContactDTO
            {
                Id = contact.Id, FacultyId = contact.FacultyId, Type = type, PriorityNumber = contact.PriorityNumber, Name = contact.Name, Position = contact.Position, Links = links,
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

        public void Update(ContactDTO contact)
        {
            var dbContact = _context.Contacts.First(e => e.Id == contact.Id);
            dbContact.FacultyId = contact.FacultyId;
            dbContact.Type = (ContactType)GetType(contact.Type);
            dbContact.PriorityNumber = contact.PriorityNumber;
            dbContact.Name = contact.Name;
            dbContact.Position = contact.Position;
            dbContact.PhoneNumber = contact.PhoneNumber;
            dbContact.Links.Clear();
            foreach (var link in contact.Links)
                dbContact.Links.Add(link);
            dbContact.Photo = contact.Photo;
            _context.SaveChanges();
        }

        public void Swap(int id1, int id2)
        {
            var contact1 = CreateContactDTO(Get(id1));
            contact1.Id = id2;
            var contact2 = CreateContactDTO(Get(id2));
            contact2.Id = id1;
            Update(contact1);
            Update(contact2);
        }

        public void Delete(int id)
        {
            var contact = Get(id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }
}