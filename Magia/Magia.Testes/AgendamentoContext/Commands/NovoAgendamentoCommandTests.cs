using Magia.Application.AgendamentoContext.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Magia.Testes.AgendamentoContext.Commands
{
    [TestClass]
    public class NovoAgendamentoCommandTests
    {
        private Application.AgendamentoContext.Commands.NovoAgendamentoCommand _command;

        public NovoAgendamentoCommandTests()
        {
            _command = new NovoAgendamentoCommand()
            {
                SalaId = Guid.NewGuid(),
                Titulo = "Panning Sprint 36",
                DataHoraInicio = DateTime.Now.AddMinutes(1),
                DataHoraFim = DateTime.Now.AddHours(1)
            };
        }

        [TestMethod]
        public void ValidaCommandValido()
        {
            _command.Validate();
            Assert.AreEqual(true, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandVazio()
        {
            _command = new NovoAgendamentoCommand();
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandSalaIdNaoInformado()
        {
            _command.SalaId = Guid.Empty;
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandTituloEmBranco()
        {
            _command.Titulo = string.Empty;
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandDataHoraInicioMaiorQueDataHoraFim()
        {
            _command.DataHoraInicio = _command.DataHoraFim.AddMinutes(1);
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandDataHoraFimMenorQueDataAtual()
        {
            _command.DataHoraFim = DateTime.Now.AddSeconds(-1);
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandDataHoraInicioMenorQueDataHoraAtual()
        {
            _command.DataHoraInicio = DateTime.Now.AddSeconds(-1);
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandDataHoraInicioIgualDataHoraFim()
        {
            var dataHora = DateTime.Now.AddMinutes(1);
            _command.DataHoraInicio = dataHora;
            _command.DataHoraFim = dataHora;
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandDataHoraInicioNaoInformada()
        {
            _command.DataHoraInicio = DateTime.MinValue;
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }

        [TestMethod]
        public void ValidaCommandDataHoraFimNaoInformada()
        {
            _command.DataHoraFim = DateTime.MinValue;
            _command.Validate();
            Assert.AreEqual(false, _command.IsValid());
        }
    }
}
