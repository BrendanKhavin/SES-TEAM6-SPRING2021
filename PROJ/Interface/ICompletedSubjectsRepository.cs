using System;
using System.Linq;
using PROJ.Models;
using System.Collections.Generic;


namespace PROJ.Interface
{
    public interface ICompletedSubjectsRepository
    {
        void InsertCompletedSubject(CompletedSubjects completedSubjects); // userID

        List<CompletedSubjects> GetCompletedSubjects(string userID);

        void DeleteCompletedSubject(string userID, CompletedSubjects completedSubject);
    }
}
