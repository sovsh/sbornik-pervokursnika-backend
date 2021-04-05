using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface ISection
    {
        bool IsTableHasId(int id);
        void Add(Section section);
        IEnumerable<SectionDTO> GetAll();
        SectionDTO Get(int id);
        void Update(Section section);
        void Delete(int id);
    }
}