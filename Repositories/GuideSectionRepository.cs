﻿using System.Collections.Generic;
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

        public IEnumerable<MainSectionDTO> GetAllMainSections()
        {
            var res = new List<MainSectionDTO>();
            foreach (var guideSection in _context.Guide.OrderBy(e=>e.Id))
            {
                if (!guideSection.IsMain)
                    continue;
                var mainSectionDTO = new MainSectionDTO
                    {Id = guideSection.Id, Picture = guideSection.Picture, Title = guideSection.Title};
                res.Add(mainSectionDTO);
            }

            return res;
        }

        public SectionDTO GetSection(int id, List<GuideSection>articles)
        {
            var articlesDictionary = new Dictionary<int, string>();
            foreach (var article in articles)
                articlesDictionary.Add(article.Id, article.Title);
            return new SectionDTO {Data = articlesDictionary};
        }

        public IEnumerable<GuideSection> GetAll() => _context.Guide.OrderBy(e => e.Id).ToList();

        public GuideSection Get(int id) => _context.Guide.First(e => e.Id == id);
        public List<GuideSection> GetChildrenArticles(int parentId)
        {
            return _context.Guide.Where(a => a.ParentId == parentId).ToList();
        }

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