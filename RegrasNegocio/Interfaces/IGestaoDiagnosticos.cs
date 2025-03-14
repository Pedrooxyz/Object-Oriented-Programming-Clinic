/// <summary>
/// Define a interface para a gestão de diagnósticos no sistema.
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
    /// Interface para a gestão de diagnósticos.
    /// </summary>
    public interface IGestaoDiagnosticos
    {
        /// <summary>
        /// Adiciona um novo diagnóstico ao sistema.
        /// 
        /// Este método cria um novo diagnóstico com base nas informações fornecidas
        /// e o adiciona ao repositório de diagnósticos.
        /// </summary>
        /// <param name="diagnosticoLight">Objeto que contém as informações mínimas de um diagnóstico.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna `true` se o diagnóstico for adicionado com sucesso, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="EntidadeJaExisteException">Se o diagnóstico já existir no sistema.</exception>
        bool AdicionarDiagnostico(DiagnosticoLight diagnosticoLight, MedicoLight medicoLight);

        /// <summary>
        /// Elimina um diagnóstico existente no sistema.
        /// 
        /// Este método elimina um diagnóstico do repositório, caso o diagnóstico exista.
        /// Caso contrário, retorna `false`.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico a ser eliminado.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna `true` se o diagnóstico for eliminado com sucesso, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        bool EliminarDiagnostico(int diagnosticoId, MedicoLight medicoLight);

        /// <summary>
        /// Verifica se um diagnóstico existe no repositório.
        /// 
        /// Este método verifica se um diagnóstico com o identificador especificado existe.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico a ser verificado.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna `true` se o diagnóstico existir, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        bool ExisteDiagnostico(int diagnosticoId, MedicoLight medicoLight);

        /// <summary>
        /// Obtém um diagnóstico pelo seu identificador.
        /// 
        /// Este método retorna um diagnóstico existente no repositório.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico a ser obtido.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Um objeto do tipo `DiagnosticoLight` representando o diagnóstico, ou `null` se não for encontrado.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        DiagnosticoLight ObterDiagnostico(int diagnosticoId, MedicoLight medicoLight);

        /// <summary>
        /// Associa um ID de consulta a um diagnóstico.
        /// 
        /// Este método associa um diagnóstico a uma consulta, usando os identificadores fornecidos.
        /// </summary>
        /// <param name="diagnosticoId">Identificador do diagnóstico.</param>
        /// <param name="consultaId">Identificador da consulta associada.</param>
        /// <returns>Retorna `true` se a consulta for associada com sucesso, `false` caso contrário.</returns>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        /// <exception cref="Exception">Se ocorrer algum erro inesperado.</exception>
        bool AssociarConsultaAoDiagnostico(int diagnosticoId, int consultaId);

        /// <summary>
        /// Obtém o ID da consulta associado a um diagnóstico pelo seu identificador.
        /// 
        /// Este método retorna o valor da variável `consultaId` de um diagnóstico específico,
        /// caso este exista no repositório.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico.</param>
        /// <returns>O ID da consulta associado ao diagnóstico.</returns>
        /// <exception cref="KeyNotFoundException">Se o diagnóstico com o ID especificado não for encontrado.</exception>
        int ObterConsultaIdDoDiagnostico(int diagnosticoId);

        /// <summary>
        /// Adiciona texto à descrição de um diagnóstico existente.
        /// 
        /// Este método permite adicionar informações adicionais à descrição de um diagnóstico.
        /// </summary>
        /// <param name="diagnosticoId">Identificador único do diagnóstico.</param>
        /// <param name="texto">Texto a ser adicionado à descrição do diagnóstico.</param>
        /// <param name="medicoLight">Objeto que contém as informações mínimas de um médico.</param>
        /// <returns>Retorna `true` se o texto for adicionado com sucesso, `false` caso contrário.</returns>
        /// <exception cref="ArgumentNullException">Se o parâmetro for `null`.</exception>
        /// <exception cref="MedicoNaoAutorizadoException">Se o médico não estiver autorizado a tomar decisões.</exception>
        /// <exception cref="ColecaoNaoInicializadaException">Se a coleção de diagnósticos não foi inicializada.</exception>
        bool AdicionarTextoADescricao(int diagnosticoId, string texto, MedicoLight medicoLight);

        /// <summary>
        /// Exporta os diagnósticos para um ficheiro binário.
        /// 
        /// Este método chama a função ExportarDiagnosticos do repositório de diagnósticos e exporta os dados para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro para o qual os dados serão exportados.</param>
        /// <returns>Retorna `true` se a exportação for bem-sucedida, ou `false` em caso de erro.</returns>
        bool ExportarDiagnosticosParaFicheiro(string nomeFicheiro);
    }
}