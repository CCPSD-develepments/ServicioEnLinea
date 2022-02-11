using System;
using CamaraComercio.Website;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CamaraComercio.WebServices
{
    public partial class MembershipJsonApi : System.Web.UI.Page
    {
        public string Username {get { return GetParam("username"); }}
        public string Password { get { return GetParam("password"); } }
        public string Token { get { return GetParam("token");}}
        public string AppId { get { return GetParam("appid");}}
        public string Operation { get { return GetParam("op"); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            var responseString = HandleRequest();

            if (String.IsNullOrEmpty(responseString)) return;
            Response.ContentType = "application/json";
            Response.Write(responseString);
        }

        private string HandleRequest()
        {
            string json = String.Empty;
            var service = new MembershipService();
            
            switch (this.Operation.ToLower())
            {
                case "usernameexists":
                    json = service.UsernameExists
                        (this.Username.ToLower()).ToJSON();
                    break;
                case "authuser":
                    json = service.AuthenticateUser
                        (this.Username.ToLower(), this.Password, this.AppId).ToJSON();
                    break;
                case "delegatelogin":
                    json = service.DelegateLogin
                        (this.Username.ToLower(), this.Password, this.AppId).ToJSON();
                    break;
                case "userlogged":
                    json = service.CheckIfLoggedIn(this.Username.ToLower()).ToJSON();
                    break;
                case "userinfo":
                    json = service.UserInfo(this.Username.ToLower()).ToJSON();
                    break;
                default:
                    break;
            }
            return json;
        }

        protected string GetParam(string paranName)
        {
            return !String.IsNullOrWhiteSpace(Request.Form[paranName])
                       ? Request.Form[paranName]
                       : String.Empty;
        }
    }
}