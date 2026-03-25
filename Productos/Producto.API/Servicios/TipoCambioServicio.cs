using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Abstracciones.Modelos.Servicio;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text.Json;
namespace Servicios
{
    public class TipoCambioServicio : ITipoCambioServicio
    {
        private readonly IConfiguracion _configuracion;
        private readonly IHttpClientFactory _httpClient;

        public TipoCambioServicio(IConfiguracion configuracion, IHttpClientFactory httpClient)
        {
            _configuracion = configuracion;
            _httpClient = httpClient;
        }

        public async Task<Conversiones> ObtenerCambio()
        {
            var endPoint = _configuracion.ObtenerMetodo("ApiEndPointsConversion", "ObtenerTipoCambio");
            var servicioCambio = _httpClient.CreateClient("ServicioCambio");
            //
            var token = _configuracion.ObtenerValor("Token");
            servicioCambio.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", token);
            //
            var respuesta = await servicioCambio.GetAsync(string.Format(endPoint, DateTime.Today.ToString("yyyy/MM/dd")));
            respuesta.EnsureSuccessStatusCode();
            var resultado = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var resultadoDeserializado = JsonSerializer.Deserialize<Conversiones>(resultado, opciones);
            return resultadoDeserializado;
        }
    }
}