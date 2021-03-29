using System;
using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IHashtag
    {
        IEnumerable<Hashtag> GetAll();

        Hashtag Get(int id);
    }
}