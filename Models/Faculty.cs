using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Факультет
    /// </summary>
    public class Faculty
    {
        public int Id { get; set; }
        public List<Hashtag> Hashtags { get; set; } = new List<Hashtag>();
    }
}