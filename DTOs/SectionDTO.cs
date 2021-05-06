using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public class SectionArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    public class SectionDTO
    {
        public string Type { get; } = "section";
        public List<SectionArticleDTO> Data { get; set; } = new List<SectionArticleDTO>();
        //public string Data { get; set; }
    }
}