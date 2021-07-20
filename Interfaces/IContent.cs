using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IContent
    {
        bool IsTableHasId(int id);
        string GetType(int type);
        ContentDTO CreateContentDTO(int id);
        List<ContentDTO> CreateContentDTOs(List<int>ids);
        void Add(Content content);
        IEnumerable<Content> GetAll();
        Content Get(int id);
        void Update(Content content);
        void Delete(int id);
    }
}