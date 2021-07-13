using System;
using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public struct ContentDTO
    {
        public int Id { get; set; }
        public string Uri { get; set; }
    }
    public class PostDTO
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string AuthorPicture { get; set; }
        public string Text { get; set; }
        public List<ContentDTO> Contents { get; set; } = new List<ContentDTO>();
        public List<string> Hashtags { get; set; } = new List<string>();
        public bool IsShared { get; set; }
        public string Comment { get; set; }
        public int OriginalPostId { get; set; }
        private bool Equals(PostDTO other)
        {

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}