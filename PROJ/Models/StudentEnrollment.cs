using System;
namespace PROJ.Models

{
    public class StudentEnrollment : Document
    {
        public int studentId { get; set; }
        public string degreeName { get; set; }
        public string major { get; set; }

        public StudentEnrollment()
        {
        }


        //get student degree
        //add student degree
        //update student degree (don't worry about that)
    }
}
