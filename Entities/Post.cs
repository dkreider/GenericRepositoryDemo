namespace GenericRepositoryDemo.Entities
{
    public class Post : BaseModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}