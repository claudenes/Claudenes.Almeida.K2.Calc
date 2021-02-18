using Microsoft.AspNetCore.TestHost;
using SClaudenes.Almeida.K2.Calc_Teste.Helpers;

namespace Claudenes.Almeida.K2.Calc_Teste.Helpers
{
    public class HttpServiceClient : BaseHttpServiceClient
    {
        public HttpServiceClient(TestServer client) : base(client)
        {
        }
    }
}