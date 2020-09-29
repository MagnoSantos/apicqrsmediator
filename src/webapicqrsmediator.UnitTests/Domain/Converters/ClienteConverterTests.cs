using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using NUnit.Framework;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Converters;

namespace webapicqrsmediator.UnitTests.Domain.Converters
{
    public class ClienteConverterTests
    {
        private IFixture _fixture;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }

        [Test]
        public void DeveConverterParaClienteCorretamente()
        {
            var adicionarClienteRequest = _fixture.Create<AdicionarClienteDataRequest>();
            var clienteConverter = new ClienteConverter();

            var resposta = clienteConverter.Convert(adicionarClienteRequest);

            resposta.Should().NotBeNull();
            resposta.Email.Should().Be(adicionarClienteRequest.Email);
            resposta.Nome.Should().Be(adicionarClienteRequest.Nome);
        }
    }
}