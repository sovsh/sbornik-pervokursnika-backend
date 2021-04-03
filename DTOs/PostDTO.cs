using System;
using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public struct ContentDTO
    {
        public ContentType Type { get; set; }
        public string Uri { get; set; }
    }
    public class PostDTO
    {
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public List<ContentDTO> Contents { get; set; } = new List<ContentDTO>();
        public List<string> Hashtags { get; set; } = new List<string>();
    }
}