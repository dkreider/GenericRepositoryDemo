using System.Collections.Generic;

namespace GenericRepositoryDemo.Entities
{
    public class Blog : BaseModel
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
    }
}