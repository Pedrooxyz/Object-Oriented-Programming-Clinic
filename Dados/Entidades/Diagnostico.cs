/// <file>
/// Definição da classe Diagnostico, representando um diagnóstico médico associado a uma consulta.
/// 
/// Este ficheiro contém a implementação da classe Diagnostico, com atributos como ID, descrição,
/// data do diagnóstico e identificador da consulta. Inclui também métodos para adicionar texto à
/// descrição e para comparar instâncias de Diagnostico.
/// 
/// Autor: PedroRibeiro nº27960 LESI
/// Data: dezembro de 2024
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
    /// Representa um diagnóstico médico associado a uma consulta.
    /// 
    /// A classe Diagnostico é utilizada para armazenar informações relacionadas a um diagnóstico médico,
    /// incluindo a descrição, data e a consulta associada.
    /// </summary>
    public class Diagnostico
    {
        #region Atributos

        /// <summary>
        /// Identificador único do diagnóstico.
        /// Permite distinguir cada diagnóstico no sistema.
        /// </summary>
        int id;

        /// <summary>
        /// Descrição do diagnóstico.
        /// Contém a descrição textual do diagnóstico médico.
        /// </summary>
        string descricao;

        /// <summary>
        /// Data em que o diagnóstico foi realizado.
        /// Representa o momento em que o diagnóstico foi efetuado.
        /// </summary>
        DateTime dataDiagnostico;

        /// <summary>
        /// Identificador da consulta associada ao diagnóstico.
        /// Este identificador está ligado à consulta que originou o diagnóstico.
        /// </summary>
        int consultaId;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para criar um diagnóstico vazio.
        /// </summary>
        public Diagnostico()
        {
            this.id = 0;
            this.descricao = string.Empty;
            this.dataDiagnostico = DateTime.MinValue;
            this.consultaId = 0;
        }

        /// <summary>
        /// Construtor para criar um diagnóstico com dados básicos.
        /// </summary>
        /// <param name="id">Identificador único do diagnóstico.</param>
        /// <param name="dataDiagnostico">Data em que o diagnóstico foi realizado.</param>
        /// <param name="consultaId">Identificador da consulta associada ao diagnóstico.</param>
        public Diagnostico(int id, DateTime dataDiagnostico, int consultaId)
        {
            this.id = id;
            this.dataDiagnostico = dataDiagnostico;
            this.consultaId = consultaId;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o identificador único do diagnóstico.
        /// </summary>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Obtém ou define a descrição do diagnóstico.
        /// </summary>
        public string Descricao
        {
            get { return descricao; }
        }

        /// <summary>
        /// Obtém a data do diagnóstico.
        /// </summary>
        public DateTime DataDiagnostico
        {
            get { return dataDiagnostico; }
        }

        /// <summary>
        /// Obtém ou define o identificador da consulta associada ao diagnóstico.
        /// </summary>
        public int ConsultaId
        {
            get { return consultaId; }
        }

        #endregion

        #region Outras Funcoes

        /// <summary>
        /// Adiciona texto à descrição do diagnóstico.
        /// </summary>
        /// <param name="texto">Texto a ser adicionado à descrição do diagnóstico.</param>
        /// <returns>Retorna <c>true</c> se o texto for adicionado com sucesso; <c>false</c> caso contrário.</returns>
        public bool AdicionarTextoDescricao(string texto)
        {
            if (!string.IsNullOrWhiteSpace(texto))
            {
                descricao += " " + texto;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verifica se a instância atual é igual a um objeto especificado.
        /// </summary>
        /// <param name="obj">Objeto a ser comparado com a instância atual.</param>
        /// <returns>Retorna <c>true</c> se o objeto especificado for igual à instância atual; caso contrário, retorna <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Diagnostico outroDiagnostico)
            {
                return this.Descricao == outroDiagnostico.Descricao && this.dataDiagnostico == outroDiagnostico.dataDiagnostico;
            }
            return false;
        }

        /// <summary>
        /// Gera o código hash da instância atual da classe <see cref="Diagnostico"/>.
        /// </summary>
        /// <returns>O código hash calculado com base na descrição e na data do diagnóstico.</returns>
        public override int GetHashCode()
        {
            return this.Descricao.GetHashCode() ^ this.dataDiagnostico.GetHashCode();
        }

        /// <summary>
        /// Associa um diagnóstico a uma consulta específica.
        /// </summary>
        /// <param name="consultaId">Identificador da consulta a ser associada ao diagnóstico.</param>
        /// <returns>Retorna <c>true</c> se a associação for bem-sucedida; <c>false</c> caso contrário.</returns>
        public bool AssociarConsulta(int consultaId)
        {
            this.consultaId = consultaId;
            return true;
        }

        /// <summary>
        /// Exporta os dados da classe para um ficheiro de texto.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida; ou <c>false</c> em caso de erro.</returns>
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
