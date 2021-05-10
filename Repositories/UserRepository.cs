using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Users.Any(e => e.Id == id);

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll() => _context.Users.OrderBy(e=>e.Id).ToList();

        public User Get(int id) => _context.Users.First(e => e.Id == id);

        public void Update(User user)
        {
            var dbUser = _context.Users.First(e => e.Id == user.Id);
            dbUser.Login = user.Login;
            dbUser.Password = user.Password;
            dbUser.UserFacultyId = user.UserFacultyId;
            dbUser.HashtagsId.Clear();
            foreach (var hashtagId in user.HashtagsId)
                dbUser.HashtagsId.Add(hashtagId);
            dbUser.FavoritePostsId.Clear();
            foreach (var favoritePostId in user.FavoritePostsId)
                dbUser.FavoritePostsId.Add(favoritePostId);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.First(e => e.Id == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}