using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;

namespace PROJ.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentEnrollmentController
    {
        private IMongoRepository<StudentEnrollment> _studentEnrollmentRepository;

        public StudentEnrollmentController(IMongoRepository<StudentEnrollment> studentEnrollmentRepository)
        {
            _studentEnrollmentRepository = studentEnrollmentRepository;
        }

        //get method
        [HttpGet("{studentId}")]
        public StudentEnrollment GetDegree(string studentId) =>
            _studentEnrollmentRepository.FindOne(s => s.studentId == studentId).studentId;


            
        


   

    }
}
