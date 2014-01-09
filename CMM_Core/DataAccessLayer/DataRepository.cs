namespace CMM.DataAccessLayer
{
    using System;
    using System.IO;
    using DataLayer;
    using DomainLayer;

    public class DataRepository
    {
        internal string dbLocation = string.Empty;
        internal CMMDatabase db = null;

        public DataRepository()
        {
            dbLocation = GetFilePath();
            db = new CMMDatabase(dbLocation);
        }

        public Country GetCountry(int id)
        {
            return db.GetItem<Country>(id);
        }

        public Country GetCountry(string capital)
        {
            return db.GetByCapital(capital);
        }

        public int SaveCountry(Country country)
        {
            return db.SaveItem(country);
        }

        private string GetFilePath()
        {
            const string dbName = "cmmDatabase.db3";

#if __ANDROID__
            string locationPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine (locationPath, dbName);
#else
            var path = dbName;
#endif
            return path;

        }
    }
}
