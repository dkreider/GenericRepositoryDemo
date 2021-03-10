using System;

namespace GenericRepositoryDemo.Entities
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}