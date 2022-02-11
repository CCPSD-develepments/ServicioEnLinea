<%@ Page Language="C#" AutoEventWireup="true"%>
<%@ Import namespace="System.Xml"%>
<%@ Import namespace="System.Collections.Generic"%>
<%@ Import namespace="CamaraComercio.FormsManager"%>
<%@ Import namespace="System.IO"%>

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
        if (!string.IsNullOrEmpty(Request.Params["formId"]) &&
            !string.IsNullOrEmpty(Request.Params["name"]) &&
            !string.IsNullOrEmpty(Request.Params["fieldId"]) &&
            !string.IsNullOrEmpty(Request.Params["fieldName"]) &&
            !string.IsNullOrEmpty(Request.Params["type"]) &&
            !string.IsNullOrEmpty(Request.Params["isMandatory"]) &&
            !string.IsNullOrEmpty(Request.Params["maxLength"]))
        {
            Save();
        }
    }

    private void Save()
    {
        DataForm newForm = DataFormProcessor.Create(Request.Form,GetAllFormsDefinitions());
        string xmlConfig = newForm.ToXml();
        string filename = Path.Combine(Server.MapPath("~/Data/Configuration"), newForm.Name + ".xml");
        File.WriteAllText(filename, xmlConfig, Encoding.Unicode);
        Response.Redirect("view.aspx?form=" + filename);
    }


    protected Dictionary<string,string> GetAllFormsDefinitions()
    {
            Dictionary<string,string> results = new Dictionary<string, string>();
            string[] formDefinitionFiles = System.IO.Directory.GetFiles(Server.MapPath("~/Data/Configuration"), "*.xml");
            foreach (string file in formDefinitionFiles)
            {
                results.Add(GetFormName(file), File.ReadAllText(file));
            }
        return results;
    }

    public string GetFormName(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        return doc.SelectSingleNode("//dataForm/name").InnerText;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
