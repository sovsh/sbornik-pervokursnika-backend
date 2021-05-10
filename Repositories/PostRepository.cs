using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class PostsComparer : IEqualityComparer<PostDTO>
    {
        public bool Equals(PostDTO? x, PostDTO? y)
        {
            if (x == null || y == null)
                return false;
            return x.Id == y.Id;
        }

        public int GetHashCode(PostDTO obj)
        {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Id);
        }
    }
    public class PostRepository : IPost
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Posts.Any(e => e.Id == id);

        public PostDTO CreatePostDTO(Post post)
        {
            var contents = new List<ContentDTO>();
            var hashtags = new List<string>();
            foreach (var id in post.ContentsId)
            {
                string uri = _context.Contents.First(e => e.Id == id).Path;
                var content = new ContentDTO {Id = id, Uri = uri};
                contents.Add(content);
            }

            foreach (var id in post.HashtagsId)
            {
                string name = _context.Hashtags.First(e => e.Id == id).Name;
                hashtags.Add(name);
            }

            return new PostDTO
            {
                Id = post.Id, Date = post.Date, Author = post.Author, Text = post.Text, Contents = contents,
                Hashtags = hashtags
            };
        }

        public List<PostDTO> CreatePostDTOs(List<Post> posts)
        {
            var result = new List<PostDTO>();
            foreach (var post in posts)
                result.Add(CreatePostDTO(post));
            return result;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();

            foreach (var hashtag in post.HashtagsId)
            {
                _context.HashtagsToPostsRelation.Add(new HashtagToPostRelation {HashtagId = hashtag, PostId = post.Id});
            }
            _context.SaveChanges();
        }

        public IEnumerable<PostDTO> GetAll()
        {
            var posts = _context.Posts.ToList();
            return CreatePostDTOs(posts);
        }
        public IEnumerable<PostDTO> GetAll(List<int> hashtags)
        {
            var res = new HashSet<PostDTO>(new PostsComparer());
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.OrderByDescending(e=>e.Date).Where(e => e.HashtagsId.Contains(hashtag)).ToList();
                var postDTOs = CreatePostDTOs(posts);
                foreach (var postDTO in postDTOs)
                    res.Add(postDTO);
            }
            return res.OrderByDescending(e=>e.Date).ToList();
        }

        public IEnumerable<PostDTO> GetAll(List<int> hashtags, DateTime date)
        {
            var res = new HashSet<PostDTO>();
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.OrderByDescending(e=>e.Date).Where(e => e.HashtagsId.Contains(hashtag)).Where(e => e.Date < date).ToList();
                var postDTOs = CreatePostDTOs(posts);
                foreach (var postDTO in postDTOs)
                    res.Add(postDTO);
            }
            return res.OrderByDescending(e=>e.Date).ToList();
        }

        public IEnumerable<PostDTO> GetAll(string searchString)
        {
            string pattern = "%" + searchString + "%";
            return CreatePostDTOs(_context.Posts.Where(p =>
                EF.Functions.Like(p.Author.ToLower(), $"%{searchString.ToLower()}%") || EF.Functions.Like(p.Text.ToLower(), searchString.ToLower())).ToList());
        }

        public PostDTO Get(int id)
        {
            var post = _context.Posts.First(e => e.Id == id);
            return CreatePostDTO(post);
        }

        public PostDTO GetLast(List<int> hashtagsId)
        {
            return GetAll(hashtagsId).First();
        }

        public void Update(Post post)
        {
            var elems = _context.HashtagsToPostsRelation.Where(e => e.PostId == post.Id);
            foreach (var elem in elems)
                _context.HashtagsToPostsRelation.Remove(elem);
            foreach (var hashtag in post.HashtagsId)
                _context.HashtagsToPostsRelation.Add(new HashtagToPostRelation {HashtagId = hashtag, PostId = post.Id});
            var dbPost = _context.Posts.First(e => e.Id == post.Id);
            dbPost.Date = post.Date;
            dbPost.Author = post.Author;
            dbPost.Text = post.Text;
            dbPost.ContentsId.Clear();
            foreach (var contentId in post.ContentsId)
                dbPost.ContentsId.Add(contentId);
            dbPost.HashtagsId.Clear();
            foreach (var hashtagId in post.HashtagsId)
                dbPost.HashtagsId.Add(hashtagId);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = _context.Posts.First(e => e.Id == id);
            var elems = _context.HashtagsToPostsRelation.Where(e => e.PostId == post.Id);
            foreach (var elem in elems)
            {
                _context.HashtagsToPostsRelation.Remove(elem);
            }
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
    }
}