<%@ Page Language="C#" AutoEventWireup="true"%>
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
        if (string.IsNullOrEmpty(Request.Form["MAIN_FORM"])) return;

        //Get New Instances Path
        string newInstancesPath = HttpContext.Current.Server.MapPath("~/Data/Instances");
        if (!Directory.Exists(newInstancesPath)) Directory.CreateDirectory(newInstancesPath);

        //Load Form Definition
        string formPath = Request.Form["FILE_PATH"];

        //Reload and Fill Submitted Form
        DataForm thisDataForm = DataFormProcessor.Fill(Request.Form);

        //Check if it's a new form
        if (thisDataForm.IsEmpty)
        {
            //This form instance is no longer empty
            thisDataForm.IsEmpty = false;

            //Save New Instance
            string tempName = string.Format("{0}.xml", DateTime.Now.Ticks);
            File.WriteAllText(Path.Combine(newInstancesPath, tempName), thisDataForm.ToXml(), Encoding.Unicode);
        }
        else
        {
            //Overwrite Existing Instance
            File.WriteAllText(formPath, thisDataForm.ToXml(), Encoding.Unicode);
        }

    }
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="refresh" content="3,url=default.aspx">
    <style type="text/css">
        .style1
        {
            font-size: xx-large;
            font-family: Calibri;
            color: #0099CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
        Saving Form ...
    </div>
    </form>
</body>
</html>
