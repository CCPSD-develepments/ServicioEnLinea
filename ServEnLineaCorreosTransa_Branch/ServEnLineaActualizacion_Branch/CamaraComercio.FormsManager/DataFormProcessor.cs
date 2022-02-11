using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Xml.XPath;
using System.Xml.Xsl;
using CamaraComercio.FormsManager.Fields;

namespace CamaraComercio.FormsManager
{
    public static class DataFormProcessor
    {
        #region Instantiate and Fill Form

        public static DataForm Fill(string xmlDefinition, NameValueCollection allValues)
        {
            //Get Form
            DataForm form = DataForm.FromXml(xmlDefinition);

            //Get All Fields Values
            string formId = int.Parse("0" + allValues["FORM_ID"]).ToString();
            foreach (DataFormField field in form.Fields)
            {
                if (field.FieldType == DataFormFieldType.NestedForm)
                {
                    var nestedFormField = ((NestedFormField)field);
                    SaveNestedFormValues(formId, nestedFormField, allValues);
                }
                else
                {
                    SaveFieldValues(formId, field, allValues);
                }
            }
            return form;
        }

        private static void SaveNestedFormValues(string formId, NestedFormField nestedFormField, NameValueCollection allValues)
        {
            //Get Number of Values
            string nestedFormId = string.Format("{0}_{1}", formId, nestedFormField.NestedForm.Name);

            //Build Values for each Field
            DataFormFieldValue nestedValue = new DataFormFieldValue(nestedFormField.Id, "NestedValue");
            foreach (DataFormField field in nestedFormField.NestedForm.Fields)
            {
                SaveFieldValues(nestedFormId, field, allValues);
            }
        }

        private static void SaveFieldValues(string formId, DataFormField field, NameValueCollection allValues)
        {
            //Nested Field
            if (field.FieldType == DataFormFieldType.NestedForm)
            {
                NestedFormField nestedField = field as NestedFormField;
                SaveNestedFormValues(formId, nestedField, allValues);
            }
            else
            {
                //Regular Field

                string valuesKey = string.Format("{0}_{1}", formId, field.Id);
                string countKey = string.Format("{0}_{1}_count", formId, field.Id);
                int instanceCount = 0;

                //HACK:if value doesnt exist, it is a nested form
                if (string.IsNullOrEmpty(allValues[valuesKey])) return;

                //Get Number of Values, Check Field not necessarily sends this value
                if (field.FieldType != DataFormFieldType.Check) instanceCount = int.Parse(allValues[countKey]);

                //Get Values for Values, For checkbox fields this check is different
                string[] instanceValues;
                if (field.FieldType == DataFormFieldType.Check)
                {
                    valuesKey += "selected";
                    instanceValues = new string[] { };
                    ((CheckboxField)field).IsChecked = bool.Parse(allValues[valuesKey]);
                }
                else
                {
                    instanceValues = allValues[valuesKey].Split(',');
                }

                //Create Values Collection to contain info
                DataFormFieldValueCollection values = new DataFormFieldValueCollection();

                //Save Values
                for (int i = 0; i < instanceCount; i++)
                {
                    string val = i > instanceValues.GetUpperBound(0) ? string.Empty : instanceValues[i].Trim();
                    values.Add(new DataFormFieldValue(field.Id, val));
                }
                field.Values = values;
            }
        }

        #endregion

        #region Create Form from Form Definition Data

