using System;
using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IHashtag
    {
        bool IsTableHasId(int id);
        void Add(Hashtag hashtag);
        IEnumerable<Hashtag> GetAll();
        Hashtag Get(int id);
        void Update(Hashtag hashtag);
        void Delete(int id);
        int Find(string name);
    }
}