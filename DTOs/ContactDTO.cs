﻿using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string Type { get; set; }
        public int PriorityNumber { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Links { get; set; } = new List<string>();
        public string Photo { get; set; }
    }
}