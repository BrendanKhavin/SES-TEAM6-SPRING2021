using System;
namespace PROJ.Models
{
    public class MyDatabaseSettings : IMyDataBaseSettings
    {
        public MyDatabaseSettings() { }

        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMyDataBaseSettings {

        public string ConnectionString { get; set; }
        public string CollectionName { get; set; }
        public string DatabaseName { get; set; }

    }



}
