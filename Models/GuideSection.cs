using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Секция сборника
    /// </summary>
    public class GuideSection
    {
        public int Id { get; set; }
    }
    /// <summary>
    /// Статья сборника
    /// </summary>
    public class Article : GuideSection
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public List<Content> Picturies { get; set; } = new List<Content>();
    }
    /// <summary>
    /// Главная статья сборника
    /// </summary>
    public class MainArticle : Article
    {
        public Content MainPic { get; set; }
    }
    /// <summary>
    /// Секция с несколькими статьями
    /// </summary>
    public class Section : GuideSection
    {
        public Content MainPic { get; set; }
        public List<Article> Articles = new List<Article>();
    }
}