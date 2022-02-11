using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace CamaraComercio.Website
{
    [Obsolete("Borrar al pasar a producción")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper'
    public static class Bootstrapper
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper'
    {
        //TODO: Amhed: Borrar al pasar a producción

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper.Setup()'
        public static void Setup()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper.Setup()'
        {
            CreateRoles();
            CreateDefaultUsers();
        }

        private static void CreateDefaultUsers()
        {

            if (Membership.GetUser("supervisor") == null)
            {
                MembershipUser user = Membership.CreateUser("supervisor", "ccpsd123", "ccpsd@nextmedia.com.do");
                Roles.AddUsersToRole(new[] {user.UserName.ToLower()}, MembershipHelper.Roles.Supervisores);
            }

            if (Membership.GetUser("gestor") == null)
            {
                MembershipUser user = Membership.CreateUser("gestor", "ccpsd123", "ccpsd1@nextmedia.com.do");
                Roles.AddUsersToRole(new[] { user.UserName.ToLower() }, MembershipHelper.Roles.Gestores);
            }

            if (Membership.GetUser("empresa") == null)
            {
                MembershipUser user = Membership.CreateUser("empresa", "ccpsd123", "ccpsd2@nextmedia.com.do");
                Roles.AddUsersToRole(new[] { user.UserName.ToLower() }, MembershipHelper.Roles.Empresas);
            }

            if (Membership.GetUser("administrador") == null)
            {
                MembershipUser user = Membership.CreateUser("administrador", "ccpsd123", "ccpsd3@nextmedia.com.do");
                Roles.AddUsersToRole(new[] { user.UserName.ToLower() }, MembershipHelper.Roles.Administradores);
            }
        }

        private static void CreateRoles()
        {
            if (!Roles.RoleExists(MembershipHelper.Roles.Supervisores))
            {
                Roles.CreateRole(MembershipHelper.Roles.Supervisores);
            }

            if (!Roles.RoleExists(MembershipHelper.Roles.Gestores))
            {
                Roles.CreateRole(MembershipHelper.Roles.Gestores);
            }

            if (!Roles.RoleExists(MembershipHelper.Roles.Empresas))
            {
                Roles.CreateRole(MembershipHelper.Roles.Empresas);
            }

            if (!Roles.RoleExists(MembershipHelper.Roles.Administradores))
            {
                Roles.CreateRole(MembershipHelper.Roles.Administradores);
            }
        }


#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper.Validator'
        public static class Validator
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper.Validator'
        {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper.Validator.WebsiteIsReady()'
            public static bool WebsiteIsReady()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Bootstrapper.Validator.WebsiteIsReady()'
            {
                if (!DatabaseIsAvailable("CamaraWebsite")) return false; //Avoid Timeout wait
                if (!DatabaseIsAvailable("CamaraWebsiteErrors")) return false;
                if (!DatabaseIsAvailable("CamaraWebsiteAccounts")) return false;
                return true;
            }

            private static bool DatabaseIsAvailable(string connectionStringName)
            {
                using (
                    SqlConnection connection =
                        new SqlConnection(ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}