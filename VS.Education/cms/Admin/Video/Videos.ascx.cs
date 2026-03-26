using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.IO;
using MoreAll;
using Entity;
using System.Drawing.Imaging;

namespace VS.E_Commerce.cms.Admin.Video
{
    public partial class Videos : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
        private string status = "";
        ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
        DatalinqDataContext db = new DatalinqDataContext();
        public string ShowXoa = "0";
        public string ShowThem = "0";
        public string ShowSua = "0";
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
            this.Page.Form.DefaultButton = lnksearch.UniqueID;

            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("210"))
                        {
                            ShowThem = "1";
                        }
                        if (strArray[i].ToString().Equals("211"))
                        {
                            ShowSua = "1";
                        }
                        if (strArray[i].ToString().Equals("212"))
                        {
                            ShowXoa = "1";
                        }
                    }
                }
            }

            if (!IsPostBack)
            {
                if (Request["st"] != null && !Request["st"].Equals(""))
                {
                    ddlstatus.SelectedValue = Request["st"];
                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstatus, this.status);
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
                this.btnsave.Text = this.label("l_insert") + "/" + this.label("l_update");
                this.btncancel.Text = this.label("l_cancel");
                LoadCategories();
                LoadItems();
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        #region Menu
        protected void LoadCategories()
        {
            if (Request["id"] != null && !Request["id"].Equals(""))
            {
                ddlcategories.SelectedValue = Request["id"];
            }
            int str = 0;
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.VD, this.lang, "-1", "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == "-1")
                {
                    ddlcategories.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                    ddlcategoriesdetail.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = Categories(dt[i].ID.ToString(), str, "...");
                }
            }
            this.ddlcategories.Items.Insert(0, new ListItem(this.label("l_alls"), "-1"));
            this.ddlcategories.DataBind();
            this.ddlcategoriesdetail.DataBind();
        }
        protected int Categories(string id, int str, string j)
        {
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.VD, this.lang, id, "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == id)
                {
                    ddlcategories.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    ddlcategoriesdetail.Items.Insert(str, new ListItem(j + dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                    str = Categories(dt[i].ID.ToString(), str, j + j);
                }
            }
            return str;
        }
        #endregion

        void LoadItems()
        {
            try
            {
                string[] searchfields = new string[] { "Title", "Brief", "Contents", "search" };
                string orderby = this.ddlorderby.SelectedValue + " " + this.ddlordertype.SelectedValue;
                List<VideoClip> dt = SVideoClip.CATEGORY_ADMIN(orderby, this.txtkeyword.Text.Replace("&nbsp;", ""), searchfields,  lang, ddlstatus.SelectedValue);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpitems;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rpitems.DataSource = CollectionPager1.DataSourcePaged;
                rpitems.DataBind();

            }
            catch (Exception) { }
        }

        protected void lnkcreatenew_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, this.ddlcategories.SelectedValue);
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            DeleteFormValue();
            LoadItems();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategories, this.ddlcategoriesdetail.SelectedValue);
                if (this.txtname.Text.Trim().Length < 1)
                {
                    this.lbl_msg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else
                {
                    string status = "0";
                    if (this.chkstatus.Checked)
                    {
                        status = "1";
                    }
                    string news = "0";
                    if (this.chknews.Checked)
                    {
                        news = "1";
                    }
                    #region Chekdata
                    string Chekdata = "0";
                    string cdate = DateTime.Now.ToString();
                    string edate = DateTime.Now.AddYears(10).ToString();
                    DateTime dcreatedate = Convert.ToDateTime(cdate.ToString());
                    DateTime denddate = Convert.ToDateTime(edate.ToString());
                    if (this.chkdaytype.Checked)
                    {
                        Chekdata = "1";
                        dcreatedate = Convert.ToDateTime(this.txtfromday.Text);
                        denddate = dcreatedate.AddDays((double)Convert.ToInt32(this.txtindays.Text));
                    }
                    #endregion
                    #region Img
                    string vimg = this.txtvimg.Text;
                    hdimgsmall.Value = vimg;
                    hdimgMax.Value = vimg;
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    int vkey = 1;
                    string path = "";
                    string small = "";
                    if (this.rdFromComputer.Checked)
                    {
                        if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                        {
                            String pathcategorise = Database.ConverCodeUni(ddlcategoriesdetail.SelectedItem.Text.Trim());
                            String paths = "/Uploads/pic/Video/" + pathcategorise + "/";
                            if (Directory.Exists(Server.MapPath(paths)) != true)
                            {
                                Directory.CreateDirectory(Server.MapPath(paths));
                            }
                            path = Path.GetFileName(this.flimage.PostedFile.FileName);
                            string str6 = "";
                            str6 = Path.GetExtension(path).ToLower();
                            vimg = paths + DateTime.Now.Ticks.ToString() + str6;
                            flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
                            small = paths + DateTime.Now.Ticks.ToString() + "SMall" + str6;
                            Database.ResizeIamgesFix(Server.MapPath(vimg), Server.MapPath(small), Convert.ToInt32(MoreVideoClip.Height()), Convert.ToInt32(MoreVideoClip.Width()));
                        }
                        else
                        {
                            if ((this.txtvimg.Text.Trim().Length > 0))
                            {
                                vimg = this.hdFileName.Value;
                            }
                        }
                        vkey = 0;
                    }
                    #endregion
                    VideoClip obj = new VideoClip();
                    if (hdinsertupdate.Value.Equals("insert"))
                    {
                        #region InsertMenu
                        int cong = 0;
                        string TangName = "";
                        Menu obm = new Menu();
                        obm.Name = txtname.Text;
                        obm.Module = 8;
                        List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                        int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtname.Text);
                        obm.TangName = TangName;
                        db.Menus.InsertOnSubmit(obm);
                        db.SubmitChanges();
                        #endregion

                        #region MyRegion
                        obj.Menu_ID = 0;
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteReplaceAll.Title(txtname.Text + txtdesc.Text + txtcontent.Text);
                        obj.Images = vimg;
                        obj.ImagesSmall = small;
                        obj.Equals = vkey;
                        obj.Chekdata = int.Parse(Chekdata);
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.lang = this.lang;
                        obj.News = int.Parse(news);
                        obj.Status = int.Parse(status);
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeywordS.Text;
                        obj.TangName = TangName;
                        #endregion
                        SVideoClip.INSERT(obj);
                    }
                    else
                    {
                        #region Delete
                        if (vimg.Equals(""))
                        {
                            vimg = this.hdimgMaxEdit.Value;
                        }
                        if (small.Equals(""))
                        {
                            small = this.hdimgsmallEdit.Value;
                        }
                        else
                        {
                            try
                            {
                                if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                                {
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgMaxEdit.Value);
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgsmallEdit.Value);
                                }
                                if (this.txtvimg.Text.Trim().Length > 0)
                                {
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgMaxEdit.Value);
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgsmallEdit.Value);
                                }
                            }
                            catch (Exception) { }
                        }
                        #endregion


                        #region UpdateMenu
                        string TagName = "";
                        List<Entity.VideoClip> item = SVideoClip.GET_BY_ID(this.hdid.Value);
                        if (item.Count > 0)
                        {
                            Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                            obk.Name = txtname.Text;
                            obk.Module = 8;
                            List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                            if (list.Count > 2)
                            {
                                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtname.Text);
                            }
                            else
                            {
                                if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(txtname.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtname.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtname.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtname.Text); } else { TagName = item[0].TangName; }
                            }
                            obk.TangName = TagName;
                            db.SubmitChanges();
                        }
                        #endregion

                        #region MyRegion
                        obj.ID = int.Parse(hdid.Value);
                        obj.Menu_ID = 0;// int.Parse(ddlcategoriesdetail.SelectedValue);
                        obj.Title = txtname.Text;
                        obj.Brief = txtdesc.Text;
                        obj.Contents = txtcontent.Text;
                        obj.Keywords = txtauthor.Text;
                        obj.search = RewriteReplaceAll.Title(txtname.Text + txtdesc.Text + txtcontent.Text);
                        obj.Images = vimg;
                        obj.ImagesSmall = small;
                        obj.Equals = vkey;
                        obj.Chekdata = int.Parse(Chekdata);
                        obj.Create_Date = dcreatedate;
                        obj.Modified_Date = denddate;
                        obj.Views = 0;
                        obj.lang = this.lang;
                        obj.News = int.Parse(news);
                        obj.Status = int.Parse(status);
                        obj.Titleseo = txttitleseo.Text;
                        obj.Meta = txtmeta.Text;
                        obj.Keyword = txtKeywordS.Text;
                        obj.TangName = TagName;
                        #endregion
                        SVideoClip.UPDATE(obj);
                    }
                    LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    DeleteFormValue();
                }
            }
            catch (Exception) { }
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        void DeleteFormValue()
        {
            txtdesc.Text = "";
            txtcontent.Text = "";
            hdivd.Value = "";
            txtname.Text = "";
            txtcontent.Text = "";
            txtauthor.Text = "";
            ltimg.Text = "";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            this.lbl_msg.Text = "";
            hdimg.Value = "";
            hdimgMax.Value = "";
            hdimgsmallEdit.Value = "";
            hdimgMaxEdit.Value = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeywordS.Text = "";
        }

        protected void Delete_Load(object sender, System.EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa tin được lựa chọn ?.')";
        }

        protected void rpitems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<VideoClip> dtdetail = new List<VideoClip>();
            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":
                    dtdetail = SVideoClip.GET_BY_ID(e.CommandArgument.ToString());
                    if (dtdetail.Count > 0)
                    {
                        txtname.Text = dtdetail[0].Title.ToString();
                        txtdesc.Text = dtdetail[0].Brief.ToString();
                        txtcontent.Text = dtdetail[0].Contents.ToString();
                        txtauthor.Text = dtdetail[0].Keywords.ToString();

                        #region Seowwebsite
                        txttitleseo.Text = dtdetail[0].Titleseo.ToString().Trim();
                        txtmeta.Text = dtdetail[0].Meta.ToString().Trim();
                        txtKeywordS.Text = dtdetail[0].Keyword.ToString().Trim();
                        #endregion

                        hdimgMaxEdit.Value = dtdetail[0].Images.ToString();
                        hdimgsmallEdit.Value = dtdetail[0].ImagesSmall.ToString();
                        ltimg.Text = MoreImage.Image(dtdetail[0].ImagesSmall.ToString());

                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, dtdetail[0].Menu_ID.ToString());
                        if (dtdetail[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chkstatus.Checked = false;
                        }
                        else if (dtdetail[0].Status.ToString().Equals("1"))
                        {
                            this.chkstatus.Checked = true;
                        }
                        this.chkstatus.Checked = true;

                        if (dtdetail[0].News.ToString().Trim().Equals("0"))
                        {
                            this.chknews.Checked = false;
                        }
                        else if (dtdetail[0].News.ToString().Equals("1"))
                        {
                            this.chknews.Checked = true;
                        }
                        #region Update
                        this.txtfromday.Text = Convert.ToDateTime(dtdetail[0].Create_Date).ToString("MM/dd/yyyy HH:mm");
                        this.txtindays.Text = ((Convert.ToDateTime(dtdetail[0].Modified_Date).Ticks - Convert.ToDateTime(dtdetail[0].Create_Date).Ticks) / 0xc92a69c000L).ToString();
                        if (dtdetail[0].Chekdata.ToString().Equals("1"))
                        {
                            this.chkdaytype.Checked = true;
                            this.pnadddate.Visible = true;
                        }
                        else
                        {
                            this.chkdaytype.Checked = false;
                            this.pnadddate.Visible = false;
                        }
                        #endregion

                        if (dtdetail[0].Equals.ToString().Trim().Equals("1"))
                        {
                            this.rdFromLinks.Checked = true;
                            this.rdFromComputer.Checked = false;
                            this.LoadView();
                            this.txtvimg.Text = dtdetail[0].Images.ToString();
                        }
                        else
                        {
                            this.rdFromComputer.Checked = true;
                            this.rdFromLinks.Checked = false;
                            this.LoadView();
                            this.hdFileName.Value = dtdetail[0].Images.ToString();
                        }
                        MultiView1.ActiveViewIndex = 1;
                        hdinsertupdate.Value = "update";
                        hdid.Value = dtdetail[0].ID.ToString();
                        // giu gia tri cua nhom thông tin cu: su dung khi thay doi nhom thông tin.
                        hdivd.Value = dtdetail[0].Menu_ID.ToString();
                        ddlcategoriesdetail.SelectedValue = hdivd.Value;
                    }
                    break;
                #endregion
                #region ChangeStatus
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
                        SVideoClip.VIDeo_UpdateStatus(str2, str3);
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                #endregion
                #region ChangeStatus
                case "ChangeNews":
                    string str1 = e.CommandName.Trim();
                    string str21 = e.CommandArgument.ToString().Trim();
                    string str41 = str1;
                    if (str41 != null)
                    {
                        string str3;
                        str21 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SVideoClip.Name_Text("update VideoClip set News=" + str3 + " where ID=" + str21 + "");
                        this.LoadItems();
                        base.Response.Redirect(base.Request.Url.ToString().Trim());
                        return;
                    }
                    return;
                #endregion
                #region updat_date
                case "updat_date":
                    SVideoClip.UPDATE_DATETIME(e.CommandArgument.ToString(), Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                case "Chekdata":
                    SVideoClip.CHECKDATA(e.CommandArgument.ToString(), "0", Convert.ToDateTime(DateTime.Now.ToString()), Convert.ToDateTime(DateTime.Now.AddYears(20).ToString()));
                    this.LoadItems();
                    MultiView1.ActiveViewIndex = 0;
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    return;
                #endregion
                #region Delete
                case "Delete":
                    List<VideoClip> str5 = SVideoClip.GET_DETAIL_BYID(e.CommandArgument.ToString());
                    if (str5.Count > 0)
                    {
                        try
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].Images.ToString());

                        }
                        catch (Exception) { }
                        try
                        {
                            SMenu.Name_Text("DELETE FROM Menu WHERE TangName=N'" + str5[0].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    SVideoClip.DELETE(e.CommandArgument.ToString());
                    LoadItems();
                    base.Response.Redirect(base.Request.Url.ToString().Trim());
                    break;
                #endregion
            }
        }

        protected void ddlcategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void ddlordertype_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void ddlorderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void btDeleteall_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rpitems.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rpitems.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rpitems.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        int j;
                        List<VideoClip> dlt = SVideoClip.GET_DETAIL_BYID(id.Value);
                        for (j = 0; j < dlt.Count; j++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());

                            }
                            catch (Exception) { }
                            try
                            {
                                SMenu.Name_Text("DELETE FROM Menu WHERE TangName=N'" + dlt[j].TangName + "'");
                            }
                            catch (Exception)
                            {
                            }
                        }
                        SVideoClip.DELETE(id.Value);
                    }
                }
                LoadItems();
                base.Response.Redirect(base.Request.Url.ToString().Trim());
            }
            catch (Exception) { }
        }

        protected void rdFromComputer_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadView();
        }

        protected void rdFromLinks_CheckedChanged(object sender, EventArgs e)
        {
            this.LoadView();
        }

        private void LoadView()
        {
            if (this.rdFromComputer.Checked)
            {
                this.MultiView2.SetActiveView(this.vwFromComputer);
            }
            else
            {
                this.MultiView2.SetActiveView(this.vwFromLinks);
            }
        }

        protected void lnksearch_Click(object sender, EventArgs e)
        {
            LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            hdinsertupdate.Value = "insert";
            MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();
            this.txtfromday.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcategoriesdetail, this.ddlcategories.SelectedValue);
        }

        protected void btDeleteimages_Click(object sender, EventArgs e)
        {
            List<Entity.VideoClip> str5 = SVideoClip.GET_BY_ID(hdid.Value);
            if (str5.Count > 0)
            {
                try
                {
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].Images.ToString());
                    File.Delete(utlitities.APPL_PHYSICAL_PATH + str5[0].ImagesSmall.ToString());
                }
                catch (Exception) { }
            }
            this.hdimgMaxEdit.Value = "";
            this.hdimgsmallEdit.Value = "";

            SVideoClip.UPDATE_IMG(hdid.Value);
            this.LoadItems();
            ltimg.Text = "";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            this.LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void bthienthi_Click(object sender, EventArgs e)
        {
            this.LoadItems();
            Response.Redirect("admin.aspx?u=Video&su=items&id=" + ddlcategories.SelectedValue + "&st=" + ddlstatus.SelectedValue + "&us=" + ddlorderby.SelectedValue + "&ds=" + ddlordertype.SelectedValue + "&kw=" + txtkeyword.Text + "");
        }

        protected void chkdaytype_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkdaytype.Checked)
            {
                this.pnadddate.Visible = true;
            }
            else
            {
                this.pnadddate.Visible = false;
            }
        }
    }
}