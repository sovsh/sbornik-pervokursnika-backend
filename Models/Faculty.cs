using System.Collections.Generic;

namespace SbornikBackend
{
    /// <summary>
    /// Тип подразделения
    /// </summary>
    // 0 - fallback - подразделение
    // 1 - факультет
    // 2 - академия
    // 3 - институт
    public enum DivisionType : int
    {
        TypeFallback,
        TypeFaculty,
        TypeAcademy,
        TypeInstitute
    }
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public DivisionType Type { get; set; }
        public string Info { get; set; }
        public string Picture { get; set; }
    }
}