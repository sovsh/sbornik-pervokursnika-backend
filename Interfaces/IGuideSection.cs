using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IGuideSection
    {
        bool IsTableHasId(int id);
        void Add(GuideSection guideSection);
        IEnumerable<int> GetAllArticles(int parentId);
        IEnumerable<MainSectionDTO> GetAllMainSection();
        GuideSection Get(int id);
        void Update(GuideSection guideSection);
        void Delete(int id);
    }
}