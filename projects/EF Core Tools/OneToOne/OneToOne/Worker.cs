using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    public class Worker
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Vehicle? Vehicle { get; set; }

        public Worker(string name)
        {
            Name = name;
        }
    }
}
