/// <summary>
/// Repositório responsável pela gestão de diagnósticos num sistema de saúde.
/// </summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe <c>DiagnosticosRepositorio</c>, que gere operações de adição, 
/// remoção, verificação da existência e obtenção de diagnósticos associados a pacientes.
/// </remarks>
/// <author>Pedro Ribeiro nº27960 LESI</author>
/// <date>dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Dados.Entidades;
using Dados.Interfaces;
using ObjetosNegocio.ClassesLight;
using TrataProblemas;

namespace Dados.Repositorios
{
    [Serializable]
    /// <summary>
    /// Classe responsável pela gestão de diagnósticos num repositório.
    /// </summary>
    public class DiagnosticosRepositorio : IRepositorio<Diagnostico>
    {
        #region Atributos

        /// <summary>
        /// Contador estático usado para gerar IDs únicos para cada repositório.
        /// </summary>
        static int contadorRepositorio = 0;

        /// <summary>
        /// ID único atribuído ao repositório atual.
        /// </summary>
        int diagnosticosRepositorioId;

        /// <summary>
        /// Lista que armazena os diagnósticos associados a este repositório.
        /// </summary>
        List<Diagnostico> diagnosticos;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor que inicializa o repositório com uma lista de diagnósticos vazia e atribui um ID único.
        /// </summary>
        public DiagnosticosRepositorio()
        {
            diagnosticosRepositorioId = ++contadorRepositorio;
            diagnosticos = new List<Diagnostico>();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um diagnóstico ao repositório.
        /// </summary>
        /// <param name="diagnostico">Objeto do tipo <c>Diagnostico</c> a ser adicionado.</param>
        /// <returns><c>true</c> se o diagnóstico foi adicionado com sucesso, <c>false</c> caso contrário.</returns>
        public bool Adicionar(Diagnostico diagnostico)
        {
            diagnosticos.Add(diagnostico);
            return true;
        }

        /// <summary>
        /// Remove um diagnóstico do repositório.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico a ser removido.</param>
        /// <returns><c>true</c> se o diagnóstico foi removido, <c>false</c> se não foi encontrado.</returns>
        public bool Remover(int diagnosticoId)
        {
            try
            {
                Diagnostico diagnosticoParaRemover = ObterPorId(diagnosticoId);
                diagnosticos.Remove(diagnosticoParaRemover);
                return true;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifica a existência de um diagnóstico no repositório.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico a ser verificado.</param>
        /// <returns><c>true</c> se o diagnóstico existir, <c>false</c> caso contrário.</returns>
        public bool Existe(int diagnosticoId)
        {
            try
            {
                Diagnostico diagnostico = ObterPorId(diagnosticoId);
                return diagnostico != null;
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
        /// Obtém um diagnóstico pelo ID.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico a ser obtido.</param>
        /// <returns>O diagnóstico correspondente ou <c>null</c> se não for encontrado.</returns>
        public Diagnostico ObterPorId(int diagnosticoId)
        {
            if (diagnosticos == null) throw new ColecaoNaoInicializadaException();
            return diagnosticos.FirstOrDefault(c => c.Id == diagnosticoId);
        }

        /// <summary>
        /// Adiciona um diagnóstico simplificado ao repositório.
        /// </summary>
        /// <param name="diagnosticoLight">Objeto do tipo <c>DiagnosticoLight</c> a ser adicionado.</param>
        /// <returns><c>true</c> se o diagnóstico foi adicionado com sucesso.</returns>
        public bool AdicionarLight(DiagnosticoLight diagnosticoLight)
        {
            if (Existe(diagnosticoLight.Id)) throw new EntidadeJaExisteException();
            Diagnostico diagnostico = new Diagnostico(diagnosticoLight.Id, diagnosticoLight.DataDiagnostico, diagnosticoLight.ConsultaId);
            if (!Adicionar(diagnostico)) throw new InvalidOperationException();
            return true;
        }

        /// <summary>
        /// Obtém um diagnóstico simplificado a partir do seu ID.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico a ser obtido.</param>
        /// <returns>O diagnóstico simplificado ou <c>null</c> se não for encontrado.</returns>
        public DiagnosticoLight ObterDiagnosticoLight(int diagnosticoId)
        {
            try
            {
                Diagnostico diagnostico = ObterPorId(diagnosticoId);
                return new DiagnosticoLight(diagnostico.Id, diagnostico.DataDiagnostico, diagnostico.ConsultaId);
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Associa um diagnóstico a uma consulta.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico a ser associado.</param>
        /// <param name="consultaId">ID da consulta a ser associada.</param>
        /// <returns><c>true</c> se a associação foi bem-sucedida.</returns>
        public bool AssociarConsultaDiagnostico(int diagnosticoId, int consultaId)
        {
            try
            {
                Diagnostico diagnostico = ObterPorId(diagnosticoId);
                diagnostico.AssociarConsulta(consultaId);
                return true;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Obtém o ID da consulta associada a um diagnóstico.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico.</param>
        /// <returns>O ID da consulta associada.</returns>
        public int ObterConsultaIdDiagnostico(int diagnosticoId)
        {
            try
            {
                Diagnostico diagnostico = ObterPorId(diagnosticoId);
                return diagnostico.ConsultaId;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Adiciona um texto de descrição a um diagnóstico.
        /// </summary>
        /// <param name="diagnosticoId">ID do diagnóstico.</param>
        /// <param name="texto">Texto a ser adicionado como descrição.</param>
        /// <returns><c>true</c> se a descrição foi adicionada com sucesso.</returns>
        public bool AdicionarTextoDescricao(int diagnosticoId, string texto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(texto)) return false;
                Diagnostico diagnostico = ObterPorId(diagnosticoId);
                diagnostico.AdicionarTextoDescricao(texto);
                return true;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Exporta todos os diagnósticos para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro onde os dados serão exportados.</param>
        /// <returns><c>true</c> se a exportação for bem-sucedida, <c>false</c> caso contrário.</returns>
        public bool ExportarDiagnosticos(string nomeFicheiro)
        {
            try
            {
                using (Stream stream = File.Open(nomeFicheiro, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, diagnosticosRepositorioId);
                    bin.Serialize(stream, diagnosticos);
                }
                return true;
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

