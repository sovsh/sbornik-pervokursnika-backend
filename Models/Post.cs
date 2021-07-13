using System;
using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Пост ленты
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string AuthorPicture { get; set; }
        public string Text { get; set; }
        public List<int> ContentsId { get; set; } = new List<int>();
        public List<int> HashtagsId { get; set; } = new List<int>();
        public bool IsShared { get; set; }
        public string Comment { get; set; }
        public int OriginalPostId { get; set; }
    }
}