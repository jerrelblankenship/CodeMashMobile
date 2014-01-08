namespace CMM.Core.DataLayer
{
    using System.Linq;
    using DL;

    public class CMMDatabase : SQLiteConnection
    {
        public CMMDatabase(string databasePath) : base(databasePath)
        {
            CreateTable<Country>();
            CreateTable<Location>();
            CreateTable<Translation>();
        }

        public T GetItem<T>(int id) where T : CMMDomainBase, new()
        {
            return Table<T>().FirstOrDefault(x => x.Id == id);
        }

        public Country GetByCapital(string capital)
        {
            return Table<Country>().FirstOrDefault(x => x.Capital == capital);
        }
    }
}
