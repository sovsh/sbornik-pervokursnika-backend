namespace SbornikBackend.DTOs
{
    public class UserDesktopPutDTO
    {
        public string Login { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Role { get; set; }
    }
}