/// <summary>
/// Classe de serviços para a gestão das consultas no sistema.
/// </summary>
/// <exception cref="MedicoNaoAutorizadoException">Quando o médico não está autorizado a realizar certas operações.</exception>
/// <exception cref="ArgumentNullException">Quando algum dos parâmetros passados para os métodos é nulo.</exception>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Interfaces;
using TrataProblemas;

namespace RegrasNegocio.Servicos
{
    /// <summary>
    /// Classe responsável pela gestão das consultas no sistema.
    /// </summary>
    public class GestaoConsultas : IGestaoConsultas
    {
        #region Atributos

        /// <summary>
        /// Repositório responsável pela persistência das consultas no sistema.
        /// </summary>
        ConsultasRepositorio consultaRepositorio;

        #endregion

        #region Metodos

        #region Construtores

        /// <summary>
        /// Construtor da classe GestaoConsultas.
        /// </summary>
        public GestaoConsultas()
        {   
            consultaRepositorio = new ConsultasRepositorio(); 
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona uma nova consulta ao sistema.
        /// </summary>
        /// <param name="consultaLight">Objeto que contém as informações mínimas de uma consulta.</param>
        /// <param name="medicoLight">Objeto que representa o médico que está a adicionar a consulta.</param>
        /// <returns>Retorna <c>true</c> se a consulta for adicionada com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se algum dos parâmetros for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a adicionar consultas.</exception>
        public bool AdicionarConsulta(ConsultaLight consultaLight, MedicoLight medicoLight)
        {
            if (consultaLight == null) throw new ArgumentNullException(nameof(consultaLight));
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                consultaRepositorio.AdicionarLight(consultaLight);
            }
            catch (EntidadeJaExisteException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return true;
        }

        /// <summary>
        /// Elimina uma consulta existente no sistema.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser eliminada.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela eliminação da consulta.</param>
        /// <returns>Retorna <c>true</c> se a consulta for eliminada com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro <paramref name="medicoLight"/> for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a eliminar consultas.</exception>
        public bool EliminarConsulta(int consultaId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                consultaRepositorio.Remover(consultaId);
            }
            catch (ColecaoNaoInicializadaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// Verifica se uma consulta existe no repositório, com permissão do médico.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser verificada.</param>
        /// <param name="medicoLight">Objeto que representa o médico que está a verificar a consulta.</param>
        /// <returns>Retorna <c>true</c> se a consulta existir e o médico tiver permissão, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro <paramref name="medicoLight"/> for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a verificar consultas.</exception>
        public bool ExisteConsulta(int consultaId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();
            try
            {
                return consultaRepositorio.Existe(consultaId);
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
        /// Verifica se uma consulta existe no repositório, com permissão do paciente.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser verificada.</param>
        /// <param name="pacienteLight">Objeto que representa o paciente que está a verificar a consulta.</param>
        /// <returns>Retorna <c>true</c> se a consulta existir e o paciente tiver permissão, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro <paramref name="pacienteLight"/> for <c>null</c>.</exception>
        public bool ExisteConsulta(int consultaId, PacienteLight pacienteLight)
        {
            if (pacienteLight == null) throw new ArgumentNullException(nameof(pacienteLight));

            try
            {
                return consultaRepositorio.Existe(consultaId);
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
        /// Obtém uma consulta pelo seu identificador, com permissão do médico.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser obtida.</param>
        /// <param name="medicoLight">Objeto que representa o médico que está a obter a consulta.</param>
        /// <returns>Retorna um objeto do tipo <see cref="ConsultaLight"/> representando a consulta, ou <c>null</c> se não for encontrada.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro <paramref name="medicoLight"/> for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a visualizar consultas.</exception>
        public ConsultaLight ObterConsulta(int consultaId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                ConsultaLight consultaLight = consultaRepositorio.ObterConsultaLight(consultaId);
                return consultaLight;
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
        /// Exporta as consultas para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, ou <c>false</c> em caso de erro.</returns>
        public bool ExportarConsultasParaFicheiro(string nomeFicheiro)
        {
            try
            {
                bool sucesso = consultaRepositorio.ExportarConsultas(nomeFicheiro);
                return sucesso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #endregion

    }
}

