using DesafioTecnico.ApiTaxaJuros;
using DesafioTecnico.ApiTaxaJuros.Helper;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioTecnico.Tests.Integrations
{
    public class ApiTaxaJurosIntegrationTest
    {
        private readonly HttpClient _client;

        public ApiTaxaJurosIntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task Deve_retornar_taxa_juros()
        {
            var response = await _client.GetAsync(ApiRoutes.TaxaJuros.Get);
            Assert.True((response.IsSuccessStatusCode));
            Assert.Equal("0.01", await response.Content.ReadAsStringAsync());
        }
    }
}
