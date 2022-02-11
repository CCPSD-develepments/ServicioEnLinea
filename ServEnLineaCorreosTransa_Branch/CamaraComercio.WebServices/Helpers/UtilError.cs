using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CamaraComercio.WebServices.Helpers
{
   
      public class EmpresaResponse
    {
        public int Flag { get; set; }
        public string RNL { get; set; }
        public string Message { get; set; }
    }

 
 public class UtilError
    {
        private UtilError() { }

        private static EventLog eventLog1 = new EventLog();
       // private static string sRuta = (ConfigurationManager.AppSettings["rutaLog"].ToString() != "") ? ConfigurationManager.AppSettings["rutaLog"].ToString() : AppDomain.CurrentDomain.BaseDirectory;
        
        public static string mensajeEnviado = "";
        public static string encabezadoEnviado = "";

        public static void EscribirEventLog(string mensaje, EventLogEntryType tipo)
        {
            try
            {
                if (!System.Diagnostics.EventLog.SourceExists("LogWebServiceSEL"))
                {
                    System.Diagnostics.EventLog.CreateEventSource(
                        "LogWebServiceSEL", "SEL");
                }
                eventLog1.Source = "LogWebServiceSEL";
                eventLog1.Log = "Application";
                eventLog1.WriteEntry(mensaje, tipo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void InscribirLogError(string mensaje, string tipoError = "WinServices")
        {
            try
            {
                string msg = string.Format("INICIO *** : {0} - [{1}] || {2} *** FIN", tipoError, DateTime.Now, mensaje);
                EscribirEventLog(msg, EventLogEntryType.Error);

                //var ruta = string.Format("{0}logError{1}.txt", sRuta, DateTime.Now.Date.ToShortDateString().Replace("/", "").Replace("-", ""));
                //var fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                //var m_streamWriter = new StreamWriter(fs);
                //m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                //m_streamWriter.WriteLine("INICIO *** : {0} - [{1}] || {2} *** FIN", tipoError, DateTime.Now, mensaje);
                //m_streamWriter.Flush();
                //m_streamWriter.Close();
            }
            catch { }
        }

        public static void InscribirLogOperaciones(string mensaje, string tipoMensaje = "Operaciones")
        {
            try
            {
                string msg = string.Format("INICIO *** : {0} - [{1}] || {2} *** FIN", tipoMensaje, DateTime.Now, mensaje);
                EscribirEventLog(msg, EventLogEntryType.Information);

                //var ruta = string.Format("{0}logOperaciones{1}.txt", sRuta, DateTime.Now.Date.ToShortDateString().Replace("/", "").Replace("-", ""));
                //var fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                //var m_streamWriter = new StreamWriter(fs);
                //m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                //m_streamWriter.WriteLine("INICIO *** : {0} - [{1}] || {2} *** FIN", tipoMensaje, DateTime.Now, mensaje);
                //m_streamWriter.Flush();
                //m_streamWriter.Close();
            }
            catch { }
        }

        public static void InscribirLog(string mensaje)
        {
            try
            {
                string msg = string.Format("INICIO *** : {0} - [{1}] || {2} *** FIN", DateTime.Now, mensaje);
                EscribirEventLog(msg, EventLogEntryType.SuccessAudit);

                //var ruta = string.Format("{0}log{1}.txt", sRuta, DateTime.Now.Date.ToShortDateString().Replace("/", "").Replace("-", ""));
                //var fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                //var m_streamWriter = new StreamWriter(fs);
                //m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                //m_streamWriter.WriteLine("INICIO *** : {0} || {1} *** FIN", DateTime.Now, mensaje);
                //m_streamWriter.Flush();
                //m_streamWriter.Close();
            }
            catch { }
        }

    

    }
}
