/// <summary>
/// Define a interface para a gestão de pacientes no sistema.
/// </summary>
/// <author>Pedro Ribeiro nº 27960</author>
/// <date>18 de dezembro de 2024</date>


using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrataProblemas;

namespace RegrasNegocio.Interfaces
{
    /// <summary>
    /// Interface para a gestão de pacientes no sistema.
    /// </summary>
    public interface IGestaoPacientes
    {
        /// <summary>
        /// Adiciona um novo paciente ao sistema.
        /// </summary>
        /// <param name="pacienteLight">Objeto com as informações mínimas de um paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns><c>true</c> se o paciente for adicionado com sucesso, <c>false</c> caso contrário.</returns>
        bool AdicionarPaciente(PacienteLight pacienteLight, MedicoLight medicoLight);

        /// <summary>
        /// Elimina um paciente existente no sistema.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="password">Senha necessária para a operação.</param>
        /// <returns><c>true</c> se o paciente for eliminado com sucesso, <c>false</c> caso contrário.</returns>
        bool EliminarPaciente(int pacienteId, int password);

        /// <summary>
        /// Verifica se um paciente existe no sistema.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns><c>true</c> se o paciente existir, <c>false</c> caso contrário.</returns>
        bool ExistePaciente(int pacienteId, MedicoLight medicoLight);

        /// <summary>
        /// Obtém um paciente pelo seu identificador.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns>Um objeto do tipo <see cref="PacienteLight"/> representando o paciente.</returns>
        PacienteLight ObterPaciente(int pacienteId, MedicoLight medicoLight);

        /// <summary>
        /// Obtém o ID de consultas associado a um paciente.
        /// </summary>
        /// <param name="pacienteId">Identificador único do paciente.</param>
        /// <param name="medicoLight">Objeto representando o médico responsável pela operação.</param>
        /// <returns>O ID de consultas associado ao paciente.</returns>
        int ObterConsultasIdDoPaciente(int pacienteId, MedicoLight medicoLight);

        /// <summary>
        /// Exporta os pacientes para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns><c>true</c> se a exportação for bem-sucedida, <c>false</c> em caso de erro.</returns>
        bool ExportarPacientesParaFicheiro(string nomeFicheiro);
    }
}

