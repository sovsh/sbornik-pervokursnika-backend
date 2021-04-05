using System;
using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
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

        public IEnumerable<Post> GetAll() => _context.Posts.ToList();
        public IEnumerable<Post> GetAll(List<int> hashtags)
        {
            //HashSet<Post> res = new HashSet<Post>();
            var res = new SortedSet<Post>(new PostsComparer());
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.Where(e => e.HashtagsId.Contains(hashtag));
                foreach (var post in posts)
                {
                    res.Add(post);
                }
            }
            return res.ToList();
        }

        public IEnumerable<Post> GetAll(List<int> hashtags, DateTime date)
        {
            var res = new SortedSet<Post>(new PostsComparer());
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.Where(e => e.HashtagsId.Contains(hashtag)).Where(e => e.Date < date);
                foreach (var post in posts)
                {
                    res.Add(post);
                }
            }
            return res.ToList();
        }

        public Post Get(int id) => _context.Posts.First(e => e.Id == id);

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