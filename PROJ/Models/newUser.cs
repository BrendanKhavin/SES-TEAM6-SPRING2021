using System;
using MongoDB.Bson;
using MongoDB.Driver; 
namespace PROJ.Models

{
    public class newUser
    {
        
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String studentType { get; set; }
        public string password { get; set; } 

        public newUser(string firstName, string lastName, string studentType, string password) 
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.studentType = studentType;
            this.password = password;
        }
    }
}
