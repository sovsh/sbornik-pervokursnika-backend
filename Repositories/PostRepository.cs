using System.Collections.Generic;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class PostRepository:IPost
    {
        public IEnumerable<Post> GetAllPosts { get; }
    }
}