using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Data.Models
{
    public class BlogPostHeader
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public virtual BlogCategory Category { get; set; }
        public string Name { get; set; }
        public int CounterOfReads { get; set; }
    }
}
