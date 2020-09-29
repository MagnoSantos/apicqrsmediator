using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using webapicqrsmediator.Domain.Entitites;

namespace webapicqrsmediator.UnitTests.Domain.Models
{
    public class ClienteTestes
    {
        private Fixture _fixture;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void DeveConstruirCorretamenteAEntidadeDeCliente()
        {
            var nome = _fixture.Create<string>();
            var email = _fixture.Create<string>();
            var data = _fixture.Create<DateTime>();

            var cliente = new Cliente(nome, email, data);

            cliente.Should().NotBeNull();
            cliente.Nome.Should().Be(nome);
            cliente.Email.Should().Be(email);
            cliente.DataCriacao.Should().Be(data);
        }
    }
}