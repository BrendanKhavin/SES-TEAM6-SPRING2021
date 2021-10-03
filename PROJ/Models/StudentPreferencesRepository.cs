using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Models
{
    public class StudentPreferencesRepository : IStudentPreferences
    {


        private List<StudentPreferences> _studentPreferencesList;


        public StudentPreferences Add(StudentPreferences preferences)
        {
            throw new NotImplementedException();
        }

        public StudentPreferences Delete(int id)
        {
            StudentPreferences preference = _studentPreferencesList.FirstOrDefault(e => e.ID == id);
            if(preference != null)
            {
                _studentPreferencesList.Remove(preference);
            }
            return preference;
        }

        public List<StudentPreferences> GetPreferences()
        {
            return _studentPreferencesList;
        }

        public StudentPreferences GetbyID(int id)
        {
            StudentPreferences preference = _studentPreferencesList.FirstOrDefault(e => e.ID == id);

            return preference;
        }

        public StudentPreferences updatePreferences(StudentPreferences changedPreferences)
        {
            StudentPreferences preference = _studentPreferencesList.FirstOrDefault(e => e.ID == changedPreferences.ID);
            if (preference != null)
            {
                preference.Groupwork = changedPreferences.Groupwork;
                preference.Essays = changedPreferences.Essays;
                preference.Presentations = changedPreferences.Presentations;
                preference.Exams = changedPreferences.Exams;
                preference.Local = changedPreferences.Local;
            }
            return preference;
        }

    }
}
