/// <summary>
/// Este ficheiro contém a implementação de várias gestões para um sistema de saúde, incluindo gestão de consultas,
/// pacientes, médicos, exames e diagnósticos. O código demonstra como adicionar, associar e manipular estas entidades.
/// </summary>
/// <author>Nome do Autor</author>
/// <date>Data da Última Modificação</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegrasNegocio; //Este projeto intereage exclusivamente com a camada de RegrasNegocio
using ObjetosNegocio.ClassesLight;
using TrataProblemas;
using RegrasNegocio.Interfaces;
using RegrasNegocio.Servicos;

namespace GestaoCentroSaude
{
    /// <summary>
    /// Classe principal que executa a gestão.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Método principal que executa os diversos testes de funcionamento das gestões.
        /// </summary>
        static void Main(string[] args)
        {

            Console.WriteLine("\nCONSULTAS:\n");
            #region Funcionamento da GestaoConsulta

            GestaoConsultas gestaoConsultas1 = new GestaoConsultas();
            GestaoConsultas gestaoConsultas2 = new GestaoConsultas();

            PacienteLight paciente1 = new PacienteLight(1, "Joao");
            PacienteLight paciente2 = new PacienteLight(2, "Jorge");

            MedicoLight medico1 = new MedicoLight(1, "Dr. João", 2);

            ConsultaLight consulta1 = new ConsultaLight(1, paciente2.Id, medico1.Id, DateTime.Now);
            ConsultaLight consulta2 = new ConsultaLight(2, paciente2.Id, medico1.Id, DateTime.Now.AddDays(1));
            ConsultaLight consulta3 = new ConsultaLight(3, paciente2.Id, medico1.Id, DateTime.Now.AddDays(2));

            try
            {
                try
                {
                    Console.WriteLine("Tentar adicionar consulta 1 ao paciente 1 para dar erro...");
                    bool resultado1 = gestaoConsultas1.AdicionarConsulta(consulta1, new MedicoLight(false));
                    Console.WriteLine("Consulta 1 adicionada: " + resultado1);
                }
                catch (MedicoNaoAutorizadoException ex)
                {
                    Console.WriteLine("Erro ao adicionar consulta 1: " + ex.Message);
                }

                try
                {
                    Console.WriteLine("Tentar adicionar consulta 2 ao paciente 1...");
                    bool resultado2 = gestaoConsultas1.AdicionarConsulta(consulta2, new MedicoLight(true));
                    Console.WriteLine("Consulta 2 adicionada: " + resultado2);
                }
                catch (MedicoNaoAutorizadoException ex)
                {
                    Console.WriteLine("Erro ao adicionar consulta 2: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro inesperado: " + ex.Message);
            }

            try
            {
                Console.WriteLine("Tentar adicionar consulta 3 ao paciente 2...");
                bool resultado3 = gestaoConsultas2.AdicionarConsulta(consulta3, new MedicoLight(true));
                Console.WriteLine("Consulta 3 adicionada: " + resultado3);
            }
            catch (MedicoNaoAutorizadoException ex)
            {
                Console.WriteLine("Erro ao adicionar consulta 3: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro inesperado: " + ex.Message);
            }

            #region Funções adicionais para testes

            try
            {
                // Verificar se a consulta 2 existe para o paciente
                bool existeConsulta2Paciente = gestaoConsultas1.ExisteConsulta(consulta2.Id, paciente1);
                Console.WriteLine("Consulta 2 existe para o paciente 1: " + existeConsulta2Paciente);

                // Verificar se a consulta 1 existe para o médico
                bool existeConsulta1Medico = gestaoConsultas1.ExisteConsulta(consulta1.Id, medico1);
                Console.WriteLine("Consulta 1 existe para o médico 1: " + existeConsulta1Medico);

                // Obter a consulta 3
                ConsultaLight consultaObtida = gestaoConsultas2.ObterConsulta(consulta3.Id, medico1);
                Console.WriteLine($"Consulta 3 obtida: Id = {consultaObtida.Id}, Data = {consultaObtida.Data}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao verificar ou obter consultas: " + ex.Message);
            }

            try
            {
                // Eliminar consulta 2
                bool sucessoEliminacao = gestaoConsultas1.EliminarConsulta(consulta2.Id, medico1);
                Console.WriteLine("Consulta 2 eliminada: " + sucessoEliminacao);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao eliminar consulta 2: " + ex.Message);
            }

            try
            {
                string nomeFicheiro = "consultas.txt";
                bool sucesso = gestaoConsultas1.ExportarConsultasParaFicheiro(nomeFicheiro);

                if (sucesso)
                {
                    Console.WriteLine("Exportação de consultas foi bem-sucedida!");
                }
                else
                {
                    Console.WriteLine("Houve um erro na exportação de consultas.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao exportar consultas: {ex.Message}");
            }

            #endregion

            #endregion

            Console.WriteLine("\nPACIENTES:\n");
            #region Funcionamento da GestaoPaciente

            try
            {
                PacienteLight pacienteLight_ = new PacienteLight(3, "Pedro");
                GestaoPacientes gestaopacientes = new GestaoPacientes();
                bool sucesso = gestaopacientes.AdicionarPaciente(pacienteLight_,medico1);
                if (sucesso)
                    Console.WriteLine("Paciente adicionado com sucesso.");
                else
                    Console.WriteLine("Falha ao adicionar o paciente.");
            }
            catch (EntidadeJaExisteException ex) 
            {
                Console.WriteLine($"Erro de paciente: {ex.Message}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            #endregion

            Console.WriteLine("\nMEDICOS:\n");
            #region Funcionamento da GestaoMedico

            try
            {
                GestaoMedicos gestaoMedicos = new GestaoMedicos();
                bool sucessoMedico = gestaoMedicos.AdicionarMedico(medico1);
                if (sucessoMedico)
                    Console.WriteLine("Médico adicionado com sucesso.");
                else
                    Console.WriteLine("Falha ao adicionar o médico.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao adicionar o médico: {ex.Message}");
            }

            #endregion

            Console.WriteLine("\nEXAMES:\n");
            #region Funcionamento da GestaoExames

            try
            {
                ExameLight exame1 = new ExameLight(1, "Exame de Sangue", new DateTime(2029,12,12), 50);
                GestaoExames gestaoExames = new GestaoExames();
                bool sucessoExame = gestaoExames.AdicionarExame(exame1,medico1);
                if (sucessoExame)
                    Console.WriteLine("Exame adicionado com sucesso.");
                else
                    Console.WriteLine("Falha ao adicionar o exame.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao adicionar o exame: {ex.Message}");
            }

            #endregion

            Console.WriteLine("\nDIAGNOSTICOS:\n");
            #region Funcionamento da GestaoDiagnosticos

            try
            {
                DiagnosticoLight diagnostico1 = new DiagnosticoLight(1, DateTime.Now,1);
                DiagnosticoLight diagnostico2 = new DiagnosticoLight(2, new DateTime(2029, 12, 12), 2);

                GestaoDiagnosticos gestaoDiagnosticos = new GestaoDiagnosticos();

                bool sucessoDiagnostico1 = gestaoDiagnosticos.AdicionarDiagnostico(diagnostico1, medico1);
                if (sucessoDiagnostico1)
                    Console.WriteLine("Diagnóstico 1 adicionado com sucesso.");
                else
                    Console.WriteLine("Falha ao adicionar o diagnóstico 1.");

                bool sucessoDiagnostico2 = gestaoDiagnosticos.AdicionarDiagnostico(diagnostico2, medico1);
                if (sucessoDiagnostico2)
                    Console.WriteLine("Diagnóstico 2 adicionado com sucesso.");
                else
                    Console.WriteLine("Falha ao adicionar o diagnóstico 2.");

                bool existeDiagnostico1 = gestaoDiagnosticos.ExisteDiagnostico(diagnostico1.Id,medico1);
                        Console.WriteLine($"Diagnóstico 1 existe: {existeDiagnostico1}");

                DiagnosticoLight diagnosticoObtido = gestaoDiagnosticos.ObterDiagnostico(diagnostico2.Id,medico1);
                if (diagnosticoObtido != null)
                    Console.WriteLine($"Diagnóstico 2: {diagnosticoObtido.Id}");
                else
                    Console.WriteLine("Diagnóstico 2 não encontrado.");

                bool associacaoSucesso = gestaoDiagnosticos.AssociarConsultaAoDiagnostico(diagnostico1.Id, consulta1.Id);
                if (associacaoSucesso)
                    Console.WriteLine("Consulta associada ao diagnóstico 1 com sucesso.");
                else
                    Console.WriteLine("Falha ao associar consulta ao diagnóstico 1.");

                bool sucessoTexto = gestaoDiagnosticos.AdicionarTextoADescricao(diagnostico1.Id, "Texto adicional ao diagnóstico.",medico1);
                if (sucessoTexto)
                    Console.WriteLine("Texto adicionado à descrição do diagnóstico 1 com sucesso.");
                else
                    Console.WriteLine("Falha ao adicionar texto à descrição do diagnóstico 1.");

                bool sucessoEliminacao = gestaoDiagnosticos.EliminarDiagnostico(diagnostico2.Id,medico1);
                if (sucessoEliminacao)
                    Console.WriteLine("Diagnóstico 2 eliminado com sucesso.");
                else
                    Console.WriteLine("Falha ao eliminar o diagnóstico 2.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao gerir os diagnósticos: {ex.Message}");
            }

            #endregion
        }
    }
}
