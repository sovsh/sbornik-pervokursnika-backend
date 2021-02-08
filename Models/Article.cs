namespace SbornikBackend
{
    /// <summary>
    /// Статья сборника
    /// </summary>
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //subtitle?
        public string Text { get; set; }
        public int PictureId { get; set; }
    }
}