using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IUserBot
    {
        bool IsTableHasId(int id);
        int GetRole(int id);
        void Add(UserBot user);
        IEnumerable<UserBot> GetAll();
        UserBot Get(int id);
        void Update(UserBot user);
        void Delete(int id);
    }
}