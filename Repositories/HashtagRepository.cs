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

        public bool IsTableHasHashtag(int id, string name)
        {
            if (IsTableHasId(id))
                return true;
            return _context.Hashtags.Any(h => h.Name.Equals(name));
        }

        public void Add(Hashtag hashtag)
        {
            _context.Hashtags.Add(hashtag);
            _context.SaveChanges();
        }

        public IEnumerable<Hashtag> GetAll() => _context.Hashtags.Where(e => !e.IsSpecial).OrderBy(e => e.Id).ToList();
        public IEnumerable<Hashtag> GetAllSpecial()=>_context.Hashtags.Where(e => e.IsSpecial).OrderBy(e => e.Id).ToList();

        public Hashtag Get(int id) => _context.Hashtags.First(h => h.Id == id);
        
        public List<int> GetListOfHashtagsIds(List<string> hashtags)
        {
            List<int> hashtagsIds = new List<int>();
            foreach (var hashtag in hashtags)
            {
                int id = Find(hashtag);
                if (id != -1)
                    hashtagsIds.Add(id);
            }

            return hashtagsIds;
        }

        public void Update(Hashtag hashtag)
        {
            var dbHashtag = _context.Hashtags.First(e => e.Id == hashtag.Id);
            dbHashtag.Name = hashtag.Name;
            dbHashtag.IsSpecial = hashtag.IsSpecial;
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