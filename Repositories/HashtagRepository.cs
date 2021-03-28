using System.Collections.Generic;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class HashtagRepository:IHashtag
    {
        public IEnumerable<Hashtag> GetAllHashtags { get; }
        public Hashtag GetObjectHashtag(int hashtagId)
        {
            throw new System.NotImplementedException();
        }
    }
}