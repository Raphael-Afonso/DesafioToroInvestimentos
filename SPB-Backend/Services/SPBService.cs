using Microsoft.Extensions.Configuration;
using SPB_Backend.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SPB_Backend.Services
{
    public class SPBService
    {
        private readonly IConfiguration _parametros;
        public SPBService(IConfiguration parametros)
        {
            _parametros = parametros;
        }
        public async Task EnviarMovimentoParaContaCorrente(SPB movimentoSPB)
        {
            using HttpClient HttpClient = new();
            using HttpRequestMessage Request = new(HttpMethod.Put, new Uri($"http://{_parametros["ContaCorrenteHost"]}/contacorrente/processarMovimento"));
            Request.Content = new StringContent(JsonSerializer.Serialize(movimentoSPB), Encoding.UTF8, "application/json");
            
            using HttpResponseMessage Response = await HttpClient.SendAsync(Request);

            if (Response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new ApplicationException("Falha ao integrar com o serviço de conta corrente!");
        }
    }
}
