using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Контакт сотрудника факультета/студсовета
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<string> PhoneNumbers { get; set; } = new List<string>();
        public string Photo { get; set; }
    }
}