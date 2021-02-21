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
        private readonly Uri _apiUrl = new Uri("https://localhost:44339/");

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
                client.BaseAddress = _apiUrl;
                var response = await client.GetAsync("taxajuros");

                if (response.IsSuccessStatusCode)                                    
                    taxa = Double.Parse((await response.Content.ReadAsStringAsync()).Replace(".", ","));                
            }
            
            var command = new CalculaJurosCommand(valor, taxa, meses);
            var result = await _mediator.Send(command);
            return result;
        }
    }
}
