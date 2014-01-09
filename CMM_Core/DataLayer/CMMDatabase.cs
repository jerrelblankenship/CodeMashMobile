namespace CMM.DataLayer
{
    using System.Collections.Generic;
    using System.Linq;
    using DomainLayer;


    public class CMMDatabase : SQLiteConnection
    {
        public CMMDatabase(string databasePath) : base(databasePath)
        {
            CreateTable<Country>();
            CreateTable<Location>();
            CreateTable<NameTranslation>();
        }

        public T GetItem<T>(int id) where T : CMMDomainBase, new()
        {
            return Table<T>().FirstOrDefault(x => x.Id == id);
        }

        public Country GetByCapital(string capital)
        {
            return Table<Country>().FirstOrDefault(x => x.Capital == capital);
        }

        public int SaveItem<T>(T objectItem) where T : CMMDomainBase
        {
            if (objectItem.Id != 0)
            {
                Update(objectItem);
                var id = objectItem.Id;
                return id;
            }
            else
            {
                Insert(objectItem);
                var id = objectItem.Id;
                return id;
            }
        }
    }
}
