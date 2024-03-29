﻿using System.Collections.Generic;
using System.Dynamic;

namespace SbornikBackend.DTOs
{
    public class FacultyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Type { get; set; }
        public string Deanery { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteLink { get; set; }
        public string VkLink { get; set; }
        public string InstagramLink { get; set; }
        public string FacebookLink { get; set; }
        public string SicLink { get; set; }
        public string Email { get; set; }
        public string SpecialHashtag { get; set; }
        public List<ContactDTO> Contacts { get; set; } = new List<ContactDTO>();
    }
}