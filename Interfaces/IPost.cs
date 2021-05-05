using System;
using System.Collections;
using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IPost
    {
        bool IsTableHasId(int id);
        void Add(Post post);
        IEnumerable<PostDTO> GetAll();
        IEnumerable<PostDTO> GetAll(List<int> hashtags);
        IEnumerable<PostDTO> GetAll(List<int> hashtags, DateTime date);
        PostDTO Get(int id);
        PostDTO GetLast(List<int> hashtagsId);
        void Update(Post post);
        void Delete(int id);
    }
}