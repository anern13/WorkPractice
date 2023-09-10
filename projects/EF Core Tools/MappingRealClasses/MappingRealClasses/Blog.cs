using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRealClasses
{
    public class Blog
    {
        public int BlogId { get; set; }
        public List<Title> Titles { get; set; } = new List<Title>();
        public List<Post> Posts { get; set; } = new List<Post>();

        public Blog(Title t_) 
        {
            Titles = new List<Title>();
            Titles.Add(t_);
        }
        public Blog() { Titles = new List<Title>(); }
    }
}
