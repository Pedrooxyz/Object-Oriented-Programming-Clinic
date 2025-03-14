/// <summary>
/// Classe de serviços para a gestão dos diagnósticos no sistema.
/// </summary>
/// <exception cref="ArgumentNullException">Quando algum dos parâmetros passados para os métodos é nulo.</exception>
/// <exception cref="MedicoNaoAutorizadoException">Quando o médico não tem permissão para realizar a ação.</exception>
/// <exception cref="EntidadeJaExisteException">Quando a entidade a ser adicionada já existe.</exception>
/// <exception cref="ColecaoNaoInicializadaException">Quando a coleção de diagnósticos não foi inicializada.</exception>
/// <exception cref="KeyNotFoundException">Quando um diagnóstico não é encontrado.</exception>

using System;
using System.Collections.Generic;

using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Interfaces;
using TrataProblemas;

namespace RegrasNegocio.Servicos
{
    /// <summary>
    /// Classe responsável pela gestão dos diagnósticos no sistema.
    /// </summary>
    public class GestaoDiagnosticos : IGestaoDiagnosticos
    {
        #region Atributos

        /// <summary>
        /// Repositório responsável pela manipulação de diagnósticos.
        /// </summary>
        DiagnosticosRepositorio diagnosticoRepositorio;

        #endregion

        #region Metodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para a classe GestaoDiagnosticos.
        /// Inicializa o repositório de diagnósticos.
        /// </summary>
        public GestaoDiagnosticos()
        {
            diagnosticoRepositorio = new DiagnosticosRepositorio();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um novo diagnóstico ao sistema.
        /// </summary>
        /// <param name="diagnosticoLight">Objeto que contém as informações mínimas de um diagnóstico.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna <c>true</c> se o diagnóstico for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="EntidadeJaExisteException">Se o diagnóstico já existir no sistema.</exception>
        public bool AdicionarDiagnostico(DiagnosticoLight diagnosticoLight, MedicoLight medicoLight)
        {
            if (diagnosticoLight == null) throw new ArgumentNullException(nameof(diagnosticoLight));
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();
            if (diagnosticoLight.DataDiagnostico < DateTime.Now) throw new ArgumentException(nameof(diagnosticoLight.DataDiagnostico));
            
            try
            {
                diagnosticoRepositorio.AdicionarLight(diagnosticoLight);
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
        /// Elimina um diagnóstico existente no sistema.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico a ser eliminado.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna <c>true</c> se o diagnóstico for eliminado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        public bool EliminarDiagnostico(int diagnosticoId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                diagnosticoRepositorio.Remover(diagnosticoId);
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
        /// Verifica se um diagnóstico existe no repositório.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico a ser verificado.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna <c>true</c> se o diagnóstico existir, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        public bool ExisteDiagnostico(int diagnosticoId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                return diagnosticoRepositorio.Existe(diagnosticoId);
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
        /// Obtém um diagnóstico pelo seu identificador.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico a ser obtido.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna um objeto do tipo <c>DiagnosticoLight</c> representando o diagnóstico, ou <c>null</c> se não for encontrado.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        public DiagnosticoLight ObterDiagnostico(int diagnosticoId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                DiagnosticoLight diagnosticoLight = diagnosticoRepositorio.ObterDiagnosticoLight(diagnosticoId);
                return diagnosticoLight;
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
        /// Associa um ID de consulta a um diagnóstico.
        /// </summary>
        /// <param name="diagnosticoId">Identificador do diagnóstico.</param>
        /// <param name="consultaId">Identificador da consulta associada.</param>
        /// <returns>Retorna <c>true</c> se a consulta for associada com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        public bool AssociarConsultaAoDiagnostico(int diagnosticoId, int consultaId)
        {
            try
            {
                diagnosticoRepositorio.AssociarConsultaDiagnostico(diagnosticoId, consultaId);
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
        /// Obtém o ID da consulta associado a um diagnóstico pelo seu identificador.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico.</param>
        /// <returns>O ID da consulta associado ao diagnóstico.</returns>
        /// <exception cref="KeyNotFoundException">Se o diagnóstico com o ID especificado não for encontrado.</exception>
        public int ObterConsultaIdDoDiagnostico(int diagnosticoId)
        {
            try
            {
                return diagnosticoRepositorio.ObterConsultaIdDiagnostico(diagnosticoId);
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
        /// Adiciona texto à descrição de um diagnóstico existente.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico.</param>
        /// <param name="texto">Texto a ser adicionado à descrição do diagnóstico.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna <c>true</c> se o texto for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        public bool AdicionarTextoADescricao(int diagnosticoId, string texto, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                return diagnosticoRepositorio.AdicionarTextoDescricao(diagnosticoId, texto);
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
        /// Exporta os diagnósticos para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, ou <c>false</c> em caso de erro.</returns>
        public bool ExportarDiagnosticosParaFicheiro(string nomeFicheiro)
        {
            try
            {
                bool sucesso = diagnosticoRepositorio.ExportarDiagnosticos(nomeFicheiro);
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
