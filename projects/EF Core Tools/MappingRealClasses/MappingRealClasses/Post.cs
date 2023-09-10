using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRealClasses
{
    public class Post
    {
        public int PostId { get; set; }
        public List<Blog> Blogs { get; set; } = new List<Blog>();
        public Title Title { get; set; } = null!; 
        public int TitleId { get; set; }
    }
}
