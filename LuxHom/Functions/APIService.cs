using Newtonsoft.Json;
using System.Text;

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
        public static async Task<bool> APSet(LuxHom.Models.ArticuloPrefabricado articuloPrefabricado)
        {
            var json_ = JsonConvert.SerializeObject(articuloPrefabricado);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "ArticuloPrefabricados/Set", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
        public static async System.Threading.Tasks.Task<bool> APUpdate(LuxHom.Models.ArticuloPrefabricado articuloPrefabricado)
        {
            var json_ = JsonConvert.SerializeObject(articuloPrefabricado);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            // Pass the handler to httpclient(from you are calling api)
            HttpClient httpClient = new HttpClient(clientHandler);
            httpClient.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await httpClient.PostAsync(baseurl + "ArticuloPrefabricados/Update", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
        public static async System.Threading.Tasks.Task<bool> APDelete(int id)
        {
            var json_ = JsonConvert.SerializeObject(id);
            var content = new StringContent(json_, Encoding.UTF8, "application/json");
            HttpClientHandler clientHandler = new()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient httpClient = new(clientHandler)
            {
                Timeout = TimeSpan.FromSeconds(timeout)
            };

            HttpResponseMessage response = await httpClient.PostAsync(baseurl + "ArticuloPrefabricados/Delete", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //return JsonConvert.DeserializeObject<IEnumerable<ClasificacionPeliculasModel.Movie>>(await response.Content.ReadAsStringAsync());
                return true;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
