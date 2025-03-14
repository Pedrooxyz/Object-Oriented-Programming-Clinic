/// <summary>
/// Classe de serviços para a gestão dos pacientes no sistema.
/// </summary>

using System;
using System.Collections.Generic;

using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Interfaces;
using TrataProblemas;

namespace RegrasNegocio.Servicos
{
    /// <summary>
    /// Classe de serviços para a gestão dos pacientes no sistema.
    /// </summary>
    public class GestaoPacientes : IGestaoPacientes
    {
        #region Atributos

        /// <summary>
        /// Repositório responsável pela manipulação de pacientes.
        /// </summary>
        PacientesRepositorio pacienteRepositorio;

        #endregion

        #region Metodos

        #region Construtores

        /// <summary>
        /// Construtor da classe `GestaoPacientes`.
        /// </summary>
        public GestaoPacientes()
        {
            pacienteRepositorio = new PacientesRepositorio();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um novo paciente ao sistema.
        /// </summary>
        /// <param name="pacienteLight">Objeto com as informações mínimas de um paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns><c>true</c> se o paciente for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `pacienteLight` ou `medicoLight` for nulo.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não tiver autorização para adicionar pacientes.</exception>
        /// <exception cref="EntidadeJaExisteException">Se o paciente já existir no sistema.</exception>
        public bool AdicionarPaciente(PacienteLight pacienteLight, MedicoLight medicoLight)
        {
            if (pacienteLight == null) throw new ArgumentNullException(nameof(pacienteLight));
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                pacienteRepositorio.AdicionarLight(pacienteLight);
                return true;
            }
            catch (EntidadeJaExisteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina um paciente existente no sistema.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="password">Senha necessária para a operação.</param>
        /// <returns><c>true</c> se o paciente for eliminado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de pacientes não estiver inicializada.</exception>
        /// <exception cref="Exception">Exceção geral em caso de erro não específico.</exception>
        public bool EliminarPaciente(int pacienteId, int password)
        {
            if (password != 0000) return false; //palavrapasse do sistema

            try
            {
                pacienteRepositorio.Remover(pacienteId);
                return true;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se um paciente existe no sistema.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns><c>true</c> se o paciente existir, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for nulo.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não tiver autorização para verificar pacientes.</exception>
        public bool ExistePaciente(int pacienteId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();
            try
            {
                return pacienteRepositorio.Existe(pacienteId);
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtém um paciente pelo seu identificador.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns>Um objeto do tipo `PacienteLight` representando o paciente.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for nulo.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não tiver autorização para obter pacientes.</exception>
        public PacienteLight ObterPaciente(int pacienteId, MedicoLight medicoLight)
        {

            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                return pacienteRepositorio.ObterPacienteLight(pacienteId);
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Tentativa de associar consultas a um paciente
        //public bool AssociarRepositorioConsultasAoPaciente(int pacienteId, int repositorioId, MedicoLight medicoLight)
        //{
        //    if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
        //    if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

        //    try
        //    {
        //        pacienteRepositorio.AssociarRepositorioConsultasPaciente(pacienteId, repositorioId);
        //        return true;
        //    }
        //    catch (ColecaoNaoInicializadaException)
        //    {
        //        throw;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        /// <summary>
        /// Obtém o ID de consultas associado a um paciente.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns>O ID de consultas associado ao paciente.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for nulo.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não tiver autorização para obter o ID de consultas.</exception>
        public int ObterConsultasIdDoPaciente(int pacienteId, MedicoLight medicoLight)
        {

            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                return pacienteRepositorio.ObterConsultasIdPaciente(pacienteId);
            }
            catch (ColecaoNaoInicializadaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Exporta os pacientes para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns><c>true</c> se a exportação for bem-sucedida, <c>false</c> em caso de erro.</returns>
        /// <exception cref="Exception">Exceção lançada caso ocorra algum erro durante a exportação.</exception>
        public bool ExportarPacientesParaFicheiro(string nomeFicheiro)
        {
            try
            {
                bool sucesso = pacienteRepositorio.ExportarPacientes(nomeFicheiro);
                return sucesso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion
    }
}
