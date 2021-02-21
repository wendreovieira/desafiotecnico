using MediatR;
using System;

namespace DesafioTecnico.Domain.Commands
{
    public class CalculaJurosCommand : IRequest<decimal>
    {
        public CalculaJurosCommand(decimal valor, double juros, int meses)
        {
            if (valor <= 0) throw new ArgumentException();
            if (juros <= 0) throw new ArgumentException();
            if (meses <= 0) throw new ArgumentException();

            Valor = valor;
            Juros = juros;
            Meses = meses;
        }

        public decimal Valor { get; set; }
        public double Juros { get; set; }
        public int Meses { get; set; }
    }
}