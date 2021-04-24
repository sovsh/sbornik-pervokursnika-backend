using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class GuideSectionRepository : IGuideSection
    {
        private readonly ApplicationContext _context;

        public GuideSectionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Guide.Any(e => e.Id == id);
        public void Add(GuideSection guideSection)
        {
            _context.Guide.Add(guideSection);
            _context.SaveChanges();
        }

        public IEnumerable<int> GetAllArticles(int parentId) =>
            _context.Guide.Where(a => parentId == a.Id).Select(a => a.Id).ToList();
        
        public IEnumerable<MainSectionDTO> GetAllMainSection()
        {
            var res = new List<MainSectionDTO>();
            foreach (var guideSection in _context.Guide)
            {
                if (guideSection.ParentId != -1)
                    continue;
                var children = GetAllArticles(guideSection.Id);
                var type = children.Count() == 1 ? "article" : "section";
                var mainSectionDTO = new MainSectionDTO
                    {Id = guideSection.Id, Picture = guideSection.Picture, Title = guideSection.Title, Type = type};
                res.Add(mainSectionDTO);
            }
            return res;
        }

        public GuideSection Get(int id) => _context.Guide.First(e => e.Id == id);

        public void Update(GuideSection guideSection)
        {
            _context.Guide.Update(guideSection);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var section = _context.Guide.First(e => e.Id == id);
            _context.Guide.Remove(section);
            _context.SaveChanges();
        }
    }
}