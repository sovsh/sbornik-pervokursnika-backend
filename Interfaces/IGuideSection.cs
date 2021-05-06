using System.Collections.Generic;
using SbornikBackend.DTOs;

namespace SbornikBackend.Interfaces
{
    public interface IGuideSection
    {
        bool IsTableHasId(int id);
        void Add(GuideSection guideSection);
        IEnumerable<MainSectionDTO> GetAllMainSections();
        SectionDTO GetSection(List<GuideSection> articles);
        IEnumerable<GuideSection> GetAll();
        GuideSection Get(int id);
        List<GuideSection> GetChildrenArticles(int parentId);
        void Update(GuideSection guideSection);
        void Delete(int id);
    }
}