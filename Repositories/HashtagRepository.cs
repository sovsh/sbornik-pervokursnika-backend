using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class HashtagRepository:IHashtag
    {
        private readonly ApplicationContext _context;
        public HashtagRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<Hashtag> GetAll() => _context.Hashtags.ToList();
        public Hashtag Get(int id) => _context.Hashtags.FirstOrDefault(h => h.Id == id);
    }
}