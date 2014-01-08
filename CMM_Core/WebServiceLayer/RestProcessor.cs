namespace CMM.WebServiceLayer
{
    using DomainLayer;
    using RestSharp;

    public class RestProcessor
    {
        public Country CountryInformation { get; set; }

        public void GetCountry()
        {
            var client = new RestClient("http://restcountries.eu");

            var request = new RestRequest("rest/capital/london", Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
    }
}
