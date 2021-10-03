using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Models
{
    public interface IStudentPreferences
    {
        List<StudentPreferences> GetPreferences();

        StudentPreferences GetbyID(int id);

        StudentPreferences Add(StudentPreferences preferences);

        StudentPreferences Delete(int id);

        StudentPreferences updatePreferences(StudentPreferences changedPreferences);

    }
}
