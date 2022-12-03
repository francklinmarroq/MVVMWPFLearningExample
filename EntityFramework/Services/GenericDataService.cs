using Domain.Models;
using Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly ApplicationDbContext  _context;

        public GenericDataService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Create(T entity)
        {

                EntityEntry<T> created = await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return created.Entity;

        }

        public async Task<bool> Delete(int id)
        {

                T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();

                return true;
         
        }

        public async Task<T> Get(int id)
        {

                T entity = await _context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                await _context.SaveChangesAsync();

                return entity;
            
        }

        public async Task<IEnumerable<T>> GetAll()
        {

                IEnumerable<T> entities = await _context.Set<T>().ToListAsync();
                return entities;
            
        }

        public async Task<T> Update(int id, T entity)
        {

                entity.Id = id;
                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            
        }
    }
}
