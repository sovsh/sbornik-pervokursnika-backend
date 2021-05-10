using System.Collections.Generic;
using System.Dynamic;

namespace SbornikBackend.DTOs
{
    public class FacultyDTO
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
        public List<ContactDTO> Contacts { get; set; } = new List<ContactDTO>();
    }
}