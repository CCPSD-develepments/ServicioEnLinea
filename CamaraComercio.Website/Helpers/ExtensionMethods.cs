using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamaraComercio.DataAccess.EF;
using CamaraComercio.DataAccess.EF.OficinaVirtual;
using Telerik.Web.UI;
using System.Web;
using System.Web.Security;
using System.Web.Profile;

namespace CamaraComercio.Website
{
    /// <summary>
    /// Métodos extendidos para facilitar operaciones cotidianas con controles en el UI y strings
    /// </summary>
    public static class ExtensionMethods
    {

        #region Html Helper Extensions

        /// <summary>
        /// Formatea un texto para desplegar como un SPAN en HTML
        /// </summary>
        /// <param name="control"></param>
        /// <param name="html"></param>
        public static void ToSpan(this ITextControl control, object html)
        {
            control.Text = String.Format("<span {0}>{1}</span>", "literals", html);
        }

        /// <summary>
        /// Sobrecarga al método de ToSpan para marcar cambios
        /// </summary>
        /// <param name="control"></param>
        /// <param name="html"></param>
        /// <param name="originalVal"></param>
        public static void ToSpan(this ITextControl control, object html, bool originalVal)
        {
            control.Text = originalVal
                               ? String.Format("<span {0}>{1}</span>", "literals", html)
                               : String.Format("<span {0} class='modified'>{1}</span>", "literals", html);
        }

        /// <summary>
        /// Convierte un List en una lista ordenada en HTML
        /// </summary>
        /// <param name="control"></param>
        /// <param name="requisitos"></param>
        public static void ToOrderedList(this ITextControl control, List<String> requisitos)
        {
            var sb = new StringBuilder();
            sb.Append("<ol class=\"disclaimer\">");
            foreach (var req in requisitos)
            {
                sb.Append(String.Format("<li><p>{0}</p></li>", req));
            }
            sb.Append("</ol>");

            control.Text = sb.ToString();
        }

        /// <summary>
        /// Bindea una coleccion a un control tipo lista
        /// </summary>
        /// <param name="control">Control a bindear</param>
        /// <param name="source">Datasource con la informacion</param>
        /// <param name="valueField">Texto a desplegar en el control</param>
        /// <param name="textField">Valor a guardar por el control</param>
        public static void BindCollection(this ListControl control, object source, string valueField, string textField)
        {
            control.DataSource = source;
            control.DataValueField = valueField;
            control.DataTextField = textField;
            control.DataBind();
        }

        /// <summary>
        /// Bindea una coleccion a un control tipo lista e intenta establecer un objeto predeterminado
        /// </summary>
        /// <param name="control"></param>
        /// <param name="source"></param>
        /// <param name="valueField"></param>
        /// <param name="textField"></param>
        /// <param name="defaultId"></param>
        public static void BindCollection(this ListControl control, object source, string valueField, string textField, string defaultId)
        {
            control.DataSource = source;
            control.DataValueField = valueField;
            control.DataTextField = textField;
            control.DataBind();


            var defaultItem = control.Items.FindByValue(defaultId);
            if (defaultItem != null)
                control.SelectedValue = defaultId;
        }

        /// <summary>
        /// Busqueda de un control dentro de la colección de controles del header de un Repeater
        /// </summary>
        /// <param name="repeater"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public static Control FindControlInHeader(this Repeater repeater, string controlName)
        {
            return repeater.Controls[0].Controls[0].FindControl(controlName);
        }

        /// <summary>
        /// Busqueda de un control dentro de la colección de controles del footer de un Repeater
        /// </summary>
        /// <param name="repeater"></param>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public static Control FindControlInFooter(this Repeater repeater, string controlName)
        {
            return repeater.Controls[repeater.Controls.Count - 1].Controls[0].FindControl(controlName);
        }

#pragma warning disable CS1573 // Parameter 'page' has no matching param tag in the XML comment for 'ExtensionMethods.GenerateCustomError(Page, string, string)' (but other parameters do)
        /// <summary>
        /// Método que asiste en la creación de Custom Error Validators (one time use)
        /// </summary>
        /// <param name="errorMsg">Mensaje de error</param>
        /// <param name="validationGroup">Grupo de validacion (opcional)</param>
        public static void GenerateCustomError(this Page page, string errorMsg, string validationGroup = "")
#pragma warning restore CS1573 // Parameter 'page' has no matching param tag in the XML comment for 'ExtensionMethods.GenerateCustomError(Page, string, string)' (but other parameters do)
        {
            var ctrl = new CustomValidator
            {
                IsValid = false,
                ErrorMessage = errorMsg,
                Display = ValidatorDisplay.None
            };
            if (!String.IsNullOrEmpty(validationGroup))
                ctrl.ValidationGroup = validationGroup;
            
            page.Form.Controls.Add(ctrl);
        }

        #endregion

        #region String Extensions

