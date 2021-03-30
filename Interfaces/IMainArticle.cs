using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IMainArticle
    {
        bool IsTableHasId(int id);
        void Add(MainArticle article);
        IEnumerable<MainArticle> GetAll();
        MainArticle Get(int id);
        void Update(MainArticle article);
        void Delete(int id);
    }
}