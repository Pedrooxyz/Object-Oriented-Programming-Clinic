/// <file>
/// <summary>Repositório responsável pela gestão de pacientes num sistema de saúde.</summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe `PacientesRepositorio`, que gere operações de adição, 
/// remoção, verificação da existência e obtenção de pacientes associados ao sistema.
/// </remarks>
/// <date>dezembro de 2024</date>


using System;
using System.Collections.Generic;
using System.Linq;
using Dados.Entidades;
using Dados.Interfaces;
using TrataProblemas;
using ObjetosNegocio.ClassesLight;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Dados.Repositorios
{
    [Serializable]
    /// <summary>Classe responsável pela gestão de pacientes num repositório.</summary>
    public class PacientesRepositorio : IRepositorio<Paciente>
    {
        #region Atributos

        /// <summary>Contador estático usado para gerar IDs únicos para cada repositório.</summary>
        static int contadorRepositorio = 0;

        /// <summary>ID único atribuído ao repositório atual.</summary>
        int pacientesRepositorioId;

        /// <summary>Lista estática que armazena os pacientes associados a este repositório.</summary>
        List<Paciente> pacientes = new List<Paciente>();

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>Construtor que inicializa o repositório com uma lista de pacientes vazia e atribui um ID único.</summary>
        /// <remarks>
        /// Este construtor inicializa o repositório com um ID único gerado automaticamente e com uma lista de pacientes vazia.
        /// </remarks>
        public PacientesRepositorio()
        {
            pacientesRepositorioId = ++contadorRepositorio;
            pacientes = new List<Paciente>();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>Adiciona um paciente ao repositório.</summary>
        /// <param name="paciente">Objeto do tipo <c>Paciente</c> a ser adicionado.</param>
        /// <returns>Retorna <c>true</c> se o paciente for adicionado com sucesso, caso contrário, retorna <c>false</c>.</returns>
        public bool Adicionar(Paciente paciente)
        {
            pacientes.Add(paciente);
            return true;
        }

        /// <summary>Remove um paciente do repositório.</summary>
        /// <param name="pacienteId">ID do paciente a ser removido.</param>
        /// <returns><c>true</c> se o paciente foi removido, <c>false</c> se não foi encontrado.</returns>
        public bool Remover(int pacienteId)
        {
            try
            {
                Paciente pacienteParaRemover = ObterPorId(pacienteId);
                pacientes.Remove(pacienteParaRemover);
                return true;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>Verifica a existência de um paciente no repositório.</summary>
        /// <param name="pacienteId">ID do paciente a ser verificado.</param>
        /// <returns><c>true</c> se o paciente existir, <c>false</c> caso contrário.</returns>
        public bool Existe(int pacienteId)
        {
            try
            {
                Paciente paciente = ObterPorId(pacienteId);
                return paciente != null;
            }
            catch (ColecaoNaoInicializadaException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>Obtém um paciente pelo ID.</summary>
        /// <param name="pacienteId">ID do paciente a ser obtido.</param>
        /// <returns>O paciente correspondente ou <c>null</c> se não for encontrado.</returns>
        public Paciente ObterPorId(int pacienteId)
        {
            if (pacientes == null) throw new ColecaoNaoInicializadaException();

            return pacientes.FirstOrDefault(p => p.Id == pacienteId);
        }

        /// <summary>Adiciona um paciente utilizando um objeto do tipo <c>PacienteLight</c>.</summary>
        /// <param name="pacienteLight">Objeto do tipo <c>PacienteLight</c> com informações do paciente.</param>
        /// <returns>Retorna <c>true</c> se o paciente for adicionado com sucesso, caso contrário, lança uma exceção.</returns>
        public bool AdicionarLight(PacienteLight pacienteLight)
        {
            if (Existe(pacienteLight.Id)) throw new EntidadeJaExisteException();
            Paciente paciente = new Paciente(pacienteLight.Id, pacienteLight.Nome, pacienteLight.NumeroUtente);
            if (!Adicionar(paciente)) throw new InvalidOperationException();
            return true;
        }

        /// <summary>Obtém um objeto <c>PacienteLight</c> com informações resumidas de um paciente.</summary>
        /// <param name="pacienteId">ID do paciente a ser obtido.</param>
        /// <returns>Um objeto <c>PacienteLight</c> com os dados resumidos do paciente.</returns>
        public PacienteLight ObterPacienteLight(int pacienteId)
        {
            try
            {
                Paciente paciente = ObterPorId(pacienteId);
                return new PacienteLight(paciente.Id, paciente.Nome, paciente.NumeroUtente);
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region Tentativa de associar consultas a ppaciente
        //public bool AssociarRepositorioConsultasPaciente(int pacienteId, int repositorioId)
        //{
        //    try
        //    {
        //        Paciente paciente = ObterPorId(pacienteId);
        //        paciente.AssociarConsultasRepositorio(repositorioId);
        //        return true;
        //    }
        //    catch (ColecaoNaoInicializadaException ex)
        //    {
        //        throw;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        /// <summary>Obtém o ID do repositório de consultas associado a um paciente.</summary>
        /// <param name="pacienteId">ID do paciente.</param>
        /// <returns>O ID do repositório de consultas associado ao paciente.</returns>
        public int ObterConsultasIdPaciente(int pacienteId)
        {
            try
            {
                Paciente paciente = ObterPorId(pacienteId);
                return paciente.ConsultasId;
            }
            catch (ColecaoNaoInicializadaException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>Exporta todas os pacientes para um ficheiro binário.</summary>
        /// <param name="nomeFicheiro">Nome do ficheiro onde os dados serão exportados.</param>
        /// <returns>Retorna <c>true</c> se a exportação for bem-sucedida, <c>false</c> caso contrário.</returns>
        public bool ExportarPacientes(string nomeFicheiro)
        {
            try
            {
                using (Stream stream = File.Open(nomeFicheiro, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, pacientesRepositorioId);
                    bin.Serialize(stream, pacientes);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #endregion
    }
}
