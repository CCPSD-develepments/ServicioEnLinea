<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="CamaraComercio.FormsManager" %>
<%@ Import Namespace="System.Xml.XPath" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Xml.Xsl" %>
<%@ Import Namespace="System.Xml" %>

<script runat="server">

    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
        Theme = string.Empty;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string formFilePath = Request["form"];
        if (File.Exists(formFilePath))
        {
            string xmlDefinition = File.ReadAllText(formFilePath);
            DataFormConfiguration config = (DataFormConfiguration)ConfigurationManager.GetSection("dataForms");
            Response.Write(DataFormProcessor.GetHtmlUI(xmlDefinition, config.FormXslFilePath, config.UiWebPath, formFilePath));
        }
    }

</script>

