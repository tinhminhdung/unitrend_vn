using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.IO;
using Services;

namespace VS.E_Commerce.cms.Admin.YCBaoGia
{
    public partial class TuVanSanPhamV : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        private string st = "";
        public string ShowXuLy = "0";
        public string ShowXoa = "0";
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

            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                ddlstatus.SelectedValue = Request["st"];
            }
            if (Request["us"] != null && !Request["us"].Equals(""))
            {
                ddlorderby.SelectedValue = Request["us"];
            }
            if (Request["ds"] != null && !Request["ds"].Equals(""))
            {
                ddlordertype.SelectedValue = Request["ds"];
            }
            if (Session["keyword"] != null && !Session["keyword"].Equals(""))
            {
                txtkeyword.Text = Session["keyword"].ToString();
            }

            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("205"))
                        {
                            ShowXoa = "1";
                        }
                        if (strArray[i].ToString().Equals("206"))
                        {
                            ShowXuLy = "1";
                        }
                    }
                }
            }

            bool ischeck = false;
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().Equals("204"))
                    {
                        if (!IsPostBack)
                        {
                            LoadItems();
                        }
                        ischeck = true;
                    }
                }
            }
            if (ischeck == false)
            {
                Response.Redirect("/admin.aspx");
            }
        }

        void LoadItems()
        {
            //try
            {
                string Sql = "";
                if (Request["st"] == "0")
                {
                    Sql += "and istatus=0";
                }
                else if (Request["st"] == "-1")
                {
                    Sql += "";
                }
                else if (Request["st"] == "1")
                {
                    Sql += " and istatus=1";
                }
                if (txtkeyword.Text.Length > 0)
                {
                    Sql += " and vname LIKE  N'%" + txtkeyword.Text + "%'";
                }
                string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;

                List<Entity.TuVanSanPham> dt = STuVanSanPham.Name_Text("select * from TuVanSanPham where 1=1 " + Sql + " order by " + orderby + "");
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();

            }
            // catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected string Showww(string id)
        {
            if (id.Length > 10)
            {
                return "<a target=\"_blank\" style=\" color:red\" href=\"" + id + "\">Tải File</a>";
            }
            return "";
        }
        protected string File_1(string id)
        {
            if (id.Length > 10)
            {
                return "<a target=\"_blank\" style=\" color:red\" href=\"" + id + "\">File 1</a>";
            }
            return "";
        }
        protected string File_2(string id)
        {
            if (id.Length > 10)
            {
                return "<a target=\"_blank\" style=\" color:red\" href=\"" + id + "\">File 2</a>";
            }
            return "";
        }
        protected void btndisplay_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                #region detail
                case "detail":
                    List<Entity.TuVanSanPham> dt = STuVanSanPham.GETBYID(e.CommandArgument.ToString());
                    if (dt.Count > 0)
                    {
                        this.ltsubject.Text = dt[0].vtitle.ToString();
                        this.ltsender.Text = dt[0].vname.ToString();
                        this.ltaddress.Text = dt[0].vaddress.ToString();
                        this.ltphone.Text = dt[0].vphone.ToString();
                        this.ltemail.Text = dt[0].vemail.ToString();
                        this.ltcontent.Text = dt[0].vcontent.ToString();
                        if (dt[0].istatus.ToString().Equals("0"))
                        {
                            this.btncheck.Visible = true;
                        }
                        else
                        {
                            this.btncheck.Visible = false;
                        }
                        hdid.Value = e.CommandArgument.ToString();
                        MultiView1.ActiveViewIndex = 1;
                    }
                    break;
                case "ChangeStatus":
                    string str = e.CommandName.Trim();
                    string str2 = e.CommandArgument.ToString().Trim();
                    string str4 = str;
                    if (str4 != null)
                    {
                        string str3;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        STuVanSanPham.UPDATE_STATUS(str2, str3);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                #endregion
                #region Email
                case "Email":
                    List<Entity.TuVanSanPham> strs = STuVanSanPham.GETBYID(e.CommandArgument.ToString());
                    if (strs.Count > 0)
                    {
                        this.txtTo.Text = strs[0].vemail.ToString();
                        hdid.Value = e.CommandArgument.ToString();
                        MultiView1.ActiveViewIndex = 2;
                        this.txttitle.Text = "";
                        this.lblmsg.Text = "";
                        this.txtContent.Text = "";
                    }
                    break;
                #endregion
                #region delete
                case "delete":
                    STuVanSanPham.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    break;
                    #endregion
            }
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin vừa Chọn?')";
        }

        protected void Delete_Load_Button(object sender, System.EventArgs e)
        {
            ((Button)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin vừa Chọn?')";
        }

        protected void btncheck_Click(object sender, EventArgs e)
        {
            List<Entity.TuVanSanPham> dt = STuVanSanPham.GETBYID(this.hdid.Value);
            if (dt.Count > 0)
            {
                STuVanSanPham.UPDATE_STATUS(this.hdid.Value, "1");
            }
            LoadItems();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            LoadItems();
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            Response.Redirect("admin.aspx?u=TuVanSanPham&st=" + ddlstatus.SelectedValue + "");
        }

        protected void btphanhoi_Click(object sender, EventArgs e)
        {
            List<Entity.TuVanSanPham> dt = STuVanSanPham.GETBYID(this.hdid.Value);
            if (dt.Count > 0)
            {
                txtTo.Text = dt[0].vemail.ToString();
            }
            MultiView1.ActiveViewIndex = 2;
            this.txttitle.Text = "";
            this.lblmsg.Text = "";
            this.txtContent.Text = "";
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            STuVanSanPham.DELETE(this.hdid.Value);
            LoadItems();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Entity.TuVanSanPham> dt = STuVanSanPham.GETBYID(this.hdid.Value);
            if (dt.Count > 0)
            {
                STuVanSanPham.UPDATE_STATUS(this.hdid.Value, "1");
            }
            LoadItems();
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnreplyemail_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txttitle.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn tiêu đề";
                }
                else if (this.txtTo.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn Email đến";
                }
                else if (!ValidateUtilities.IsValidEmail(this.txtTo.Text))
                {
                    this.lblmsg.Text = "Email không hợp lệ";
                }
                else if (this.txtContent.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn nội dung";
                }
                else
                {
                    string email = Email.email();
                    string password = Email.password();
                    int port = Convert.ToInt32(Email.port());
                    string host = Email.host();
                    MailUtilities.SendMail(this.txttitle.Text.Trim(), email, password, this.txtTo.Text, host, port, this.txttitle.Text.Trim(), this.txtContent.Text.Trim());
                    this.txttitle.Text = "";
                    this.txtTo.Text = "";
                    this.lblmsg.Text = "";
                    this.txtContent.Text = "";
                    MultiView1.ActiveViewIndex = 0;
                    LoadItems();
                }
            }
            catch (Exception)
            {
                this.lblmsg.Text = "Hệ thống Email của bạn có thể chưa điền hoặc chưa điền đúng hoặc chưa đúng thông tài khoản Gmail mà chúng tôi yêu cầu";
            }
        }

        protected void btcancelemail_Click(object sender, EventArgs e)
        {
            this.txttitle.Text = "";
            this.txtTo.Text = "";
            this.lblmsg.Text = "";
            this.txtContent.Text = "";
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btdelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rpitems.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        STuVanSanPham.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception) { }
        }

        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            Response.Redirect("admin.aspx?u=TuVanSanPham&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            Response.Redirect("admin.aspx?u=TuVanSanPham&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void lnksearch_Click(object sender, EventArgs e)
        {
            this.LoadItems();
            Session["keyword"] = txtkeyword.Text.Trim();
            Response.Redirect("admin.aspx?u=TuVanSanPham&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }
    }
}