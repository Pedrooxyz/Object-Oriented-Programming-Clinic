/// <summary>
/// Repositório responsável pela gestão de exames num sistema de saúde.
/// </summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe <c>ExamesRepositorio</c>, que gere operações de adição, 
/// remoção, verificação da existência e obtenção de exames. Adicionalmente, permite calcular o custo 
/// total dos exames realizados.
/// </remarks>
/// <author>PedroRibeiro nº27960 LESI</author>
/// <date>dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetosNegocio.ClassesLight;
using Dados.Entidades;
using Dados.Interfaces;
using TrataProblemas;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados.Repositorios
{
    [Serializable]
    /// <summary>
    /// Classe responsável pela gestão de exames num repositório.
    /// </summary>
    public class ExamesRepositorio : IRepositorio<Exame>
    {
        #region Atributos

        /// <summary>
        /// Contador estático usado para gerar IDs únicos para cada repositório.
        /// </summary>
        static int contadorRepositorio = 0;

        /// <summary>
        /// ID único atribuído ao repositório atual.
        /// </summary>
        int examesRepositorioId;

        /// <summary>
        /// Lista que armazena os exames associados a este repositório.
        /// </summary>
        List<Exame> exames;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor que inicializa o repositório e atribui um ID único.
        /// </summary>
        /// <remarks>
        /// Este construtor inicializa a lista de exames e incrementa o contador estático para garantir 
        /// que cada repositório tem um ID exclusivo.
        /// </remarks>
        public ExamesRepositorio()
        {
            examesRepositorioId = ++contadorRepositorio;
            exames = new List<Exame>();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um exame ao repositório.
        /// </summary>
        /// <param name="exame">Objeto do tipo 'Exame' a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> se o exame foi adicionado com sucesso, <c>false</c> caso contrário.</returns>
        public bool Adicionar(Exame exame)
        {
            exames.Add(exame);
            return true;
        }

        /// <summary>
        /// Remove um exame do repositório.
        /// </summary>
        /// <param name="idExame">ID do exame a ser removido.</param>
        /// <returns>Retorna <c>true</c> se o exame foi removido, <c>false</c> se não foi encontrado.</returns>
        public bool Remover(int idExame)
        {
            try
            {
                Exame exameParaRemover = ObterPorId(idExame);
                return true; ;
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
        /// Verifica a existência de um exame no repositório.
        /// </summary>
        /// <param name="idExame">ID do exame a ser verificado.</param>
        /// <returns>Retorna <c>true</c> se o exame existir, <c>false</c> caso contrário.</returns>
        public bool Existe(int idExame)
        {
            try
            {
                Exame exame = ObterPorId(idExame);
                return exame != null;
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
        /// Obtém um exame pelo ID.
        /// </summary>
        /// <param name="exameId">ID do exame a ser obtido.</param>
        /// <returns>O exame correspondente ou <c>null</c> se não for encontrado.</returns>
        public Exame ObterPorId(int exameId)
        {
            if (exames == null) throw new ColecaoNaoInicializadaException();
            return exames.FirstOrDefault(e => e.Id == exameId);
        }

        /// <summary>
        /// Calcula o custo total de todos os exames no repositório.
        /// </summary>
        /// <returns>O custo total de todos os exames no repositório.</returns>
        public double CalcularCustoTotal()
        {
            return exames.Sum(e => e.Custo);
        }

        /// <summary>
        /// Adiciona um exame a partir de um objeto <c>ExameLight</c>.
        /// </summary>
        /// <param name="exameLight">Objeto do tipo 'ExameLight' a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> se o exame foi adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="EntidadeJaExisteException">Lançada se o exame já existir.</exception>
        public bool AdicionarLight(ExameLight exameLight)
        {
            if (Existe(exameLight.Id)) throw new EntidadeJaExisteException();
            Exame exame = new Exame(exameLight.Id, exameLight.Tipo, exameLight.Data, exameLight.PacienteId);
            if (!Adicionar(exame)) throw new InvalidOperationException();
            return true;
        }

        /// <summary>
        /// Obtém um exame em formato <c>ExameLight</c> a partir de seu ID.
        /// </summary>
        /// <param name="exameId">ID do exame a ser obtido.</param>
        /// <returns>O exame correspondente em formato <c>ExameLight</c>.</returns>
        public ExameLight ObterExameLight(int exameId)
        {
            try
            {
                Exame exame = ObterPorId(exameId);
                return new ExameLight(exame.Id, exame.Tipo, exame.DataExame, exame.PacienteId);
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
        /// Atualiza o resultado de um exame.
        /// </summary>
        /// <param name="exameId">ID do exame a ser atualizado.</param>
        /// <param name="novoResultado">Novo resultado a ser atribuído ao exame.</param>
        /// <returns>Retorna <c>true</c> se o resultado foi atualizado com sucesso, <c>false</c> caso contrário.</returns>
        public bool AtualizarResultadoExame(int exameId, string novoResultado)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(novoResultado)) return false;

                Exame exame = ObterPorId(exameId);

                exame.AtualizarResultado(novoResultado);
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
        /// Atualiza o custo de um exame.
        /// </summary>
        /// <param name="exameId">ID do exame a ser atualizado.</param>
        /// <param name="novoCusto">Novo custo a ser atribuído ao exame.</param>
        /// <returns>Retorna <c>true</c> se o custo foi atualizado com sucesso, <c>false</c> caso contrário.</returns>
        public bool AtualizarCustoExame(int exameId, double novoCusto)
        {
            try
            {
                Exame exame = ObterPorId(exameId);
                exame.AtualizarCusto(novoCusto);
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
        /// Exporta todas os exames para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro onde os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, <c>false</c> caso contrário.</returns>
        public bool ExportarExames(string nomeFicheiro)
        {
            try
            {
                using (Stream stream = File.Open(nomeFicheiro, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, examesRepositorioId);
                    bin.Serialize(stream, exames);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Ordena a lista de exames no repositório com base no custo dos exames.
        /// </summary>
        /// <returns>Retorna <c>true</c> se a lista de exames foi ordenada com sucesso. Se a lista for nula, retorna <c>false</c>.</returns>
        public bool OrdenarExamesPorCusto()
        {
            if (exames ==null) return false;
            exames.Sort();
            return true;
        }

        #endregion

        #endregion
    }
}
