using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace sunrise_sunset
{
    class Program
    {
        static void Main(string[] args)
        {
            string userCategoryUrl = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400&date=today";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(userCategoryUrl);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                SunMode sunMode = JsonConvert.DeserializeObject<SunMode>(response);
                Console.WriteLine(sunMode.Status);
                Console.WriteLine($"Sunrise: {sunMode.Results.Sunrise}");
                Console.WriteLine($"Sunset: {sunMode.Results.Sunset}");
            }
        }
    }
}
