using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class LogonGoogle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Google"] != null)
            {
                Response.Write(Session["Google"].ToString() + "<br/>");
            }
        }
    }
}