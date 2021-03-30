using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface ISection
    {
        bool IsTableHasId(int id);
        void Add(Section section);
        IEnumerable<Section> GetAll();
        Section Get(int id);
        void Update(Section section);
        void Delete(int id);
    }
}