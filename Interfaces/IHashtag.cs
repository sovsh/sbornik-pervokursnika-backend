using System;
using System.Collections;
using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IHashtag
    {
        IEnumerable<Hashtag>GetAllHashtags { get; }

        Hashtag GetObjectHashtag(int hashtagId);
    }
}