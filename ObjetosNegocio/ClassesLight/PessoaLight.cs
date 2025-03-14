/// @file
/// @brief Classe Light que contém informações básicas de uma pessoa.
/// 
/// Este ficheiro define a classe `PessoaLight`, que representa uma pessoa com atributos básicos como ID e nome.
/// 
/// @date dezembro de 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosNegocio.ClassesLight
{
    /// @class PessoaLight
    /// @brief Classe Light que representa informações básicas sobre uma pessoa.
    /// 
    /// A classe `PessoaLight` contém apenas os dados essenciais sobre uma pessoa, como o ID e o nome. 
    /// Esta classe é utilizada para operações simplificadas onde apenas informações básicas são necessárias.
    /// 
    /// @date dezembro de 2024
    public class PessoaLight
    {
        #region Atributos

        /// @brief Identificador único da pessoa.
        int id;

        /// @brief Nome da pessoa.
        string nome;

        #endregion

        #region Metodos

        #region Propriedades

        /// @brief Obtém ou define o identificador único da pessoa.
        /// 
        /// Esta propriedade acessa o atributo `id`, que contém o identificador único da pessoa.
        public int Id 
        { 
            get {return id;}
            set {id = value;}
        }

        /// @brief Obtém ou define o nome da pessoa.
        /// 
        /// Esta propriedade acessa o atributo `nome`, que contém o nome da pessoa.
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        #endregion

        #endregion
    }
}

