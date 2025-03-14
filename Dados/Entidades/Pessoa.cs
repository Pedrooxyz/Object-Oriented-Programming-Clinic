/// <file>
/// <summary>Definição da classe Pessoa, representando uma entidade básica no sistema.</summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe Pessoa, que inclui atributos básicos
/// como ID, nome, género e data de nascimento, além de métodos para gerir a sua igualdade 
/// e propriedades para acesso aos atributos.
/// </remarks>
/// <author>Pedro Ribeiro nº27960 LESI</author>
/// <date>Dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Entidades
{
    [Serializable]
    /// <summary>
    /// Classe base para representar uma pessoa.
    /// </summary>
    /// <remarks>
    /// A classe Pessoa é utilizada para representar uma entidade básica com informações
    /// como ID, nome, género e data de nascimento. Inclui métodos para manipular e 
    /// comparar objetos deste tipo.
    /// </remarks>
    public class Pessoa
    {
        #region Atributos

        /// <summary>Identificador único da pessoa.</summary>
        int id;

        /// <summary>Nome da pessoa.</summary>
        string nome;

        /// <summary>Género da pessoa.</summary>
        string genero;

        /// <summary>Data de nascimento da pessoa.</summary>
        DateTime dataNascimento;

        /// <summary>Identificador único de consultas associadas a Pessoa.</summary>
        int consultasId;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para criar uma pessoa vazia.
        /// </summary>
        public Pessoa() { }

        /// <summary>
        /// Construtor para criar uma pessoa com ID e nome.
        /// </summary>
        /// <param name="pessoaId">O identificador único da pessoa.</param>
        /// <param name="nomePessoa">O nome da pessoa.</param>
        public Pessoa(int pessoaId, string nomePessoa) //atributos de PessoaLight
        {
            this.nome = nomePessoa;
            this.id = pessoaId;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o ID da pessoa.
        /// </summary>
        public int Id
        {
            get { return id; }
            internal set { id = value; }
        }

        /// <summary>
        /// Obtém o nome da pessoa.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            internal set { nome = value; }  
        }

        /// <summary>
        /// Obtém o género da pessoa.
        /// </summary>
        public string Genero
        {
            get { return genero; }
        }

        /// <summary>
        /// Obtém a data de nascimento da pessoa.
        /// </summary>
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
        }

        #endregion

        #region Outras Funções

        /// <summary>
        /// Verifica se a instância atual é igual a um objeto especificado.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com a instância atual.</param>
        /// <returns>
        /// Retorna <c>true</c> se o objeto especificado for igual à instância atual; caso contrário, retorna <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Pessoa outraPessoa)
            {
                return this.Id == outraPessoa.Id;
            }
            return false;
        }

        /// <summary>
        /// Gera o código hash da instância.
        /// </summary>
        /// <returns>
        /// Retorna o código hash baseado no ID.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #region Tentativa de associar diretamente consultas ao consultasId de paciente e de medico
        /// <summary>
        /// Método comentado, que anteriormente associava um ID de repositório de consultas ao paciente.
        /// </summary>
        //public bool AssociarConsultasRepositorio(int repositorioId)
        //{
        //    consultasId = repositorioId;
        //    return true;
        //}
        #endregion

        /// <summary>
        /// Obtém o ID do repositório de consultas associado.
        /// </summary>
        /// <returns>
        /// O ID do repositório de consultas.
        /// </returns>
        public int ObterConsultasRepositorio()
        {
            return consultasId;
        }

        #endregion

        #endregion
    }
}
