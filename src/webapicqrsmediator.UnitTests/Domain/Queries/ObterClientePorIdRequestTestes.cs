using AutoFixture;
using FluentAssertions;
using NUnit.Framework;
using System;
using webapicqrsmediator.Domain.Queries;

namespace webapicqrsmediator.UnitTests.Domain.Queries
{
    public class ObterClientePorIdRequestTestes
    {
        private Fixture _fixture;
        private ObterClientePorIdRequest _request;

        [OneTimeSetUp]
        public void ConfigurararFixture()
        {
            _fixture = new Fixture();
        }

        [Test]
        public void DeveConstruirCorretamenteARequestDeObterClientePorId()
        {
            var id = _fixture.Create<Guid>();
            _request = new ObterClientePorIdRequest
            {
                Id = id
            };

            _request.Should().NotBeNull();
            _request.Id.Should().Be(id);
            _request.Chave.Should().NotBeNullOrEmpty();
        }
    }
}