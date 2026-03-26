using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.Contacts
{
    public partial class u_ct_setting : System.Web.UI.UserControl
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
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsetup);
                #endregion
                this.binddata();
            }
        }

        private void binddata()
        {
            string str5 = "";
            string EmailLienhe = "";
            string Width = "";
            string Height = "";
            #region Setting
            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "ContactsXacNhan")
                    {
                        this.txtxacnhanemail.Text = its.Value;
                    }
                    else if (its.Properties == "txtbando")
                    {
                        this.txtbando.Text = its.Value;
                    }
                    else if (its.Properties == "Emailden")
                    {
                        this.txtEmail.Text = its.Value;
                    }
                    else if (its.Properties == "Contactspath")
                    {
                        str5 = its.Value;
                    }
                    else if (its.Properties == "EmailLienhe")
                    {
                        EmailLienhe = its.Value;
                    }
                }
            }
            #endregion
            if (EmailLienhe.ToString().Equals("0"))
            {
                this.rdcommentoptioncheckcomments.Checked = false;
                this.rdcommentoptionnotcheckcomments.Checked = true;
            }
            else if (EmailLienhe.Equals("1"))
            {
                this.rdcommentoptioncheckcomments.Checked = true;
                this.rdcommentoptionnotcheckcomments.Checked = false;
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {

            int num = 0;
            if (this.rdcommentoptioncheckcomments.Checked)
            {
                num = 1;
            }
            string vvalue = "";

            Entity.Setting obj = new Entity.Setting();
            obj.Lang = lang;
            obj.Properties = "Contactspath";
            obj.Value = vvalue;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "txtbando";
            obj.Value = txtbando.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "ContactsXacNhan";
            obj.Value = txtxacnhanemail.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "ContactsXacNhan";
            obj.Value = num.ToString();
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Emailden";
            obj.Value = txtEmail.Text;
            SSetting.UPDATE(obj);

            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";

        }
    }
}