/// <file>
/// <summary>Definição da interface IRepositorio, que representa um repositório genérico.</summary>
/// <remarks>
/// Este ficheiro contém a definição da interface IRepositorio, que define operações 
/// básicas de acesso e manipulação de dados de um tipo genérico. A interface inclui 
/// métodos para adicionar, remover, verificar existência e obter elementos por ID.
/// </remarks>
/// <author>Pedro Ribeiro nº27960 LESI</author>
/// <date>Dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Interfaces
{
    /// <summary>
    /// Interface para repositórios genéricos que gerem entidades do tipo T.
    /// </summary>
    /// <remarks>
    /// A interface IRepositorio define operações básicas para a gestão de entidades 
    /// do tipo T, como adicionar, remover, verificar existência e obter um elemento 
    /// específico pelo seu identificador.
    /// </remarks>
    public interface IRepositorio<T>
    {
        /// <summary>
        /// Adiciona um item ao repositório.
        /// </summary>
        /// <param name="item">O item a ser adicionado ao repositório.</param>
        /// <returns>Retorna <c>true</c> se o item for adicionado com sucesso, caso contrário retorna <c>false</c>.</returns>
        bool Adicionar(T item);

        /// <summary>
        /// Remove um item do repositório com base no seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item a ser removido.</param>
        /// <returns>Retorna <c>true</c> se o item for removido com sucesso, caso contrário retorna <c>false</c>.</returns>
        bool Remover(int id);

        /// <summary>
        /// Verifica se um item existe no repositório com base no seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item a ser verificado.</param>
        /// <returns>Retorna <c>true</c> se o item existir no repositório, caso contrário retorna <c>false</c>.</returns>
        bool Existe(int id);

        /// <summary>
        /// Obtém um item do repositório com base no seu ID.
        /// </summary>
        /// <param name="id">O identificador único do item a ser obtido.</param>
        /// <returns>Retorna o item com o ID especificado, ou <c>null</c> se o item não for encontrado.</returns>
        T ObterPorId(int id);
    }
}
