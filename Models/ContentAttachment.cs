namespace SbornikBackend
{
    /// <summary>
    /// Таблица соответствия id поста/статьи и id контента, содержащегося в посте/статье
    /// </summary>
    public class ContentAttachment
    {
        public int Id { get; set; }
        public int ContentId { get; set; }
    }
}