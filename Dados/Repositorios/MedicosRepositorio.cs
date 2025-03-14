/// <file>
/// <summary>
/// Repositório responsável pela gestão de médicos num sistema de saúde.
/// </summary>
/// <remarks>
/// Este ficheiro contém a implementação da classe `MedicosRepositorio`, que gere operações de adição, 
/// remoção, verificação da existência e obtenção de médicos associados ao sistema.
/// </remarks>
/// <author>PedroRibeiro nº27960 LESI</author>
/// <date>dezembro de 2024</date>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Dados.Entidades;
using Dados.Interfaces;
using ObjetosNegocio.ClassesLight;
using TrataProblemas;

namespace Dados.Repositorios
{
    [Serializable]
    /// <summary>
    /// Classe responsável pela gestão de médicos num repositório.
    /// </summary>
    public class MedicosRepositorio : IRepositorio<Medico>
    {
        #region Atributos

        /// <summary>
        /// Contador estático usado para gerar IDs únicos para cada repositório.
        /// </summary>
        static int contadorRepositorio = 0;

        /// <summary>
        /// ID único atribuído ao repositório atual.
        /// </summary>
        int medicosRepositorioId;

        /// <summary>
        /// Lista que armazena os médicos associados a este repositório.
        /// </summary>
        List<Medico> medicos;

        #endregion

        #region Métodos

        #region Construtores

        /// <summary>
        /// Construtor que inicializa o repositório com uma lista de médicos vazia e atribui um ID único.
        /// </summary>
        /// <remarks>
        /// Este construtor inicializa o contador estático e cria a lista de médicos vazia para o repositório.
        /// </remarks>
        public MedicosRepositorio()
        {
            medicosRepositorioId = ++contadorRepositorio;
            medicos = new List<Medico>();
        }

        #endregion

        #region OutrasFuncoes

        /// <summary>
        /// Adiciona um médico ao repositório.
        /// </summary>
        /// <param name="medico">Objeto do tipo `Medico` a ser adicionado.</param>
        /// <returns>`true` se o médico foi adicionado com sucesso.</returns>
        public bool Adicionar(Medico medico)
        {
            medicos.Add(medico);
            return true;
        }

        /// <summary>
        /// Remove um médico do repositório.
        /// </summary>
        /// <param name="medicoId">ID do médico a ser removido.</param>
        /// <returns>`true` se o médico foi removido, `false` caso não seja encontrado.</returns>
        public bool Remover(int medicoId)
        {
            try
            {
                Medico medicoParaRemover = ObterPorId(medicoId);
                medicos.Remove(medicoParaRemover); ///< Remove o médico da lista.
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

        /// <summary>
        /// Verifica a existência de um médico no repositório.
        /// </summary>
        /// <param name="medicoId">ID do médico a ser verificado.</param>
        /// <returns>`true` se o médico existir, `false` caso contrário.</returns>
        public bool Existe(int medicoId)
        {
            try
            {
                Medico medico = ObterPorId(medicoId);
                return medico != null;
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

        /// <summary>
        /// Obtém um médico pelo ID.
        /// </summary>
        /// <param name="medicoId">ID do médico a ser obtido.</param>
        /// <returns>O médico correspondente ou `null` se não for encontrado.</returns>
        public Medico ObterPorId(int medicoId)
        {
            if (medicos == null) throw new ColecaoNaoInicializadaException();
            return medicos.FirstOrDefault(m => m.Id == medicoId);
        }

        /// <summary>
        /// Adiciona um médico utilizando uma versão simplificada de dados.
        /// </summary>
        /// <param name="medicoLight">Objeto do tipo `MedicoLight` a ser adicionado.</param>
        /// <returns>`true` se o médico foi adicionado com sucesso.</returns>
        public bool AdicionarLight(MedicoLight medicoLight)
        {
            if (Existe(medicoLight.Id)) throw new EntidadeJaExisteException();
            Medico medico = new Medico(medicoLight.Id, medicoLight.Nome, medicoLight.NumeroCedula);
            if (!Adicionar(medico)) throw new InvalidOperationException();
            return true;
        }

        /// <summary>
        /// Obtém um médico simplificado (`MedicoLight`) pelo ID.
        /// </summary>
        /// <param name="medicoId">ID do médico a ser obtido.</param>
        /// <returns>Um objeto `MedicoLight` representando o médico simplificado.</returns>
        public MedicoLight ObterMedicoLight(int medicoId)
        {
            try
            {
                Medico medico = ObterPorId(medicoId);
                return new MedicoLight(medico.Id, medico.Nome, medico.NumeroCedula);
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

        #region Tentativa de associar consultas a medicos

        /// <summary>
        /// Associa um repositório de consultas a um médico.
        /// </summary>
        /// <param name="medicoId">ID do médico a ser associado.</param>
        /// <param name="repositorioId">ID do repositório de consultas a ser associado.</param>
        /// <returns>`true` se a associação for bem-sucedida.</returns>
        //public bool AssociarRepositorioConsultasMedico(int medicoId, int repositorioId)
        //{
        //    try
        //    {
        //        Medico medico = ObterPorId(medicoId);
        //        medico.AssociarConsultasRepositorio(repositorioId);
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

        /// <summary>
        /// Obtém o ID do repositório de consultas associado a um médico.
        /// </summary>
        /// <param name="medicoId">ID do médico.</param>
        /// <returns>O ID do repositório de consultas associado.</returns>
        public int ObterConsultasIdMedico(int medicoId)
        {
            try
            {
                Medico medico = ObterPorId(medicoId);
                return medico.ConsultasId;
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

        /// <summary>
        /// Exporta todas os medicos para um ficheiro binário.
        /// </summary>
        /// <param name="nomeFicheiro">Nome do ficheiro onde os dados serão exportados.</param>
        /// <returns>`true` se a exportação for bem-sucedida, `false` caso contrário.</returns>
        public bool ExportarMedicos(string nomeFicheiro)
        {
            try
            {
                using (Stream stream = File.Open(nomeFicheiro, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();

                    bin.Serialize(stream, medicosRepositorioId);
                    bin.Serialize(stream, medicos);
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
