using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;

namespace VS.E_Commerce.cms.Display.OnOff
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                Senmail();
                this.ltcontent.Text = OnOffs.OnOff();
            }
        }
        void Senmail()
        {
            try
            {
                string title = "";
                System.Text.StringBuilder strb = new System.Text.StringBuilder();
                strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
                strb.AppendLine("<div style=\"font-size:18px; font-weight:bold; text-align:center; color:#F00; text-decoration:underline;text-transform:uppercase;\">Website Vi phạm bản quyền của web site : " + MoreAll.Other.website() + "</div> ");
                strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + " - " + DateTime.Now + "</div>");
                string email = "TestSystemWeb@gmail.com";
                string password = "@1234567";
                int port = Convert.ToInt32("587");
                string host = "smtp.gmail.com";
                MailUtilities.SendMail("Website Vi phạm bản quyền" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", email, password, "nvietdung1109@gmail.com", host, port, "Website Vi phạm bản quyền" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "", strb.ToString());
            }
            catch (Exception)
            { }
        }
    }
}