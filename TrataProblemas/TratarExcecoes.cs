using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrataProblemas
{
    /// <summary>
    /// Exceção lançada quando uma entidade já existe.
    /// </summary>
    public class EntidadeJaExisteException : Exception
    {
        #region Atributos

        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        int codigoErro;

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o código de erro associado à exceção.
        /// </summary>
        public int CodigoErro
        {
            get { return codigoErro; }
            private set { codigoErro = value; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="EntidadeJaExisteException"/>.
        /// </summary>
        public EntidadeJaExisteException() : base()
        {
            CodigoErro = 123;
        }

        #endregion
    }

    /// <summary>
    /// Exceção lançada quando um médico não está autorizado.
    /// </summary>
    public class MedicoNaoAutorizadoException : Exception
    {
        #region Atributos

        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        int codigoErro;

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o código de erro associado à exceção.
        /// </summary>
        public int CodigoErro
        {
            get { return codigoErro; }
            private set { codigoErro = value; }
        }
        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="MedicoNaoAutorizadoException"/>.
        /// </summary>
        public MedicoNaoAutorizadoException() : base()
        {
            CodigoErro = 101;
        }
        #endregion
    }

    /// <summary>
    /// Exceção lançada quando uma coleção não foi inicializada corretamente.
    /// </summary>
    public class ColecaoNaoInicializadaException : Exception
    {
        #region Atributos

        /// <summary>
        /// Código de erro associado à exceção.
        /// </summary>
        int codigoErro;

        #endregion

        #region Propriedades

        /// <summary>
        /// Obtém o código de erro associado à exceção.
        /// </summary>
        public int CodigoErro
        {
            get { return codigoErro; }
            private set { codigoErro = value; }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="ColecaoNaoInicializadaException"/>.
        /// </summary>
        public ColecaoNaoInicializadaException() : base()
        {
            CodigoErro = 000;
        }
        #endregion
    }
}
