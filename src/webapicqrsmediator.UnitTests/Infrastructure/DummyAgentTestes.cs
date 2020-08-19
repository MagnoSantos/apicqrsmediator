using AutoFixture;
using FluentAssertions;
using Flurl.Http.Testing;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.Data.Agents.Dummy.Options;
using webapicqrsmediator.Infrastructure.Data.Agents.Dummy.Responses;
using webapicqrsmediator.Infrastructure.DataAgents;

namespace webapicqrsmediator.UnitTests.Infrastructure
{
    public class DummyAgentTestes
    {
        private Fixture _fixture;
        private HttpTest _httpTest;
        private DummyOptions _options;
        private Mock<IOptionsMonitor<DummyOptions>> _optionsMonitor;
        private DummyAgent _agent;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
        }

        [SetUp]
        public void ConfigurarDependencias()
        {
            _httpTest = new HttpTest();
            _optionsMonitor = new Mock<IOptionsMonitor<DummyOptions>>();
            _options = _fixture
                .Build<DummyOptions>()
                .With(opt => opt.UrlBase, _fixture.Create<Uri>().ToString())
                .Create();
            _optionsMonitor
                .Setup(mock => mock.CurrentValue)
                .Returns(_options);
            _agent = new DummyAgent(_optionsMonitor.Object);
        }

        [TearDown]
        public void Dispose()
        {
            _httpTest.Dispose();
        }

        [Test]
        public async Task DeveChamarRequestDeAdicionarUmNovoColaboradorCorretamente()
        {
            var nome = _fixture.Create<string>();
            var salario = _fixture.Create<string>();
            var idade = _fixture.Create<string>();
            var response = _fixture.Create<AdicionarColaboradorResponse>();
            _httpTest.RespondWithJson(response);

            await _agent.AdicionarColaborador(nome, salario, idade);

            _httpTest
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    name = $"{nome}",
                    salario = $"{salario}",
                    idade = $"{idade}"
                });
        }

        [Test]
        public async Task DeveRetornarColaboradorQuandoAposAdicionado()
        {
            var nome = _fixture.Create<string>();
            var salario = _fixture.Create<string>();
            var idade = _fixture.Create<string>();
            var response = _fixture.Create<AdicionarColaboradorResponse>();
            _httpTest.RespondWithJson(response);

            var resposta = await _agent.AdicionarColaborador(nome, salario, idade);

            _httpTest
                .ShouldHaveMadeACall()
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new
                {
                    name = $"{nome}",
                    salario = $"{salario}",
                    idade = $"{idade}"
                });
            resposta.Should().BeEquivalentTo(response);
        }
    }
}