﻿using System.Collections.Generic;
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
            List<ContactDTO> contacts =
                new ContactRepository(_context).CreateContactDTOs(_context.Contacts
                    .Where(c => c.FacultyId == faculty.Id).ToList());

            /*contacts = contacts.Where(c => new ContactRepository(_context).GetType(c.Type) == 0)
                .OrderBy(c => c.PriorityNumber)
                .Union(contacts.Where(c => new ContactRepository(_context).GetType(c.Type) == 1)
                    .OrderBy(c => c.PriorityNumber)).Union(contacts
                    .Where(c => new ContactRepository(_context).GetType(c.Type) == 2).OrderBy(c => c.PriorityNumber)).ToList();*/
            contacts = contacts.Where(c => new ContactRepository(_context).GetType(c.Type) == 0 && c.PriorityNumber > 0)
                .OrderBy(c => c.PriorityNumber).Union(contacts.Where(c =>
                    new ContactRepository(_context).GetType(c.Type) == 0 && c.PriorityNumber == -1))
                .Union(contacts.Where(c => new ContactRepository(_context).GetType(c.Type) == 1 && c.PriorityNumber > 0)
                    .OrderBy(c => c.PriorityNumber)).Union(contacts.Where(c =>
                    new ContactRepository(_context).GetType(c.Type) == 1 && c.PriorityNumber == -1)).Union(contacts
                    .Where(c => new ContactRepository(_context).GetType(c.Type) == 2 && c.PriorityNumber > 0)
                    .OrderBy(c => c.PriorityNumber)).Union(contacts.Where(c =>
                    new ContactRepository(_context).GetType(c.Type) == 2 && c.PriorityNumber == -1)).ToList();
                       

            string type = GetType((int) faculty.Type);
            string deanery = _context.DeaneryTypesRelation.First(e => e.Type == faculty.Type).DeaneryName;
            string specialHashtag = new HashtagRepository(_context).Get(faculty.SpecialHashtagId).Name;

            return new FacultyDTO
            {
                Id = faculty.Id, Name = faculty.Name, Abbreviation = faculty.Abbreviation, Type = type,
                Deanery = deanery, Info = faculty.Info, Picture = faculty.Picture, PhoneNumber = faculty.PhoneNumber,
                WebsiteLink = faculty.WebsiteLink, VkLink = faculty.VkLink, InstagramLink = faculty.InstagramLink,
                FacebookLink = faculty.FacebookLink, SicLink = faculty.SicLink, Email = faculty.Email,
                SpecialHashtag = specialHashtag,
                Contacts = contacts
            };

        }

        public Faculty CreateFaculty(FacultyPostDTO facultyDTO)
        {
            var hashtag = new Hashtag {Name = facultyDTO.Abbreviation, IsSpecial = true};
            new HashtagRepository(_context).Add(hashtag);
            return new Faculty
            {
                Name = facultyDTO.Name, Abbreviation = facultyDTO.Abbreviation, Type = facultyDTO.Type,
                Info = facultyDTO.Info, Picture = facultyDTO.Picture, PhoneNumber = facultyDTO.PhoneNumber,
                WebsiteLink = facultyDTO.WebsiteLink, VkLink = facultyDTO.VkLink,
                InstagramLink = facultyDTO.InstagramLink, FacebookLink = facultyDTO.FacebookLink,
                SicLink = facultyDTO.SicLink, Email = facultyDTO.Email, SpecialHashtagId = hashtag.Id
            };
        }

        public FacultySomeInfoDTO CreateFacultySomeInfoDTO(Faculty faculty)
        {
            return new FacultySomeInfoDTO
            {
                Id = faculty.Id,
                Name = faculty.Name,
                Abbreviation = faculty.Abbreviation
            };
        }

        public IEnumerable<FacultySomeInfoDTO> CreateFacultySomeInfoDTOs(List<Faculty> faculties)
        {
            return faculties.Select(CreateFacultySomeInfoDTO).ToList();
        }

        public void Add(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            _context.SaveChanges();
        }

        public Faculty Add(FacultyPostDTO facultyDTO)
        {
            var faculty = CreateFaculty(facultyDTO);
            Add(faculty);
            return faculty;
        }

        public IEnumerable<Faculty> GetAll() => _context.Faculties.ToList().OrderBy(e => e.Name);

        public IEnumerable<FacultySomeInfoDTO> GetAllSomeInfoDTOs()
        {
            return CreateFacultySomeInfoDTOs(GetAll().ToList());
        }

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

        public void Update(FacultyPostDTO faculty)
        {
            var dbFaculty = _context.Faculties.First(e => e.Id == faculty.Id);
            dbFaculty.Name = faculty.Name;
            dbFaculty.Abbreviation = faculty.Abbreviation;
            dbFaculty.Type = faculty.Type;
            dbFaculty.Info = faculty.Info;
            dbFaculty.Picture = faculty.Picture;
            dbFaculty.PhoneNumber = faculty.PhoneNumber;
            dbFaculty.WebsiteLink = faculty.WebsiteLink;
            dbFaculty.VkLink = faculty.VkLink;
            dbFaculty.InstagramLink = faculty.InstagramLink;
            dbFaculty.FacebookLink = faculty.FacebookLink;
            dbFaculty.SicLink = faculty.SicLink;
            dbFaculty.Email = faculty.Email;
            new HashtagRepository(_context).Update(new Hashtag
                {Id = dbFaculty.SpecialHashtagId, Name = faculty.Abbreviation, IsSpecial = true});
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