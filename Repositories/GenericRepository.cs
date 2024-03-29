using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryDemo.Repositories
{
    public class GenericRepository<Entity> where Entity : BaseModel
    {
        private readonly BloggingContext _context;
        private DbSet<Entity> _dbSet;
        public GenericRepository(BloggingContext context)
        {
            _context = context;
            _dbSet = _context.Set<Entity>();
        }

        public virtual async Task<List<Entity>> GetAllAsync(int count = -1, int skip = -1, string searchTerm = null)
        {
            if (!String.IsNullOrEmpty(searchTerm))
            {
                throw new Exception("Cannot search in generic repository. Please fix this by extending the custom repository.");
            }

            if (count != -1 || skip != -1)
            {
                return await _dbSet.Skip(skip).Take(count).ToListAsync();
            }

            return await _dbSet.ToListAsync();
        }

        public async Task<Entity> GetAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(Entity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(Entity entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(Entity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}