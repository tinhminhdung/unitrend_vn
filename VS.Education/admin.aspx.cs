using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using AjaxPro;
using Services;
using System.Data;
using System.IO;
using System.Web.Services;

namespace VS.E_Commerce
{
    public partial class admin1 : System.Web.UI.Page
    {
        private string lang = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            if (!base.IsPostBack)
            {

            }
            #region icon
            string str = Other.Icon();
            LiteralControl lticon = new LiteralControl("<link rel='icon' href='/Uploads/pic/web/icon/" + str + "' type='image/x-icon' /><link rel='shortcut icon' href='/Uploads/pic/web/icon/" + str + "' type='image/x-icon' />");
            Page.Header.Controls.Add(lticon);
            #endregion
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

    }
}