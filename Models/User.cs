using System.Collections.Generic;

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
        public int UserFacultyId { get; set; }
        public List<int> HashtagsId { get; set; } = new List<int>();
        public List<int> FavoritePostsId { get; set; } = new List<int>();
    }
}