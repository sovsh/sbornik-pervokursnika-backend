using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class UserDesktopRepository : IUserDesktop
    {
        private readonly ApplicationContext _context;

        public UserDesktopRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasLogin(string login) => _context.UsersDesktop.Any(e => e.Login.Equals(login));
        public bool ArePasswordsMatch(string login, string password) => _context.UsersDesktop.First(e=>e.Login.Equals(login)).Password.Equals(password);

        public UserDesktopGetDTO CreateUserDesktopGetDTO(UserDesktop user)
        {
            return new UserDesktopGetDTO
            {
                Login = user.Login,
                Role = user.Role
            };
        }

        public IEnumerable<UserDesktopGetDTO> CreateUserDesktopGetDTOs(List<UserDesktop> users) =>
            users.Select(CreateUserDesktopGetDTO).ToList();
        

        public void Add(UserDesktop user)
        {
            _context.UsersDesktop.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserDesktopGetDTO> GetAll() =>
            CreateUserDesktopGetDTOs(_context.UsersDesktop.ToList()).ToList();

        public UserDesktopGetDTO Get(string login) =>
            CreateUserDesktopGetDTO(_context.UsersDesktop.First(e => e.Login.Equals(login)));

        public void Update(UserDesktopPutDTO user)
        {
            var dbUser = _context.UsersDesktop.First(e => e.Login.Equals(user.Login));
            dbUser.Password = user.NewPassword;
            dbUser.Role = user.Role;
            _context.SaveChanges();
        }

        public void Delete(string login)
        {
            var user = _context.UsersDesktop.First(e => e.Login.Equals(login));
            _context.UsersDesktop.Remove(user);
            _context.SaveChanges();
        }
    }
}