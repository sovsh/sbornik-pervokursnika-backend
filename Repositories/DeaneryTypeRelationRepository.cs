using System.Collections.Generic;
using System.Linq;
using SbornikBackend.Interfaces;
using SbornikBackend.DataAccess;

namespace SbornikBackend.Repositories
{
    public class DeaneryTypeRelationRepository:IDeaneryTypeRelation
    {
        private readonly ApplicationContext _context;

        public DeaneryTypeRelationRepository(ApplicationContext context)
        {
            _context = context;
        }

        public bool IsTableHasId(int id) => _context.DeaneryTypesRelation.Any(e => e.Id == id);

        public void Add(DeaneryTypeRelation relation)
        {
            _context.DeaneryTypesRelation.Add(relation);
            _context.SaveChanges();
        }

        public IEnumerable<string> GetAllDivisionsTypes()
        {
            return _context.DeaneryTypesRelation.Select(e => e.DivisionName).ToList();
        }

        public IEnumerable<DeaneryTypeRelation> GetAll() => _context.DeaneryTypesRelation.OrderBy(e => e.Id).ToList();

        public DeaneryTypeRelation Get(int id) => _context.DeaneryTypesRelation.First(e => e.Id == id);

        public void Update(DeaneryTypeRelation relation)
        {
            var dbRelation = Get(relation.Id);
            dbRelation.Type = relation.Type;
            dbRelation.DivisionName = relation.DivisionName;
            dbRelation.DeaneryName = relation.DeaneryName;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var relation = Get(id);
            _context.DeaneryTypesRelation.Remove(relation);
            _context.SaveChanges();
        }
    }
}