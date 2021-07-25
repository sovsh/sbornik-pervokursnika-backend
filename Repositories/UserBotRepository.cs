using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class UserBotRepository : IUserBot
    {
        private readonly ApplicationContext _context;

        public UserBotRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.UsersBot.Any(e => e.IdVk == id);
        public int GetRole(int id) => Get(id).Role;

        public void Add(UserBot user)
        {
            _context.UsersBot.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<UserBot> GetAll() => _context.UsersBot.OrderBy(e => e.IdVk).ToList();

        public UserBot Get(int id) => _context.UsersBot.First(e => e.IdVk == id);

        public void Update(UserBot user)
        {
            var dbUser = _context.UsersBot.First(e => e.IdVk == user.IdVk);
            dbUser.Role = user.Role;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.UsersBot.First(e => e.IdVk == id);
            _context.UsersBot.Remove(user);
            _context.SaveChanges();
        }
    }
}