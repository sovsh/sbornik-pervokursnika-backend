using System.ComponentModel.DataAnnotations;

namespace SbornikBackend
{
    /// <summary>
    /// Уровень доступа пользовалетеля бота
    /// 0 - пользователь не авторизован
    /// 1 - Администратор - полный набор прав
    /// 2 - Модератор - не модет добавлять и удалять пользователей
    /// </summary>
    public enum UserBotRole : int
    {
        Moderator,
        Administrator
    }

    /// <summary>
    /// Пользователь бота Вк
    /// </summary>
    public class UserBot
    {
        [Key]
        public int IdVk { get; set; }
        public int Role { get; set; }
    }
}