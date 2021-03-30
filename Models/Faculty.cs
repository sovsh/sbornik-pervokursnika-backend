using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Факультет
    /// </summary>
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public int PictureId { get; set; }
        public List<int> HashtagsId { get; set; } = new List<int>();
    }
}