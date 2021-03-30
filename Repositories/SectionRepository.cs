using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
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

        public IEnumerable<Section> GetAll() => _context.Sections.Where(e => (int) e.Type == 2).ToList();

        public Section Get(int id) => _context.Sections.First(e => e.Id == id);

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