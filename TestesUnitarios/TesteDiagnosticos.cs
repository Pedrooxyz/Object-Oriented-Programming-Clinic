/// <summary>
/// Classe de testes unitários para a gestão de diagnósticos no sistema.
/// </summary>

using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Servicos;
using TrataProblemas;

namespace TestesUnitarios
{
    [TestClass]
    public sealed class TesteDiagnosticos
    {
        #region Sucesso

        /// <summary>
        /// Testa o sucesso da adição de um diagnóstico ao sistema.
        /// </summary>
        [TestMethod]
        public void AdicionarDiagnosticoSucesso()
        {
            GestaoDiagnosticos gestaoDiagnositcos = new GestaoDiagnosticos();
            DiagnosticoLight diagnosticoLight = new DiagnosticoLight(1, new DateTime (2029,1,1), 1);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            bool resultado = gestaoDiagnositcos.AdicionarDiagnostico(diagnosticoLight, medicoLight);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testa o sucesso na eliminação de um diagnóstico.
        /// </summary>
        [TestMethod]
        public void EliminarDiagnosticoSucesso()
        {
            GestaoDiagnosticos gestaoDiagnositcos = new GestaoDiagnosticos();
            DiagnosticoLight diagnosticoLight = new DiagnosticoLight(1, new DateTime(2029, 1, 1), 1);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            gestaoDiagnositcos.AdicionarDiagnostico(diagnosticoLight, medicoLight);

            bool resultado = gestaoDiagnositcos.EliminarDiagnostico(1, medicoLight);

            Assert.IsTrue(resultado);
        }

        /// <summary>
        /// Testa a obtenção de um diagnóstico com sucesso.
        /// </summary>
        [TestMethod]
        public void ObterDiagnosticoSucesso()
        {
            GestaoDiagnosticos gestaoDiagnositcos = new GestaoDiagnosticos();
            DiagnosticoLight diagnosticoLight = new DiagnosticoLight(1, new DateTime(2029, 1, 1), 1);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            gestaoDiagnositcos.AdicionarDiagnostico(diagnosticoLight, medicoLight);

            DiagnosticoLight resultado = gestaoDiagnositcos.ObterDiagnostico(1, medicoLight);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
        }

        #endregion

        #region Insucesso

        /// <summary>
        /// Testa a adição de um diagnóstico com data inválida.
        /// </summary>
        [TestMethod]
        public void AdicionarDiagnosticoInsucesso_DataInvalida()
        {
            GestaoDiagnosticos gestaoDiagnositcos = new GestaoDiagnosticos();

            DiagnosticoLight diagnosticoLight = new DiagnosticoLight(1, new DateTime(2001, 1, 1), 1);
            MedicoLight medicoLight = new MedicoLight(1, "Dr. João", 2);

            ArgumentException e = Assert.ThrowsException<ArgumentException>(() => gestaoDiagnositcos.AdicionarDiagnostico(diagnosticoLight, medicoLight));

        }

        /// <summary>
        /// Testa a adição de um diagnóstico com um id de médico inválido.
        /// </summary>
        [TestMethod]
        public void AdicionarDiagnosticoInsucesso_IdMedicoInvalido()
        {
            
            GestaoDiagnosticos gestaoDiagnositcos = new GestaoDiagnosticos();
            DiagnosticoLight diagnosticoLight = new DiagnosticoLight(1, new DateTime(2029, 1, 1), 999);
            MedicoLight medicoLight = new MedicoLight(999, "Dr. João", 2);

            medicoLight.PodeTomarDecisoes = false;

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoDiagnositcos.AdicionarDiagnostico(diagnosticoLight, medicoLight));
        }

        /// <summary>
        /// Testa a eliminação de um diagnóstico quando o médico não é responsável.
        /// </summary>
        [TestMethod]
        public void EliminarDiagnosticoInsucesso_MedicoNaoResponsavel()
        {
            GestaoDiagnosticos gestaoDiagnositcos = new GestaoDiagnosticos();
            DiagnosticoLight diagnosticoLight = new DiagnosticoLight(1, new DateTime(2029, 1, 1), 1);
            MedicoLight medicoResponsavel = new MedicoLight(1, "Dr. João", 2); // Médico responsável pelo diagnóstico
            MedicoLight medicoNaoResponsavel = new MedicoLight(2, "Dr. José", 2); // Médico não responsável

            medicoNaoResponsavel.PodeTomarDecisoes = false;


            gestaoDiagnositcos.AdicionarDiagnostico(diagnosticoLight, medicoResponsavel);

            MedicoNaoAutorizadoException e = Assert.ThrowsException<MedicoNaoAutorizadoException>(() => gestaoDiagnositcos.EliminarDiagnostico(1, medicoNaoResponsavel));
        }


        #endregion
    }
}
