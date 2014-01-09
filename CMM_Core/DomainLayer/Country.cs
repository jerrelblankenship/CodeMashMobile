namespace CMM.DomainLayer
{
    using System.Collections.Generic;

    public class Country : CMMDomainBase
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public string Capital { get; set; }
        public string Population { get; set; }
        public string Currency { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string TopLevelDomain { get; set; }
        public List<double> latlng { get; set; }

        //public IList<NameTranslation> Translations { get; set; }
    }
}
