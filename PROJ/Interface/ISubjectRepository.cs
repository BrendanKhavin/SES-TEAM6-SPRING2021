using PROJ.Models;
using System.Collections.Generic;


namespace PROJ.Interface
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetSubjects();
        Subject GetSubjectById(string Id);
        Subject GetSubjectByCode(string code);
        List<Subject> GetSubjectsByCourseArea(string courseArea);
        List<Subject> GetSubjectsByCreditPoints(string creditPoints);
        List<Subject> GetSubjectsByCourseAndCredit(string courseArea, string creditPoints);
        List<Subject> GetSubjectbyDiffCreditPoints(string creditPoints1, string creditPoints2);
        void InsertSubject(Subject Subject);
        void DeleteSubject(string SubjectID);
        void UpdateSubject(Subject Subject);
        void Save();
    }
}
