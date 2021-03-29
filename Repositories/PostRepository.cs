using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class PostRepository:IPost
    {
        private readonly ApplicationContext _context;
        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAll() => _context.Posts.ToList();
    }
}