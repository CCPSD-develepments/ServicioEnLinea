using System;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CamaraComercio.MailBot
{
    public class DataAccess : IDisposable
    {
        SqlConnection _conn;

        public DataAccess()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CamaraMailBot"].ConnectionString);
        }

        public DataTable GetTemplate(string templateCode)
        {
            var cmdGetTemplate = new SqlCommand("TemplateGetByCode", this._conn)
                                     {CommandType = CommandType.StoredProcedure};
            cmdGetTemplate.Parameters.AddWithValue("@TemplateCode", templateCode);
            var daGetTemplate = new SqlDataAdapter(cmdGetTemplate);
            var ds = new DataSet();

            try
            {
                _conn.Open();
                daGetTemplate.Fill(ds);
                return ds.Tables[0];
            }
            finally
            {
                _conn.Close();
            }

        }

        public bool InsertMail(string to, string cc, string bcc, string from, bool isHTML, string mailText, int templateID, int SourceID, string subject)
        {
            var cmdInsertMail = new SqlCommand("MailInsert", this._conn) {CommandType = CommandType.StoredProcedure};
            cmdInsertMail.Parameters.AddWithValue("@TemplateID", templateID);
            cmdInsertMail.Parameters.AddWithValue("@SourceID", SourceID);
            cmdInsertMail.Parameters.AddWithValue("@To", to);
            cmdInsertMail.Parameters.AddWithValue("@CC", cc);
            cmdInsertMail.Parameters.AddWithValue("@BCC", bcc);
            cmdInsertMail.Parameters.AddWithValue("@From", from);
            cmdInsertMail.Parameters.AddWithValue("@IsHtml", isHTML);
            cmdInsertMail.Parameters.AddWithValue("@MailText", mailText);
            cmdInsertMail.Parameters.AddWithValue("@Subject", subject);

            try
            {
                _conn.Open();
                cmdInsertMail.ExecuteNonQuery();
                return true;
            }
            finally
            {
                _conn.Close();
            }
        }

        public bool InsertTemplate(string templateName, string tempalateCode, bool isHtml, string templateText, string subject)
        {
            using (var cmd = new SqlCommand("TemplateInsert", _conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@TemplateName", templateName);
                cmd.Parameters.AddWithValue("@TempalateCode", tempalateCode);
                cmd.Parameters.AddWithValue("@IsHtml", isHtml);
                cmd.Parameters.AddWithValue("@TemplateText", templateText);
                cmd.Parameters.AddWithValue("@Subject", subject);

                try
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    _conn.Close();
                }

            }
        }

        public bool UpdateTemplate(string templateName, string tempalateCode, bool isHtml, string templateText, string subject, int templateId)
        {
            using (var cmd = new SqlCommand("TemplateUpdate", _conn) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@TemplateName", templateName);
                cmd.Parameters.AddWithValue("@TempalateCode", tempalateCode);
                cmd.Parameters.AddWithValue("@IsHtml", isHtml);
                cmd.Parameters.AddWithValue("@TemplateText", templateText);
                cmd.Parameters.AddWithValue("@Subject", subject);
                cmd.Parameters.AddWithValue("@TemplateId", templateId);

                try
                {
                    _conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                finally
                {
                    _conn.Close();
                }

            }
        }

        public DataTable GetTemplate(int? templateId)
        {
            using (var cmd = new SqlCommand("GetTemplate", _conn) { CommandType = CommandType.StoredProcedure })
            {
                if(templateId.HasValue)
                    cmd.Parameters.AddWithValue("@TemplateId", templateId.Value);

                try
                {
                    _conn.Open();
                    var reader = cmd.ExecuteReader();
                    
                    var table = new DataTable();
                    table.Load(reader);

                    return table;
                }
                finally
                {
                    _conn.Close();
                }

            }
        }

        public void Dispose()
        {
            if(_conn.State == ConnectionState.Open)
                _conn.Close();

            _conn = null;
        }
    }
}
