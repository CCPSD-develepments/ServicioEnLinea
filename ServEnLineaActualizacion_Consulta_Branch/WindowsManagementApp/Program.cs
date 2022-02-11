using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Management.Smo;

namespace WindowsManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var srv = new Server(".\\SQLEXPRESS");
            var login = srv.Logins.Cast<Login>()
                        .Where(logItem => logItem.Name == "NT AUTHORITY\\NETWORK SERVICE").
                        FirstOrDefault();
            
            if (login != null)
            {
                var db = srv.Databases["CamaraWebsite"];
                var permissionSet = new DatabasePermissionSet();
                //db.Grant(permissionSet, "NT AUTHORITY\\NETWORK SERVICE", true, "db_owner");
            }

            Console.Read();
        }
    }
}
