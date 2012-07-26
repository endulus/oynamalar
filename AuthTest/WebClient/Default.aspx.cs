using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ServiceReference1;

namespace WebClient
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var userId = Request.QueryString["u"];
            var transferId = Request.QueryString["tid"];
            var token = Request.QueryString["tkn"];
            ServiceReference1.AuthServiceClient c = new AuthServiceClient();
            c.ClientCredentials.UserName.UserName = "byshocala";
            c.ClientCredentials.UserName.Password = "none";
            var newSessionId = c.ValidateTransfer("", userId, transferId, token);
            if (newSessionId != null)
            {
                lbl.Text = "Successfully Authenticated <br/>" + userId + " + " + newSessionId;
            }
        }
    }
}
