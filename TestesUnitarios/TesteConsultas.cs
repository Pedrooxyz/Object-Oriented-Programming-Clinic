/// <summary>
/// Classe de testes unitários para a gestão de consultas no sistema.
/// </summary>

using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Servicos;
using TrataProblemas;

namespace TestesUnitarios
{
    [TestClass]
    /// <summary>
    /// Classe de testes unitários para a gestão de consultas no sistema.
    /// </summary>
    public sealed class TesteConsultas
    {
        #region Sucesso

        /// <summary>
        /// Testa o sucesso da adição de uma consulta ao sistema.
        /// </summary>
        [TestMethod]
        public void AdicionarConsultaSucesso()
        {
            GestaoConsultas gestaoConsultas = new GestaoConsultas();
            ConsultaLight consultaLight = new ConsultaLight(3, 2, 1, DateTime.Now.AddDays(2));
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            bool resultado = gestaoConsultas.AdicionarConsulta(consultaLight, medicoLight);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testa a eliminação de uma consulta com sucesso.
        /// </summary>
        [TestMethod]
        public void EliminarConsultaComSucesso()
        {
            GestaoConsultas gestaoConsultas = new GestaoConsultas();
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);
            int consultaId = 1; // Id de uma consulta existente

            bool resultado = gestaoConsultas.EliminarConsulta(consultaId, medicoLight);

            Assert.IsTrue(resultado);
        }

        #endregion

        #region Insucesso

        /// <summary>
        /// Testa a adição de uma consulta quando o médico não está autorizado.
        /// </summary>
        [TestMethod]
        public void AdicionarConsultaLancaMedicoNaoAutorizadoException()
        {
            GestaoConsultas gestaoConsultas = new GestaoConsultas();
            ConsultaLight consultaLight = new ConsultaLight(3, 2, 1, DateTime.Now.AddDays(2));
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);
            medicoLight.PodeTomarDecisoes=false;

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoConsultas.AdicionarConsulta(consultaLight, medicoLight));

        }

        /// <summary>
        /// Testa a eliminação de uma consulta quando o médico não está autorizado.
        /// </summary>
        [TestMethod]
        public void EliminarConsultaLancaMedicoNaoAutorizadoException()
        {
            GestaoConsultas gestaoConsultas = new GestaoConsultas();
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);
            medicoLight.PodeTomarDecisoes = false;  // Médico não autorizado
            int consultaId = 1; // Id de uma consulta existente

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoConsultas.EliminarConsulta(consultaId, medicoLight));
        }

        /// <summary>
        /// Testa a obtenção de uma consulta quando o médico não está autorizado.
        /// </summary>
        [TestMethod]
        public void ObterConsultaLancaMedicoNaoAutorizadoException()
        {
            GestaoConsultas gestaoConsultas = new GestaoConsultas();
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);
            medicoLight.PodeTomarDecisoes = false;  // Médico não autorizado
            int consultaId = 1; // Id de uma consulta existente

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoConsultas.ObterConsulta(consultaId, medicoLight));
        }

        /// <summary>
        /// Testa a adição de uma consulta passando um objeto <c>null</c> como parâmetro para a consulta.
        /// </summary>
        [TestMethod]
        public void AdicionarConsultaLancaArgumentNullExceptionQuandoConsultaNull()
        {
            GestaoConsultas gestaoConsultas = new GestaoConsultas();
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            ArgumentNullException e = Assert.ThrowsException<ArgumentNullException>(() => gestaoConsultas.AdicionarConsulta(null, medicoLight));
        }

        #endregion
    }
}
