/// <summary>
/// Classe de testes unitários para a gestão de diagnósticos no sistema.
/// </summary>

using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Servicos;
using TrataProblemas;

namespace TestesUnitarios
{
    /// <summary>
    /// Classe de testes unitários para a gestão de diagnósticos no sistema.
    /// </summary>
    [TestClass]
    public sealed class TesteExames
    {
        #region Sucesso

        /// <summary>
        /// Testa o sucesso da adição de um diagnóstico ao sistema.
        /// </summary>
        [TestMethod]
        public void AdicionarExameSucesso()
        {
            GestaoExames gestaoExames = new GestaoExames();
            ExameLight exameLight = new ExameLight(1, "Exame de Sangue", new DateTime(2029, 1, 1), 10);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

         
            bool resultado = gestaoExames.AdicionarExame(exameLight, medicoLight);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testa o sucesso na eliminação de um diagnóstico.
        /// </summary>
        [TestMethod]
        public void EliminarExameSucesso()
        {
            GestaoExames gestaoExames = new GestaoExames();
            ExameLight exameLight = new ExameLight(1, "Exame de Sangue", new DateTime(2029, 1, 1), 10);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            gestaoExames.AdicionarExame(exameLight, medicoLight);

            bool resultado = gestaoExames.EliminarExame(1, medicoLight);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testa a obtenção de um diagnóstico com sucesso.
        /// </summary>
        [TestMethod]
        public void ObterExameSucesso()
        {
            GestaoExames gestaoExames = new GestaoExames();
            ExameLight exameLight = new ExameLight(1, "Exame de Sangue", new DateTime(2029, 1, 1), 10);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            gestaoExames.AdicionarExame(exameLight, medicoLight);

            ExameLight resultado = gestaoExames.ObterExame(1);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }

        #endregion

        #region Insucesso

        /// <summary>
        /// Testa a adição de um diagnóstico com data inválida.
        /// </summary>
        [TestMethod]
        public void AdicionarExameInsucesso_DataInvalida()
        {
            GestaoExames gestaoExames = new GestaoExames();
            ExameLight exameLight = new ExameLight(1, "Exame de Sangue", new DateTime(2020, 1, 1), 10);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            ArgumentException e = Assert.ThrowsException<ArgumentException>(() => gestaoExames.AdicionarExame(exameLight, medicoLight));
        }

        /// <summary>
        /// Testa a adição de um diagnóstico com um id de médico inválido.
        /// </summary>
        [TestMethod]
        public void AdicionarExameInsucesso_IdMedicoInvalido()
        {
            GestaoExames gestaoExames = new GestaoExames();
            ExameLight exameLight = new ExameLight(1, "Exame de Sangue", new DateTime(2029, 1, 1), 10);
            MedicoLight medicoLight = new MedicoLight(999, "Dr. João", 2);
            medicoLight.PodeTomarDecisoes = false;

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoExames.AdicionarExame(exameLight, medicoLight));
        }

        /// <summary>
        /// Testa a eliminação de um diagnóstico quando o médico não é responsável.
        /// </summary>
        [TestMethod]
        public void EliminarExameInsucesso_MedicoNaoResponsavel()
        {
            GestaoExames gestaoExames = new GestaoExames();
            ExameLight exameLight = new ExameLight(1, "Exame de Sangue", new DateTime(2029, 1, 1), 10);
            MedicoLight medicoResponsavel = new MedicoLight(1, "Dr. João", 2); // Médico responsável pelo exame
            MedicoLight medicoNaoResponsavel = new MedicoLight(2, "Dr. José", 2); // Médico não responsável

            medicoNaoResponsavel.PodeTomarDecisoes = false;

            gestaoExames.AdicionarExame(exameLight, medicoResponsavel);

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoExames.EliminarExame(1, medicoNaoResponsavel));
        }

        #endregion
    }
}


