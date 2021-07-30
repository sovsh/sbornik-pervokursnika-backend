using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IContact
    {
        bool IsTableHasId(int id);
        string GetDeaneryType(int facultyId);
        List<string> GetAllTypes(int facultyId);
        string GetType(Contact contact);
        int GetType(string type);
        ContactDTO CreateContactDTO(Contact contact);
        List<ContactDTO>CreateContactDTOs(List<Contact> contacts);
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        void Update(ContactDTO contact);
        void Delete(int id);
    }
}