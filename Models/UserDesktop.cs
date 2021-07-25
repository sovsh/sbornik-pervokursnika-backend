using System.ComponentModel.DataAnnotations;

namespace SbornikBackend
{
    /// <summary>
    /// Пользователь админского приложения
    /// </summary>
    public class UserDesktop
    {
        [Key]
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}