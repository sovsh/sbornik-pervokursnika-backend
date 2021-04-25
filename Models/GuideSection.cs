using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Секция сборника
    /// </summary>
    public class GuideSection
    {
        public int Id { get; set; }
        public bool IsMain { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Picture { get; set; }
        public int ParentId { get; set; }
        public List<string> Pictures { get; set; } = new List<string>();
    }
}