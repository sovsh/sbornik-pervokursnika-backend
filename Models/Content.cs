namespace SbornikBackend
{
    /// <summary>
    /// Тип контента
    /// </summary>
    // 0 - картинка
    // 1 - гифка
    // 2 - файл (.doc, .pdf etc)
    // 3 - ссылка
    public enum ContentType : int
    {
        Picture,
        Gif,
        File,
        Link
    }
    /// <summary>
    /// Контент
    /// </summary>
    public class Content
    {
        public int Id { get; set; }
        public ContentType Type { get; set; }
        public string Path { get; set; }
    }
}