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
    public partial class Variables
    {
        #region Property Metadata
    	
    	public struct PropColumns
    	{
    		public static string VariableId = @"VariableId";
    public static string Descripcion = @"Descripcion";
    public static string TablaVariable = @"TablaVariable";
    public static string CampoVariable = @"CampoVariable";
    public static string ValorPredeterminado = @"ValorPredeterminado";
    public static string TipoFormato = @"TipoFormato";
    public static string Formato = @"Formato";
    public static string TipoDespliegue = @"TipoDespliegue";
    public static string Filtro = @"Filtro";
    public static string CaseFormat = @"CaseFormat";
    public static string TipoVariable = @"TipoVariable";
    public static string MultiCampoVariable = @"MultiCampoVariable";
    public static string MultiCampoDespiegue = @"MultiCampoDespiegue";
    public static string MultiRow = @"MultiRow";
    public static string AutoReplace = @"AutoReplace";
     
    	}
        #endregion

        #region Primitive Properties
    
        public virtual string VariableId
        {
            get;
            set;
        }
    
        public virtual string Descripcion
        {
            get;
            set;
        }
    
        public virtual string TablaVariable
        {
            get;
            set;
        }
    
        public virtual string CampoVariable
        {
            get;
            set;
        }
    
        public virtual string ValorPredeterminado
        {
            get;
            set;
        }
    
        public virtual int TipoFormato
        {
            get;
            set;
        }
    
        public virtual string Formato
        {
            get;
            set;
        }
    
        public virtual int TipoDespliegue
        {
            get;
            set;
        }
    
        public virtual string Filtro
        {
            get;
            set;
        }
    
        public virtual int CaseFormat
        {
            get;
            set;
        }
    
        public virtual int TipoVariable
        {
            get;
            set;
        }
    
        public virtual bool MultiCampoVariable
        {
            get;
            set;
        }
    
        public virtual int MultiCampoDespiegue
        {
            get;
            set;
        }
    
        public virtual bool MultiRow
        {
            get;
            set;
        }
    
        public virtual bool AutoReplace
        {
            get;
            set;
        }

        #endregion

    }
}
