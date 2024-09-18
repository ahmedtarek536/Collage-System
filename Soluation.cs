using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageSystem
{
    internal class Soluation
    {
       public string title;
       public string description;
       public User student;
        public Soluation(string title, string description, User student) {
            this.title = title;
            this.description = description;
            this.student = student;
        }
        
    }
}
