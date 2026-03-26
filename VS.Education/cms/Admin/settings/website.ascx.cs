using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework;
using MoreAll;
using Entity;
using Services;

namespace VS.E_Commerce.cms.Admin.settings
{
    public partial class website : System.Web.UI.UserControl
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
        public void binddata()
        {
            FSetting DB = new FSetting();
            List<Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            string Thongbao = "";
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "website")
                    {
                        this.txtwebsite.Text = its.Value;
                    }
                    else if (its.Properties == "Viphamcontent")
                    {
                        this.txtcontent.Text = its.Value;
                    }
                    else if (its.Properties == "Thongbao")
                    {
                        Thongbao = its.Value;
                    }
                }
            }
            if (Thongbao.Equals("0"))
            {
                this.rdthongbao.Checked = false;
                this.rdthongbaos.Checked = true;
            }
            else if (Thongbao.Equals("1"))
            {
                this.rdthongbao.Checked = true;
                this.rdthongbaos.Checked = false;
            }
            this.btnsetup.Text = this.label("l_update");
        }
        protected void btnsetup_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (this.rdthongbao.Checked)
            {
                num = 1;
            }
            if (Page.IsValid)
            {
                Setting obj = new Setting();
                obj.Lang = lang;
                obj.Properties = "website";
                obj.Value = txtwebsite.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Viphamcontent";
                obj.Value = txtcontent.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Thongbao";
                obj.Value = num.ToString();
                SSetting.UPDATE(obj);


                this.binddata();
                this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}