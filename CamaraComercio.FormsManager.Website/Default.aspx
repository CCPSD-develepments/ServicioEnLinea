<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    protected override void OnPreInit(EventArgs e)
    {
        //Disable Theme
        base.OnPreInit(e);
        Theme = string.Empty;
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<FormItem> newForms = new List<FormItem>();
            string[] formDefinitionFiles = Directory.GetFiles(Server.MapPath("~/Data/Configuration"), "*.xml");
            foreach (string file in formDefinitionFiles)
            {
                newForms.Add(new FormItem(GetFormName(file), file));
            }
            ddlNewForm.DataSource = newForms;
            ddlNewForm.DataBind();

            List<FormItem> editForms = new List<FormItem>();
            string[] formInstanceFiles = Directory.GetFiles(Server.MapPath("~/Data/Instances"), "*.xml");
            foreach (string file in formInstanceFiles)
            {
                editForms.Add(new FormItem(GetFormName(file) + " " + Path.GetFileNameWithoutExtension(file), file));
            }
            ddlExistingForm.DataSource = editForms;
            ddlExistingForm.DataBind();
        }
    }

    public string GetFormName(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        return doc.SelectSingleNode("//dataForm/name").InnerText;
    }

    public class FormItem
    {
        private string name;
        private string path;

        public FormItem(string name, string path)
        {
            this.name = name;
            this.path = path;
        }

        public string Name
        {
            get { return name; }
        }

        public string Path
        {
            get { return path; }
        }
    }

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        body *
        {
            font-family: Calibri, Verdana;
        }
        .subtitle
        {
            font-size: x-large;
        }
        .listTable
        {
            padding: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="get">
    <div style="padding: 15px;">
        <h1>Data Forms ( <a href="Builder.aspx" class="subtitle">Create new Form</a> )</h1>
        <span class="subtitle">Fil out a new Form</span>
        <asp:DataList ID="ddlNewForm" runat="server" RepeatColumns="4">
            <ItemStyle CssClass="listTable" />
            <ItemTemplate>
                - <a href='view.aspx?form=<%#Eval("Path")%>'><%#Eval("Name") %></a>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <span class="subtitle">Edit a Previously Filled out Form</span>
        <asp:DataList ID="ddlExistingForm" runat="server" RepeatColumns="4">
            <ItemStyle CssClass="listTable" />
            <ItemTemplate>
                - <a href='view.aspx?form=<%#Eval("Path")%>'><%#Eval("Name") %></a>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
