using CamaraComercio.DataAccess.EF.CamaraComun;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using CamaraComercio.DataAccess.EF.SRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.Formularios
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData'
    public class FormularioData
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData'
    {
        #region Properties
        #region Gestor Data
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Solicitante'
        public string Solicitante { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Solicitante'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.NombreContacto'
        public string NombreContacto { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.NombreContacto'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmailGestor'
        public string EmailGestor { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmailGestor'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FacturarA'
        public string FacturarA { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FacturarA'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RNC1'
        public string RNC1 { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RNC1'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Cedula'
        public string Cedula { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Cedula'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Telefono'
        public string Telefono { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Telefono'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RNC2'
        public string RNC2 { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RNC2'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.HasComprobante'
        public bool HasComprobante { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.HasComprobante'
        #endregion

        #region Sociedad Data
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RazonSocial'
        public string RazonSocial { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RazonSocial'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.NoRegistro'
        public int NoRegistro { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.NoRegistro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.DireccionSociedad'
        public string DireccionSociedad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.DireccionSociedad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Telefono1'
        public string Telefono1 { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Telefono1'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Telefono2'
        public string Telefono2 { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Telefono2'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmailSociedad'
        public string EmailSociedad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmailSociedad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaEmision'
        public DateTime FechaEmision { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaEmision'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaVencimiento'
        public DateTime FechaVencimiento { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaVencimiento'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaConstitutivo'
        public DateTime FechaConstitutivo { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaConstitutivo'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.DuracionSociedad'
        public int DuracionSociedad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.DuracionSociedad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EstadoActual'
        public int EstadoActual { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EstadoActual'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmpleadosFem'
        public int EmpleadosFem { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmpleadosFem'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmpleadosMasc'
        public int EmpleadosMasc { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.EmpleadosMasc'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.TotalEmpleados'
        public int TotalEmpleados { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.TotalEmpleados'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.NombreComercial'
        public string NombreComercial { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.NombreComercial'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RNCSociedad'
        public string RNCSociedad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.RNCSociedad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.PaginaWeb'
        public string PaginaWeb { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.PaginaWeb'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.sucursales'
        public List<Suscursales> sucursales { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.sucursales'
        #endregion

        #region Servicio
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Servicio'
        public string Servicio { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Servicio'
        #endregion


        #region Socios/Accionistas
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Socios'
        public List<Socios> Socios { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Socios'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.TotalSocios'
        public int TotalSocios { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.TotalSocios'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.TotalAcciones'
        public int TotalAcciones { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.TotalAcciones'
        #endregion

        #region OrganoGestor/ConsejoAdministracion
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Gestores'
        public List<Socios> Gestores { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.Gestores'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.DuracionGestion'
        public int DuracionGestion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.DuracionGestion'
        #endregion

        #region Referencias
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.refBancarias'
        public List<DataAccess.EF.SRM.ReferenciasBancarias> refBancarias { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.refBancarias'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.refComerciales'
        public List<DataAccess.EF.SRM.ReferenciasComerciales> refComerciales { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.refComerciales'
        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaAsamblea'
        public DateTime FechaAsamblea { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaAsamblea'

        #region Datos de pago
        // SE TOMAN LUEGO
        //public string NombreFact { get; set; }
        //public string CedulaFact { get; set; }
        //public string  Beneficiario { get; set; }
        //public decimal MontoDelPago { get; set; }
        //public string MedioPago { get; set; }
        #endregion

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaFormulario'
        public DateTime FechaFormulario { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'FormularioData.FechaFormulario'
        #endregion

        
    }

}