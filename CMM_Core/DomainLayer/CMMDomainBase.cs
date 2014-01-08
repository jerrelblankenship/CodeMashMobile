namespace CMM.DomainLayer
{
    using DataLayer;
    
    public class CMMDomainBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
