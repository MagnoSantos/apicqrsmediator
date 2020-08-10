using AutoFixture;
using FluentValidation.TestHelper;
using NUnit.Framework;
using webapicqrsmediator.Domain.Commands;

namespace webapicqrsmediator.UnitTests.Domain.Command
{
    [TestFixture]
    public class AdicionarClienteValidatorTestes
    {
        private Fixture _fixture;
        private AdicionarClienteValidator _validator;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            _fixture = new Fixture();
        }

        [SetUp]
        public void SetupMocks()
        {
            _validator = new AdicionarClienteValidator();
        }

        [Test]
        public void DeveVerificarAsRegrasDeAdicaoDeClienteComDadosDeEntradaValidos()
        {
            var cliente = _fixture.Build<AdicionarClienteRequest>()
                .With(c => c.Nome, "Magno")
                .With(c => c.Email, "teste@teste.com")
                .Create();

            _validator.ShouldNotHaveValidationErrorFor(c => c.Nome, cliente);
            _validator.ShouldNotHaveValidationErrorFor(c => c.Email, cliente);
        }

        [Test]
        public void DeveRetornarErroAoVerificarAsRegrasDeAdicaoDeClienteComDadosDeEntradaVazios()
        {
            var cliente = _fixture.Build<AdicionarClienteRequest>()
                .With(c => c.Nome, string.Empty)
                .With(c => c.Email, string.Empty)
                .Create();

            var resultado = _validator.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(c => c.Nome)
                .WithErrorMessage("O campo de nome deve ser preenchido");
            resultado.ShouldHaveValidationErrorFor(c => c.Email)
                .WithErrorMessage("'Email' é um endereço de email inválido.");
        }

        [Test]
        public void DeveRetornarErroAoVerificarAsRegrasDeAdicaoDeClienteComDadosDeEntradaNulos()
        {
            var cliente = _fixture.Build<AdicionarClienteRequest>()
                .With(c => c.Nome, null as string)
                .With(c => c.Email, null as string)
                .Create();

            var resultado = _validator.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(c => c.Nome);
        }

        [Test]
        public void DeveRetornarErroAoVerificarAsRegrasDeAdicaoDeClienteComDadosDeEntradaComMaisDe25caracteres()
        {
            var cliente = _fixture.Build<AdicionarClienteRequest>()
                .With(c => c.Nome, "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.")
                .With(c => c.Email, null as string)
                .Create();

            var resultado = _validator.TestValidate(cliente);

            resultado.ShouldHaveValidationErrorFor(c => c.Nome)
                .WithErrorMessage("O campo deve conter no máximo 25 caracteres");
        }
    }
}