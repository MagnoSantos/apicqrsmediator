using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using webapicqrsmediator.Shared;

namespace webapicqrsmediator.UnitTests.Shared
{
    public class ExtensionsMethodsTests
    {
        private IFixture _fixture;
        private HttpContext _httpContextMock;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
            _fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }

        [SetUp]
        public void ConfigurarMocks()
        {
            _httpContextMock = new DefaultHttpContext();
        }

        [Test]
        [TestCase("data-json")]
        [TestCase("data-json-1")]
        [TestCase("data-json-2")]
        public async Task DeveObterConteudoCorretamente(string data)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(data));
            _httpContextMock.Request.Body = stream;
            _httpContextMock.Request.ContentLength = stream.Length;

            var resposta = await ExtensionsMethods.ObterConteudo(_httpContextMock.Request.Body);

            resposta.Should().NotBeNull();
            _httpContextMock.Request.ContentLength.Should().Be(stream.Length);
        }
    }
}