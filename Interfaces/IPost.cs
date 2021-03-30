using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IPost
    {
        bool IsTableHasId(int id);
        void Add(Post post);
        IEnumerable<Post> GetAll();
        Post Get(int id);
        void Update(Post post);
        void Delete(int id);
    }
}