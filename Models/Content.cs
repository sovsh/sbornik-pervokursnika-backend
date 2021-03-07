namespace SbornikBackend
{
    /// <summary>
    /// Тип контента
    /// </summary>
    enum ContentType : int
    {
        Picture,
        Gif,
        File
    }
    /// <summary>
    /// Контент
    /// </summary>
    public class Content
    {
        public int Id { get; set; }
        private ContentType Type { get; set; }
        public string Path { get; set; }
    }
}