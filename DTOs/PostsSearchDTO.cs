using System;

namespace SbornikBackend.DTOs
{
    public class PostsSearchDTO
    {
        public int Number { get; set; }
        public string SearchString { get; set; }
    }

    public class PostsSearchDateDTO : PostsSearchDTO
    {
        public DateTime Date { get; set; }
    }
}