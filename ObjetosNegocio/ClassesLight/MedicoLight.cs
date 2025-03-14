/// @file
/// @brief Classe Light que contém informações resumidas sobre um médico.
/// 
/// Este ficheiro define a classe `MedicoLight`, que herda de `PessoaLight` e contém informações essenciais sobre um médico,
/// como o número de cédula profissional e a possibilidade de tomar decisões no âmbito do sistema.
/// 
/// @date dezembro de 2024

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetosNegocio.ClassesLight
{
    /// @class MedicoLight
    /// @brief Classe Light para representação simplificada de um médico.
    /// 
    /// A classe `MedicoLight` herda da classe `PessoaLight` e adiciona informações adicionais relacionadas ao médico, 
    /// como o número de cédula e a capacidade de tomar decisões. A classe é utilizada para operações rápidas, 
    /// contendo apenas os dados essenciais do médico.
    /// 
    /// @date dezembro de 2024
    public class MedicoLight : PessoaLight
    {
        #region Atributos

        /// @brief Número de cédula profissional do médico.
        int numeroCedula;

        /// @brief Indica se o médico pode tomar decisões dentro do sistema.
        bool podeTomarDecisoes = true;

        #endregion

        #region Propriedades

        /// @brief Obtém ou define o número de cédula profissional do médico.
        /// 
        /// Esta propriedade acessa o atributo `numeroCedula`, que contém o número de cédula profissional do médico.
        public int NumeroCedula
        {
            get { return numeroCedula; }
            set { numeroCedula = value; }
        }

        /// @brief Obtém a capacidade do médico de tomar decisões dentro do sistema.
        /// 
        /// Esta propriedade acessa o atributo `podeTomarDecisoes`, indicando se o médico tem a capacidade de tomar decisões.
        public bool PodeTomarDecisoes
        {
            get { return podeTomarDecisoes; }
            set { podeTomarDecisoes = value; }
        }

        #endregion

        #region Construtores

        /// @brief Construtor que inicializa a capacidade do médico de tomar decisões.
        /// 
        /// Este construtor define o valor da propriedade `podeTomarDecisoes` para a capacidade de decisão do médico.
        /// 
        /// @param valor Indica se o médico pode ou não tomar decisões.
        public MedicoLight(bool valor)
        {
            podeTomarDecisoes = valor;
        }

        /// @brief Construtor que inicializa um médico com o ID, nome e número de cédula.
        /// 
        /// Este construtor define os atributos `Id`, `Nome` e `numeroCedula` para o médico.
        /// 
        /// @param id Identificador único do médico.
        /// @param nome Nome do médico.
        /// @param numcedula Número de cédula profissional do médico.
        public MedicoLight(int id, string nome, int numcedula)
        {
            this.Id = id;
            this.Nome = nome;
            this.numeroCedula = numcedula;
        }

        #endregion
    }
}
