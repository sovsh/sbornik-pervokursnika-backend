using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class HashtagRepository : IHashtag
    {
        private readonly ApplicationContext _context;

        public HashtagRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Hashtags.Any(h => h.Id == id);

        public void Add(Hashtag hashtag)
        {
            _context.Hashtags.Add(hashtag);
            _context.SaveChanges();
        }

        public IEnumerable<Hashtag> GetAll() => _context.Hashtags.ToList();

        public Hashtag Get(int id) => _context.Hashtags.First(h => h.Id == id);
        
        public void Update(Hashtag hashtag)
        {
            _context.Hashtags.Update(hashtag);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hashtag = _context.Hashtags.First(h => h.Id == id);
            _context.Hashtags.Remove(hashtag);
            _context.SaveChanges();
        }

        public int Find(string name)
        {
            var found = _context.Hashtags.FirstOrDefault(e => e.Name == name);
            if (found == null)
                return -1;
            return found.Id;
        }
    }
}