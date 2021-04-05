using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class SectionRepository : ISection
    {
        private readonly ApplicationContext _context;

        public SectionRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Guide.Any(e => e.Id == id);

        public void Add(Section section)
        {
            _context.Guide.Add(section);
            _context.SaveChanges();
        }

        public IEnumerable<SectionDTO> GetAll()
        {
            var sections = _context.Sections.Where(e => (int) e.Type == 2).ToList();
            var res = new List<SectionDTO>();
            foreach (var section in sections)
            {
                var articles = new Dictionary<int, string>();
                foreach (var id in section.ArticlesId)
                {
                    articles.Add(id, _context.Articles.First(e => e.Id == id).Title);
                }
                var sectionDTO = new SectionDTO
                {
                    Id = section.Id, Type = section.Type, Title = section.Title,
                    SectionMainPicture = section.SectionMainPicture, Articles = articles
                };
                res.Add(sectionDTO);
            }
            return res;
        }//=> _context.Sections.Where(e => (int) e.Type == 2).ToList();

        public SectionDTO Get(int id)
        {
            var section =_context.Sections.First(e => e.Id == id);
            var articles = new Dictionary<int, string>();
            foreach (var articlesId in section.ArticlesId)
            {
                articles.Add(articlesId, _context.Articles.First(e => e.Id == articlesId).Title);
            }
            var sectionDTO = new SectionDTO
            {
                Id = section.Id, Type = section.Type, Title = section.Title,
                SectionMainPicture = section.SectionMainPicture, Articles = articles
            };
            return sectionDTO;
        }
        //_context.Sections.First(e => e.Id == id);

        public void Update(Section section)
        {
            _context.Guide.Update(section);
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