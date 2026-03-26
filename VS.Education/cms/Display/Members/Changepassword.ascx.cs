using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Framework;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class Changepassword : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            if (!base.IsPostBack)
            {
                txtcurrentpass.Focus();
                btnchangepassword.Text = this.label("lt_changepassword");
            }
        }
        protected void btnchangepassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (((this.txtcurrentpass.Text.Trim().Length < 1) || (this.txtnewpassword.Text.Length < 1)) || (this.txtnewpasswordconfirm.Text.Length < 1))
                {
                    this.ltmsg.Text = "Mật khẩu kh\x00f4ng hợp lệ";
                }
                else if (this.txtnewpassword.Text.Trim().Length < 3)
                {
                    this.ltmsg.Text = "Mật khẩu mới kh\x00f4ng hợp lệ";
                }
                else if (!this.txtnewpassword.Text.Equals(this.txtnewpasswordconfirm.Text))
                {
                    this.ltmsg.Text = "Mật khẩu mới kh\x00f4ng hợp lệ";
                }
                else
                {

                    if (MoreAll.MoreAll.GetCookie("Members") != null)
                    {
                        Fusers item = new Fusers();
                        DataTable table = new DataTable();
                        if (item.Getdetailbyunpwd(MoreAll.MoreAll.GetCookies("Members").ToString(), this.txtcurrentpass.Text).Rows.Count < 1)
                        {
                            this.ltmsg.Text = "Mật khẩu hiện tại kh\x00f4ng đ\x00fang";
                        }
                        else
                        {
                            item.users_update_updatepassword(MoreAll.MoreAll.GetCookies("Members").ToString(), this.txtnewpassword.Text.Trim());
                            this.ltmsg.Text = "Mật khẩu đ\x00e3 được đổi";
                        }
                    }
                    else
                    {
                        base.Response.Redirect(MoreAll.MoreAll.RequestUrl(Request.Url.ToString()));
                    }
                }
            }
            catch (Exception) { }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}