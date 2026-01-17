using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Stockpoint.Shared.Models
{
    public class GetClient
    {
        public cResul? R { get; set; }
        private HttpClient _client;

        public void Actualizar()
        {
            switch (R?.metodos)
            {
                case "obtGetClient":
                    _client = ObtGetClient();
                    break;
                    // Puedes añadir más casos aquí
            }
        }

        private HttpClient ObtGetClient()
        {
            if (_client == null)
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri("https://stockpoint.ocadis.org/")
                };

                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                // Configuración adicional basada en R
                if (!string.IsNullOrWhiteSpace(R?.Token))
                {
                    _client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", R.Token);
                }
            }

            return _client;
        }

        // Método para obtener el cliente configurado
        public HttpClient GetClientConfigured()
        {
            if (_client == null)
            {
                Actualizar(); // Asegura que el cliente esté configurado
            }
            return _client;
        }
        // Agrega este método a tu clase GetClient existente
        
        //public async Task<List<cElemento>> ObtenerRolesAsync()
        //{
        //    try
        //    {

        //        var client = new GetClient
        //        {
        //            R = new cResul
        //            {
        //                metodos = "obtGetClient",
        //                Token = "tu_token_si_es_necesario", // Opcional
        //                Pantalla = "Usuarios"
        //            }
        //        }.GetClientConfigured();
        //        var response = await client.GetAsync("WebServices/ElementosA");
               
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            var errorContent = await response.Content.ReadAsStringAsync();
        //            throw new HttpRequestException($"Error: {response.StatusCode} - {errorContent}");
        //        }

        //        return await response.Content.ReadFromJsonAsync<List<cElemento>>();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error en GetClient: {ex.ToString()}");
        //        throw; // Relanzamos para manejar en el componente
        //    }
        //}
    }
    public class ServerApiResponse
    {
        // Usa JsonPropertyName para mapear exactamente el nombre de la propiedad en el JSON
        // Si tu JSON usa "Data" (PascalCase), puedes omitir el atributo o usar [JsonPropertyName("Data")]
        // Si tu JSON usa "data" (camelCase), DEBES usar [JsonPropertyName("data")]
        [JsonPropertyName("Data")] // <--- ¡AJUSTA ESTO SEGÚN EL JSON REAL!
        public List<vwResultado> Data { get; set; }

        // Si tu JSON usa "Total" (PascalCase), puedes omitir el atributo o usar [JsonPropertyName("Total")]
        // Si tu JSON usa "total" (camelCase), DEBES usar [JsonPropertyName("total")]
        [JsonPropertyName("Total")] // <--- ¡AJUSTA ESTO SEGÚN EL JSON REAL!
        public int Total { get; set; }

        // Si tu servidor devuelve un "Success" o "Message" en caso de error, puedes añadirlos aquí también.
        // [JsonPropertyName("Success")]
        // public bool Success { get; set; }
        // [JsonPropertyName("Message")]
        // public string Message { get; set; }
    }

}