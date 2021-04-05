using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public class SectionDTO
    {
        public int Id { get; set; }
        public GuideSectionType Type { get; set; }
        public string Title { get; set; }
        public int SectionMainPicture { get; set; }
        public Dictionary<int, string> Articles { get; set; } = new Dictionary<int, string>();
    }
}