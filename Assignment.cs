using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageSystem
{
    internal class Assignment
    {
        public string title;
        public string description;
        public List<Soluation> soluations = new List<Soluation>();
        public Assignment(string title , string description) {
            this.title = title;
            this.description = description;
        }
    }
}
