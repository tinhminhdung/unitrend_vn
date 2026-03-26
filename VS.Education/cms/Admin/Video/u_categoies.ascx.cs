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

namespace VS.E_Commerce.cms.Admin.Video
{
    public partial class u_categoies : System.Web.UI.UserControl
    {
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
            if (!base.IsPostBack)
            {
                this.UpdateList();
                this.btn_back.Text = this.label("l_back");
                this.btn_Homepage.Text = this.label("l_rootcate");
                this.btnCancel.Text = this.label("l_cancel");
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
                    this.lblmsg.Text = "Xin vui lòng kiểm tra dữ liệu đầu vào của bạn!";
                }
                else
                {
                    string status = "0";
                    if (this.chck_Enable.Checked)
                    {
                        status = "1";
                    }
                    string news = "0";
                    if (this.chknews.Checked)
                    {
                        news = "1";
                    }
                    string TrangChu = "0";
                    if (this.chkTrangChu.Checked)
                    {
                        TrangChu = "1";
                    }
                    #region IMG
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    int vkey = 1;
                    string vimg = this.txtvimg.Text;
                    string path = "";
                    if (this.rdFromComputer.Checked)
                    {
                        if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                        {
                            path = Path.GetFileName(this.flimage.PostedFile.FileName);
                            string str6 = "";
                            str6 = Path.GetExtension(path).ToLower();
                            vimg = "/Uploads/pic/News/" + DateTime.Now.Ticks.ToString() + str6;
                            flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
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
                    Entity.Menu obj = new Entity.Menu();
                    string str5 = this.hd_insertupdate.Value.Trim();
                    if (str5 != null)
                    {
                        if (!(str5 == "update"))
                        {
                            if (str5 == "insert")
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


                                #region Insert
                                obj.Parent_ID = Convert.ToInt32(this.hd_id.Value.Trim());
                                obj.capp = More.VD;
                                obj.Type = -1;
                                obj.Lang = lang;
                                obj.Name = txt_title.Text.Trim();
                                obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                                obj.Link = "";
                                obj.Styleshow = "";
                                obj.Equals = vkey;
                                obj.Images = vimg;
                                obj.Description = txtNoiDung.Text;
                                obj.Create_Date = DateTime.Now;
                                obj.Views = 0;
                                obj.ShowID = 100;
                                obj.Orders = Convert.ToInt32(txt_order.Text);
                                obj.Level = 100;
                                obj.News = Convert.ToInt32(chknews.Checked ? "1" : "0");
                                obj.page_Home = Convert.ToInt32(chkTrangChu.Checked ? "1" : "0");
                                obj.Status = Convert.ToInt32(chck_Enable.Checked ? "1" : "0");
                                obj.Titleseo = txttitleseo.Text;
                                obj.Meta = txtmeta.Text;
                                obj.Keyword = txtKeyword.Text;
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
                                obj.Module = 7;
                                obj.TangName = TangName;
                                #endregion
                                SMenu.Insert(obj);
                            }
                        }
                        else
                        {
                            #region DELETE
                            if (vimg.Equals(""))
                            {
                                vimg = this.hdFileName.Value;
                            }
                            else
                            {
                                try
                                {
                                    if ((this.txtvimg.Text.Trim().Length > 0))
                                    {
                                        File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdFileName.Value);
                                    }
                                    if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
                                    {
                                        File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdFileName.Value);
                                    }
                                }
                                catch (Exception) { }
                            }
                            #endregion
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

                            #region Update
                            obj.ID = Convert.ToInt32(this.hd_page_edit_id.Value);
                            obj.Parent_ID = Convert.ToInt32(this.hd_id.Value.Trim());
                            obj.capp = More.VD;
                            obj.Type = -1;
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                            obj.Link = "";
                            obj.Styleshow = "";
                            obj.Equals = vkey;
                            obj.Images = vimg;
                            obj.Description = txtNoiDung.Text;
                            obj.Create_Date = DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = 100;
                            obj.Orders = Convert.ToInt32(txt_order.Text);
                            obj.Level = 100;
                            obj.News = Convert.ToInt32(chknews.Checked ? "1" : "0");
                            obj.page_Home = Convert.ToInt32(chkTrangChu.Checked ? "1" : "0");
                            obj.Status = Convert.ToInt32(chck_Enable.Checked ? "1" : "0");
                            obj.Titleseo = txttitleseo.Text;
                            obj.Meta = txtmeta.Text;
                            obj.Keyword = txtKeyword.Text;
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
                            obj.Module = 7;
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
                    this.txt_order.Text = "";
                    this.txtvimg.Text = "";
                    this.hdFileName.Value = "";
                    ltimg.Text = "";
                    this.txtNoiDung.Text = "";
                    txttitleseo.Text = "";
                    txtmeta.Text = "";
                    txtKeyword.Text = "";
                    pnseo.Visible = false;
                    this.lblmsg.Text = "";
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
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            ltimg.Text = "";
            this.txtNoiDung.Text = "";
            this.lblmsg.Text = "";
            txttitleseo.Text = "";
            txtmeta.Text = "";
            txtKeyword.Text = "";
            pnseo.Visible = false;
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa bài viết này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            this.ltimg.Text = "";
            this.txtNoiDung.Text = "";
            this.lblmsg.Text = "";
            this.txt_title.Text = "";
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;

            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VD, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VD, this.lang, hd_id.Value).ToString();
            }
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;

