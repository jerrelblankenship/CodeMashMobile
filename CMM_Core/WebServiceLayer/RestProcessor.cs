namespace CMM.WebServiceLayer
{
    using System.Collections.Generic;
    using System.IO;
    using DomainLayer;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
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

                byte[] byteArray = StringToAscii(content);
                var stream = new MemoryStream(byteArray);
                var streamReader = new StreamReader(stream);

                var serializer = new JsonSerializer
                {
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    NullValueHandling = NullValueHandling.Ignore
                };

                var result = (List<Country>) serializer.Deserialize(streamReader, typeof (List<Country>));

                int i = 9;
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
