namespace CMM.WebServiceLayer
{
    using System.Collections.Generic;
    using System.IO;
    using DataAccessLayer;
    using DomainLayer;
    using Newtonsoft.Json;
    using RestSharp;

    public class RestProcessor
    {
        public Country CountryInformation { get; set; }

        public void GetCountry()
        {
            var client = new RestClient("http://restcountries.eu");

            var request = new RestRequest("rest/capital/london", Method.GET);

            client.ExecuteAsync(request, response =>
            {
                var content = response.Content;

                var internetIsDown = false;

                if (internetIsDown)
                {
                    content =
                        @"[{'alpha2Code':'GB','alpha3Code':'GBR','altSpellings':'GB,Great Britain,England,UK,Wales,Scotland,Northern Ireland','area':242900.0,'callingcode':'44','capital':'London','currency':'GBP','gini':34.0,'isoNumericCode':'826','languages':['en'],'latlng':[54.0,-2.0],'name':'United Kingdom','nationality':'British','population':63705000,'region':'Europe','relevance':'2.5','subregion':'Northern Europe','topLevelDomain':'.uk'}]";
                }


                byte[] byteArray = StringToAscii(content);
                var stream = new MemoryStream(byteArray);
                var streamReader = new StreamReader(stream);

                var serializer = new JsonSerializer
                {
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    NullValueHandling = NullValueHandling.Ignore
                };

                var result = (List<Country>) serializer.Deserialize(streamReader, typeof (List<Country>));

                if (result != null && result.Count > 0)
                {
                    var repo = new DataRepository();
                    repo.SaveCountry(result[0]);
                }
            });
        }
        
        public static byte[] StringToAscii(string s)
        {
            var retval = new byte[s.Length];
            for (var ix = 0; ix < s.Length; ++ix)
            {
                var ch = s[ix];
                if (ch <= 0x7f) retval[ix] = (byte)ch;
                else retval[ix] = (byte)'?';
            }
            return retval;
        }
    }
}
