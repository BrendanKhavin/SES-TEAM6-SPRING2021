using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Models
{
    public class StudentPreferences
    {
        public int ID { get; set; }

        public int StudentID { get; set; }

        public bool Groupwork { get; set; }

        public bool Essays { get; set; }

        public bool Presentations { get; set; }

        public bool Exams { get; set; }

        public bool Local { get; set; }

    }
}
