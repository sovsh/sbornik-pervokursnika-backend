using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IUserDesktop
    {
        bool IsTableHasLogin(string login);
        bool ArePasswordsMatch(string login, string password);
        UserDesktopGetDTO CreateUserDesktopGetDTO(UserDesktop user);
        IEnumerable<UserDesktopGetDTO> CreateUserDesktopGetDTOs(List<UserDesktop> users);
        void Add(UserDesktop user);
        IEnumerable<UserDesktopGetDTO> GetAll();
        UserDesktopGetDTO Get(string login);
        void Update(UserDesktopPutDTO user);
        void Delete(string login);
    }
}