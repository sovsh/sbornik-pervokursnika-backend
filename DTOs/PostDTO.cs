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
        public string Text { get; set; }
        public List<ContentDTO> Contents { get; set; } = new List<ContentDTO>();
        public List<string> Hashtags { get; set; } = new List<string>();
        private bool Equals(PostDTO other)
        {

            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            //return StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Id);
            return Id.GetHashCode();
        }
    }
}