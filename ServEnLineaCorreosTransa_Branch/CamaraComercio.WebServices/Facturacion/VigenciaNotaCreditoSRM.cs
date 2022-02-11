using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.WebServices.Facturacion
{
    public class VigenciaNotaCreditoSRM
    {

        #region Propiedades
        

        /// <summary>
        /// Retornar o establece si la nota es valida:
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public string NotaCreditoValida //true/false en char
        {
            get;
            set;
        }

        /// <summary>
        /// Retornar o establece si la nota es valida:
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public DateTime FechaCreacionNota //mostrar la fecha cuando se creo la nota
        {
            get;
            set;
        }

        /// <summary>
        /// Muestra los dias transcurridos al momento de la creacion de la nota:
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public int DiasTranscurridos //0-90
        {
            get;
            set;
        }

        // <summary>
        /// Muestra el Id de la nota:
        /// </summary>
        /// <value>
        /// The valor entregado.
        /// </value>
        public int IdNotaCredito //
        {
            get;
            set;
        }



        #endregion Propiedades
    }
}