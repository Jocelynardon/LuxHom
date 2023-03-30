using Newtonsoft.Json;

namespace LuxHom.Functions
{
    public class APIService
    {
        private static readonly int timeout = 600;
        private static readonly string baseurl = "https://localhost:7067/";

        public static async Task<IEnumerable<LuxHom.Models.ArticuloPrefabricado>> APGetList()
        {
            HttpClientHandler clientHandler = new()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient httpClient = new(clientHandler)
            {
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            HttpResponseMessage response = await httpClient.PostAsync(baseurl + "ArticuloPrefabricados/GetList", null);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IEnumerable<LuxHom.Models.ArticuloPrefabricado>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
