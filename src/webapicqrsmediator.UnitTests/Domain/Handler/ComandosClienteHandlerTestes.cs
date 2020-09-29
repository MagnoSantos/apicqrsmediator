using AutoFixture;
using FluentAssertions;
using MediatR;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using webapicqrsmediator.Domain.Commands;
using webapicqrsmediator.Domain.Commands.Response;
using webapicqrsmediator.Domain.Entitites;
using webapicqrsmediator.Domain.Handler;
using webapicqrsmediator.Domain.Interfaces.Converters;
using webapicqrsmediator.Domain.Interfaces.Repositories;

namespace webapicqrsmediator.UnitTests.Domain.Handler
{
    public class ComandosClienteHandlerTestes
    {
        private Fixture _fixture;
        private Mock<IClienteRepository> _repository;
        private Mock<IMediator> _mediator;
        private Mock<IConversor<AdicionarClienteDataRequest, Cliente>> _conversorClienteModelMock;
        private Mock<IConversor<AdicionarClienteDataRequest, AdicionarClienteDataResponse>> _conversorClienteResponseMock;
        private ComandosClienteHandler _comandosClienteHandler;

        [OneTimeSetUp]
        public void ConfigurarFixture()
        {
            _fixture = new Fixture();
        }

        [SetUp]
        public void ConfigurarDependencias()
        {
            _repository = new Mock<IClienteRepository>();
            _mediator = new Mock<IMediator>();
            _comandosClienteHandler = new ComandosClienteHandler(
                _repository.Object,
                _mediator.Object,
                _conversorClienteModelMock.Object,
                _conversorClienteResponseMock.Object
            );
        }

        [Test]
        public async Task DeveChamarHandlerDeComandosClienteParaAdicionarUmNovoCliente()
        {
            var clienteRequest = _fixture.Create<AdicionarClienteDataRequest>();
            var cliente = new Cliente(clienteRequest.Nome, clienteRequest.Email, DateTime.UtcNow);
            _repository
                .Setup(mock => mock.Adicionar(cliente))
                .Returns(Task.CompletedTask);

            var clienteResponse = await _comandosClienteHandler.Handle(clienteRequest, default);

            clienteResponse.Should().NotBeNull();
            clienteResponse.Nome.Should().Be(cliente.Nome);
            clienteResponse.Email.Should().Be(cliente.Email);
        }
    }
}