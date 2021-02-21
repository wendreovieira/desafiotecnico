using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.ApiTaxaJuros.Controllers
{
    [ApiController]
    [Route("taxajuros")]
    public class TaxaJurosController : ControllerBase
    {
        private static readonly double taxaJuros = 0.01;

        [HttpGet]
        public double Get()
        {
            return taxaJuros;
        }
    }
}
