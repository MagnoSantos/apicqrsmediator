using AutoFixture;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using webapicqrsmediator.Api.Controllers;
using webapicqrsmediator.Domain.Queries;
using webapicqrsmediator.Domain.Queries.Response;
using webapicqrsmediator.Shared;

namespace webapicqrsmediator.UnitTests.API
{
    public class ClienteControllerTestes
    {
        private Fixture _fixture;
        private ClienteController _colaboradorController;
        private Mock<IMediator> _mediator;

        [OneTimeSetUp]
        public void InstaciarFixture()
        {
            _fixture = new Fixture();
        }

        [SetUp]
        public void InstanciarDependencias()
        {
            _colaboradorController = new ClienteController();
            _mediator = new Mock<IMediator>();
        }

        [Test]
        [Description("GET api/v1/Cliente/{id}")]
        public async Task DeveRetornarFalhaCasoNaoConsigaObterOClienteComOIdInformado()
        {
            var obterClientePorIdRequest = _fixture.Create<ObterClientePorIdRequest>();
            _mediator
                .Setup(mock => mock.Send(obterClientePorIdRequest, default))
                .ReturnsAsync(null as ObterClientePorIdResponse);

            var resposta = await _colaboradorController.ObterPorId(_mediator.Object, obterClientePorIdRequest);

            resposta.Should()
                .BeOfType<NotFoundObjectResult>()
                .Which.Value
                .Should()
                .BeEquivalentTo(new Falha(Constantes.Erros.ClienteNaoEncontrado));
        }

        [Test]
        [Description("GET api/v1/Cliente/{id}")]
        public async Task DeveRetornarSucessoCasoConsigaObterOClienteComOIdInformado()
        {
            var obterClientePorIdRequest = _fixture.Create<ObterClientePorIdRequest>();
            var obterClientePorIdResponse = _fixture.Create<ObterClientePorIdResponse>();
            _mediator
                .Setup(mock => mock.Send(obterClientePorIdRequest, default))
                .ReturnsAsync(obterClientePorIdResponse);

            var resposta = await _colaboradorController.ObterPorId(_mediator.Object, obterClientePorIdRequest);

            resposta.Should()
                .BeOfType<OkObjectResult>()
                .Which.Value
                .Should()
                .BeEquivalentTo(new Sucesso<ObterClientePorIdResponse>(
                    new ObterClientePorIdResponse
                    {
                        Id = obterClientePorIdResponse.Id,
                        Nome = obterClientePorIdResponse.Nome,
                        Email = obterClientePorIdResponse.Email,
                    })
                );
        }
    }
}