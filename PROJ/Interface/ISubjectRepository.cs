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
        List<Subject> GetSubjectsByCreditPoints(int creditPoints);
        void InsertSubject(Subject Subject);
        void DeleteSubject(string SubjectID);
        void UpdateSubject(Subject Subject);
        void Save();
    }
}
