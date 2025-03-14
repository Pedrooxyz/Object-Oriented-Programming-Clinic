/// @file
/// @brief Classe Light que contém informações resumidas sobre um exame.
/// 
/// Este ficheiro define a classe `ExameLight`, que serve como uma versão simplificada de um exame, 
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
    /// @class ExameLight
    /// @brief Classe Light para representação simplificada de um exame.
    /// 
    /// A classe `ExameLight` é usada para armazenar informações resumidas sobre um exame, como o 
    /// ID do exame, o tipo de exame, a data em que o exame foi realizado e o ID do paciente associado. 
    /// Ela é usada principalmente para operações em que não é necessário o uso completo dos dados do exame.
    /// 
    /// @date dezembro de 2024
    public class ExameLight
    {
        #region Atributos

        /// @brief Identificador único do exame.
        int id;

        /// @brief Tipo do exame realizado.
        string tipo;

        /// @brief Data em que o exame foi realizado.
        DateTime data;

        /// @brief Identificador do paciente que realizou o exame.
        int pacienteId;

        #endregion

        #region Metodos

        #region Propriedades

        /// @brief Obtém ou define o identificador único do exame.
        /// 
        /// Esta propriedade acessa o atributo `id`, que contém o identificador único do exame.
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// @brief Obtém ou define o tipo do exame realizado.
        /// 
        /// Esta propriedade acessa o atributo `tipo`, que contém o tipo de exame realizado.
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        /// @brief Obtém ou define a data em que o exame foi realizado.
        /// 
        /// Esta propriedade acessa o atributo `data`, que contém a data em que o exame foi realizado.
        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        /// @brief Obtém ou define o identificador do paciente que realizou o exame.
        /// 
        /// Esta propriedade acessa o atributo `pacienteId`, que contém o identificador do paciente que realizou o exame.
        public int PacienteId
        {
            get { return pacienteId; }
            set { pacienteId = value; }
        }

        #endregion

        #region Construtores

        /// @brief Construtor da classe ExameLight.
        /// 
        /// Este construtor inicializa um objeto `ExameLight` com os dados fornecidos para o ID do exame, 
        /// o tipo de exame, a data do exame e o ID do paciente associado.
        /// 
        /// @param id Identificador único do exame.
        /// @param tipo Tipo do exame realizado.
        /// @param dataExame Data e hora em que o exame foi realizado.
        /// @param pacienteId Identificador do paciente que realizou o exame.
        public ExameLight(int id, string tipo, DateTime dataExame, int pacienteId)
        {
            this.id = id;
            this.tipo = tipo;
            this.data = dataExame;
            this.pacienteId = pacienteId;
        }

        #endregion

        #endregion
    }
}

