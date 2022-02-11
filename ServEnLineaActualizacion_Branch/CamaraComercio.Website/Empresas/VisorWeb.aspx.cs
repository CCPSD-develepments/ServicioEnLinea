using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.IO;
using System.Drawing.Imaging;
using CamaraComercio.Website.Helpers;

namespace CamaraComercio.Website.Empresas
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb'
    public partial class VisorWeb : System.Web.UI.Page
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb'
    {

        private byte[] Siguiente 
        {
            get 
            {
                byte[] imagen = null;
               List<byte[]> Imagenes = ((List<byte[]>)Session["Imagenes"]);
                
                if ((PosActual < (Imagenes.Count-1)))
                {
                    PosActual = PosActual + 1;
                    imagen = Imagenes.ElementAt(PosActual);
                    lblCount.Text = string.Format("{0} / {1}", PosActual + 1, Imagenes.Count);

                    if (PosActual == Imagenes.Count)
                        PosActual = PosActual - 1;
                }
                
                return imagen;
            }
        }

        private byte[] Anterior
        {
            get 
            {
                if(PosActual > 0)
                    PosActual = PosActual - 1;
                
                byte[] imagen = null;

                List<byte[]> Imagenes = ((List<byte[]>)Session["Imagenes"]);

                if (!(PosActual >= Imagenes.Count))
                {
                    imagen = Imagenes.ElementAt(PosActual);
                    lblCount.Text = string.Format("{0} / {1}", PosActual + 1, Imagenes.Count);
                }

                return imagen;
            }
        }

        private int PosActual 
        {
            set { ViewState["Pos"] = value; }

            get 
            {
                int pos = 0;
                if (ViewState["Pos"] != null)
                {
                    int.TryParse(ViewState["Pos"].ToString(), out pos);
                }
                return pos;
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb.Page_Load(object, EventArgs)'
        protected void Page_Load(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb.Page_Load(object, EventArgs)'
        {
            if (IsPostBack) return;
            string id = Request.QueryString["id"];
            long value = 0;
            long.TryParse(id, out value);

            //Grabo el log de la transaccion.
            LogTransaccionesMethods.GrabarLogTransacciones(0, "Visualizacion Copias Certificadas", true, User.Identity.Name);
            
            //Cargar las imagenes
            LoadImagen(value);
        }

        /// <summary>
        /// Cargo la imagen del documento.
        /// </summary>
        /// <param name="documentId"></param>
        public void LoadImagen(long documentId)
        {
            //Hago 2 llamadas al metodo ya que el servidor de content da error en la primera llamada.
            try
            {
                GetDocuments(documentId);
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch (Exception ex) 
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                GetDocuments(documentId);
            }
        }

        private void GetDocuments(long documentId)
        {
            kofaxVisorWeb.DocumentWebService ws = new kofaxVisorWeb.DocumentWebService();
            byte[][] listaImagenes = ws.GetDocument(documentId);
            
            List<byte[]> Imagenes = listaImagenes.ToList();
            
            lblCount.Text = string.Format("{0} / {1}", 1, Imagenes.Count);

            //Cargo la primera imagen en el load
            binaryImage.DataValue = Imagenes.ElementAt(0);

            Session["Imagenes"] = Imagenes;
        }

        private static byte[] ReadImage(string p_postedImageFileName, string[] p_fileType)
        {
            bool isValidFileType = false;
            try
            {
                FileInfo file = new FileInfo(p_postedImageFileName);
                
                foreach (string strExtensionType in p_fileType)
                {
                    if (strExtensionType == file.Extension)
                    {
                        isValidFileType = true;
                        break;
                    }
                }
                if (isValidFileType)
                {
                    FileStream fs = new FileStream(p_postedImageFileName, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);

                    byte[] image = br.ReadBytes((int)fs.Length);
                   
                    br.Close();
                    fs.Close();
                    
                    return image;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb.btnNext_Click(object, EventArgs)'
        protected void btnNext_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb.btnNext_Click(object, EventArgs)'
        {
            binaryImage.DataValue = Siguiente;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb.btnBack_Click(object, EventArgs)'
        protected void btnBack_Click(object sender, EventArgs e)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'VisorWeb.btnBack_Click(object, EventArgs)'
        {
            binaryImage.DataValue = Anterior;
        }

        private void CreateFile(byte[] stream) 
        {
            try
            {
                FileStream fs = new FileStream(@"C:\Firmas\imagen1.png",FileMode.CreateNew);
                byte[] buf = stream;
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buf);
                bw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}
 
