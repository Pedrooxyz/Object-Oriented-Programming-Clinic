/// <summary>
/// Define a interface para a gestão de médicos no sistema.
/// </summary>
/// <author>Pedro Ribeiro nº 27960</author>
/// <date>18 de dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using TrataProblemas;


namespace RegrasNegocio.Interfaces
{
    /// <summary>
    /// Interface para a gestão dos médicos no sistema.
    /// </summary>
    internal interface IGestaoMedicos
    {
        /// <summary>
        /// Adiciona um novo médico ao sistema.
        /// </summary>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns><c>true</c> se o médico for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for <c>null</c>.</exception>
        bool AdicionarMedico(MedicoLight medicoLight);

        /// <summary>
        /// Elimina um médico existente no sistema.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico a ser eliminado.</param>
        /// <param name="password">Senha do médico responsável pela eliminação.</param>
        /// <returns><c>true</c> se o médico for eliminado com sucesso, <c>false</c> caso contrário.</returns>
        bool EliminarMedico(int medicoId, int password);

        /// <summary>
        /// Verifica se um médico existe no repositório.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico a ser verificado.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns><c>true</c> se o médico existir, <c>false</c> caso contrário.</returns>
        bool ExisteMedico(int medicoId, MedicoLight medicoLight);

        /// <summary>
        /// Obtém um médico pelo seu identificador.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico a ser obtido.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Um objeto do tipo <see cref="MedicoLight"/> representando o médico, ou <c>null</c> se não for encontrado.</returns>
        MedicoLight ObterMedico(int medicoId, MedicoLight medicoLight);

        /// <summary>
        /// Obtém o ID de consultas associado a um médico pelo seu identificador.
        /// </summary>
        /// <param name="medicoId">Identificador único do médico.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>O ID de consultas associado ao médico.</returns>
        /// <exception cref="KeyNotFoundException">Se o médico com o ID especificado não for encontrado.</exception>
        int ObterConsultasIdDoMedico(int medicoId, MedicoLight medicoLight);

        /// <summary>
        /// Exporta os médicos para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns><c>true</c> se a exportação for bem-sucedida, <c>false</c> em caso de erro.</returns>
        bool ExportarMedicosParaFicheiro(string nomeFicheiro);
    }
}
