using System.Collections.Generic;
using System.Linq;
using SbornikBackend.DataAccess;
using SbornikBackend.DTOs;
using SbornikBackend.Interfaces;

namespace SbornikBackend.Repositories
{
    public class ContentRepository : IContent
    {
        private readonly ApplicationContext _context;

        public ContentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.Contents.Any(e => e.Id == id);
        public string GetType(int type)
        {
            return type switch
            {
                0 => "Picture",
                1 => "Gif",
                2 => "File",
                3 => "Link",
                _ => "Error"
            };
        }

        public ContentDTO CreateContentDTO(int id)
        {
            Content content = Get(id);
            string type = GetType((int) content.Type);
            return new ContentDTO {Id = content.Id, Type = type, Uri = content.Path};
        }

        public List<ContentDTO> CreateContentDTOs(List<int> ids)
        {
            return ids.Select(CreateContentDTO).ToList();
        }

        public void Add(Content content)
        {
            _context.Contents.Add(content);
            _context.SaveChanges();
        }

        public IEnumerable<Content> GetAll() => _context.Contents.OrderBy(e=>e.Id).ToList();

        public Content Get(int id) => _context.Contents.First(e => e.Id == id);

        public void Update(Content content)
        {
            var dbContent = _context.Contents.First(e => e.Id == content.Id);
            dbContent.Type = content.Type;
            dbContent.Path = content.Path;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var content = _context.Contents.First(e => e.Id == id);
            _context.Contents.Remove(content);
            _context.SaveChanges();
        }
    }
}