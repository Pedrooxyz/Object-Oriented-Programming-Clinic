/// <summary>
/// Define a interface para a gestão de consultas no sistema.
/// </summary>
/// <file>
/// <author>Pedro Ribeiro nº27960</author>
/// <date>dezembro 2024</date>
/// </file>

using Dados.Repositorios;
using ObjetosNegocio.ClassesLight;
using RegrasNegocio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrataProblemas;

namespace RegrasNegocio.Interfaces
{
    /// <summary>
    /// Interface para a gestão de consultas.
    /// </summary>
    public interface IGestaoConsultas
    {
        /// <summary>
        /// Adiciona uma nova consulta ao sistema.
        /// 
        /// Este método cria uma nova consulta com base nas informações fornecidas,
        /// e a adiciona ao repositório de consultas se o médico estiver autorizado.
        /// Caso a consulta já exista ou o médico não tenha permissão, o método retorna `false`.
        /// </summary>
        /// <param name="consultaLight">Objeto que contém as informações mínimas de uma consulta.</param>
        /// <param name="medicoLight">Objeto que representa o médico que está a adicionar a consulta.</param>
        /// <returns>Retorna `true` se a consulta for adicionada com sucesso, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se algum dos parâmetros for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a adicionar consultas.</exception>
        bool AdicionarConsulta(ConsultaLight consultaLight, MedicoLight medicoLight);

        /// <summary>
        /// Elimina uma consulta existente no sistema.
        /// 
        /// Este método elimina uma consulta do repositório, caso a consulta exista e o médico esteja autorizado.
        /// Caso contrário, retorna `false`.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser eliminada.</param>
        /// <param name="medicoLight">Objeto que representa o médico responsável pela eliminação da consulta.</param>
        /// <returns>Retorna `true` se a consulta for eliminada com sucesso, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a eliminar consultas.</exception>
        bool EliminarConsulta(int consultaId, MedicoLight medicoLight);

        /// <summary>
        /// Verifica se uma consulta existe no repositório, com permissão do médico.
        /// 
        /// Este método verifica se uma consulta com o identificador especificado existe
        /// e se o médico tem permissão para visualizar essa consulta.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser verificada.</param>
        /// <param name="medicoLight">Objeto que representa o médico que está a verificar a consulta.</param>
        /// <returns>Retorna `true` se a consulta existir e o médico tiver permissão, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a verificar consultas.</exception>
        bool ExisteConsulta(int consultaId, MedicoLight medicoLight);

        /// <summary>
        /// Verifica se uma consulta existe no repositório, com permissão do paciente.
        /// 
        /// Este método verifica se uma consulta com o identificador especificado existe
        /// e se o paciente tem permissão para visualizar essa consulta.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser verificada.</param>
        /// <param name="pacienteLight">Objeto que representa o paciente que está a verificar a consulta.</param>
        /// <returns>Retorna `true` se a consulta existir e o paciente tiver permissão, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `pacienteLight` for `null`.</exception>
        bool ExisteConsulta(int consultaId, PacienteLight pacienteLight);

        /// <summary>
        /// Obtém uma consulta pelo seu identificador, com permissão do médico.
        /// 
        /// Este método retorna uma consulta existente no repositório, desde que o médico tenha permissão
        /// para visualizar essa consulta.
        /// </summary>
        /// <param name="consultaId">Identificador único da consulta a ser obtida.</param>
        /// <param name="medicoLight">Objeto que representa o médico que está a obter a consulta.</param>
        /// <returns>Um objeto do tipo `ConsultaLight` representando a consulta, ou `null` se não for encontrada.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro `medicoLight` for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a visualizar consultas.</exception>
        ConsultaLight ObterConsulta(int consultaId, MedicoLight medicoLight);

        /// <summary>
        /// Exporta as consultas para um ficheiro binário.
        /// 
        /// Este método chama a função ExportarConsultas do repositório de consultas e exporta os dados para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna `true` se a exportação for bem-sucedida, ou `false` em caso de erro.</returns>
        bool ExportarConsultasParaFicheiro(string nomeFicheiro);
    }
}