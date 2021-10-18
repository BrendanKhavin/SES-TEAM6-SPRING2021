using PROJ.Models;
using System.Collections.Generic;


namespace PROJ.Interface
{
    public interface IDegreeRepository
    {
        IEnumerable<Degree> GetDegrees();
        Degree GetDegreeById(string Id);
        Degree GetDegreeByCode(string code);
        void InsertDegree(Degree degree);
        void DeleteDegree(string degreeID);
        void UpdateDegree(Degree degree);
        void Save();
    }
}
