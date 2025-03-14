/// <file>
/// <summary>Repositório responsável pela gestão de consultas num sistema de saúde.</summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe `ConsultasRepositorio`, que gere operações de adição, 
/// remoção, verificação da existência e obtenção de consultas associadas a pacientes.
/// </remarks>
/// <author>Pedro Ribeiro nº27960 LESI</author>
/// <date>Dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Entidades;
using Dados.Interfaces;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ObjetosNegocio.ClassesLight;
using TrataProblemas;
using System.Linq.Expressions;

namespace Dados.Repositorios
{
    [Serializable]
    /// <summary>
    /// Classe responsável pela gestão de consultas num repositório.
    /// </summary>
    /// <remarks>
    /// A classe `ConsultasRepositorio` fornece funcionalidades para manipular consultas associadas a pacientes. 
    /// As operações incluem adicionar, remover, verificar a existência e obter consultas específicas ou todas as 
    /// consultas associadas a pacientes.
    /// </remarks>
    /// <date>Dezembro de 2024</date>
    public class ConsultasRepositorio : IRepositorio<Consulta>
    {
        #region Atributos

        /// <summary>
        /// Contador estático usado para gerar IDs únicos para cada repositório.
        /// </summary>
        static int contadorRepositorio = 0;

        /// <summary>
        /// ID único atribuído ao repositório atual.
        /// </summary>
        int consultasRepositorioId;

        /// <summary>
        /// Lista que armazena as consultas associadas a este repositório.
        /// </summary>
        List<Consulta> consultas;

        #endregion

        #region Métodos

        #region Propriedades

        /// <summary>
        /// Obtém o ID do repositório de consultas.
        /// </summary>
        public int ConsultasRepositorioId
        {
            get { return consultasRepositorioId; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor que inicializa o repositório com uma lista de consultas vazia e atribui um ID único.
        /// </summary>        
        public ConsultasRepositorio()
        {
            consultasRepositorioId = ++contadorRepositorio;
            consultas = new List<Consulta>();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona uma consulta ao repositório.
        /// </summary>
        /// <param name="consulta">Objeto do tipo `Consulta` a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> se a consulta for adicionada com sucesso, caso contrário retorna <c>false</c>.</returns>
        public bool Adicionar(Consulta consulta)
        {
            consultas.Add(consulta); //O metodo Add retorna void
            return true;
        }

        /// <summary>
        /// Remove uma consulta do repositório.
        /// </summary>
        /// <param name="consultaId">ID da consulta a ser removida.</param>
        /// <returns>Retorna <c>true</c> se a consulta foi removida, <c>false</c> se não foi encontrada.</returns>
        public bool Remover(int consultaId)
        {
            try
            {
                Consulta consultaParaRemover = ObterPorId(consultaId);
                consultas.Remove(consultaParaRemover);
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
        /// Verifica a existência de uma consulta no repositório.
        /// </summary>
        /// <param name="consultaId">ID da consulta a ser verificada.</param>
        /// <returns>Retorna <c>true</c> se a consulta existir, <c>false</c> caso contrário.</returns>
        public bool Existe(int consultaId)
        {
            try
            {
                Consulta consulta = ObterPorId(consultaId);
                return consulta != null;
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
        /// Obtém uma consulta pelo ID.
        /// </summary>
        /// <param name="consultaId">ID da consulta a ser obtida.</param>
        /// <returns>A consulta correspondente ou <c>null</c> se não for encontrada.</returns>
        public Consulta ObterPorId(int consultaId)
        {
            if (consultas == null) throw new ColecaoNaoInicializadaException();

            return consultas.FirstOrDefault(c => c.Id == consultaId);
        }

        /// <summary>
        /// Exporta todas as consultas para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro onde os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, <c>false</c> caso contrário.</returns>
        public bool ExportarConsultas(string nomeFicheiro)
        {
            try
            {
                using (Stream stream = File.Open(nomeFicheiro, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, consultasRepositorioId);
                    bin.Serialize(stream, consultas);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma consulta light ao repositório.
        /// </summary>
        /// <param name="consultaLight">Objeto do tipo `ConsultaLight` a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> se a consulta for adicionada com sucesso.</returns>
        public bool AdicionarLight(ConsultaLight consultaLight)
        {
            if (Existe(consultaLight.Id)) throw new EntidadeJaExisteException();
            Consulta consulta = new Consulta(consultaLight.Id, consultaLight.Data, consultaLight.PacienteId);
            if (!Adicionar(consulta)) throw new InvalidOperationException();
            return true;
        }

        /// <summary>
        /// Obtém uma consulta light a partir do ID da consulta.
        /// </summary>
        /// <param name="consultaId">ID da consulta a ser obtida.</param>
        /// <returns>Retorna um objeto `ConsultaLight` correspondente à consulta.</returns>
        public ConsultaLight ObterConsultaLight(int consultaId)
        {
            try
            {
                Consulta consulta = ObterPorId(consultaId);
                return new ConsultaLight(consulta.Id, consulta.PacienteId, consulta.MedicoId, consulta.Data);
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

        #endregion

        #endregion
    }
}
