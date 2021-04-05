using System;
using System.Collections.Generic;

namespace SbornikBackend.DTOs
{
    public class PostHashtagsDTO
    {
        public int Number { get; set; }
        public List<string>Hashtags { get; set; }
    }

    public class PostHashtagDateDTO : PostHashtagsDTO
    {
        public DateTime Date { get; set; }
    }
}