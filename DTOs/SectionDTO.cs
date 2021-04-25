using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public class SectionDTO
    {
        public string Type { get; } = "section";
        public Dictionary<int, string> Data { get; set; } = new Dictionary<int, string>();
    }
}