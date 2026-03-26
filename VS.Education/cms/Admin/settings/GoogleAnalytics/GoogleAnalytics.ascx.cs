using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;
using Framework;

namespace VS.E_Commerce.cms.Admin.settings.GoogleAnalytics
{
    public partial class GoogleAnalytics : System.Web.UI.UserControl
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
            this.Page.Form.DefaultButton = btnsetup.UniqueID;
            if (!base.IsPostBack)
            {
                this.binddata();
            }
        }

        private void binddata()
        {
            try
            {
                FSetting DB = new FSetting();
                List<Setting> str = DB.GETBYALL(lang);
                ltmsg.Text = string.Empty;
                if (str.Count >= 1)
                {
                    foreach (Setting its in str)
                    {
                        if (its.Properties == "GoogleAnalytics")
                        {
                            this.txtwebname.Text = its.Value;
                        }
                    }
                }
                this.btnsetup.Text = this.label("l_update");
            }
            catch (Exception) { }
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            try
            {
                Setting obj = new Setting();
                obj.Lang = lang;
                obj.Properties = "GoogleAnalytics";
                obj.Value = txtwebname.Text;
                SSetting.UPDATE(obj);
                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
            catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}