            switch (e.CommandName)
            {
                #region EditDetail
                case "EditDetail":

                    List<Entity.Menu> table = SMenu.GETBYID(str2);
                    if (table.Count > 0)
                    {
                        this.btn_InsertUpdate.Text = this.label("l_update");
                        // this.lt_info.Text = " - " + this.label("lt_edit");
                        this.pn_list.Visible = false;
                        this.pn_insert.Visible = true;
                        this.hd_insertupdate.Value = "update";
                        this.hd_page_edit_id.Value = str2.Trim();
                        if (table.Count > 0)
                        {
                            this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                            this.hdid.Value = table[0].ID.ToString().Trim();
                            this.txt_title.Text = table[0].Name.ToString().Trim();
                            this.txt_order.Text = table[0].Orders.ToString().Trim();
                            this.txtNoiDung.Text = table[0].Description.ToString().Trim();
                            #region Seowwebsite
                            if (table[0].Titleseo.ToString().Length > 0)
                            {
                                pnseo.Visible = true;
                            }
                            txttitleseo.Text = table[0].Titleseo.ToString().Trim();
                            txtmeta.Text = table[0].Meta.ToString().Trim();
                            txtKeyword.Text = table[0].Keyword.ToString().Trim();
                            #endregion
                            ltimg.Text = MoreImage.Image(table[0].Images.ToString());
                            hdFileName.Value = table[0].Images.ToString();
                            if (table[0].Status.ToString().Trim().Equals("0"))
                            {
                                this.chck_Enable.Checked = false;
                            }
                            else if (table[0].Status.ToString().Equals("1"))
                            {
                                this.chck_Enable.Checked = true;
                            }
                            this.chck_Enable.Checked = true;


                            if (table[0].News.ToString().Trim().Equals("0"))
                            {
                                this.chknews.Checked = false;
                            }
                            else if (table[0].News.ToString().Equals("1"))
                            {
                                this.chknews.Checked = true;
                            }
                            this.chknews.Checked = true;


                            if (table[0].page_Home.ToString().Trim().Equals("0"))
                            {
                                this.chkTrangChu.Checked = false;
                            }
                            else if (table[0].page_Home.ToString().Equals("1"))
                            {
                                this.chkTrangChu.Checked = true;
                            }
                            this.chkTrangChu.Checked = true;


                            if (table[0].Equals.ToString().Trim().Equals("1"))
                            {
                                this.rdFromLinks.Checked = true;
                                this.rdFromComputer.Checked = false;
                                this.LoadView();
                                this.txtvimg.Text = table[0].Images.ToString();
                            }
                            else
                            {
                                this.rdFromComputer.Checked = true;
                                this.rdFromLinks.Checked = false;
                                this.LoadView();
                                this.hdFileName.Value = table[0].Images.ToString();
                            }
                        }
                    }
                    return;
                #endregion
                #region Delete
                case "Delete":
                    {
                        try
                        {
                            #region Xoa anh Va danh sach
                            int j;
                            List<VideoClip> dlt = SVideoClip.GET_DETAIL_BY_MENUID(str2, More.Sub_Menu(More.VD, str2));
                            for (j = 0; j < dlt.Count; j++)
                            {
                                try
                                {
                                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].ImagesSmall.ToString());
                                }
                                catch (Exception) { }
                            }
                            //Xóa danh mục
                            int k;
                            List<Entity.Menu> str1 = SMenu.GETPARENT_ID(str2, More.Sub_Menu(More.VD, str2));
                            for (k = 0; k < str1.Count; k++)
                            {
                                try
                                {
                                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                    File.Delete(utlitities.APPL_PHYSICAL_PATH + str1[k].Images.ToString());
                                }
                                catch (Exception) { }
                            }
                            #endregion
                            SVideoClip.DELETE_ID_MEUN(str2, More.Sub_Menu(More.VD, str2));
                            SMenu.DELETE(More.Sub_Menu(More.VD, str2));
                            this.UpdateList();
                            this.ltmsg.Text = "";
                        }
                        catch (Exception)
                        {
                            this.ltmsg.Text = "<span class=alert> : " + label("lt_youmustdeleteallitemsinthiscategoryfirst") + "</span>";
                        }
                    }
                    return;
                #endregion
                #region ListChildren
                case "ListChildren":
                    {
                        this.hd_id.Value = str2;
                        int _cid = -1;
                        if (int.TryParse(str2, out _cid))
                        {
                            string nva = "";
                            this.lbl_curpage.Text = More.LoadNav(_cid, ref nva);
                        }
                        this.UpdateList();
                    }
                    return;
                #endregion
                #region ChangeStatus
                case "ChangeStatus":
                    {
                        string str3;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str3 = "0"; }
                        else { str3 = "1"; }
                        SMenu.UPDATESTATUS(str2, str3);
                        this.UpdateList();
                    }
                    return;
                #endregion
                #region Tang_Giam
                case "Tang":
                    SMenu.UPDATEVIEWS_T(str2);
                    this.UpdateList();
                    return;
                case "Giam":
                    SMenu.UPDATEVIEWS_G(str2);
                    this.UpdateList();
                    return;
                #endregion
            }
        }

        private void UpdateList()
        {
            try
            {
                if (this.hd_id.Value.Equals(""))
                {
                    this.hd_id.Value = "-1";
                }
                List<Entity.Menu> table = SMenu.CATE_LOADALL_MENU(More.VD, this.lang, this.hd_id.Value.Trim());
                this.rp_pagelist.DataSource = table;
                this.rp_pagelist.DataBind();
                if (this.hd_id.Value.Equals("-1"))
                {
                    this.lbl_curpage.Text = this.label("l_rootcate");
                }
                else
                {
                    table = SMenu.GETBYID(this.hd_id.Value.Trim());
                    if (table.Count > 0)
                    {
                        //this.lbl_curpage.Text = this.label("l_rootcate") + " : " + table[0].Name.ToString().Trim();
                        this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                    }
                }
            }
            catch (Exception) { }
        }

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_pagelist.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_pagelist.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_pagelist.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        #region Xoa anh Va danh sach
                        List<VideoClip> dlt = SVideoClip.GET_DETAIL_BY_MENUID(id.Value, More.Sub_Menu(More.VD, id.Value));
                        for (int j = 0; j < dlt.Count; j++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].Images.ToString());
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + dlt[j].ImagesSmall.ToString());
                            }
                            catch (Exception) { }
                        }
                        //Xóa danh mục
                        List<Entity.Menu> str1 = SMenu.GETPARENT_ID(id.Value, More.Sub_Menu(More.VD, id.Value));
                        for (int k = 0; k < str1.Count; k++)
                        {
                            try
                            {
                                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                                File.Delete(utlitities.APPL_PHYSICAL_PATH + str1[k].Images.ToString());
                            }
                            catch (Exception) { }
                        }
                        #endregion
                        SVideoClip.DELETE_ID_MEUN(id.Value, More.Sub_Menu(More.VD, id.Value));
                        SMenu.DELETE(More.Sub_Menu(More.VD, id.Value));
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert> : " + label("lt_youmustdeleteallitemsinthiscategoryfirst") + "</span>";
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

        protected void btDeleteimages_Click(object sender, EventArgs e)
        {
            try
            {
                ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                File.Delete(utlitities.APPL_PHYSICAL_PATH + this.hdFileName.Value);
            }
            catch (Exception) { }
            SMenu.UPDATEIMG(hdid.Value, "");
            this.UpdateList();
            ltimg.Text = "";
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
        }

        protected void btthemmoi_Click(object sender, EventArgs e)
        {
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            this.txtvimg.Text = "";
            this.hdFileName.Value = "";
            ltimg.Text = "";
            this.txtNoiDung.Text = "";
            this.lblmsg.Text = "";
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VD, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VD, this.lang, hd_id.Value).ToString();
            }
        }
        protected void btseo_Click(object sender, EventArgs e)
        {
            pnseo.Visible = true;
            System.Threading.Thread.Sleep(1000);
        }
    }
}