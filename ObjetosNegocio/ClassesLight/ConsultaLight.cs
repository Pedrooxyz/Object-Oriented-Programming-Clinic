/// @file
/// @brief Classe Light que contém informações resumidas sobre uma consulta.
/// 
/// Este ficheiro define a classe `ConsultaLight`, que serve como uma versão simplificada de uma consulta, 
/// contendo apenas os dados essenciais para operações rápidas e eficientes.
/// 
/// @date dezembro de 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObjetosNegocio.ClassesLight
{
    /// @class ConsultaLight
    /// @brief Classe Light para representação simplificada de uma consulta.
    /// 
    /// A classe `ConsultaLight` é usada para armazenar informações resumidas sobre uma consulta, como o 
    /// ID da consulta, o ID do paciente, o ID do médico e a data da consulta. Ela é usada principalmente 
    /// para operações em que não é necessário o uso completo dos dados da consulta.
    /// 
    /// @date dezembro de 2024
    public class ConsultaLight
    {
        #region Atributos

        /// @brief Identificador único da consulta.
        int id;

        /// @brief Identificador do paciente associado à consulta.
        int pacienteId;

        /// @brief Identificador do médico associado à consulta.
        int medicoId;

        /// @brief Data e hora em que a consulta está agendada.
        DateTime data;

        #endregion

        #region Metodos

        #region Propriedades

        /// @brief Obtém ou define o identificador único da consulta.
        /// 
        /// Esta propriedade acessa o atributo `id`, que contém o identificador único da consulta.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// @brief Obtém ou define o identificador do paciente associado à consulta.
        /// 
        /// Esta propriedade acessa o atributo `pacienteId`, que contém o identificador do paciente.
        public int PacienteId
        {
            get { return pacienteId; }
            set { pacienteId = value; }
        }

        /// @brief Obtém ou define o identificador do médico associado à consulta.
        /// 
        /// Esta propriedade acessa o atributo `medicoId`, que contém o identificador do médico.
        public int MedicoId
        {
            get { return medicoId; }
            set { medicoId = value; }
        }

        /// @brief Obtém ou define a data e hora da consulta.
        /// 
        /// Esta propriedade acessa o atributo `data`, que contém a data e hora agendada para a consulta.
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        #endregion

        #region Construtores

        /// @brief Construtor que inicializa os atributos de uma consulta simplificada.
        /// 
        /// Este construtor inicializa um objeto `ConsultaLight` com os dados fornecidos para o ID da consulta,
        /// o ID do paciente, o ID do médico e a data da consulta.
        /// 
        /// @param id Identificador único da consulta.
        /// @param pacienteId Identificador do paciente associado à consulta.
        /// @param medicoId Identificador do médico associado à consulta.
        /// @param dataConsulta Data e hora agendada para a consulta.
        public ConsultaLight(int id, int pacienteId, int medicoId, DateTime dataConsulta)
        {
            this.id = id;
            this.pacienteId = pacienteId;
            this.medicoId = medicoId;
            data = dataConsulta;
        }

        #endregion

        #endregion
    }
}
