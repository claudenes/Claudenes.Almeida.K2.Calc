using System.Net;
using System.Threading.Tasks;
using Claudenes.Almeida.K2.Calc_Teste.Helpers;
using NUnit.Framework;
using SoftPlan.Calc.Integration.Tests.Helpers;

namespace Claudenes.Almeida.K2.Calc_Teste
{
    public class CalculaTaxaJuros
    {
        public HttpServiceClient _serviceClient;

        [TestCase(100, 5)]
        public async Task Calcula_juros_com_sucesso(decimal valorInicial, int meses)
        {
            //Arranger's
            var responseTaxaJuros = await _serviceClient.GetAsync("TaxaJuros/taxaJuros");

            responseTaxaJuros.StatusCode = HttpStatusCode.OK;
            var resultTaxaJuros = responseTaxaJuros.ConvertResponseMessageAsType<decimal>();
            

            //Act
            var responseCalculaJuros = await _serviceClient.GetAsync($"CalculaJuros/calculajuros/{valorInicial}/{meses}");

            //Assent's
            responseCalculaJuros.StatusCode = HttpStatusCode.OK;
            var resultCalculaJuros = responseCalculaJuros.ConvertResponseMessageAsType<double>();
            
        }

        [TestCase(100, 15)]
        [TestCase(100, -15)]
        public async Task Calcula_juros_passando_quantidade_meses_incorreto(decimal valorInicial, int quantidadeMeses)
        {
            //Arranger's

            //Act
            var response = await _serviceClient.GetAsync($"CalculaJuros/calculajuros/{valorInicial}/{quantidadeMeses}");

            //Assent's
            response.StatusCode = HttpStatusCode.BadRequest;
            var result = response.ConvertResponseMessageAsType<string>();
           
        }
    }
}
