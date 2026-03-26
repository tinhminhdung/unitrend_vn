using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.IO;
using Entity;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.Sitemap
{
    public partial class MapGoogle : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();

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
            if (!IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsave);
                #endregion
                this.ddlstatus.Items.Add(new ListItem(this.label("l_alls"), "-1"));
                this.ddlstatus.Items.Add(new ListItem(this.label("l_checked"), "1"));
                this.ddlstatus.Items.Add(new ListItem(this.label("l_unchecked"), "0"));
                this.btncancel.Text = this.label("l_cancel");
                txtname.Focus();
                this.btnsave.Text = this.label("l_insert") + "/" + this.label("l_update");
                LoadItems();
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btndisplay_Click(object sender, EventArgs e)
        {
            LoadItems();
        }

        void LoadItems()
        {
            try
            {
                List<GoogleMap> dt = SGoogleMap.CATEGORY_ADMIN(lang, ddlstatus.SelectedValue);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();
            }
            catch (Exception) { }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int status = 0;
                if (chkstatus.Checked == true)
                {
                    status = 1;
                }
                string vimg = "";
                string path = "";
                if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                {
                    path = Path.GetFileName(this.flimage.PostedFile.FileName);
                    string str6 = "";
                    str6 = Path.GetExtension(path).ToLower();
                    if ((!str6.Equals(".jpg") && !str6.Equals(".gif")) && (!str6.Equals(".bmp") && !str6.Equals(".png")))
                    {
                        this.lbl_msg.Visible = true;
                        this.lbl_msg.Text = "Kh\x00f4ng hỗ trợ dạng *" + str6 + ". Chỉ hỗ trợ định dạng *.jpg,*.gif,*.bmp,*.png";
                        return;
                    }
                    vimg = "/Uploads/pic/Map/" + DateTime.Now.Ticks.ToString() + str6;
                    flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
                }
                GoogleMap obj = new GoogleMap();
                if (this.hdinsertupdate.Value.Equals("insert"))
                {
                    #region MyRegion
                    obj.Name = this.txtname.Text.Trim();
                    obj.Degrees = txttoado.Text.Trim();
                    obj.vimg = vimg;
                    obj.lang = this.lang;
                    obj.Orders = int.Parse(this.txtoder.Text);
                    obj.Createdate = DateTime.Now;
                    obj.Status = status;
                    #endregion
                    SGoogleMap.INSERT(obj);
                }
                else
                {
                    #region DELETE
                    if (vimg.Equals(""))
                    {
                        vimg = this.hdimg.Value;
                    }
                    else
                    {
                        try
                        {
                            if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                            {
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimg.Value);
                            }
                        }
                        catch (Exception) { }
                    }
                    #endregion
                    #region MyRegion
                    obj.igm = int.Parse(this.hdid.Value);
                    obj.Name = this.txtname.Text.Trim();
                    obj.Degrees = txttoado.Text.Trim();
                    obj.vimg = vimg;
                    obj.lang = this.lang;
                    obj.Orders = int.Parse(this.txtoder.Text);
                    obj.Createdate = DateTime.Now;
                    obj.Status = status;
                    #endregion
                    SGoogleMap.UPDATE(obj);
                }
                MultiView1.ActiveViewIndex = 0;
                LoadItems();
            }
            catch (Exception) { }
        }

        protected void linkcreatenew_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DeleteFormValue();
            LoadItems();
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa Thông Tin vừa Chọn?')";
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                #region update
                case "update":
                    List<GoogleMap> dt = new List<GoogleMap>();
                    dt = SGoogleMap.DETAIL(e.CommandArgument.ToString());
                    if (dt.Count > 0)
                    {
                        this.hdimg.Value = dt[0].vimg.ToString();
                        this.ltimg.Text = MoreImage.Image(dt[0].vimg.ToString());
                        this.txtname.Text = dt[0].Name.ToString();
                        this.txttoado.Text = dt[0].Degrees.ToString();
                        this.txtoder.Text = dt[0].Orders.ToString();

                        if (dt[0].Status.ToString().Equals("1"))
                        {
                            this.chkstatus.Checked = true;
                        }
                        else
                        {
                            this.chkstatus.Checked = false;
                        }
                    }
                    hdid.Value = e.CommandArgument.ToString();
                    MultiView1.ActiveViewIndex = 1;
                    hdinsertupdate.Value = "update";
                    break;
                #endregion
                #region ChangeStatus
                case "ChangeStatus":
                    string str = e.CommandName.Trim();
                    string str2 = e.CommandArgument.ToString().Trim();
                    string str4 = str;
                    if (str4 != null)
                    {
                        string image;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            image = "0";
                        }
                        else
                        {
                            image = "1";
                        }
                        SGoogleMap.UPDATE_STATUS(str2, image);
                        this.LoadItems();
                        return;
                    }
                    break;
                #endregion
                #region delete
                case "delete":
                    List<GoogleMap> table = SGoogleMap.DETAIL(e.CommandArgument.ToString());
                    if (table.Count > 0)
                    {
                        try
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + table[0].vimg.ToString());
                        }
                        catch (Exception) { }
                    }
                    SGoogleMap.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    break;
                #endregion
            }
        }

        void DeleteFormValue()
        {
            txtname.Text = "";
            txttoado.Text = "";
            this.txtoder.Text = "1";
            ltimg.Text = "";
            this.hdFileName.Value = "";

        }

        protected void lnkxoa_Click(object sender, EventArgs e)
        {
            if (!SGoogleMap.DETAIL(hdid.Value).ToString().Equals("-1"))
            {
                try
                {
                    File.Delete(utlitities.APPL_PHYSICAL_PATH + hdimg.Value);
                }
                catch (Exception) { }
            }
            SGoogleMap.UPDATE_IMG(hdid.Value, "");
            MultiView1.ActiveViewIndex = 1;
            LoadItems();
            hdimg.Value = "";
            ltimg.Text = "";
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        protected void btinsert_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
        }

        protected void btdelete_Click(object sender, EventArgs e)
        {
            //try
            //{
            for (int i = 0; i < rpitems.Items.Count; i++)
            {
                CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                if (chk.Checked)
                {
                    #region Xoa danh sach tin va anh
                    int k;
                    List<GoogleMap> str = SGoogleMap.DETAIL(id.Value);
                    for (k = 0; k < str.Count; k++)
                    {
                        try
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].vimg.ToString());
                        }
                        catch (Exception) { }
                    }
                    #endregion
                    SGoogleMap.DELETE(id.Value);
                }
            }
            LoadItems();
            //}
            //catch (Exception) { }
        }

        protected void ddlvalue_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            LoadItems();
        }
    }
}