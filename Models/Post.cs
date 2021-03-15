using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Пост ленты
    /// </summary>
    public class Post
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public List<Content> Contents { get; set; } = new List<Content>();
        public List<Hashtag> Hashtags { get; set; } = new List<Hashtag>();
    }
}