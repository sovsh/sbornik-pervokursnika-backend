using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IContact
    {
        bool IsTableHasId(int id);
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        void Update(Contact contact);
        void Delete(int id);
    }
}