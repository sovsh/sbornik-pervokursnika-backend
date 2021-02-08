namespace SbornikBackend
{
    /// <summary>
    /// Раздел сборника
    /// </summary>
    public class Section
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
    }
    /// <summary>
    /// Основной раздел
    /// </summary>
    public class MainSection : Section
    {
        public int PictureId { get; set; }
        public int SubsectionId { get; set; }
    }
    /// <summary>
    /// Подраздел
    /// </summary>
    public class Subsection : Section
    {
    }
}