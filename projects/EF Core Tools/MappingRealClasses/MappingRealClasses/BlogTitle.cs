using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingRealClasses
{
    internal class BlogTitle
    {
        public Title Title { get; set; }
        public int TitlesTitleId { get; set; }
        public Blog Blog { get; set; }
        public int BlogsBlogId { get; set; }
        public DateTime PublishDate { get; set; }
        public int Quantity { get; set; }

    }
}
