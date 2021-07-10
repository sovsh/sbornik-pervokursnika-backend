using System;
using System.Collections;
using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IPost
    {
        bool IsTableHasId(int id);
        PostDTO CreatePostDTO(Post post);
        Post CreatePost(PostDTO postDTO);
        List<PostDTO> CreatePostDTOs(List<int> ids);
        List<PostDTO> CreatePostDTOs(List<Post> posts);
        void Add(Post post);
        IEnumerable<PostDTO> GetAll();
        IEnumerable<PostDTO> GetAll(List<int> hashtags);
        IEnumerable<PostDTO> GetAll(List<int> hashtags, DateTime date);
        IEnumerable<PostDTO> GetAll(string searchString);
        IEnumerable<PostDTO> GetAll(string searchString, DateTime date);
        PostDTO Get(int id);
        PostDTO GetLast(List<int> hashtagsId);
        void Update(Post post);
        void Delete(int id);
        public int FindHashtag(string name);
    }
}