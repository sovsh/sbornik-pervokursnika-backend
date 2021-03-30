using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class MainArticleRepository : IMainArticle
    {
        private readonly ApplicationContext _context;

        public MainArticleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Guide.Any(e => e.Id == id);

        public void Add(MainArticle article)
        {
            _context.Guide.Add(article);
            _context.SaveChanges();
        }

        public IEnumerable<MainArticle> GetAll() => _context.MainArticles.Where(e => (int) e.Type == 1).ToList();

        public MainArticle Get(int id) => _context.MainArticles.First(e => e.Id == id);

        public void Update(MainArticle article)
        {
            _context.Guide.Update(article);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = _context.Guide.First(e => e.Id == id);
            _context.Guide.Remove(article);
            _context.SaveChanges();
        }
    }
}