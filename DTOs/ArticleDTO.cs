namespace SbornikBackend.DTOs
{
    public class ArticleDTO
    {
        public string Type { get; } = "article";
        public GuideSection Data { get; set; }
    }
}