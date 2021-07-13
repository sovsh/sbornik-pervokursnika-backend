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
                Id = post.Id, Date = post.Date, Author = post.Author,AuthorPicture = post.AuthorPicture, Text = post.Text, Contents = contents,
                Hashtags = hashtags, IsShared = post.IsShared, Comment = post.Comment, OriginalPostId = post.OriginalPostId
            };
        }

        public Post CreatePost(PostDTO postDTO)
        {
            var postContents = postDTO.Contents;
            var listOfContents = new List<int>();
            foreach (var postContent in postContents)
            {
                var content = new Content {Path = postContent.Uri};
                _context.Contents.Add(content);
                _context.SaveChanges();
                listOfContents.Add(content.Id);
            }

            var postHashtags = postDTO.Hashtags;
            var listOfHashtags = new List<int>();
            foreach (var postHashtag in postHashtags)
            {
                var found = FindHashtag(postHashtag);
                if (found == -1)
                {
                    var hashtag = new Hashtag {Name = postHashtag};
                    _context.Hashtags.Add(hashtag);
                    _context.SaveChanges();
                    listOfHashtags.Add(hashtag.Id);
                }
                else
                {
                    var hashtag = _context.Hashtags.First(h => h.Id == found);
                    listOfHashtags.Add(hashtag.Id);
                }
            }

            return new Post
            {
                Date = postDTO.Date, Author = postDTO.Author, AuthorPicture = postDTO.AuthorPicture, Text = postDTO.Text, ContentsId = listOfContents,
                HashtagsId = listOfHashtags, IsShared = postDTO.IsShared, Comment = postDTO.Comment, OriginalPostId = postDTO.OriginalPostId
            };
        }

        public List<PostDTO> CreatePostDTOs(List<int> ids)
        {
            return ids.Select(Get).OrderByDescending(e => e.Date).ToList();
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
            var posts = _context.Posts.OrderByDescending(e => e.Date).ToList();
            return CreatePostDTOs(posts);
        }

        public IEnumerable<PostDTO> GetAll(List<int> hashtags)
        {
            var res = new HashSet<int>();
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.OrderByDescending(e => e.Date).Where(e => e.HashtagsId.Contains(hashtag))
                    .Select(e => e.Id
                    ).ToList();
                foreach (var id in posts)
                    res.Add(id);
            } 
            return CreatePostDTOs(res.ToList());
        }

        public IEnumerable<PostDTO> GetAll(DateTime date)
        {
            var res = new HashSet<int>();
            var posts = _context.Posts.OrderByDescending(e => e.Date)
                .Where(e => e.Date < date).Select(e => e.Id
                ).ToList();
            foreach (var id in posts)
                res.Add(id);

            return CreatePostDTOs(res.ToList());
        }

        public IEnumerable<PostDTO> GetAll(List<int> hashtags, DateTime date)
        {
            var res = new HashSet<int>();
            foreach (var hashtag in hashtags)
            {
                var posts = _context.Posts.OrderByDescending(e => e.Date).Where(e => e.HashtagsId.Contains(hashtag))
                    .Where(e => e.Date < date).Select(e => e.Id
                    ).ToList();
                foreach (var id in posts)
                    res.Add(id);
            }

            return CreatePostDTOs(res.ToList());

        }

        public IEnumerable<PostDTO> GetAll(string searchString)
        {
            return CreatePostDTOs(_context.Posts.OrderByDescending(p => p.Date).Where(p =>
                EF.Functions.Like(p.Author.ToLower(), $"%{searchString.ToLower()}%") ||
                EF.Functions.Like(p.Text.ToLower(), $"%{searchString.ToLower()}%")).ToList());
        }

        public IEnumerable<PostDTO> GetAll(string searchString, DateTime date)
        {
            return CreatePostDTOs(_context.Posts.OrderByDescending(p => p.Date).Where(p => p.Date < date).Where(p =>
                EF.Functions.Like(p.Author.ToLower(), $"%{searchString.ToLower()}%") ||
                EF.Functions.Like(p.Text.ToLower(), $"%{searchString.ToLower()}%")).ToList());
        }

        public PostDTO Get(int id)
        {
            var post = _context.Posts.First(e => e.Id == id);
            return CreatePostDTO(post);
        }

        public PostDTO GetLast()
        {
            return GetAll().First();
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
            dbPost.AuthorPicture = post.AuthorPicture;
            dbPost.Text = post.Text;
            dbPost.ContentsId.Clear();
            foreach (var contentId in post.ContentsId)
                dbPost.ContentsId.Add(contentId);
            dbPost.HashtagsId.Clear();
            foreach (var hashtagId in post.HashtagsId)
                dbPost.HashtagsId.Add(hashtagId);
            dbPost.IsShared = post.IsShared;
            dbPost.Comment = post.Comment;
            dbPost.OriginalPostId = post.OriginalPostId;
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

        public int FindHashtag(string name)
        {
            var found = _context.Hashtags.FirstOrDefault(e => e.Name == name);
            if (found == null)
                return -1;
            return found.Id;
        }
    }
}