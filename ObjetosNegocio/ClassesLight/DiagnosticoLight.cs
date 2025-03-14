/// @file
/// @brief Classe Light que contém informações resumidas sobre um diagnóstico.
/// 
/// Este ficheiro define a classe `DiagnosticoLight`, que serve como uma versão simplificada de um diagnóstico, 
/// contendo apenas os dados essenciais para operações rápidas e eficientes.
/// 
/// @date dezembro de 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosNegocio.ClassesLight
{
    /// @class DiagnosticoLight
    /// @brief Classe Light para representação simplificada de um diagnóstico.
    /// 
    /// A classe `DiagnosticoLight` é usada para armazenar informações resumidas sobre um diagnóstico, como o 
    /// ID do diagnóstico, a data em que o diagnóstico foi feito e o ID da consulta associada. Ela é usada 
    /// principalmente para operações em que não é necessário o uso completo dos dados do diagnóstico.
    /// 
    /// @date dezembro de 2024
    public class DiagnosticoLight
    {
        #region Atributos

        /// @brief Identificador único do diagnóstico.
        int id;

        /// @brief Data em que o diagnóstico foi realizado.
        DateTime dataDiagnostico;

        /// @brief Identificador da consulta associada ao diagnóstico.
        int consultaId;

        #endregion

        #region Metodos

        #region Propriedades

        /// @brief Obtém ou define o identificador único do diagnóstico.
        /// 
        /// Esta propriedade acessa o atributo `id`, que contém o identificador único do diagnóstico.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// @brief Obtém ou define a data em que o diagnóstico foi realizado.
        /// 
        /// Esta propriedade acessa o atributo `dataDiagnostico`, que contém a data do diagnóstico.
        public DateTime DataDiagnostico
        {
            get { return dataDiagnostico; }
            set { dataDiagnostico = value; }
        }

        /// @brief Obtém ou define o identificador da consulta associada ao diagnóstico.
        /// 
        /// Esta propriedade acessa o atributo `consultaId`, que contém o identificador da consulta relacionada.
        public int ConsultaId
        {
            get { return consultaId; }
            set { consultaId = value; }
        }

        #endregion

        #region Construtores

        /// @brief Construtor que inicializa os atributos de um diagnóstico simplificado.
        /// 
        /// Este construtor inicializa um objeto `DiagnosticoLight` com os dados fornecidos para o ID do diagnóstico, 
        /// a data do diagnóstico e o ID da consulta associada.
        /// 
        /// @param id Identificador único do diagnóstico.
        /// @param dataDiagnostico Data em que o diagnóstico foi realizado.
        /// @param consultaId Identificador da consulta associada ao diagnóstico.
        public DiagnosticoLight(int id, DateTime dataDiagnostico, int consultaId)
        {
            this.id = id;
            this.dataDiagnostico = dataDiagnostico;
            this.consultaId = consultaId;
        }

        #endregion

        #endregion
    }
}

