using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
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

        public void Add(UserDesktop user)
        {
            _context.UsersDesktop.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserDesktop> GetAll() => _context.UsersDesktop.OrderBy(e => e.Login).ToList();

        public UserDesktop Get(string login) => _context.UsersDesktop.First(e => e.Login.Equals(login));

        public void Update(UserDesktop user)
        {
            var dbUser = _context.UsersDesktop.First(e => e.Login.Equals(user.Login));
            dbUser.Password = user.Password;
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