using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magia.Testes.AgendamentoContext.Commands
{
    [TestClass]
    public class NovaSalaCommandTests
    {
        [TestMethod]
        public void ValidarCommandValido()
        {
            var command =
                new Application.AgendamentoContext.Commands.NovaSalaCommand()
                {
                    Descricao = "Sala 1"
                };

            command.Validate();

            Assert.AreEqual(true, command.Valid);
        }

        [TestMethod]
        public void ValidarCommandQuandoDescricaoVazia()
        {
            var command =
                new Application.AgendamentoContext.Commands.NovaSalaCommand();

            command.Validate();

            Assert.AreEqual(true, command.Invalid);
        }
    }
}
