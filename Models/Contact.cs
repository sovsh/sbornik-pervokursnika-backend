using System.Collections.Generic;

namespace SbornikBackend
{
    public enum ContactType : int
    {
        Deanery,
        StudentCouncil,
        Other,
    }
    /// <summary>
    /// Контакт сотрудника факультета/студсовета
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }
        public int FacultyId { get; set; }
        public ContactType Type { get; set; }
        public int PriorityNumber { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Links { get; set; } = new List<string>();
        public string Photo { get; set; }
    }
}