/// @file
/// @brief Classe Light que contém informações resumidas sobre um paciente.
/// 
/// Este ficheiro define a classe `PacienteLight`, que herda de `PessoaLight` e contém informações essenciais sobre um paciente,
/// como o número de utente.
/// 
/// @date dezembro de 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosNegocio.ClassesLight
{
    /// @class PacienteLight
    /// @brief Classe Light para representação simplificada de um paciente.
    /// 
    /// A classe `PacienteLight` herda da classe `PessoaLight` e adiciona informações adicionais relacionadas ao paciente,
    /// como o número de utente. A classe é utilizada para operações rápidas, contendo apenas os dados essenciais do paciente.
    /// 
    /// @date dezembro de 2024
    public class PacienteLight : PessoaLight
    {
        #region Atributos

        /// @brief Número de utente do paciente.
        int numeroUtente;

        #endregion

        #region Metodos

        #region Propriedades

        /// @brief Obtém ou define o número de utente do paciente.
        /// 
        /// Esta propriedade acessa o atributo `numeroUtente`, que contém o número de utente do paciente.
        public int NumeroUtente {
            get { return numeroUtente; } 
            set { numeroUtente = value; } 
        }

        #endregion

        #region Construtores

        /// @brief Construtor que inicializa um paciente com o ID e nome.
        /// 
        /// Este construtor define os atributos `Id` e `Nome` para o paciente e inicializa o número de utente com valor padrão.
        /// 
        /// @param id Identificador único do paciente.
        /// @param nome Nome do paciente.
        public PacienteLight(int id, string nome)
        {
            this.Id = id;
            this.Nome = nome;
            this.NumeroUtente = numeroUtente;
        }

        /// @brief Construtor que inicializa um paciente com o ID, nome e número de utente.
        /// 
        /// Este construtor define os atributos `Id`, `Nome` e `NumeroUtente` para o paciente.
        /// 
        /// @param id Identificador único do paciente.
        /// @param nome Nome do paciente.
        /// @param numeroUtente Número de utente do paciente.
        public PacienteLight(int id, string nome, int numeroUtente)
        {
            this.Id = id;
            this.Nome = nome;
            this.NumeroUtente = numeroUtente;
        }

        #endregion

        #endregion
    }
}

