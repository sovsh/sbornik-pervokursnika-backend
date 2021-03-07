namespace SbornikBackend
{
    /// <summary>
    /// Профиль
    /// </summary>
    public class Profile
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Faculty UserFaculty { get; set; }
    }
}