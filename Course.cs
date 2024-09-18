using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollageSystem
{
    internal class Course
    {
        public string title;
        public string description;
        public int duration;
        public User Creator;
        public List<Assignment> assignmentes = new List<Assignment>();
        public Course(string title , string description , int duration) {
            this.title = title;
            this.description = description;
            this.duration = duration;
        }
        
    }
}
