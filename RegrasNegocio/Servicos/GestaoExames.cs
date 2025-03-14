/// <summary>
/// Classe de serviços para a gestão dos exames no sistema.
/// </summary>
/// <exception cref="ArgumentNullException">Lançada quando algum dos parâmetros passados para os métodos é nulo.</exception>
/// <exception cref="KeyNotFoundException">Lançada quando o exame especificado não for encontrado.</exception>

using System;

using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Interfaces;
using TrataProblemas;



namespace RegrasNegocio.Servicos
{
    /// <summary>
    /// Classe responsável pela gestão dos exames no sistema.
    /// </summary>
    public class GestaoExames : IGestaoExames
    {
        #region Atributos

        /// <summary>
        /// Repositório responsável pela manipulação de exames.
        /// </summary>
        ExamesRepositorio exameRepositorio;

        #endregion

        #region Metodos

        #region Construtores

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public GestaoExames()
        {
            exameRepositorio = new ExamesRepositorio();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um novo exame ao sistema.
        /// </summary>
        /// <param name="exameLight">Objeto que contém as informações mínimas de um exame.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pelo exame.</param>
        /// <returns>Retorna <c>true</c> se o exame for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        public bool AdicionarExame(ExameLight exameLight, MedicoLight medicoLight)
        {
            if (exameLight == null) throw new ArgumentNullException(nameof(exameLight));
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();
            if (exameLight.Data < DateTime.Now) throw new ArgumentException(nameof(exameLight.Data));

            try
            {
                exameRepositorio.AdicionarLight(exameLight);
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
        /// Elimina um exame existente no sistema.
        /// </summary>
        /// <param name="exameId">Identificador único do exame a ser eliminado.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela eliminação do exame.</param>
        /// <returns>Retorna <c>true</c> se o exame for eliminado com sucesso, <c>false</c> caso contrário.</returns>
        public bool EliminarExame(int exameId, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                exameRepositorio.Remover(exameId);
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
        /// Verifica se um exame existe no repositório.
        /// </summary>
        /// <param name="exameId">Identificador único do exame a ser verificado.</param>
        /// <returns>Retorna <c>true</c> se o exame existir, <c>false</c> caso contrário.</returns>
        public bool ExisteExame(int exameId)
        {
            try
            {
                return exameRepositorio.Existe(exameId);
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
        /// Obtém um exame pelo seu identificador.
        /// </summary>
        /// <param name="exameId">Identificador único do exame a ser obtido.</param>
        /// <returns>Um objeto do tipo <c>ExameLight</c> representando o exame, ou <c>null</c> se não for encontrado.</returns>
        public ExameLight ObterExame(int exameId)
        {
            try
            {
                ExameLight exameLight = exameRepositorio.ObterExameLight(exameId);
                return exameLight;
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
        /// Atualiza o resultado de um exame existente.
        /// </summary>
        /// <param name="exameId">Identificador único do exame.</param>
        /// <param name="novoResultado">Novo resultado a ser associado ao exame.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela atualização do exame.</param>
        /// <returns>Retorna <c>true</c> se o resultado for atualizado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o exame não existir.</exception>
        public bool AtualizarResultadoDoExame(int exameId, string novoResultado, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            try
            {
                exameRepositorio.AtualizarResultadoExame(exameId, novoResultado);
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
        /// Atualiza o custo de um exame existente.
        /// </summary>
        /// <param name="exameId">Identificador único do exame.</param>
        /// <param name="novoCusto">Novo custo a ser associado ao exame.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela atualização do custo.</param>
        /// <returns>Retorna <c>true</c> se o custo for atualizado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o exame não existir.</exception>
        public bool AtualizarCustoDoExame(int exameId, double novoCusto, MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            if (novoCusto < 0) return false;

            try
            {
                exameRepositorio.AtualizarCustoExame(exameId, novoCusto);
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
        /// Exporta os exames para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, ou <c>false</c> em caso de erro.</returns>
        public bool ExportarExamesParaFicheiro(string nomeFicheiro)
        {
            try
            {
                bool sucesso = exameRepositorio.ExportarExames(nomeFicheiro);
                return sucesso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Ordena os exames por custo.
        /// </summary>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela ordenação dos exames.</param>
        /// <returns>Retorna <c>true</c> se a ordenação for bem-sucedida, <c>false</c> caso contrário.</returns>
        public bool OrdenarExames(MedicoLight medicoLight)
        {
            if (medicoLight == null) throw new ArgumentNullException(nameof(medicoLight));
            if (!medicoLight.PodeTomarDecisoes) throw new MedicoNaoAutorizadoException();

            if (!exameRepositorio.OrdenarExamesPorCusto())return false;
            return true; 
        }

        #endregion

        #endregion
    }
}
