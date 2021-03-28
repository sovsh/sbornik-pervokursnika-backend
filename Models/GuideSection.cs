using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Секция сборника
    /// </summary>
    public class GuideSection
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
    /// <summary>
    /// Статья сборника
    /// </summary>
    public class Article : GuideSection
    {
        public string Text { get; set; }
        public List<int> ArticlePicturiesId { get; set; } = new List<int>();
    }
    /// <summary>
    /// Главная статья сборника
    /// </summary>
    public class MainArticle : Article
    {
        public Content MainArticleMainPicture { get; set; }
    }
    /// <summary>
    /// Секция с несколькими статьями
    /// </summary>
    public class Section : GuideSection
    {
        public Content SectionMainPicture { get; set; }
        public List<int> ArticlesId = new List<int>();
    }
}