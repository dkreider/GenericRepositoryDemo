using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GenericRepositoryDemo.Entities;
using GenericRepositoryDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly GenericRepository<Blog> _repository;
        public BlogController(GenericRepository<Blog> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Blog>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<Blog> GetAsync(Guid id)
        {
            return await _repository.GetAsync(id);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] Blog blog)
        {
            await _repository.CreateAsync(blog);
            await _repository.SaveChangesAsync();
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody] Blog blog)
        {
            _repository.Update(blog);
            await _repository.SaveChangesAsync();
        }

        [HttpDelete]
        public async Task DeleteAsync([FromBody] Blog blog)
        {
            _repository.Delete(blog);
            await _repository.SaveChangesAsync();
        }
    }
}
