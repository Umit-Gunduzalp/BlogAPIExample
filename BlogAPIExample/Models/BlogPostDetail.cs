using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPIExample.Models
{
    public class BlogPostDetail
    {
        public Guid Id { get; set; }
        public Guid HeaderId { get; set; }
        public BlogPostHeader Header { get; set; }
        public string Text { get; set; }
    }
}
