/// <file>
/// <summary>Definição da classe Medico, representando um médico no sistema.</summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe Medico, que herda da classe Pessoa e
/// inclui atributos específicos como especialidade e número de ordem, além de métodos para 
/// comparar a instância atual com outra e gerar um código hash.
/// </remarks>
/// <author>PedroRibeiro nº27960 LESI</author>
/// <date>Dezembro de 2024</date>

using ObjetosNegocio.ClassesLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Entidades
{
    [Serializable]

    /// <summary>
    /// Classe para representar um médico, herdando de Pessoa.
    /// </summary>
    /// <remarks>
    /// A classe Medico representa um médico no sistema e herda as propriedades básicas
    /// da classe Pessoa. Inclui atributos específicos, como especialidade e número de ordem,
    /// além de métodos para comparar instâncias e gerar códigos hash.
    /// </remarks>
    public class Medico : Pessoa
    {
        #region Atributos

        /// <summary>Especialidade do médico.</summary>
        string especialidade;

        /// <summary>Número de ordem do médico.</summary>
        int numeroCedula;

        /// <summary>Variável de permissão de gestão.</summary>
        bool podeTomarDecisoes;

        /// <summary>Identificador do repositório de consultas.</summary>
        int consultasId;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para criar um médico vazio.
        /// </summary>
        /// <remarks>Este construtor inicializa um médico sem definir dados específicos.</remarks>
        public Medico() : base()
        {
            podeTomarDecisoes = true;
        }

        /// <summary>
        /// Construtor para criar um médico com um identificador, nome e número de cédula.
        /// </summary>
        /// <param name="id">Identificador único do médico.</param>
        /// <param name="Nome">Nome do médico.</param>
        /// <param name="NumeroCedula">Número de ordem do médico.</param>
        public Medico(int id, string Nome, int NumeroCedula) : base()
        {
            podeTomarDecisoes = true;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém a especialidade do médico.
        /// </summary>
        public string Especialidade
        {
            get { return especialidade; }
        }

        /// <summary>
        /// Obtém o número de ordem do médico.
        /// </summary>
        public int NumeroCedula
        {
            get { return numeroCedula; }
        }

        /// <summary>
        /// Obtém um valor que indica se o médico pode adicionar consultas.
        /// </summary>
        public bool PodeAdicionarConsulta
        {
            get { return podeTomarDecisoes; }
        }

        /// <summary>
        /// Obtém o identificador de consultas.
        /// </summary>
        public int ConsultasId
        {
            get { return consultasId; }
        }

        #endregion

        #region Outras Funções

        /// <summary>
        /// Verifica se a instância atual é igual a um objeto especificado.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com a instância atual.</param>
        /// <returns>
        /// Retorna <c>true</c> se o objeto especificado for igual à instância atual;
        /// caso contrário, retorna <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Medico outroMedico)
            {
                return base.Equals(obj);
            }
            return false;
        }

        /// <summary>
        /// Gera um código hash para a instância atual de <see cref="Medico"/>.
        /// </summary>
        /// <returns>
        /// O código hash da instância atual, baseado no hash gerado pela classe base <see cref="Pessoa"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Exporta os dados da classe para um ficheiro de texto.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>
        /// Retorna <c>true</c> se a exportação for bem-sucedida, ou <c>false</c> em caso de erro.
        /// </returns>
        public bool Exportar(string nomeFicheiro)
        {
            if (File.Exists(nomeFicheiro))
            {
                try
                {
                    Stream stream = File.Open(nomeFicheiro, FileMode.Create);
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, this);
                    stream.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return false;
        }

        #endregion

        #endregion

    }
}
