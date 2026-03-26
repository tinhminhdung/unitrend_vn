using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.Tienich
{
    public partial class Listcontentpages : System.Web.UI.UserControl
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
                Utilities_.LoadDropdownlistDisplayItems(ref this.ddlstatus, this.lang);
                this.btncontentcancel.Text = this.label("l_cancel");
                this.btnshow.Text = this.label("lt_display");
                this.btncontentsave.Text = this.label("l_insert") + "/" + this.label("l_update");
            }
            this.LoadNewsList();
        }

        protected void btncancelcontent_Click(object sender, EventArgs e)
        {
            this.txtcontentcontent.Text = "";
            this.txtcontenttitle.Text = "";
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btncontentsave_Click(object sender, EventArgs e)
        {
            //  try
            {
                if (this.txtcontenttitle.Text.Trim().Length < 1)
                {
                    this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else
                {
                    onlyitems obj = new onlyitems();
                    if (this.hdcontentinsertupdate.Value.Equals("insert"))
                    {
                        obj.vtitle = txtcontenttitle.Text;
                        obj.vcontent = txtcontentcontent.Text;
                        obj.dcreatedate =DateTime.Now;
                        obj.lang = lang;
                        obj.display = int.Parse(chkdisplaytitle.Checked ? "1" : "0");
                        obj.istatus = int.Parse(chkcontentstatus.Checked ? "1" : "0");
                        SOnlyitems.INSERT(obj);
                    }
                    else
                    {
                        obj.idl = int.Parse(hdcontentid.Value);
                        obj.vtitle = txtcontenttitle.Text;
                        obj.vcontent = txtcontentcontent.Text;
                        obj.dcreatedate =DateTime.Now;
                        obj.lang = lang;
                        obj.display = int.Parse(chkdisplaytitle.Checked ? "1" : "0");
                        obj.istatus = int.Parse(chkcontentstatus.Checked ? "1" : "0");
                        SOnlyitems.UPDATE(obj);
                    }
                    this.LoadNewsList();
                    this.MultiView1.ActiveViewIndex = 0;
                    this.txtcontentcontent.Text = "";
                    this.txtcontenttitle.Text = "";
                }
            }
            //catch (Exception) { }
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("admin.aspx?u=sc&st=" + this.ddlstatus.SelectedValue);
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa thông tin?')";
        }

        protected string Enable(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<img src='Uploads/pic/web/icon/action_delete.gif'border='0'>";
            }
            return "<img src='Uploads/pic/web/icon/action_check.gif' border='0'>";
        }

        private void InitializeComponent()
        {
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnkcreatenew_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 1;
            this.hdcontentinsertupdate.Value = "insert";
        }

        void LoadNewsList()
        {
            try
            {
                List<onlyitems> dt = SOnlyitems.LIST_ADMIN(ddlstatus.SelectedValue, lang);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rppages;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 15;
                rppages.DataSource = CollectionPager1.DataSourcePaged;
                rppages.DataBind();
            }
            catch (Exception) { }
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void rp_newslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandName = e.CommandName;
            if (commandName != null)
            {
                if (!(commandName == "Edit"))
                {
                    if (!(commandName == "Delete"))
                    {
                        return;
                    }
                }
                else
                {
                    List<onlyitems> table = SOnlyitems.GET_BY_ID(e.CommandArgument.ToString());
                    if (table.Count > 0)
                    {
                        this.txtcontenttitle.Text = table[0].vtitle.ToString();
                        this.txtcontentcontent.Text = table[0].vcontent.ToString();
                        if (table[0].display.ToString().Equals("1"))
                        {
                            this.chkdisplaytitle.Checked = true;
                        }
                        else
                        {
                            this.chkdisplaytitle.Checked = false;
                        }
                        if (table[0].istatus.ToString().Equals("1"))
                        {
                            this.chkcontentstatus.Checked = true;
                        }
                        else
                        {
                            this.chkcontentstatus.Checked = false;
                        }
                    }
                    this.hdcontentid.Value = e.CommandArgument.ToString();
                    this.hdcontentinsertupdate.Value = "update";
                    this.MultiView1.ActiveViewIndex = 1;
                    return;
                }
                SOnlyitems.DELETE(e.CommandArgument.ToString());
                this.LoadNewsList();
            }
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadNewsList();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 1;
            this.hdcontentinsertupdate.Value = "insert";
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rppages.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rppages.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rppages.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SOnlyitems.DELETE(id.Value);
                    }
                }
                LoadNewsList();
            }
            catch (Exception)
            {
            }
        }
    }
}