        public static DataForm Create(NameValueCollection allValues, Dictionary<int, string> allFormsDefinitions)
        {
            string title = allValues["title"];
            string description = allValues["description"];
            string instructions = allValues["instructions"];
            string[] fieldIds = allValues["fieldId"].Split(',');
            string[] fieldNames = allValues["fieldId"].Split(','); //allValues["fieldName"].Split(',');
            string[] fieldSRMs = allValues["SRM"].Split(',');
            string[] fieldTypes = allValues["type"].Split(',');
            string[] fieldMandatory = allValues["isMandatory"].Split(',');
            string[] fieldNumeric = allValues["isNumber"].Split(',');
            string[] fieldLenghts = allValues["maxLength"].Split(',');
            string[] fieldNestedForms = ("" + allValues["nestedForm"]).Split(',');
            string[] fieldOptions = ("" + allValues["options"]).Split(',');
            string[] chkDefaultValues = ("" + allValues["defaultValue"]).Split(',');

            DataForm newForm = null;
            if (fieldIds.Length == fieldNames.Length &&
                fieldIds.Length == fieldTypes.Length &&
                fieldIds.Length == fieldMandatory.Length &&
                fieldIds.Length == fieldNumeric.Length &&
                fieldIds.Length == fieldLenghts.Length)
            {
                //Create Form
                newForm = new DataForm(title, description, instructions);
                for (int i = 0; i < fieldIds.Length; i++)
                {
                    string fieldId = fieldIds[i].Trim();
                    string fieldName = fieldNames[i].Trim();
                    string fieldSRM = fieldSRMs[i].Trim();
                    DataFormFieldType fieldType = (DataFormFieldType)Enum.Parse(typeof(DataFormFieldType), fieldTypes[i]);
                    bool isMandatory = bool.Parse(fieldMandatory[i]);
                    bool isNumber = bool.Parse(fieldNumeric[i]);
                    int maxLength = int.Parse(fieldLenghts[i]);
                    string defaultValue = chkDefaultValues[i].Trim();

                    //Nested Form
                    DataForm nestedForm = null;
                    if (!string.IsNullOrEmpty(fieldNestedForms[i]))
                    {
                        nestedForm = DataForm.FromXml(allFormsDefinitions[Convert.ToInt32(fieldNestedForms[i])]);
                    }

                    //Options
                    string[] options = new string[] { };
                    if (fieldType == DataFormFieldType.DropDown)
                    {
                        options = fieldOptions[i].Split(';');
                    }
                    CreateAndAddField(newForm, fieldId, fieldName, fieldSRM, fieldType, isMandatory,isNumber, maxLength, options, nestedForm, defaultValue);
                }
            }
            else
            {
                throw new FormManagerException("Needed Values to create the form were not supplied. Try Again.");
            }
            return newForm;
        }

        private static void CreateAndAddField(DataForm form, string id, string name, string SRM, DataFormFieldType type, bool mandatory, bool isNumber,
                                              int length, string[] options, DataForm nestedForm, string defaultValue)
        {
            switch (type)
            {
                case DataFormFieldType.Text:
                    form.Fields.Add(new TextField(id, name, SRM, mandatory,isNumber, 1, length));
                    break;
                case DataFormFieldType.Check:
                    form.Fields.Add(new CheckboxField(id, name, SRM, defaultValue, false));
                    break;
                case DataFormFieldType.DropDown:
                    {
                        DropDownField ddf = new DropDownField(id, name, SRM, mandatory, 1);
                        foreach (string option in options)
                        {
                            ddf.Options.Add(option);
                        }
                        form.Fields.Add(ddf);
                    }
                    break;
                case DataFormFieldType.NestedForm:
                    form.Fields.Add(new NestedFormField(id, name, SRM, nestedForm, mandatory, 1));
                    break;
            }
        }

        #endregion

        public static string GetHtmlUI(int dataFormDefinitionId, int instanceId, string formDefinitionXml, DataFormConfiguration config)
        {
            //Set XSL Params
            XsltArgumentList xsltArgs = new XsltArgumentList();
            xsltArgs.AddParam("websiteUrl", "", config.WebsiteUrl);
            xsltArgs.AddParam("action", "", "process.aspx");
            xsltArgs.AddParam("definition", "", Convert.ToBase64String(Encoding.Unicode.GetBytes(formDefinitionXml)));
            xsltArgs.AddParam("formid", "", dataFormDefinitionId);
            xsltArgs.AddParam("instanceid", "", instanceId);

            //Load DataForm Xml
            XPathDocument doc = new XPathDocument(new StringReader(formDefinitionXml));

            //Load default Xsl
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(config.EntryXslPath);

            //Perform Transformation
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                xslt.Transform(doc, xsltArgs, sw);
                return sw.ToString();
            }
        }

        public static string GetHtmlPreview(string formDefinitionXml, string formRenderingXslPath)
        {
            //Load DataForm Xml
            XPathDocument doc = new XPathDocument(new StringReader(formDefinitionXml));

            //Load default Xsl
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(formRenderingXslPath);

            //Perform Transformation
            using (StringWriter sw = new StringWriter(new StringBuilder()))
            {
                xslt.Transform(doc, null, sw);
                return sw.ToString();
            }
        }
    }
}