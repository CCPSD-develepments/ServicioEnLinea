<%@ Page Language="C#" AutoEventWireup="true"%>
<%@ Import namespace="System.Xml"%>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    protected override void OnPreInit(EventArgs e)
    {
        //Disable Theme
        base.OnPreInit(e);
        Theme = string.Empty;
    }
    
    protected string allForms = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Data/Configuration/"));
        FileInfo[] files = dir.GetFiles("*.xml");

        StringBuilder result = new StringBuilder();
        result.Append("[Embedded Form];0");
        foreach (FileInfo file in files)
        {
            result.AppendFormat(",{0};{1}", GetFormName(file.FullName), file.Name);
        }
        allForms = result.ToString();
    }
    public string GetFormName(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        return doc.SelectSingleNode("//dataForm/name").InnerText;
    }    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Data Form Builder</title>
    <link href="UI/Common/toolbar.css" rel="stylesheet" type="text/css" />
    <link href="UI/Common/ext-all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="UI/Common/js/ext-base.js"></script>
    <script type="text/javascript" src="UI/Common/js/ext-all.js"></script>
    <script type="text/javascript" src="UI/Common/js/builder.js"></script>
    <style type="text/css">
        body
        {
            font-family: calibri,verdana;
        }
        input {display:inline;}
        select {display:inline;}
        .newField
        {
    	display: block;
    	padding: 4px 2px 4px 10px;
    	border-bottom: solid 1px #c0c0c0;
    	background-color:#FFFFFF;
    	}
    </style>

    <script type="text/javascript">
    
        formBuilder_UI_init();
        
        function validateForm()
        {
            if(formBuilder.lastFieldId==0) return false;
            var info = '';

            if(Ext.getDom('formId').value.length==0) info = '- Provide an id for the form.\n'
            if(Ext.getDom('name').value.length==0) info += '- Provide a name for the form.\n'
            if(Ext.getDom('description').value.length==0) info += '- Provide a description for the form.\n'
            if(Ext.getDom('instructions').value.length==0) info += '- Provide filling instructions for the form.\n'
            for(i=0;i<formBuilder.lastFieldId;i++)
            {
                var icur = i+1;
                var iid = Ext.getDom('id_'+i).value;
                var iname = Ext.getDom('name_'+i).value;
                var itype = Ext.getDom('type_'+i);
                var imandatory = Ext.getDom('isMandatory_'+i);
                var ilength = Ext.getDom('maxLength_'+i);
                var inested = Ext.getDom('nestedForm_'+i);
                var ioptions = Ext.getDom('options_'+i);

                if(iid.length==0) info = info + '- Field ' + icur + ' does not have an id specified.\n';
                if(iname.length==0) info = info + '- Field ' + icur + ' does not have a name specified.\n';
                switch(itype.value)
                {
                   case "DropDown":
                        if(ioptions.length==0) info = info + '- Field ' + icur + ' has an invalid options specification, specify options for drop down.\n';
                    break;
                    case "Text":
                        if(isNaN(ilength.value)) info = info + '- Field ' + icur + ' has a non numeric maximum length.\n';
                        if(ilength<1) info = info + '- Field ' + icur + ' has an invalid maximum length.\n';
                    break;
                    case "Check":
                    break;
                    case "NestedForm":
                        if(inested.value=='') info = info + '- Field ' + icur + ' is missing the nested form selection.\n';
                    break;
                }
            }
            
            if(info == '') return true;
            else 
            {
                alert('Errors in Form:\n' + info);
                return false;
            }
        }
    </script>
    
    <script type="text/javascript">
        var formOptions = "<%=allForms%>";
    </script>
</head>
<body>
    <form id="fieldsForm" method="post" action="Save.aspx" onsubmit="return validateForm();">
    <div style="padding: 40px;">
        <table cellspacing="3" style="width:95%;">
            <tr>
                <td colspan="6">
                    Form Identifier<br />
                    <input type="text" size="40" name="formId" id="formId" /><br />
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    Form Name<br />
                    <input type="text" size="40" name="name" id="name" /><br />
                </td>
            </tr>
            <tr>
                <td style="width:20%">
                    Description<br />
                    <textarea cols="40" rows="4" name="description" id="description"></textarea>
                </td>
                <td style="width:20%">
                    Filling Instructions<br />
                    <textarea cols="40" rows="4" name="instructions" id="instructions"></textarea>
                </td>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="6">
                    Fields<br />
                    <div id="fieldsContainer">
                        <div id="fieldsToolbar" style="width: 100%;"></div>
                        <div id="fields" style="width: 100%;"></div>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="6">
                    <input type="submit" name="Save" value="Save New Form" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
