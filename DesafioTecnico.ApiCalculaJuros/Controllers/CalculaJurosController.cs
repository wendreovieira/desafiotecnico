using DesafioTecnico.ApiTaxaJuros.Helper;
using DesafioTecnico.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioTecnico.ApiCalculaJuros.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly IMediator _mediator;                

        public CalculaJurosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<decimal> Get(decimal valor, int meses)
        {
            double taxa = 0;

            using (var client = new HttpClient())
            {                                
                var response = await client.GetAsync(ApiRoutes.TaxaJuros.GetDocker);
                
                if (response.IsSuccessStatusCode)                                    
                    taxa = Double.Parse(await response.Content.ReadAsStringAsync());                
            }
            
            var command = new CalculaJurosCommand(valor, taxa, meses);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
