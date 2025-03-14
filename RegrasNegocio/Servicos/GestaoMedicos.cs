/// <summary>
/// Classe de serviços para a gestão dos médicos no sistema.
/// </summary>
/// <exception cref="ArgumentNullException">Se algum parâmetro for nulo.</exception>
/// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a realizar operações.</exception>
/// <exception cref="EntidadeJaExisteException">Se o médico já existir no sistema.</exception>
/// <exception cref="ColecaoNaoInicializadaException">Se a coleção de médicos não estiver inicializada.</exception>
/// <exception cref="Exception">Exceção geral em caso de erro não específico.</exception>

using System;
using System.Collections.Generic;

using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Interfaces;
using TrataProblemas;

namespace RegrasNegocio.Servicos
{
    /// @brief Classe responsável pela gestão dos médicos no sistema.
    /// 
    /// Esta classe oferece métodos para adicionar, eliminar, verificar e obter médicos.
    /// Também lança exceções adequadas quando um médico não é encontrado.
    public class GestaoMedicos : IGestaoMedicos
    {

        #region Atributos 

        /// <summary>
        /// Repositório responsável pela manipulação de medicos.
        /// </summary>
        MedicosRepositorio medicoRepositorio;

        #endregion

        #region Metodos

        #region Construtores

        /// <summary>
        /// Construtor da classe `GestaoMedicos`.
        /// </summary>
        public GestaoMedicos()
        {
            medicoRepositorio = new MedicosRepositorio();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um novo médico ao sistema.
        /// </summary>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna <c>true</c> se o médico foi adicionado com sucesso, ou <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado.</exception>
        public bool AdicionarMedico(MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                medicoRepositorio.AdicionarLight(medicoLight);
                return true;

            }
            catch (EntidadeJaExisteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Elimina um médico do sistema.
        /// </summary>
        /// <param name="medicoId">Identificador do médico a ser eliminado.</param>
        /// <param name="password">Senha para autorização de eliminação.</param>
        /// <returns>Retorna <c>true</c> se o médico foi eliminado com sucesso, ou <c>false</c> caso contrário.</returns>
        public bool EliminarMedico(int medicoId, int password)
        {
            if (password != 0000) return false;

            try
            {
                medicoRepositorio.Remover(medicoId);
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
        /// Verifica se um médico existe no repositório.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico.</param>
        /// <param name="medicoLight">Objeto de dados do médico.</param>
        /// <returns>Retorna <c>true</c> se o médico existir, <c>false</c> caso contrário.</returns>
        public bool ExisteMedico(int medicoId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                return medicoRepositorio.Existe(medicoId);
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
        /// Obtém um médico pelo seu identificador.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico.</param>
        /// <param name="medicoLight">Objeto de dados do médico.</param>
        /// <returns>Retorna um objeto `MedicoLight` do médico, ou <c>null</c> se não encontrado.</returns>
        public MedicoLight ObterMedico(int medicoId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                MedicoLight medicoLightt = medicoRepositorio.ObterMedicoLight(medicoId);
                return medicoLightt;
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

        #region Tentativa de associar consultas a um medico
        //public bool AssociarRepositorioConsultasAoMedico(int medicoId, int repositorioId, MedicoLight medicoLight)
        //{
        //    if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
        //    if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

        //    try
        //    {
        //        medicoRepositorio.AssociarRepositorioConsultasMedico(medicoId, repositorioId);
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
        /// Obtém o ID de consultas associado a um médico pelo seu identificador.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico.</param>
        /// <param name="medicoLight">Objeto de dados do médico.</param>
        /// <returns>O ID de consultas associado ao médico.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a realizar operações.</exception>
        /// <exception cref="KeyNotFoundException">Se o médico com o ID especificado não for encontrado.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de médicos não estiver inicializada.</exception>
        /// <exception cref="Exception">Exceção geral em caso de erro não específico.</exception>
        public int ObterConsultasIdDoMedico(int medicoId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                return medicoRepositorio.ObterConsultasIdMedico(medicoId);
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
        /// Exporta os médicos para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, ou <c>false</c> em caso de erro.</returns>
        /// <exception cref="Exception">Exceção lançada caso ocorra algum erro durante a exportação.</exception>
        public bool ExportarMedicosParaFicheiro(string nomeFicheiro)
        {
            try
            {
                bool sucesso = medicoRepositorio.ExportarMedicos(nomeFicheiro);
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