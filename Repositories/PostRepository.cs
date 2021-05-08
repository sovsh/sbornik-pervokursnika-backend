using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class PostRepository : IPost
    {
        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        internal class PostsComparer : IComparer<Post>
        {
            public int Compare(Post x, Post y)
            {
                return y.Date.CompareTo(x.Date);
            }
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
            var res = new List<PostDTO>();
            foreach (var post in posts)
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

                var postDTO = new PostDTO
                {
                    Id = post.Id, Date = post.Date, Author = post.Author, Text = post.Text, Contents = contents,
                    Hashtags = hashtags
                };
                res.Add(postDTO);
            }
            return res;
        }
        public IEnumerable<PostDTO> GetAll(List<int> hashtags)
        {
            var res = new HashSet<PostDTO>();
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.OrderByDescending(e=>e.Date).Where(e => e.HashtagsId.Contains(hashtag)).ToList();
                foreach (var post in posts)
                {
                    var contents = new List<ContentDTO>();
                    var _hashtags = new List<string>();
                    foreach (var id in post.ContentsId)
                    {
                        string uri = _context.Contents.First(e => e.Id == id).Path;
                        var content = new ContentDTO {Id = id, Uri = uri};
                        contents.Add(content);
                    }
                
                    foreach (var id in post.HashtagsId)
                    {
                        string name = _context.Hashtags.First(e => e.Id == id).Name;
                        _hashtags.Add(name);
                    }

                    var postDTO = new PostDTO
                    {
                        Id = post.Id, Date = post.Date, Author = post.Author, Text = post.Text, Contents = contents,
                        Hashtags = _hashtags
                    };
                    res.Add(postDTO);
                }
            }
            return res.ToList();
        }

        public IEnumerable<PostDTO> GetAll(List<int> hashtags, DateTime date)
        {
            var res = new HashSet<PostDTO>();
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.OrderByDescending(e=>e.Date).Where(e => e.HashtagsId.Contains(hashtag)).Where(e => e.Date < date).ToList();
                foreach (var post in posts)
                {
                    var contents = new List<ContentDTO>();
                    var _hashtags = new List<string>();
                    foreach (var id in post.ContentsId)
                    {
                        string uri = _context.Contents.First(e => e.Id == id).Path;
                        var content = new ContentDTO {Id = id, Uri = uri};
                        contents.Add(content);
                    }
                
                    foreach (var id in post.HashtagsId)
                    {
                        string name = _context.Hashtags.First(e => e.Id == id).Name;
                        _hashtags.Add(name);
                    }

                    var postDTO = new PostDTO
                    {
                        Id = post.Id, Date = post.Date, Author = post.Author, Text = post.Text, Contents = contents,
                        Hashtags = _hashtags
                    };
                    res.Add(postDTO);
                }
            }
            return res.ToList();
        }

        public IEnumerable<PostDTO> GetAll(string searchString)
        {
            /*string ss = searchString.ToLower();
            var posts = _context.Posts.Where(p => p.Text.ToLower().Contains(ss) || p.Author.ToLower().Contains(ss))
                .ToList();
            return CreatePostDTOs(posts);*/
            string pattern = "%" + searchString + "%";
            return CreatePostDTOs(_context.Posts.Where(p =>
                EF.Functions.Like(p.Author.ToLower(), $"%{searchString.ToLower()}%") || EF.Functions.Like(p.Text.ToLower(), searchString.ToLower())).ToList());
        }

        public PostDTO Get(int id)
        {
            var post = _context.Posts.First(e => e.Id == id);
            var contents = new List<ContentDTO>();
            var hashtags = new List<string>();
            foreach (var _id in post.ContentsId)
            {
                string uri = _context.Contents.First(e => e.Id == _id).Path;
                var content = new ContentDTO {Id = _id, Uri = uri};
                contents.Add(content);
            }
                
            foreach (var _id in post.HashtagsId)
            {
                string name = _context.Hashtags.First(e => e.Id == _id).Name;
                hashtags.Add(name);
            }

            var postDTO = new PostDTO
            {
                Id = post.Id, Date = post.Date, Author = post.Author, Text = post.Text, Contents = contents,
                Hashtags = hashtags
            };
            return postDTO;
        }

        public PostDTO GetLast(List<int> hashtagsId)
        {
            return GetAll(hashtagsId).First();
        }

        public void Update(Post post)
        {
            var elems = _context.HashtagsToPostsRelation.Where(e => e.PostId == post.Id);
            foreach (var elem in elems)
            {
                _context.HashtagsToPostsRelation.Remove(elem);
            }
            _context.Posts.Update(post);
            foreach (var hashtag in post.HashtagsId)
            {
                _context.HashtagsToPostsRelation.Add(new HashtagToPostRelation {HashtagId = hashtag, PostId = post.Id});
            }
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