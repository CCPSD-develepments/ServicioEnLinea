//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace CamaraComercio.DataAccess.EF.SRM
{
    public partial class HistoricosDocumentos
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string Id = @"Id";
    public static string RegistroId = @"RegistroId";
    public static string DocumentoId = @"DocumentoId";
    public static string FechaDocumento = @"FechaDocumento";
    public static string NoDocumento = @"NoDocumento";
    public static string Libro = @"Libro";
    public static string Folio = @"Folio";
    public static string NoExpediente = @"NoExpediente";
    public static string Documento = @"Documento";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual int RegistroId
        {
            get { return _registroId; }
            set
            {
                if (_registroId != value)
                {
                    if (Registros != null && Registros.RegistroId != value)
                    {
                        Registros = null;
                    }
                    _registroId = value;
                }
            }
        }
        private int _registroId;
    
        public virtual int DocumentoId
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> FechaDocumento
        {
            get;
            set;
        }
    
        public virtual Nullable<int> NoDocumento
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Libro
        {
            get;
            set;
        }
    
        public virtual Nullable<int> Folio
        {
            get;
            set;
        }
    
        public virtual int NoExpediente
        {
            get;
            set;
        }
    
        public virtual string Documento
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
    
        public virtual Registros Registros
        {
            get { return _registros; }
            set
            {
                if (!ReferenceEquals(_registros, value))
                {
                    var previousValue = _registros;
                    _registros = value;
                    FixupRegistros(previousValue);
                }
            }
        }
        private Registros _registros;

        #endregion

        #region Association Fixup
    
        private void FixupRegistros(Registros previousValue)
        {
            if (previousValue != null && previousValue.HistoricosDocumentos.Contains(this))
            {
                previousValue.HistoricosDocumentos.Remove(this);
            }
    
            if (Registros != null)
            {
                if (!Registros.HistoricosDocumentos.Contains(this))
                {
                    Registros.HistoricosDocumentos.Add(this);
                }
                if (RegistroId != Registros.RegistroId)
                {
                    RegistroId = Registros.RegistroId;
                }
            }
        }

        #endregion

    }
}
