using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericRepositoryDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryDemo.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        private DbSet<Post> _dbSet;
        public PostRepository(BloggingContext context) : base(context) { }

        public override async Task<List<Post>> GetAllAsync(int count = -1, int skip = -1, string searchTerm = null)
        {
            if (!String.IsNullOrEmpty(searchTerm))
            {
                return await _dbSet.Where(p => p.Title.Contains(searchTerm) || p.Content.Contains(searchTerm)).ToListAsync();
            }

            return await base.GetAllAsync(count, skip, searchTerm);
        }
    }
}