/// <file>
/// <summary>Definição da classe Paciente, representando um paciente no sistema de gestão de saúde.</summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe Paciente, que herda da classe Pessoa e
/// inclui atributos e métodos específicos relacionados a pacientes, como número de utente,
/// diagnósticos e consultas.
/// </remarks>
/// <author>Pedro Ribeiro nº27960 LESI</author>
/// <date>Dezembro de 2024</date>

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
    /// Classe que representa um paciente no sistema de gestão de saúde.
    /// </summary>
    /// <remarks>
    /// A classe Paciente herda da classe Pessoa e adiciona funcionalidades específicas
    /// para gerir informações relacionadas a pacientes, como número de utente, diagnósticos
    /// e consultas.
    /// </remarks>
    public class Paciente : Pessoa
    {
        #region Atributos

        /// <summary>Número de utente do paciente.</summary>
        int numeroUtente;

        /// <summary>Identificador único de diagnósticos associados ao paciente.</summary>
        int diagnosticosId;

        /// <summary>Identificador de consultas do paciente.</summary>
        int consultasId;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para criar um paciente vazio.
        /// </summary>
        public Paciente()
        {
        }

        /// <summary>
        /// Construtor para criar um paciente com id, nome e número de utente.
        /// </summary>
        /// <param name="id">Identificador do paciente.</param>
        /// <param name="nome">Nome do paciente.</param>
        /// <param name="numUt">Número de utente do paciente.</param>
        public Paciente(int id, string nome, int numUt)
        {
            this.Id = id;
            this.Nome = nome;
            numeroUtente = numUt;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o número de utente do paciente.
        /// </summary>
        public int NumeroUtente
        {
            get { return numeroUtente; }
        }

        /// <summary>
        /// Obtém o identificador de diagnósticos do paciente.
        /// </summary>
        public int DiagnosticosId
        {
            get { return diagnosticosId; }
        }

        /// <summary>
        /// Obtém o identificador de consultas do paciente.
        /// </summary>
        public int ConsultasId
        {
            get { return consultasId; }
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Verifica se a instância atual é igual a um objeto especificado.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com a instância atual.</param>
        /// <returns>
        /// Retorna <c>true</c> se o objeto especificado for igual à instância atual; caso contrário, retorna <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Paciente outroPaciente)
            {
                return base.Equals(outroPaciente) && this.numeroUtente == outroPaciente.numeroUtente;
            }
            return false;
        }

        /// <summary>
        /// Gera o código hash da instância.
        /// </summary>
        /// <returns>
        /// Retorna o código hash da instância.
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
