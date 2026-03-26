using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Admin.Member
{
    public partial class Members : System.Web.UI.UserControl
    {
        public string ShowRS = "0";
        public string ShowXoa = "0";
        public string ShowKhoa = "0";

        private string status = "-1";
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
            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                status = Request["st"];
            }
            if (!base.IsPostBack)
            {
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
                if (Request["kw"] != null && !Request["kw"].Equals(""))
                {
                    txtkeyword.Text = Request["kw"];
                }
                this.ddlstatus.Items.Add(new ListItem(this.label("l_alls"), "-1"));
                this.ddlstatus.Items.Add(new ListItem(this.label("l_enable"), "1"));
                this.ddlstatus.Items.Add(new ListItem(this.label("l_locked"), "0"));
                this.btndisplay.Text = this.label("lt_display");
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);


                if (MoreAll.MoreAll.GetCookie("URole") != null)
                {
                    string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                    if (strArray.Length > 0)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].ToString().Equals("73"))
                            {
                                ShowRS = "1";
                            }
                            if (strArray[i].ToString().Equals("74"))
                            {
                                ShowKhoa = "1";
                            }
                            if (strArray[i].ToString().Equals("75"))
                            {
                                ShowXoa = "1";
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
                        if (strArray[i].ToString().Equals("72"))
                        {
                            this.LoadItems();
                            ischeck = true;
                        }
                    }
                }
                if (ischeck == false)
                {
                    Response.Redirect("/admin.aspx");
                }
            }
        }
        protected void btndisplay_Click(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        protected void lnksearch_Click(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn c\x00f3 muốn x\x00f3a th\x00e0nh vi\x00ean n\x00e0y?')";
        }
        protected bool EnableLock(string status)
        {
            return status.Equals("1");
        }
        protected bool EnablecUnLock(string status)
        {
            return status.Equals("1");
        }
        protected bool EnablecLock(string status)
        {
            return status.Equals("2");
        }
        protected bool EnableUnLock(string status)
        {
            return status.Equals("0");
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        void LoadItems()
        {
            //try
            //{
            string[] searchfields = new string[] { "vfname", "vlname", "vaddress", "vphone", "vemail", "iuser_id" };
            string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
            List<Entity.users> dt = Susers.CATEGORY_ADMIN(orderby, this.txtkeyword.Text.Replace("&nbsp;", ""), searchfields, lang, ddlstatus.SelectedValue);
            CollectionPager1.DataSource = dt;
            CollectionPager1.BindToControl = Repeater1;
            CollectionPager1.MaxPages = 10000;
            CollectionPager1.PageSize = 30;
            Repeater1.DataSource = CollectionPager1.DataSourcePaged;
            Repeater1.DataBind();
            //}
            //catch (Exception)
            //{ }
        }
        protected void Lock_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn c\x00f3 muốn kh\x00f3a t\x00e0i khoản n\x00e0y?')";
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "delete":
                    Susers.DELETE(e.CommandArgument.ToString().Trim());
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "lock":
                    this.UpdateStatus(e.CommandArgument.ToString().Trim(), "0");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "unlock":
                    this.UpdateStatus(e.CommandArgument.ToString().Trim(), "1");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Pass":
                    Susers.Name_Text("update users set vuserpwd='123456' where iuser_id =" + e.CommandArgument.ToString().Trim() + " ");
                    this.LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
            }
        }
        protected string Status(string status)
        {
            if (status.Equals("1"))
            {
                return "Đang hoạt động";
            }
            return "Đ\x00e3 kh\x00f3a";
        }
        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            LoadRequest();
        }
        protected string Enablechon(string chon)
        {
            if (chon.Equals("1"))
            {
                return "Thành viên";
            }
            return "Nội bộ";
        }
        private void UpdateStatus(string un, string status)
        {
            Susers.UPDATE_STATUS(un, status);
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadItems();
            LoadRequest();
        }
        protected void LoadRequest()
        {
            Response.Redirect("admin.aspx?u=Thanhvien&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }
        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < Repeater1.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)Repeater1.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)Repeater1.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        Susers.DELETE(id.Value);
                    }
                }
                LoadItems();
            }
            catch (Exception)
            {

            }
        }
        //protected string TongCartDetail(string id)
        //{
        //    string str = "";
        //    List<Entity.CartDetail> dt = SCartDetail.Detail_ID_Cart(id);
        //    if (dt.Count > 0)
        //    {
        //        str = dt.Count.ToString();
        //    }
        //    return str.ToString();
        //}
    }
}