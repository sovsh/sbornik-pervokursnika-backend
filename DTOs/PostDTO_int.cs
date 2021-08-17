using System;
using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public class PostDTO_int
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string AuthorPicture { get; set; }
        public string Text { get; set; }
        public List<Content> Contents { get; set; } = new List<Content>();
        public List<string> Hashtags { get; set; } = new List<string>();
        public bool IsShared { get; set; }
        public string Comment { get; set; }
        public int OriginalPostId { get; set; }
        public string VkPostLink { get; set; }
    }
}