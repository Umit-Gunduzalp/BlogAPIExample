using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Models
{
    public class BlogPostHeader
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public int CounterOfReads { get; set; }
        public bool IsDelete { get; set; }
    }
}
