using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class ArticleRepository : IArticle
    {
        private readonly ApplicationContext _context;

        public ArticleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Guide.Any(e => e.Id == id);

        public void Add(Article article)
        {
            _context.Guide.Add(article);
            _context.SaveChanges();
        }

        //public IEnumerable<Article> GetAll() => _context.Articles.Where(e => (int) e.Type == 0).ToList();
        public IEnumerable<Article> GetAll() => _context.Set<Article>().Where(e => (int) e.Type == 0).ToList();


        public Article Get(int id) => _context.Articles.First(e => e.Id == id);

        public void Update(Article article)
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