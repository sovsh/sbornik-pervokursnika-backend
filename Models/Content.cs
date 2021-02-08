namespace SbornikBackend
{
    /// <summary>
    /// Контент
    /// </summary>
    public class Content
    {
        public int Id { get; set; }
        public string Path { get; set; }
    }
    /// <summary>
    /// Картинка
    /// </summary>
    public class Picture : Content
    {
        
    }
    /// <summary>
    /// Гифка
    /// </summary>
    public class Gif : Content
    {
        
    }
    /// <summary>
    /// Файл формата .pdf, .word, .excel etc.
    /// </summary>
    public class File : Content
    {
        
    }
}