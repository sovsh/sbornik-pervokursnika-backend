using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Тип секции сборника
    /// </summary>
    public enum GuideSectionType : int
    {
        Article,
        MainArticle,
        Section
    }
    /// <summary>
    /// Секция сборника
    /// </summary>
    public class GuideSection
    {
        public int Id { get; set; }
        public GuideSectionType Type { get; set; }
        public string Title { get; set; }
    }
    /// <summary>
    /// Статья сборника
    /// </summary>
    public class Article : GuideSection
    {
        public string Text { get; set; }
        public List<int> ArticlePicturesId { get; set; } = new List<int>();
    }
    /// <summary>
    /// Главная статья сборника
    /// </summary>
    public class MainArticle : Article
    {
        public int ArticleMainPicture { get; set; }
    }
    /// <summary>
    /// Секция с несколькими статьями
    /// </summary>
    public class Section : GuideSection
    {
        public int SectionMainPicture { get; set; }
        public List<int> ArticlesId { get; set; } = new List<int>();
    }
}