using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Models
{
    public interface IPreferences
    {
        List<Preferences> GetPreferences();

        Preferences GetbyID(int id);

        Preferences Add(Preferences preferences);

        Preferences Delete(int id);

        Preferences updatePreferences(Preferences changedPreferences);

    }
}
