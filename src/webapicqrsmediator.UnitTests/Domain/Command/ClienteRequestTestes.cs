using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using webapicqrsmediator.Domain.Commands;

namespace webapicqrsmediator.UnitTests.Domain.Command
{
    public class ClienteRequestTestes
    {
        private Fixture _fixture;
        private AdicionarClienteDataRequest _clienteRequest;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void DeveConstruirClienteRequestCorretamente()
        {
            var nome = _fixture.Create<string>();
            var email = _fixture.Create<string>();
            _clienteRequest = new AdicionarClienteDataRequest
            {
                Nome = nome,
                Email = email
            };

            _clienteRequest.Should().NotBeNull();
            _clienteRequest.Nome.Should().Be(nome);
            _clienteRequest.Email.Should().Be(email);
        }
    }
}