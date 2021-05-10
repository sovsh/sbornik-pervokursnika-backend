using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class ContentRepository : IContent
    {
        private readonly ApplicationContext _context;

        public ContentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Contents.Any(e => e.Id == id);

        public void Add(Content content)
        {
            _context.Contents.Add(content);
            _context.SaveChanges();
        }

        public IEnumerable<Content> GetAll() => _context.Contents.OrderBy(e=>e.Id).ToList();

        public Content Get(int id) => _context.Contents.First(e => e.Id == id);

        public void Update(Content content)
        {
            var dbContent = _context.Contents.First(e => e.Id == content.Id);
            dbContent.Type = content.Type;
            dbContent.Path = content.Path;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var content = _context.Contents.First(e => e.Id == id);
            _context.Contents.Remove(content);
            _context.SaveChanges();
        }
    }
}