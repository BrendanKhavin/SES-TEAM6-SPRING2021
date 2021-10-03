using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Models
{
    public class PreferencesRepository : IPreferences
    {


        private List<Preferences> _studentPreferencesList;


        private IMongoCollection<Subject> _preferences;

        public PreferencesRepository(IMyDataBaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _preferences = database.GetCollection<Subject>("COLLECTION DOESNT EXIST YET");
        }


        public Preferences Add(Preferences preferences)
        {
            throw new NotImplementedException();
        }

        public Preferences Delete(int id)
        {
            Preferences preference = _studentPreferencesList.FirstOrDefault(e => e.ID == id);
            if(preference != null)
            {
                _studentPreferencesList.Remove(preference);
            }
            return preference;
        }

        public List<Preferences> GetPreferences()
        {
            return _studentPreferencesList;
        }

        public Preferences GetbyID(int id)
        {
            Preferences preference = _studentPreferencesList.FirstOrDefault(e => e.ID == id);

            return preference;
        }

        public Preferences updatePreferences(Preferences changedPreferences)
        {
            Preferences preference = _studentPreferencesList.FirstOrDefault(e => e.ID == changedPreferences.ID);
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
