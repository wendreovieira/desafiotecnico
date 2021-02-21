using DesafioTecnico.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesafioTecnico.Tests.Commands
{
    public class CalculaJurosCommandTest
    {
        private readonly decimal _valor = 100;
        private readonly double _juros = 0.01;
        private readonly int _meses = 5;
        
        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void Quando_informar_valor_invalido(decimal valor)
        {            
            Assert.Throws<ArgumentException>(() => new CalculaJurosCommand(valor, _juros, _meses));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void Quando_informar_juros_invalido(double juros)
        {
            Assert.Throws<ArgumentException>(() => new CalculaJurosCommand(_valor, juros, _meses));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-15)]
        public void Quando_informar_meses_invalido(int meses)
        {
            Assert.Throws<ArgumentException>(() => new CalculaJurosCommand(_valor, _juros, meses));
        }

        [Fact]
        public void Quando_calcula_juros()
        {
            var command = new CalculaJurosCommand(_valor, _juros, _meses);
            Assert.Equal(_valor, command.Valor);
            Assert.Equal(_juros, command.Juros);
            Assert.Equal(_meses, command.Meses);
        }
    }
}
