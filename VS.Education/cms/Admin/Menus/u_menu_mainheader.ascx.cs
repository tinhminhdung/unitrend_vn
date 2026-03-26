using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.IO;
using Entity;
using System.Drawing.Imaging;

namespace VS.E_Commerce.cms.Admin.Menus
{
    public partial class u_menu_mainheader : System.Web.UI.UserControl
    {
        string nav = "";
        string nav2 = "";
        private string ID = "-1";
        int _cid = -1;
        int _cidc = -1;
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (Request["ID"] != null && !Request["ID"].Equals(""))
            {
                ID = Request["ID"];
            }

            if (!base.IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btncontentsave);
                #endregion

                if (MoreAll.MoreAll.GetParamValue("su").Equals("pages"))
                {
                    this.MultiView1.ActiveViewIndex = 1;
                    this.UpdatePages();
                }
                else
                {
                    this.MultiView1.ActiveViewIndex = 0;
                    this.UpdateList();
                }
                this.ControlControl();
                this.btnCancel.Text = this.label("l_cancel");
                this.btncontentcancel.Text = this.label("l_cancel");
                this.ltcontentpagestype.Text = "Kiểu trang nội dung hiển thị";
                // this.rdinsamepage.Text = this.label("l_displayin1page");
                //  this.rdseperatepages.Text = this.label("l_displayinortherpage");
                this.rdcontentmenu.Text = this.label("l_contentmenu");
                this.rdmodulelink.Text = this.label("l_modulelink");
                this.rdlinkmenu.Text = this.label("l_linkmenu");
            }
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            this.hd_id.Value = this.hd_par_id.Value;
            this.UpdateList();
        }

        protected void btn_Homepage_Click(object sender, EventArgs e)
        {
            this.hd_par_id.Value = "-1";
            this.hd_id.Value = "-1";
            this.UpdateList();
        }

        protected void btn_InsertUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txt_title.Text.Trim().Length < 1)
                {
                    this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn";
                }
                else if (!ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
                {
                    this.lblmsg.Text = "Vui lòng kiểm tra dữ liệu đầu vào của bạn!";
                }
                else
                {
                    string Type = "0";
                    if (this.rdlinkmenu.Checked)
                    {
                        Type = "0";
                    }
                    else if (this.rdcontentmenu.Checked)
                    {
                        Type = "1";
                    }
                    else if (this.rdmodulelink.Checked)
                    {
                        Type = "2";
                    }
                    string Styleshow = "0";
                    if (this.rdinsamepage.Checked)
                    {
                        Styleshow = "1";
                    }
                    else if (this.rdlistcontentpages.Checked)
                    {
                        Styleshow = "2";
                    }
                    else if (this.rdinsamepageCollapPanel.Checked)
                    {
                        Styleshow = "3";
                    }
                    else if (this.rdinLisnews.Checked)
                    {
                        Styleshow = "4";
                    }
                    string status = "0";
                    if (this.chck_Enable.Checked)
                    {
                        status = "1";
                    }
                    string ShowID = "0";
                    if (this.chkenablechildcate.Checked)
                    {
                        ShowID = "1";
                    }
                    string Link = "";
                    if (Type.Equals("2"))
                    {
                        Link = this.ddlmodulelinks.SelectedValue;
                    }
                    else
                    {
                        Link = this.txturl.Text;
                    }
                    Entity.Menu obj = new Entity.Menu();
                    string str6 = this.hd_insertupdate.Value.Trim();

                    if (str6 != null)
                    {
                        if (!(str6 == "update"))
                        {
                            if (str6 == "insert")
                            {
                                #region Menu
                                string TangName = "";
                                int cong = 0;
                                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                                int tong = int.Parse(curItem[0].ID.ToString());
                                cong = tong + 1;
                                var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault();
                                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txt_title.Text);
                                #endregion

                                #region MyRegion
                                obj.Parent_ID = int.Parse(this.hd_id.Value.Trim());
                                obj.capp = More.MN;
                                obj.Type = int.Parse(Type);
                                obj.Lang = lang;
                                obj.Name = txt_title.Text.Trim();
                                obj.Url_Name = RewriteURL.GetNewTitle(txt_title.Text.Trim());
                                obj.Link = Link;
                                obj.Styleshow = Styleshow;
                                obj.Equals = 0;
                                obj.Images = "";
                                obj.Description = "";
                                obj.Create_Date = DateTime.Now;
                                obj.Views = 0;
                                obj.ShowID = int.Parse(ShowID);
                                obj.Orders = int.Parse(txt_order.Text);
                                obj.Level = 0;
                                obj.News = 0;
                                obj.page_Home = 0;
                                obj.Status = int.Parse(status);
                                obj.Titleseo = "";
                                obj.Meta = "";
                                obj.Keyword = "";
                                obj.Check_01 = 0;
                                obj.Check_02 = 0;
                                obj.Check_03 = 0;
                                obj.Check_04 = 0;
                                obj.Check_05 = 0;
                                obj.Noidung1 = "";
                                obj.Noidung2 = "";
                                obj.Noidung3 = "";
                                obj.Noidung4 = "";
                                obj.Noidung5 = "";
                                obj.Module = 0;
                                obj.TangName = TangName;
                                #endregion
                                SMenu.Insert(obj);
                            }
                        }
                        else
                        {
                            #region UpdateMenu
                            string TagName = "";
                            List<Entity.Menu> item = SMenu.GETBYID(hd_page_edit_id.Value);
                            if (item.Count > 0)
                            {
                                Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txt_title.Text;
                                obk.Module = 1;
                                List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(txt_title.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text); } else { TagName = item[0].TangName; }
                                }
                                obk.TangName = TagName;
                                db.SubmitChanges();
                            }
                            #endregion

                            #region MyRegion
                            obj.ID = int.Parse(this.hd_page_edit_id.Value);
                            obj.Parent_ID = int.Parse(this.hd_id.Value.Trim());
                            obj.capp = More.MN;
                            obj.Type = int.Parse(Type);
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURL.GetNewTitle(txt_title.Text.Trim());
                            obj.Link = Link;
                            obj.Styleshow = Styleshow;
                            obj.Equals = 0;
                            obj.Images = "";
                            obj.Description = "";
                            obj.Create_Date = DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = int.Parse(ShowID);
                            obj.Orders = int.Parse(txt_order.Text);
                            obj.Level = 0;
                            obj.News = 0;
                            obj.page_Home = 0;
                            obj.Status = int.Parse(status);
                            obj.Titleseo = "";
                            obj.Meta = "";
                            obj.Keyword = "";
                            obj.Check_01 = 0;
                            obj.Check_02 = 0;
                            obj.Check_03 = 0;
                            obj.Check_04 = 0;
                            obj.Check_05 = 0;
                            obj.Noidung1 = "";
                            obj.Noidung2 = "";
                            obj.Noidung3 = "";
                            obj.Noidung4 = "";
                            obj.Noidung5 = "";
                            obj.Module = 0;
                            obj.TangName = TagName;
                            #endregion
                            SMenu.UPDATE(obj);
                        }
                    }
                    this.UpdateList();
                    this.pn_list.Visible = true;
                    this.pn_insert.Visible = false;
                    this.hd_insertupdate.Value = "";
                    this.txt_title.Text = "";
                    this.lblmsg.Text = "";
                    this.txt_order.Text = More.GetNextCateOrder(More.MN, this.lang, "-1").ToString();
                }
            }
            catch (Exception) { }
        }

        private void btn_link_cancel_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = "";
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
        }

        protected void btncancelcontent_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = "";
            DeleteFormValue();
            UpdatePages();
            this.MultiView1.ActiveViewIndex = 1;
        }

        protected void btncontentsave_Click(object sender, EventArgs e)
        {
            string istatus = "0";
            if (this.chkcontentstatus.Checked)
            {
                istatus = "1";
            }
            #region IMG danh sách tin
            string vimg = this.txtvimg.Text;
            hdimgsmall.Value = vimg;
            hdimgMax.Value = vimg;
            ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
            int vkey = 1;
            if (this.rdFromComputer.Checked)
            {
                if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                {
                    vimg = "/Uploads/pic/news/" + DateTime.Now.Ticks.ToString();
                    String UploadedFile = flimage.PostedFile.FileName;
                    int ExtractPos = UploadedFile.LastIndexOf("/") + 1;
                    String UploadedFileName = UploadedFile.Substring(ExtractPos, UploadedFile.Length - ExtractPos);
                    flimage.PostedFile.SaveAs(Request.PhysicalApplicationPath + vimg + UploadedFileName);
                    String imageUrl = UploadedFileName;
                    int imageHeight = Convert.ToInt32(MoreNews.Height());
                    int imageWidth = Convert.ToInt32(MoreNews.Width());
                    imageUrl = vimg + imageUrl;
                    System.Drawing.Image fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imageUrl));
                    System.Drawing.Image.GetThumbnailImageAbort dummyCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                    System.Drawing.Image thumbNailImg = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero);
                    DateTime MyDate = DateTime.Now;
                    String MyString = ".png";
                    thumbNailImg.Save(Request.PhysicalApplicationPath + vimg + "small" + MyString, ImageFormat.Png);
                    thumbNailImg.Dispose();
                    hdimgMax.Value = vimg + UploadedFileName;
                    hdimgsmall.Value = vimg + "small" + MyString;
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
            MNews obj = new MNews();
            if (this.hdcontentinsertupdate.Value.Equals("insert"))
            {
                #region InsertMenu
                int cong = 0;
                string TangName = "";
                Menu obm = new Menu();
                obm.Name = txtTitle.Text;
                obm.Module = 100;
                List<Entity.Menu> curItem = SMenu.Name_Text("SELECT top 1 * FROM Menu order by ID desc");
                int tong = int.Parse(curItem[0].ID.ToString()); cong = tong + 1; var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTitle.Text)).FirstOrDefault(); TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTitle.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txtTitle.Text);
                obm.TangName = TangName;
                db.Menus.InsertOnSubmit(obm);
                db.SubmitChanges();
                #endregion

                #region MyRegion
                obj.Menu_ID = int.Parse(this.hd_id.Value);
                obj.Title = txtTitle.Text;
                obj.Brief = txtBrief.Text;
                obj.Contents = txtContents.Text;
                obj.Keywords = RewriteReplaceAll.Title(txtTitle.Text + txtBrief.Text + txtContents.Text);
                obj.Equals = vkey;
                obj.Images = hdimgsmall.Value;
                obj.ImagesSmall = hdimgMax.Value;
                obj.Url_Name = TangName;
                obj.User_Name = "";
                obj.Search = "";
                obj.Orders = 0;
                obj.Create_Date = DateTime.Now;
                obj.Modified_Date = DateTime.Now;
                obj.Views = 0;
                obj.Tags = "";
                obj.Lang = lang;
                obj.Types = 0;
                obj.Status = int.Parse(istatus);
                obj.TangName = TangName;
                obj.CheckBox1 = int.Parse(this.CheckBox1.Checked ? "1" : "0");
                obj.CheckBox2 = int.Parse(this.CheckBox2.Checked ? "1" : "0");
                obj.CheckBox3 = int.Parse(this.CheckBox3.Checked ? "1" : "0");
                obj.CheckBox4 = int.Parse(this.CheckBox4.Checked ? "1" : "0");
                obj.CheckBox5 = int.Parse(this.CheckBox5.Checked ? "1" : "0");
                obj.CheckBox6 = int.Parse(this.CheckBox6.Checked ? "1" : "0");
                #endregion
                SMNews.INSERT(obj);
            }
            else
            {
                #region Delete
                if (hdimgsmall.Value.Equals(""))
                {
                    hdimgsmall.Value = this.hdimgsmallEdit.Value;
                }
                if (hdimgMax.Value.Equals(""))
                {
                    hdimgMax.Value = this.hdimgMaxEdit.Value;
                }
                else
                {
                    #region MyRegion
                    try
                    {
                        if ((this.txtvimg.Text.Trim().Length > 0))
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgMaxEdit.Value);
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgsmallEdit.Value);
                        }
                        if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgMaxEdit.Value);
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdimgsmallEdit.Value);
                        }
                    }
                    catch (Exception) { }
                    #endregion
                }
                #endregion

                #region UpdateMenu
                string TagName = "";
               List<MNews> item = SMNews.GET_BY_ID(this.hdcontentid.Value);
                if (item.Count > 0)
                {
                    Menu obk = db.Menus.SingleOrDefault(p => p.TangName == item[0].Url_Name);
                    obk.Name = txtTitle.Text;
                    obk.Module = 100;
                    List<Menu> list = (from p in db.Menus where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                    if (list.Count > 2)
                    {
                        var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTitle.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTitle.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtTitle.Text);
                    }
                    else
                    {
                        if (MoreAll.AddURL.SeoURL(item[0].Title) != MoreAll.AddURL.SeoURL(txtTitle.Text)) { var hasTagName = db.Menus.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txtTitle.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txtTitle.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txtTitle.Text); } else { TagName = item[0].Url_Name; }
                    }
                    obk.TangName = TagName;
                    db.SubmitChanges();
                }
                #endregion


                #region MyRegion
                obj.ID = int.Parse(this.hdcontentid.Value);
                obj.Menu_ID = int.Parse(this.hd_id.Value);
                obj.Title = txtTitle.Text;
                obj.Brief = txtBrief.Text;
                obj.Contents = txtContents.Text;
                obj.Keywords = RewriteReplaceAll.Title(txtTitle.Text + txtBrief.Text + txtContents.Text);
                obj.Equals = vkey;
                obj.Images = hdimgsmall.Value;
                obj.ImagesSmall = hdimgMax.Value;
                obj.Url_Name = TagName;
                obj.User_Name = "";
                obj.Search = "";
                obj.Orders = 0;
                obj.Create_Date = DateTime.Now;
                obj.Modified_Date = DateTime.Now;
                obj.Views = 0;
                obj.Tags = "";
                obj.Lang = lang;
                obj.Types = 0;
                obj.Status = int.Parse(istatus);
                obj.TangName = TagName;
                obj.CheckBox1 = int.Parse(this.CheckBox1.Checked ? "1" : "0");
                obj.CheckBox2 = int.Parse(this.CheckBox2.Checked ? "1" : "0");
                obj.CheckBox3 = int.Parse(this.CheckBox3.Checked ? "1" : "0");
                obj.CheckBox4 = int.Parse(this.CheckBox4.Checked ? "1" : "0");
                obj.CheckBox5 = int.Parse(this.CheckBox5.Checked ? "1" : "0");
                obj.CheckBox6 = int.Parse(this.CheckBox6.Checked ? "1" : "0");
                #endregion
                SMNews.UPDATE(obj);
            }
            this.UpdatePages();
            this.MultiView1.ActiveViewIndex = 1;
            DeleteFormValue();

        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        void DeleteFormValue()
        {
            this.txtTitle.Text = "";
            this.txtBrief.Text = "";
            this.txtContents.Text = "";
            ltimg.Text = "";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            this.lbl_msg.Text = "";
            hdimgMax.Value = "";
            hdimgsmallEdit.Value = "";
            hdimgMaxEdit.Value = "";

        }

        private void BuidRoad()
        {
            List<Entity.Menu> table = new List<Entity.Menu>();
            if (this.hd_id.Value.Equals("-1"))
            {
                this.btn_Homepage.Text = "";
            }
            else
            {
                try
                {
                    if (int.TryParse(hd_id.Value.Trim(), out _cid))
                    {
                        lbl_cur.Text = LoadNav(_cid);
                        ltrnav.Text = ltrnav1.Text = "";
                    }
                }
                catch (Exception)
                { }
                table = SMenu.Detail(this.hd_id.Value.Trim());
                if (table.Count > 0)
                {
                    this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                }
                else
                {
                    this.btn_Homepage.Text = "";
                }
            }
        }

        private void ControlControl()
        {
            if (this.rdcontentmenu.Checked)
            {
                this.rdinsamepage.Visible = true;
                this.rdseperatepages.Visible = true;
                this.rdlistcontentpages.Visible = true;
                this.rdinsamepageCollapPanel.Visible = true;
                this.rdinLisnews.Visible = true;
                this.ddlmodulelinks.Visible = false;
                this.txturl.Visible = false;
                this.txturl.Text = "";
                this.lturl.Visible = false;
                this.ltcontentpagestype.Visible = true;
                this.chkenablechildcate.Visible = true;
                this.Panelrdlis.Visible = true;
            }
            else
            {
                this.rdinsamepage.Visible = false;
                this.rdseperatepages.Visible = false;
                this.rdlistcontentpages.Visible = false;
                this.rdinsamepageCollapPanel.Visible = false;
                this.rdinLisnews.Visible = false;
                this.chkenablechildcate.Visible = false;
                this.ltcontentpagestype.Visible = false;
                this.Panelrdlis.Visible = false;
                if (this.rdmodulelink.Checked)
                {
                    this.txturl.Visible = false;
                    this.ddlmodulelinks.Visible = true;
                    this.lturl.Visible = true;
                    this.lturl.Text = "Chọn Module";
                }
                else
                {
                    this.ddlmodulelinks.Visible = false;
                    this.txturl.Visible = true;
                    this.lturl.Visible = true;
                    this.Panelrdlis.Visible = false;
                    this.lturl.Text = "Liên kết";
                }
            }
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn chắc chắn có muốn xóa?')";
        }

        protected bool EnableButtonContent(string type)
        {
            return type.Equals("1");
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txt_title.Text = "";
            this.txturl.Text = "";
            this.lblmsg.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.MN, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.MN, this.lang, hd_id.Value).ToString();
            }
        }

        protected void lnkaddpagecontent_Click(object sender, EventArgs e)
        {
            this.btncontentsave.Text = this.label("l_insert");
            this.MultiView1.ActiveViewIndex = 2;
            this.hdcontentinsertupdate.Value = "insert";
            loadPanel();
        }

        protected void rdcontentmenu_CheckedChanged(object sender, EventArgs e)
        {
            this.ControlControl();
        }

        protected void rdlinkmenu_CheckedChanged(object sender, EventArgs e)
        {
            this.ControlControl();
        }

        protected void rdmodulelink_CheckedChanged(object sender, EventArgs e)
        {
            this.ControlControl();
        }

        protected void rp_newslist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            switch (e.CommandName)
            {
                #region Edit
                case "Edit":
                    this.btncontentsave.Text = this.label("lupdate");
                    List<Entity.MNews> table = SMNews.GET_BY_ID(str2);
                    if (table.Count > 0)
                    {
                        txtTitle.Text = table[0].Title.ToString();
                        txtBrief.Text = table[0].Brief.ToString();
                        txtContents.Text = table[0].Contents.ToString();
                        hdimgMaxEdit.Value = table[0].ImagesSmall.ToString();
                        hdimgsmallEdit.Value = table[0].Images.ToString();
                        ltimg.Text = MoreImage.Image(table[0].Images.ToString());

                        if (table[0].Status.ToString().Equals("1"))
                        {
                            this.chkcontentstatus.Checked = true;
                        }
                        else
                        {
                            this.chkcontentstatus.Checked = false;
                        }

                        if (table[0].Equals.ToString().Trim().Equals("1"))
                        {
                            this.rdFromLinks.Checked = true;
                            this.rdFromComputer.Checked = false;
                            this.LoadView();
                            this.txtvimg.Text = table[0].ImagesSmall.ToString();
                        }
                        else
                        {
                            this.rdFromComputer.Checked = true;
                            this.rdFromLinks.Checked = false;
                            this.LoadView();
                            this.hdFileName.Value = table[0].ImagesSmall.ToString();
                        }
                    }
                    this.hdcontentid.Value = e.CommandArgument.ToString();
                    this.hdcontentinsertupdate.Value = "update";
                    this.MultiView1.ActiveViewIndex = 2;
                    loadPanel();
                    return;
                #endregion
                #region ChangeSta
                case "ChangeStatusi":
                    string str7 = e.CommandName.Trim();
                    string str24 = e.CommandArgument.ToString().Trim();
                    string str44 = str7;
                    if (str44 != null)
                    {
                        string str3;
                        str24 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str3 = "0";
                        }
                        else
                        {
                            str3 = "1";
                        }
                        SMNews.Name_Text("update MNews set status=" + str3 + " where ID=" + str24 + "");
                        this.UpdatePages();
                        this.MultiView1.ActiveViewIndex = 1;
                        return;
                    }
                    return;
                #endregion
                #region Delete
                case "Delete":
                    List<MNews> ist = SMNews.GET_BY_ID(str2);
                    for (int k = 0; k < ist.Count; k++)
                    {
                        try
                        {
                            ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + ist[k].Images.ToString());
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + ist[k].ImagesSmall.ToString());
                        }
                        catch (Exception) { }
                        try
                        {
                            SMenu.Name_Text("DELETE FROM Menu WHERE TangName ='" + ist[k].TangName + "'");
                        }
                        catch (Exception)
                        { }
                    }
                    ///xoa con thieu
                    SMNews.DELETE(str2);
                    this.UpdatePages();
                    this.MultiView1.ActiveViewIndex = 1;
                    return;
                #endregion
            }
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

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<Entity.Menu> table;
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            switch (str)
            {
                #region EditDetail
                case "EditDetail":
                    this.btn_InsertUpdate.Text = this.label("lupdate");
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "update";
                    this.hd_page_edit_id.Value = str2;
                    table = SMenu.Detail(str2);
                    if (table.Count <= 0)
                    {
                        return;
                    }
                    this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                    this.txt_title.Text = table[0].Name.ToString().Trim();
                    this.txt_order.Text = table[0].Orders.ToString().Trim();
                    this.txturl.Text = table[0].Link.ToString().Trim();
                    if (!table[0].Styleshow.ToString().Equals("0"))
                    {
                        if (table[0].Styleshow.ToString().Equals("1"))
                        {
                            this.rdinsamepage.Checked = true;
                            this.rdseperatepages.Checked = false;
                            this.rdinsamepageCollapPanel.Checked = false;
                            this.rdlistcontentpages.Checked = false;
                            this.rdinLisnews.Checked = false;
                        }
                        else if (table[0].Styleshow.ToString().Equals("2"))
                        {
                            this.rdinsamepage.Checked = false;
                            this.rdseperatepages.Checked = false;
                            this.rdinsamepageCollapPanel.Checked = false;
                            this.rdlistcontentpages.Checked = true;
                            this.rdinLisnews.Checked = false;
                        }
                        else if (table[0].Styleshow.ToString().Equals("3"))
                        {
                            this.rdinsamepage.Checked = false;
                            this.rdseperatepages.Checked = false;
                            this.rdlistcontentpages.Checked = false;
                            this.rdinsamepageCollapPanel.Checked = true;
                            this.rdinLisnews.Checked = false;
                        }
                        else if (table[0].Styleshow.ToString().Equals("4"))
                        {
                            this.rdinsamepage.Checked = false;
                            this.rdseperatepages.Checked = false;
                            this.rdlistcontentpages.Checked = false;
                            this.rdinsamepageCollapPanel.Checked = false;
                            this.rdinLisnews.Checked = true;
                        }
                        break;
                    }
                    this.rdinsamepage.Checked = false;
                    this.rdseperatepages.Checked = true;
                    this.rdinsamepageCollapPanel.Checked = false;
                    this.rdlistcontentpages.Checked = false;
                    this.rdinLisnews.Checked = false;

                    break;
                #endregion
                #region ListChildren
                case "ListChildren":
                    this.hd_id.Value = str2;
                    this.UpdateList();
                    return;
                #endregion
                #region ChangeStatus
                case "ChangeStatus":
                    string str3;
                    str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (!(e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1"))
                    {
                        str3 = "1";
                    }
                    else
                    {
                        str3 = "0";
                    }
                    SMenu.UPDATESTATUS(str2, str3);
                    this.UpdateList();
                    return;
                #endregion
                #region Delete
                case "Delete":
                    try
                    {
                        #region Xoa danh sach tin va anh
                        int k;
                        List<Entity.MNews> dt = SMNews.GET_DETAIL_BYMENUID(str2, More.Sub_Menu(More.MN, str2));
                        for (k = 0; k < dt.Count; k++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + dt[k].Images.ToString());
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + dt[k].ImagesSmall.ToString());
                            }
                            catch (Exception) { }
                        }
                        #endregion
                        SMNews.CATE_DELETE_MENUID(More.Sub_Menu(More.MN, str2));
                        SMenu.DELETE(More.Sub_Menu(More.MN, str2));
                        this.UpdateList();
                        this.ltmsg.Text = "";
                    }
                    catch (Exception)
                    {
                        this.ltmsg.Text = "<span class=alert>Xóa thông tin trong phân mục này trước khi muốn xóa nó!</a>";
                    }
                    return;

                #endregion
                #region MyRegion
                case "moveup":
                    SMenu.UPDATEVIEWS_G(e.CommandArgument.ToString());
                    this.UpdateList();
                    return;

                case "movedown":
                    SMenu.UPDATEVIEWS_T(e.CommandArgument.ToString());
                    this.UpdateList();
                    return;
                #endregion
                #region EditContent
                case "EditContent":
                    this.hd_id.Value = str2;
                    this.ltmsg.Text = "Quản lý nội dung";
                    this.MultiView1.SetActiveView(this.View2);
                    this.BuidRoad();
                    this.UpdatePages();
                    try
                    {
                        if (int.TryParse(str2.ToString(), out _cidc))
                        {
                            ltrnav.Text = LoadNav2(_cidc);
                            ltrnav1.Text = ltrnav.Text;
                            lbl_cur.Text = "";
                        }
                    }
                    catch (Exception)
                    { }
                    return;
                default:
                    return;
                #endregion
            }
            #region MyRegion
            if (table[0].Status.ToString().Trim().Equals("0"))
            {
                this.chck_Enable.Checked = false;
            }
            else if (table[0].Status.ToString().Equals("1"))
            {
                this.chck_Enable.Checked = true;
            }

            // Chọn các radio check
            if (table[0].Type.ToString().Trim().Equals("0"))
            {
                this.rdlinkmenu.Checked = true;
                this.rdmodulelink.Checked = false;
                this.rdcontentmenu.Checked = false;
            }
            else if (table[0].Type.ToString().Equals("1"))
            {
                this.rdmodulelink.Checked = false;
                this.rdlinkmenu.Checked = false;
                this.rdcontentmenu.Checked = true;
            }
            else if (table[0].Type.ToString().Equals("2"))
            {
                this.rdmodulelink.Checked = true;
                this.rdlinkmenu.Checked = false;
                this.rdcontentmenu.Checked = false;
            }


            if (table[0].Type.ToString().Trim().Equals("0") || table[0].Type.ToString().Trim().Equals("2"))
            {
                if (table[0].Type.ToString().Trim().Equals("2"))
                {
                    // this.rdlinkmenu.Checked = false;
                    this.rdmodulelink.Checked = true;
                    this.txturl.Visible = false;
                    this.ddlmodulelinks.Visible = true;
                    this.Panelrdlis.Visible = false;
                    this.chkenablechildcate.Visible = false;
                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlmodulelinks, table[0].Link.ToString().Trim());
                }
                else
                {

                    // this.rdlinkmenu.Checked = true;
                    this.rdmodulelink.Checked = false;
                    this.txturl.Visible = true;
                    this.ddlmodulelinks.Visible = false;
                    this.Panelrdlis.Visible = false;
                    this.txturl.Text = table[0].Link.ToString().Trim();
                }
                //this.rdcontentmenu.Checked = false;
                this.rdinsamepage.Visible = false;
                this.rdseperatepages.Visible = false;
                this.rdinsamepageCollapPanel.Visible = false;
                this.rdinLisnews.Visible = false;
                this.ltcontentpagestype.Visible = false;
                this.chkenablechildcate.Visible = false;
            }
            else if (table[0].Type.ToString().Equals("1"))
            {
                if (table[0].ShowID.ToString().Trim().Equals("0"))
                {
                    this.chkenablechildcate.Checked = false;
                }
                else
                {
                    this.chkenablechildcate.Checked = true;
                }
                // this.rdlinkmenu.Checked = false;
                this.rdcontentmenu.Checked = true;
                this.rdinsamepage.Visible = true;
                this.rdseperatepages.Visible = true;
                this.rdlistcontentpages.Visible = true;
                this.Panelrdlis.Visible = true;
                this.rdinsamepageCollapPanel.Visible = true;
                this.rdinLisnews.Visible = true;
                this.ltcontentpagestype.Visible = true;
                this.ddlmodulelinks.Visible = false;
                this.txturl.Visible = false;
                this.chkenablechildcate.Visible = true;
            }
            #endregion
        }

        protected string TypeMenu(string type, string contentType)
        {
            switch (type)
            {
                case "0":
                    return "Trang liên kết";
                case "1":
                    return "Trang nội dung";
                case "2":
                    return "Trang module";
            }
            return "";
        }

        protected string TypeMenu_Styleshow(string type, string contentType)
        {
            switch (type)
            {
                case "1":
                    if (contentType.Equals("0"))
                    {
                        return "Hiển thị ra tiêu đề và các tin khác";
                    }
                    if (contentType.Equals("1"))
                    {
                        return "Hiển thị trên cùng một trang";
                    }
                    if (contentType.Equals("2"))
                    {
                        return "Hiển thị theo tiêu đề ";
                    }
                    if (contentType.Equals("3"))
                    {
                        return "Kiểu trên cùng một trang - Collap";
                    }
                    if (contentType.Equals("4"))
                    {
                        return "Kiểu danh sách tin (List tin)";
                    }
                    return "";
            }
            return "";
        }

        private void UpdateList()
        {
            if (this.hd_id.Value.Equals(""))
            {
                this.hd_id.Value = "-1";
            }
            List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.MN, this.lang, this.hd_id.Value.Trim());
            this.rp_pagelist.DataSource = table;
            this.rp_pagelist.DataBind();
            this.ltmsg.Text = "";
            this.MultiView1.SetActiveView(this.viwList);
            this.BuidRoad();
        }

        void UpdatePages()
        {
            List<MNew> list = (from p in db.MNews where p.Lang == lang && p.Menu_ID == int.Parse(hd_id.Value) orderby p.Create_Date descending select p).ToList();
            //MNew.Name_Text("select * from MNews where  Menu_ID=" + this.hd_id.Value + "  and Lang='" + lang + "'  order by Create_Date desc");
            rppages.DataSource = list;
            rppages.DataBind();
        }

        void loadPanel()
        {
            List<Entity.Menu> ta = SMenu.Detail(hd_id.Value);
            if (ta.Count > 0)
            {
                if (ta[0].Styleshow.ToString().Equals("4"))
                {
                    this.PanelTextBox.Visible = true;
                }
                else this.PanelTextBox.Visible = false;
            }
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
                        int k;
                        List<Entity.MNews> str = SMNews.IN_ID(More.Sub_Menu(More.MN, id.Value));
                        for (k = 0; k < str.Count; k++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].Images.ToString());
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].ImagesSmall.ToString());
                            }
                            catch (Exception) { }
                            try
                            {
                                SMenu.Name_Text("DELETE FROM Menu WHERE TangName ='" + str[k].TangName + "'");
                            }
                            catch (Exception)
                            { }
                        }
                        SMNews.DELETE(More.Sub_Menu(More.MN, id.Value));
                    }
                }
                UpdatePages();
                this.MultiView1.ActiveViewIndex = 1;
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert> : " + label("lt_youmustdeleteallitemsinthiscategoryfirst") + "</span>";
            }
        }

        protected void btroot_Homepage_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btthemmoind_Click(object sender, EventArgs e)
        {
            this.btncontentsave.Text = this.label("l_insert");
            this.MultiView1.ActiveViewIndex = 2;
            this.hdcontentinsertupdate.Value = "insert";
            loadPanel();
        }

        protected void btthemmoi1_Click(object sender, EventArgs e)
        {
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txt_title.Text = "";
            this.txturl.Text = "";
            this.lblmsg.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.MN, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.MN, this.lang, hd_id.Value).ToString();
            }
        }

        protected void btn_Homepage1_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
        }

        protected void btn1_back_Click(object sender, EventArgs e)
        {
            this.hd_id.Value = this.hd_par_id.Value;
            this.UpdateList();
        }

        protected void btxoa2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_pagelist.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_pagelist.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        #region Xoa danh sach tin va anh
                        int k;
                        List<Entity.MNews> str = SMNews.GET_DETAIL_BYMENUID(id.Value, More.Sub_Menu(More.MN, id.Value));
                        for (k = 0; k < str.Count; k++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].Images.ToString());
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str[k].ImagesSmall.ToString());
                            }
                            catch (Exception) { }
                        }
                        #endregion
                        try
                        {
                            SMenu.Name_Text("DELETE FROM Menu WHERE TangName ='" + str[k].TangName + "'");
                        }
                        catch (Exception)
                        { }
                        SMNews.CATE_DELETE_MENUID(More.Sub_Menu(More.MN, id.Value));
                        SMenu.DELETE(More.Sub_Menu(More.MN, id.Value));
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert> : " + label("lt_youmustdeleteallitemsinthiscategoryfirst") + "</a>";
            }
        }

        private string LoadNav2(int ID)
        {
            var item = db.Menus.FirstOrDefault(s => s.ID == ID);
            if (item != null)
            {
                if (item.Parent_ID == -1)
                {
                    nav2 = " <div class='Namemenu'>" + item.Name + "</div>" + nav2;
                }
                else
                {
                    nav2 = " <div class='Namemenu'><span> >> </span>" + item.Name + "</div>  " + nav2;
                }
                if (item.Parent_ID != -1)
                {
                    LoadNav2(Convert.ToInt32(item.Parent_ID));
                }
            }
            return "<div class=\"menun\"><div class='Namemenu'><span class='pmgoc'>Phân mục gốc</span> : </div>" + nav2 + "</div>";
        }
        private string LoadNav(int ID)
        {
            var item = db.Menus.FirstOrDefault(s => s.ID == ID);
            if (item != null)
            {
                if (item.Parent_ID == -1)
                {
                    nav = " <div class='Namemenu'>" + item.Name + "</div>" + nav;
                }
                else
                {
                    nav = " <div class='Namemenu'><span> >> </span>" + item.Name + "</div>  " + nav;
                }
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return "<div class=\"menun\"><div class='Namemenu'><span class='pmgoc'>Phân mục gốc</span> : </div>" + nav + "</div>";
        }
    }
}