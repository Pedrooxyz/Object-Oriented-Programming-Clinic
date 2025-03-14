/// <summary>
/// Definição da classe Consulta, representando uma consulta médica realizada a um paciente.
/// </summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe Consulta, com atributos como ID, data da consulta, 
/// identificadores do paciente e do médico, além de métodos para adicionar e remover exames, calcular 
/// o custo total da consulta e comparar instâncias de Consulta.
/// </remarks>
/// <author>Pedro Ribeiro nº27960 LESI</author>
/// <date>dezembro de 2024</date>

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
    /// Representa uma consulta médica realizada a um paciente por um médico.
    /// </summary>
    /// <remarks>
    /// A classe Consulta armazena informações sobre uma consulta, incluindo a data da consulta, 
    /// o paciente e o médico relacionados, e os exames realizados durante a consulta.
    /// </remarks>
    public class Consulta
    {
        #region Atributos

        /// <summary>
        /// Identificador único da consulta.
        /// </summary>
        /// <remarks>
        /// Este identificador permite distinguir cada consulta de forma única no sistema.
        /// </remarks>
        int id;

        /// <summary>
        /// Data e hora da consulta.
        /// </summary>
        /// <remarks>
        /// Representa o momento em que a consulta foi realizada.
        /// </remarks>
        DateTime data;

        /// <summary>
        /// Identificador do paciente que realizou a consulta.
        /// </summary>
        /// <remarks>
        /// Este identificador associa a consulta a um paciente específico.
        /// </remarks>
        int pacienteId;

        /// <summary>
        /// Identificador do médico responsável pela consulta.
        /// </summary>
        /// <remarks>
        /// Este identificador associa a consulta a um médico específico.
        /// </remarks>
        int medicoId;

        /// <summary>
        /// Identificador do repositório de exames associados à consulta.
        /// </summary>
        /// <remarks>
        /// Este identificador refere-se ao conjunto de exames realizados durante a consulta.
        /// </remarks>
        int examesRepositorioId;

        /// <summary>
        /// Identificador do repositório de diagnósticos associados à consulta.
        /// </summary>
        /// <remarks>
        /// Este identificador refere-se aos diagnósticos realizados durante a consulta.
        /// </remarks>
        int diagnosticosRepositorioId;

        /// <summary>
        /// Custo associado à consulta, que pode incluir os custos de exames e outros fatores.
        /// </summary>
        /// <remarks>
        /// Este valor representa o custo total da consulta, incluindo quaisquer exames realizados.
        /// </remarks>
        double custo;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor padrão para criar uma consulta vazia.
        /// </summary>
        /// <remarks>
        /// Este construtor inicializa a consulta com valores padrão.
        /// </remarks>
        public Consulta()
        {
            id = 0;
            data = DateTime.MinValue;
            pacienteId = 0;
            medicoId = 0;
            examesRepositorioId = 0;
            diagnosticosRepositorioId = 0;
        }

        /// <summary>
        /// Construtor para criar uma consulta com dados básicos (ConsultaLight).
        /// </summary>
        /// <param name="id">Identificador único da consulta.</param>
        /// <param name="data">Data da consulta.</param>
        /// <param name="pacienteId">Identificador do paciente relacionado à consulta.</param>
        /// <remarks>
        /// Este construtor permite criar uma consulta com informações mínimas, como ID, data e paciente.
        /// </remarks>
        public Consulta(int id, DateTime data, int pacienteId)
        {
            this.id = id;
            this.data = data;
            this.pacienteId = pacienteId;
            medicoId = 0;
            examesRepositorioId = 0;
            diagnosticosRepositorioId = 0;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o identificador único da consulta.
        /// </summary>
        /// <returns>O identificador único da consulta.</returns>
        public int Id
        {
            get { return id; }
        }

        /// <summary>
        /// Obtém a data e hora da consulta.
        /// </summary>
        /// <returns>A data e hora da consulta.</returns>
        public DateTime Data
        {
            get { return data; }
        }

        /// <summary>
        /// Obtém o identificador do paciente que realizou a consulta.
        /// </summary>
        /// <returns>O identificador do paciente.</returns>
        public int PacienteId
        {
            get { return pacienteId; }
        }

        /// <summary>
        /// Obtém o identificador do médico responsável pela consulta.
        /// </summary>
        /// <returns>O identificador do médico.</returns>
        public int MedicoId
        {
            get { return medicoId; }
        }

        /// <summary>
        /// Obtém o identificador do repositório de exames associados à consulta.
        /// </summary>
        /// <returns>O identificador do repositório de exames.</returns>
        public int ExamesRepositorioId
        {
            get { return examesRepositorioId; }
        }

        /// <summary>
        /// Obtém o identificador do repositório de diagnósticos associados à consulta.
        /// </summary>
        /// <returns>O identificador do repositório de diagnósticos.</returns>
        public int DiagnosticosRepositorioId
        {
            get { return diagnosticosRepositorioId; }
        }

        /// <summary>
        /// Obtém o custo associado à consulta.
        /// </summary>
        /// <returns>O custo total da consulta.</returns>
        public double Custo
        {
            get { return custo; }
        }

        #endregion

        #region Outras Funções

        /// <summary>
        /// Compara duas instâncias de Consulta para verificar se são iguais.
        /// </summary>
        /// <param name="obj">O objeto a ser comparado com a instância atual.</param>
        /// <returns>Verdadeiro se as consultas forem iguais, falso caso contrário.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Consulta consulta)
            {
                return this.Id == consulta.Id &&
                       this.Data == consulta.Data &&
                       this.PacienteId == consulta.PacienteId &&
                       this.MedicoId == consulta.MedicoId;
            }
            return false;
        }

        /// <summary>
        /// Obtém o código hash para a instância da consulta.
        /// </summary>
        /// <returns>O código hash da consulta.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        #endregion

        #endregion
    }
}
