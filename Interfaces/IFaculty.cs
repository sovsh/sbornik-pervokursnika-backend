﻿using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IFaculty
    {
        bool IsTableHasId(int id);
        string GetType(int type);
        FacultyDTO CreateFacultyDTO(Faculty faculty);
        FacultySomeInfoDTO CreateFacultySomeInfoDTO(Faculty faculty);
        IEnumerable<FacultySomeInfoDTO> CreateFacultySomeInfoDTOs(List<Faculty> faculties);
        void Add(Faculty faculty);
        IEnumerable<Faculty> GetAll();
        IEnumerable<FacultySomeInfoDTO> GetAllSomeInfoDTOs();
        Faculty Get(int id);
        FacultyDTO GetDTO(int id);
        FacultyDTO GetDTO(string name);
        void Update(Faculty faculty);
        void Delete(int id);
    }
}