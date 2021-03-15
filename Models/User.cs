using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SbornikBackend
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Faculty UserFaculty { get; set; }
        public List<Hashtag>UserHashtags { get; set; }
        public List<Post>Favorites { get; set; }
    }
}