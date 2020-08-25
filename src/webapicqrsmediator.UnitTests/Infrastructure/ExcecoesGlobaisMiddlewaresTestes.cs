using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using webapicqrsmediator.Infrastructure.CrossCutting;

namespace webapicqrsmediator.UnitTests.Infrastructure
{
    [TestFixture]
    public class ExcecoesGlobaisMiddlewaresTestes
    {
        private DefaultHttpContext _httpContext;
        private Mock<ILogger<ApiMiddleware>> _logger;
        private ApiMiddleware _hostMiddleware;

        [SetUp]
        public void SetupMocks()
        {
            _httpContext = new DefaultHttpContext();
            _logger = new Mock<ILogger<ApiMiddleware>>();
        }

        [Test]
        public async Task DeveRetornarOkSeNaoOcorrerErroNaChamada()
        {
            _hostMiddleware = new ApiMiddleware(_ => Task.CompletedTask, _logger.Object);

            await _hostMiddleware.Invoke(_httpContext);

            _httpContext.Response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task DeveRetornarErroInternoDaAplicacaoSeAChamadaNaoForBemSucedida()
        {
            _hostMiddleware = new ApiMiddleware(_ => throw new Exception(), _logger.Object);

            await _hostMiddleware.Invoke(_httpContext);

            _httpContext.Response.StatusCode.Should().Be(500);
            _httpContext.Response.ContentType.Should().Be("application/json");
        }
    }
}