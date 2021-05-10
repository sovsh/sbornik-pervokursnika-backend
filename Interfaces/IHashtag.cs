using System;
using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IHashtag
    {
        bool IsTableHasId(int id);
        bool IsTableHasHashtag(int id, string name);
        void Add(Hashtag hashtag);
        IEnumerable<Hashtag> GetAll();
        Hashtag Get(int id);
        List<int> GetListOfHashtagsIds(List<string> hashtags);
        void Update(Hashtag hashtag);
        void Delete(int id);
        public int Find(string name);
    }
}