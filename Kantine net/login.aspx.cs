using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kantine_net
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void loginbtn_Click(object sender, EventArgs e)
        {
            string kode = kodetxt.Text;

            if (kode == "123")
            {
                Response.Redirect("admin.aspx");
            }
            else
            {
                lblerror.Text = "Feil passord";
            }
        }
    }
}