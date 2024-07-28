using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context ;
        private DbSet<T> entities;

        public GenericRepository(ECommerceDbContext context) {
            _context = context;
        }
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = _context.Set<T>();
                }
                return entities;
            }
        }

        public T GetById(int id)
        {
            return Entities.Find(id);
        }
        public IEnumerable<T> GetAll() {
            return Entities.ToList();
        }
        public void Add(T entity) {
            Entities.Add(entity);
        }
        public void Update(T entity)
        {
            Entities.Update(entity);
        }
        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }
    }
}
