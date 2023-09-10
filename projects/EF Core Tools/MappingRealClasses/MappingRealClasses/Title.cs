using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRealClasses
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Post? Post { get; set; } 
        public List<Blog> Blogs { get; set; } = new List<Blog>();

    }
}
