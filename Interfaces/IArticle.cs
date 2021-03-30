using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IArticle
    {
        bool IsTableHasId(int id);
        void Add(Article article);
        IEnumerable<Article> GetAll();
        Article Get(int id);
        void Update(Article article);
        void Delete(int id);
    }
}