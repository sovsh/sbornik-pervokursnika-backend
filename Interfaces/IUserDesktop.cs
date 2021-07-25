using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IUserDesktop
    {
        bool IsTableHasLogin(string login);
        void Add(UserDesktop user);
        IEnumerable<UserDesktop> GetAll();
        UserDesktop Get(string login);
        void Update(UserDesktop user);
        void Delete(string login);
    }
}