        /// <summary>
        /// Formato del RNC y la Cedula para facilitar búsquedas en la base de datos
        /// </summary>
        /// <param name="rnc"></param>
        /// <returns></returns>
        public static string FormatRnc(this string rnc)
        {
            if (String.IsNullOrEmpty(rnc))
                return String.Empty;

            rnc = rnc.Replace("-", "");

            switch (rnc.Length)
            {
                case 9:
                    rnc = String.Format("{0}-{1}-{2}-{3}", rnc.Substring(0, 1), rnc.Substring(1, 2), rnc.Substring(3, 5), rnc.Substring(8, 1));
                    break;
                case 11:
                    rnc = String.Format("{0}-{1}-{2}", rnc.Substring(0, 3), rnc.Substring(3, 7), rnc.Substring(10, 1));
                    break;
            }

            return rnc;
        }

#pragma warning disable CS1572 // XML comment has a param tag for 'rnc', but there is no parameter by that name
        /// <summary>
        /// Formato de números de teléfono para facilitar su presentacion
        /// </summary>
        /// <param name="rnc"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static string FormatTelefono(this string tel)
#pragma warning restore CS1572 // XML comment has a param tag for 'rnc', but there is no parameter by that name
        {
            if (String.IsNullOrEmpty(tel))
                return String.Empty;

            tel = tel.Replace("-", "");
            tel = tel.Replace("(", "");
            tel = tel.Replace(")", "");
            tel = tel.Replace(" ", "");


            if (tel.Length >= 10)
            {
                tel = String.Format("({0}) {1}-{2}", tel.Substring(0, 3), tel.Substring(3, 3), tel.Substring(6));
            }

            return tel;
        }

        /// <summary>
        /// Remueve el formato de un texto para guardar en la base de datos
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoverFormato(this String str)
        {
            if (String.IsNullOrWhiteSpace(str))
                return String.Empty;

            var charsInvalidos = new string[] { "(", ")", "-", " ", "," };
            str = charsInvalidos.Aggregate(str, (current, c) => current.Replace(c, ""));
            return str.Trim();
        }

        /// <summary>
        /// Método que cambia los acentos por sus vocales equivalentes
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoverAcentos(this string str)
        {
            str = str.ToLower();
            return str.Replace("á", "a")
                      .Replace("é", "a")
                      .Replace("í", "i")
                      .Replace("ó", "o")
                      .Replace("ú", "u")
                      .Replace("ñ", "n");
        }

        #endregion

        #region Nullable Types Extensions

        /// <summary>
        /// Retorna una fecha aunque el valor del DateTime? sea nulo
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static DateTime Value2(this DateTime? fecha)
        {
            return fecha.HasValue ? fecha.Value : DateTime.Now;
        }

        /// <summary>
        /// Retorna un valor decimal aunque el valor del Decimal? sea nulo
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static Decimal Value2(this Decimal? valor)
        {
            return valor.HasValue ? valor.Value : 0m;
        }

        /// <summary>
        /// Retorna un valor entero aunque el valor del Int32? sea nulo
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static Int32 Value2(this Int32? valor)
        {
            return valor.HasValue ? valor.Value : 0;
        }

        /// <summary>
        /// Retorna un valor boleano aunque el valor del bool? sea nulo
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static bool Value2(this bool? valor)
        {
            return valor.HasValue ? valor.Value : default(bool);
        }

        /// <summary>
        /// Formatea un objeto DateTime con el Locale dominicano
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string ToStringDom(this DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy", new CultureInfo("es-DO"));
            //return fecha.ToString("dd MMMM yyyy", new CultureInfo("es-DO"));
        }

        /// <summary>
        /// Formatea un objeto DateTime con el Locale dominicano con el detalle de la hora
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static string ToStringDomConHora(this DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy hh:mm tt", new CultureInfo("es-DO"));
        }

        #endregion

        #region Texbox Extensions
        /// <summary>
        /// Obtiene el valor decimal de un input control de Telerik
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static Decimal DecimalValue(this RadInputControl txt)
        {
            var valor = 0m;
            if (txt.Text.Length == 0) return valor;
            Decimal.TryParse(txt.Text, out valor);
            return valor;
        }

        /// <summary>
        /// Obtiene el valor decimal de un Label
        /// </summary>
        /// <param name="lbl">Label del cual se leerá el valor decimal</param>
        /// <returns></returns>
        public static Decimal DecimalValue(this Label lbl)
        {
            var valor = 0m;
            if (lbl.Text.Length == 0) return valor;
            Decimal.TryParse(lbl.Text, out valor);
            return valor;
        }

        /// <summary>
        /// Obtiene el valor entero de un input control de telerik
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static Int32 IntegerValue(this RadInputControl txt)
        {
            var valor = 0;
            if (txt.Text.Length == 0) return valor;
            Int32.TryParse(txt.Text, out valor);
            return valor;
        }

        /// <summary>
        /// Obtiene el valor entero de un control textbox
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static Int32 IntegerValue(this TextBox txt)
        {
            var valor = 0;
            if (txt.Text.Length == 0) return valor;
            Int32.TryParse(txt.Text, out valor);
            return valor;
        }

        /// <summary>
        /// Obtiene el valor DateTime de un label
        /// </summary>
        /// <param name="lbl">Label del cual se eleerá el valor de la fecha</param>
        /// <returns></returns>
        public static DateTime? DateValue(this Label lbl)
        {
            DateTime fecha;
            if (lbl.Text.Length == 0) return null;
            return DateTime.TryParse(lbl.Text, out fecha) ? (DateTime?) fecha : null;
        }
        #endregion

        #region Membership Extensions

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ExtensionMethods.IsGestorAdmin(OficinaVirtualUserProfile)'
        public static bool IsGestorAdmin(this OficinaVirtualUserProfile profile)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ExtensionMethods.IsGestorAdmin(OficinaVirtualUserProfile)'
        {
            //si es null el usuario padre o son iguales es gestor administrativo
            if (profile.UsuarioPadre == null || profile.UsuarioPadre == profile.UserName.ToLower() || string.IsNullOrEmpty(profile.UsuarioPadre))
                return true;
            else
                return false;
        }

        #endregion
    }

}
