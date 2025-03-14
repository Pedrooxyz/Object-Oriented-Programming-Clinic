/// <summary>
/// Define a interface para a gestão de exames no sistema.
/// </summary>
/// <author>Pedro Ribeiro nº 27960</author>
/// <date>18 de dezembro de 2024</date>



using ObjetosNegocio.ClassesLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Repositorios;
using TrataProblemas;

namespace RegrasNegocio.Interfaces
{
    /// <summary>
    /// Interface para a gestão dos exames no sistema.
    /// </summary>
    public interface IGestaoExames
    {
        /// <summary>
        /// Adiciona um novo exame ao sistema.
        /// </summary>
        /// <param name="exameLight">Objeto que contém as informações mínimas de um exame.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pelo exame.</param>
        /// <returns><c>true</c> se o exame for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        bool AdicionarExame(ExameLight exameLight, MedicoLight medicoLight);

        /// <summary>
        /// Elimina um exame existente no sistema.
        /// </summary>
        /// <param name="exameId">Identificador único do exame a ser eliminado.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela eliminação do exame.</param>
        /// <returns><c>true</c> se o exame for eliminado com sucesso, <c>false</c> caso contrário.</returns>
        bool EliminarExame(int exameId, MedicoLight medicoLight);

        /// <summary>
        /// Verifica se um exame existe no repositório.
        /// </summary>
        /// <param name="exameId">Identificador único do exame a ser verificado.</param>
        /// <returns><c>true</c> se o exame existir, <c>false</c> caso contrário.</returns>
        bool ExisteExame(int exameId);

        /// <summary>
        /// Obtém um exame pelo seu identificador.
        /// </summary>
        /// <param name="exameId">Identificador único do exame a ser obtido.</param>
        /// <returns>Um objeto do tipo <see cref="ExameLight"/> representando o exame, ou <c>null</c> se não for encontrado.</returns>
        ExameLight ObterExame(int exameId);

        /// <summary>
        /// Atualiza o resultado de um exame existente.
        /// </summary>
        /// <param name="exameId">Identificador único do exame.</param>
        /// <param name="novoResultado">Novo resultado a ser associado ao exame.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela atualização do exame.</param>
        /// <returns><c>true</c> se o resultado for atualizado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o exame não existir.</exception>
        bool AtualizarResultadoDoExame(int exameId, string novoResultado, MedicoLight medicoLight);

        /// <summary>
        /// Atualiza o custo de um exame existente.
        /// </summary>
        /// <param name="exameId">Identificador único do exame.</param>
        /// <param name="novoCusto">Novo custo a ser associado ao exame.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela atualização do custo.</param>
        /// <returns><c>true</c> se o custo for atualizado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o exame não existir.</exception>
        bool AtualizarCustoDoExame(int exameId, double novoCusto, MedicoLight medicoLight);

        /// <summary>
        /// Exporta os exames para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns><c>true</c> se a exportação for bem-sucedida, <c>false</c> em caso de erro.</returns>
        bool ExportarExamesParaFicheiro(string nomeFicheiro);
    }
}
