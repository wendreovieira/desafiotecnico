using DesafioTecnico.Domain.Commands;
using System;
using System.Threading;
using Xunit;

namespace DesafioTecnico.Tests.Commands
{
    public class CalculaJurosCommandHandlerTest
    {
        private CalculaJurosCommand _command;
        private CalculaJurosCommandHandler _handler;

        public CalculaJurosCommandHandlerTest()
        {
            _command = new CalculaJurosCommand(100, 0.01, 5);
            _handler = new CalculaJurosCommandHandler();
        }

        [Fact]
        public async void Deve_retornar_valor_corretamente()
        {            
            var result = await _handler.Handle(_command, new CancellationToken());
            Assert.True(result == Convert.ToDecimal(105.10));
        }
    }
}
