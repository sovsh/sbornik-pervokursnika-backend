using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IContent
    {
        bool IsTableHasId(int id);
        void Add(Content content);
        IEnumerable<Content> GetAll();
        Content Get(int id);
        void Update(Content content);
        void Delete(int id);
    }
}