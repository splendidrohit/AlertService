

namespace NotificationService.Storage
{
    using NotificationService.Models;

    // Due to unavailability of local database currently i am using inMemoryCache to store data 
    // but we can use this class to load data from Database.

    public class DataBase : IStorage
    {
        private static IStorage DBInstance = null;

        public static IStorage GetInstance()
        {
            if (DBInstance == null)
            {
                DBInstance = new DataBase();
            }

            return DBInstance;
        }

        public Team GetTeam(string name)
        {
            throw new System.NotImplementedException();
        }

        public void SaveTeam(Team team)
        {
            throw new System.NotImplementedException();
        }
    }
}
