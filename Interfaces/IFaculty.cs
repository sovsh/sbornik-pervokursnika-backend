using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IFaculty
    {
        bool IsTableHasId(int id);
        void Add(Faculty faculty);
        IEnumerable<Faculty> GetAll();
        Faculty Get(int id);
        void Update(Faculty faculty);
        void Delete(int id);
    }
}