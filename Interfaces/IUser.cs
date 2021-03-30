using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IUser
    {
        bool IsTableHasId(int id);
        void Add(User user);
        IEnumerable<User> GetAll();
        User Get(int id);
        void Update(User user);
        void Delete(int id);
    }
}