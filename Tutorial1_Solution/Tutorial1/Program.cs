using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            
            var websiteUrl = args[0];
            var httpClient = new HttpClient();

            var respones = await httpClient.GetAsync(websiteUrl);

            if (respones.IsSuccessStatusCode)
            {
                var htmlContent =await respones.Content.ReadAsStringAsync();

                var regex = new Regex("[a-z0-9]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var emialAdresses = regex.Matches(htmlContent);

                foreach (var match in emialAdresses)
                {
                    Console.WriteLine(match.ToString());
                }

            }


            
    }
    }
}
