using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioTecnico.Domain.Commands
{
    public class CalculaJurosCommandHandler : IRequestHandler<CalculaJurosCommand, decimal>
    {
        public Task<decimal> Handle(CalculaJurosCommand request, CancellationToken cancellationToken)
        {
            var juros = Math.Pow(1 + request.Juros, request.Meses);            
            var valor = request.Valor * ((decimal)juros);            
            var resultado = Math.Truncate(valor * 100) / 100;
            return Task.FromResult(resultado);
        }
    }
}
