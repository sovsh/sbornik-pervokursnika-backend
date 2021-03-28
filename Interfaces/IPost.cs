using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IPost
    {
        IEnumerable<Post>GetAllPosts { get; }
    }
}