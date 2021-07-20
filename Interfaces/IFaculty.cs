using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IFaculty
    {
        bool IsTableHasId(int id);
        string GetType(int type);
        FacultyDTO CreateFacultyDTO(Faculty faculty);
        void Add(Faculty faculty);
        IEnumerable<Faculty> GetAll();
        Faculty Get(int id);
        FacultyDTO GetDTO(int id);
        FacultyDTO GetDTO(string name);
        void Update(Faculty faculty);
        void Delete(int id);
    }
}