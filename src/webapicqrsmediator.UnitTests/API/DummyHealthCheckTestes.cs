using AutoFixture;
using FluentAssertions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using webapicqrsmediator.Api.HealthCheck;
using webapicqrsmediator.Infrastructure.DataAgents;
using webapicqrsmediator.Infrastructure.DataAgents.Dummy.Responses;

namespace webapicqrsmediator.UnitTests.API
{
    public class DummyHealthCheckTestes
    {
        private Fixture _fixture;
        private Mock<IDummyAgent> _dummyAgentMock;
        private HealthCheckContext _context;
        private DummyHealthCheck _healthCheck;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
        }

        [SetUp]
        public void ConfigurarDependencias()
        {
            _dummyAgentMock = new Mock<IDummyAgent>();
            _context = new HealthCheckContext();
            _healthCheck = new DummyHealthCheck(_dummyAgentMock.Object);
        }

        [Test]
        public async Task DeveRetorarUnhealthyCasoNaoRetorneAoMenosUmColaborador()
        {
            _dummyAgentMock
                .Setup(mock => mock.BuscarTodosColaboradores())
                .ReturnsAsync(null as BuscarColaboradorResponse);

            var resultado = await _healthCheck.CheckHealthAsync(_context, default);

            resultado.Status.Should().Be(HealthStatus.Unhealthy);
        }

        [Test]
        public async Task DeveRetornarHealthyCasoSejaRetornadoAoMenosUmColaborador()
        {
            var buscarColaboradorResponse = _fixture.Create<BuscarColaboradorResponse>();
            _dummyAgentMock
                .Setup(mock => mock.BuscarTodosColaboradores())
                .ReturnsAsync(buscarColaboradorResponse);

            var resultado = await _healthCheck.CheckHealthAsync(_context, default);

            resultado.Status.Should().Be(HealthStatus.Healthy);
        }

        [Test]
        public async Task DeveRetornarUnhealthyCasoOcorraUmaExcecao()
        {
            var excecao = new Exception();
            _dummyAgentMock
                .Setup(mock => mock.BuscarTodosColaboradores())
                .ThrowsAsync(excecao);

            var resultado = await _healthCheck.CheckHealthAsync(_context, default);

            resultado.Status.Should().Be(HealthStatus.Unhealthy);
        }
    }
}