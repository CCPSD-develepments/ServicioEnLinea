using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CamaraComercio.Website.DTO.DGII
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc'
    public class SolicitudRnc
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.RazonSocial'
        public string RazonSocial { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.RazonSocial'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NombreComercial'
        public string NombreComercial { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NombreComercial'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.Nacionalidad'
        public string Nacionalidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.Nacionalidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.EmpresaDominicana'
        public bool EmpresaDominicana{ get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.EmpresaDominicana'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.DomicilioFiscal'
        public Direccion DomicilioFiscal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.DomicilioFiscal'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.TipoSociedad'
        public TiposSociedades TipoSociedad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.TipoSociedad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaConstitucion'
        public DateTime FechaConstitucion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaConstitucion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaInicioOperaciones'
        public DateTime FechaInicioOperaciones { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaInicioOperaciones'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.CapitalSocialAutorizado'
        public Decimal CapitalSocialAutorizado { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.CapitalSocialAutorizado'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.CapitalSuscritoPagado'
        public Decimal CapitalSuscritoPagado { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.CapitalSuscritoPagado'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.Moneda'
        public Monedas Moneda { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.Moneda'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.CamaraComercio'
        public String CamaraComercio { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.CamaraComercio'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NoRegistroMercantil'
        public String NoRegistroMercantil { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NoRegistroMercantil'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NoExpedienteOnapi'
        public String NoExpedienteOnapi { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NoExpedienteOnapi'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.ReciboPagoDgii'
        public long ReciboPagoDgii { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.ReciboPagoDgii'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaCierreFiscal'
        public PeriodoFiscal FechaCierreFiscal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaCierreFiscal'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.ActividadPrincipal'
        public string ActividadPrincipal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.ActividadPrincipal'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.ActividadSecundaria'
        public string ActividadSecundaria { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.ActividadSecundaria'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.TipoEntidad'
        public TiposEntidades TipoEntidad { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.TipoEntidad'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.TipoEntidadOtro'
        public string TipoEntidadOtro { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.TipoEntidadOtro'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.Categoria'
        public Categorias Categoria { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.Categoria'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NumeroResolucion'
        public string NumeroResolucion { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.NumeroResolucion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaEnvio'
        public DateTime FechaEnvio { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'SolicitudRnc.FechaEnvio'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion'
    public class Direccion
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Calle'
        public string Calle { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Calle'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Numero'
        public string Numero { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Numero'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.AptLocal'
        public string AptLocal { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.AptLocal'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Sector'
        public string Sector { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Sector'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Provincia'
        public string Provincia { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Provincia'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Municipio'
        public string Municipio { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Municipio'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Telefono'
        public string Telefono { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Telefono'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Celular'
        public string Celular { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Celular'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Fax'
        public string Fax { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Fax'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Email'
        public string Email { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Direccion.Email'
    }
    
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades'
    public enum TiposSociedades
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.HechoParticipacion'
        HechoParticipacion = 1,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.HechoParticipacion'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.Anonima'
        Anonima = 2,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.Anonima'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.SinFinesDeLucroPrivada'
        SinFinesDeLucroPrivada = 3,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.SinFinesDeLucroPrivada'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.PorAcciones'
        PorAcciones = 4,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.PorAcciones'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.SinFinesDeLucroEstatal'
        SinFinesDeLucroEstatal = 5,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.SinFinesDeLucroEstatal'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.Otro'
        Otro = 5
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposSociedades.Otro'
    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Monedas'
    public enum Monedas
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Monedas'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Monedas.RD'
        RD,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Monedas.RD'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Monedas.US'
        US,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Monedas.US'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Monedas.Euro'
        Euro
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Monedas.Euro'
    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades'
    public enum TiposEntidades
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Politica'
        Politica = 1,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Politica'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.SocialCultural'
        SocialCultural = 2,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.SocialCultural'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Religiosa'
        Religiosa = 3,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Religiosa'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Sindical'
        Sindical = 4,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Sindical'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Ayuntamiento'
        Ayuntamiento = 5,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Ayuntamiento'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Condominio'
        Condominio = 6,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Condominio'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Cooperativa'
        Cooperativa = 7, 
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Cooperativa'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Otro'
        Otro = 8
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TiposEntidades.Otro'
    }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Categorias'
    public enum Categorias
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Categorias'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Categorias.ZonaFranca'
        ZonaFranca = 1,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Categorias.ZonaFranca'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Categorias.Importador'
        Importador = 2,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Categorias.Importador'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Categorias.LeyIncentivo'
        LeyIncentivo =3,
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Categorias.LeyIncentivo'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Categorias.Exportador'
        Exportador = 4
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Categorias.Exportador'
    }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PeriodoFiscal'
    public struct PeriodoFiscal
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PeriodoFiscal'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PeriodoFiscal.Mes'
        public int Mes;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PeriodoFiscal.Mes'
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'PeriodoFiscal.Dia'
        public int Dia;
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'PeriodoFiscal.Dia'
    }
}