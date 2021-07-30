using System.Collections.Generic;

namespace SbornikBackend.Interfaces
{
    public interface IDeaneryTypeRelation
    {
        bool IsTableHasId(int id);
        void Add(DeaneryTypeRelation relation);
        IEnumerable<string> GetAllDivisionsTypes();
        IEnumerable<DeaneryTypeRelation> GetAll();
        DeaneryTypeRelation Get(int id);
        void Update(DeaneryTypeRelation relation);
        void Delete(int id);
    }
}