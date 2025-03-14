/// <file>
/// Definição da classe Exame, representando um exame realizado por um paciente.
/// 
/// Este ficheiro contém a implementação da classe Exame, com atributos como ID, data do exame, 
/// identificador do paciente, tipo e resultado do exame, e custo. Além disso, são definidos métodos 
/// para comparar e gerar códigos hash para instâncias de Exame.
/// 
/// Autor: Pedro Ribeiro nº27960 LESI
/// Data: Dezembro de 2024
/// </file>

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
    /// Classe para representar um exame realizado por um paciente.
    /// 
    /// A classe Exame é usada para armazenar informações sobre exames realizados por pacientes,
    /// incluindo dados como tipo de exame, resultado, custo, e a data em que o exame foi realizado.
    /// </summary>
    public class Exame : IComparable<Exame>
    {

        #region Atributos

        /// <summary>
        /// Identificador único do exame.
        /// </summary>
        int id;

        /// <summary>
        /// Data e hora em que o exame foi realizado.
        /// </summary>
        DateTime dataExame;

        /// <summary>
        /// Identificador do paciente que realizou o exame.
        /// </summary>
        int pacienteId;

        /// <summary>
        /// Tipo do exame realizado.
        /// </summary>
        string tipo;

        /// <summary>
        /// Resultado do exame realizado.
        /// </summary>
        string resultado;

        /// <summary>
        /// Custo do exame realizado.
        /// </summary>
        double custo;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para criar um exame vazio.
        /// 
        /// Este construtor cria um exame sem dados iniciais, sendo possível definir os atributos posteriormente.
        /// </summary>
        public Exame()
        {
        }

        /// <summary>
        /// Construtor para criar um exame com parâmetros básicos.
        /// 
        /// Este construtor cria um exame com os parâmetros fornecidos para id, tipo, data e identificador do paciente.
        /// </summary>
        /// <param name="id">Identificador único do exame.</param>
        /// <param name="tipo">Tipo do exame realizado.</param>
        /// <param name="dataHora">Data e hora em que o exame foi realizado.</param>
        /// <param name="pacienteId">Identificador do paciente que realizou o exame.</param>
        public Exame(int id, string tipo, DateTime dataHora, int pacienteId)
        {
            this.id = id;
            this.tipo = tipo;
            this.dataExame = dataHora;
            this.pacienteId = pacienteId;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o identificador único do exame.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Obtém a data e hora em que o exame foi realizado.
        /// </summary>
        public DateTime DataExame
        {
            get { return dataExame; }
        }

        /// <summary>
        /// Obtém o identificador do paciente que realizou o exame.
        /// </summary>
        public int PacienteId
        {
            get { return pacienteId; }
        }

        /// <summary>
        /// Obtém o tipo do exame.
        /// </summary>
        public string Tipo
        {
            get { return tipo; }
        }

        /// <summary>
        /// Obtém o resultado do exame.
        /// </summary>
        public string Resultado
        {
            get { return resultado; }
        }

        /// <summary>
        /// Obtém o custo do exame.
        /// </summary>
        public double Custo
        {
            get { return custo; }
        }

        #endregion

        #region Outras Funções

        /// <summary>
        /// Verifica se a instância atual é igual a um objeto especificado.
        /// 
        /// Este método compara o exame atual com outro objeto do tipo Exame.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com a instância atual.</param>
        /// <returns>Retorna <c>true</c> se o objeto especificado for igual à instância atual; caso contrário, retorna <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Exame exame)
            {
                return Tipo == exame.Tipo && Custo == exame.Custo;
            }
            return false;
        }

         /// <summary>
        /// Gera o código hash da instância atual da classe <see cref="Exame"/>.
        /// 
        /// Este método calcula o código hash para a instância do exame com base no tipo e custo do exame.
        /// </summary>
        /// <returns>O código hash calculado.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Atualiza o resultado do exame.
        /// 
        /// Este método permite alterar o resultado de um exame para o valor especificado.
        /// </summary>
        /// <param name="novoResultado">O novo resultado a ser atribuído ao exame.</param>
        /// <returns>Retorna <c>true</c> se o resultado for atualizado com sucesso, <c>false</c> caso contrário.</returns>
        public bool AtualizarResultado(string novoResultado)
        {
            if (string.IsNullOrWhiteSpace(novoResultado))
            {
                return false; 
            }

            resultado = novoResultado; 
            return true;
        }

        /// <summary>
        /// Atualiza o custo do exame.
        /// 
        /// Este método permite alterar o custo de um exame para o valor especificado.
        /// </summary>
        /// <param name="novoCusto">O novo custo a ser atribuído ao exame.</param>
        /// <returns>Retorna <c>true</c> se o custo for atualizado com sucesso, <c>false</c> caso contrário.</returns>
        public bool AtualizarCusto(double novoCusto)
        {
            if (novoCusto <= 0)
            {
                return false; // custo inválido, tem que ser maior ou igual a 0.
            }

            custo = novoCusto;
            return true;
        }

        /// <summary>
        /// Exporta os dados do exame para um ficheiro binário.
        /// 
        /// Este método permite exportar os dados do exame para um ficheiro no formato binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, <c>false</c> caso contrário.</returns>
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

        /// <summary>
        /// Compara o exame atual com outro exame baseado no custo.
        /// 
        /// Este método implementa a comparação entre dois exames para ordenação.
        /// </summary>
        /// <param name="outroExame">O exame a ser comparado com o exame atual.</param>
        /// <returns>Retorna um valor negativo se o exame atual for menor, 
        /// um valor positivo se for maior, ou zero se forem iguais.</returns>
        public int CompareTo(Exame outroExame)
        {
            if (outroExame == null) return 1;

            return this.custo.CompareTo(outroExame.custo);
        }
        
        #endregion

        #endregion
    }
}
