using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using System.IO;

namespace VS.E_Commerce.cms.Admin.Products
{
    public partial class ManagementPrice : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
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
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("59"))
                        {
                            ShowThem = "1";
                        }
                        if (strArray[i].ToString().Equals("60"))
                        {
                            ShowSua = "1";
                        }
                        if (strArray[i].ToString().Equals("61"))
                        {
                            ShowXoa = "1";
                        }
                    }
                }
            }
            if (!base.IsPostBack)
            {
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                #endregion
                Bind_ddlCountry();
                Bind_Tinhthanh();
                ddlstate.Items.Add(new ListItem("--" + label("chonqh") + "--", "0"));
                this.UpdateList();
                this.btn_back.Text = this.label("l_back");
                this.btn_Homepage.Text = this.label("l_rootcate");
                this.btnCancel.Text = this.label("l_cancel");
            }
        }
        protected void Bind_Tinhthanh()
        {
            List<Entity.Tinhthanh> list = STinhthanh.LOAD_CATESPARENT_ID(More.TT, this.lang, "-1", "1");
            ddltinhthanh.Items.Clear();
            ddltinhthanh.Items.Add(new ListItem("--" + label("chontp") + "--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddltinhthanh.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }
        protected void Bind_Quanhuyen()
        {
            List<Entity.Tinhthanh> list = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='" + More.TT + "' and Lang='" + lang + "'  and Parent_ID=" + ddltinhthanh.SelectedValue + "  and Status=1 order by Orders asc");
            ddlquanhuyen.Items.Clear();
            ddlquanhuyen.Items.Add(new ListItem("--" + label("chonqh") + "--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlquanhuyen.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }

        protected void ddltinhthanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_Quanhuyen();
        }
        protected void Bind_ddlCountry()
        {
            List<Entity.Tinhthanh> list = STinhthanh.LOAD_CATESPARENT_ID(More.TT, this.lang, "-1", "1");
            ddlcountry.Items.Clear();
            ddlcountry.Items.Add(new ListItem("--" + label("chontp") + "--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlcountry.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }
        protected void Bind_ddlState()
        {
            List<Entity.Tinhthanh> list = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='" + More.TT + "' and Lang='" + lang + "'  and Parent_ID=" + ddlcountry.SelectedValue + "  and Status=1 order by Orders asc");
            ddlstate.Items.Clear();
            ddlstate.Items.Add(new ListItem("--" + label("chonqh") + "--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlstate.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }
        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlState();
            UpdateList();

        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateList();
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
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcountry, this.ddltinhthanh.SelectedValue);
                WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstate, this.ddlquanhuyen.SelectedValue);
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
                    int status = 0;
                    if (this.chck_Enable.Checked)
                    {
                        status = 1;
                    }
                    int news = 0;
                    if (this.chknews.Checked)
                    {
                        news = 1;
                    }
                    int TrangChu = 0;
                    if (this.chkTrangChu.Checked)
                    {
                        TrangChu = 1;
                    }
                    Entity.Tinhthanh obj = new Entity.Tinhthanh();
                    string str5 = this.hd_insertupdate.Value.Trim();
                    if (str5 != null)
                    {
                        if (!(str5 == "update"))
                        {
                            if (str5 == "insert")
                            {
                                #region Tinhthanh
                                string TangName = "";
                                int cong = 0;
                                List<Entity.Tinhthanh> curItem = STinhthanh.Name_Text("SELECT top 1 * FROM Tinhthanh order by ID desc");
                                int tong = int.Parse(curItem[0].ID.ToString());
                                cong = tong + 1;
                                var hasTagName = db.Tinhthanhs.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault();
                                TangName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + cong : MoreAll.AddURL.SeoURL(txt_title.Text);
                                #endregion

                                #region MyRegion
                                obj.Parent_ID = int.Parse(ddlquanhuyen.SelectedValue);
                                obj.capp = More.KG;
                                obj.Type = int.Parse(ddlquanhuyen.SelectedValue);
                                obj.Lang = lang;
                                obj.Name = txt_title.Text.Trim();
                                obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                                obj.Link = txttu.Text.Trim();
                                obj.Styleshow = txtden.Text.Trim();
                                obj.Equals = 0;
                                obj.Images = "";
                                obj.Description = "";
                                obj.Create_Date = DateTime.Now;
                                obj.Views = int.Parse(ddltinhthanh.SelectedValue);
                                obj.ShowID = 0;
                                obj.Orders = int.Parse(txt_order.Text);
                                obj.Level = 0;
                                obj.News = int.Parse(chknews.Checked ? "1" : "0");
                                obj.page_Home = int.Parse(chkTrangChu.Checked ? "1" : "0");
                                obj.Status = int.Parse(chck_Enable.Checked ? "1" : "0");
                                obj.Titleseo = "";
                                obj.Meta = "";
                                obj.Keyword = "";
                                obj.Check_01 = 0;
                                obj.Check_02 = 0;
                                obj.Check_03 = 0;
                                obj.Check_04 = 0;
                                obj.Check_05 = 0;
                                obj.Noidung1 = txttu.Text.Trim();
                                obj.Noidung2 = txtden.Text.Trim();
                                obj.Noidung3 = txtnhanh.Text.Trim();
                                obj.Noidung4 = txtcham.Text;
                                obj.Noidung5 = "";
                                obj.Module = 24;
                                obj.TangName = TangName;
                                #endregion
                                STinhthanh.Insert(obj);
                            }
                        }
                        else
                        {
                            #region UpdateTinhthanh
                            string TagName = "";
                            List<Entity.Tinhthanh> item = STinhthanh.GETBYID(hd_page_edit_id.Value);
                            if (item.Count > 0)
                            {
                                Tinhthanh obk = db.Tinhthanhs.SingleOrDefault(p => p.TangName == item[0].TangName);
                                obk.Name = txt_title.Text;
                                obk.Module = 24;
                                List<Tinhthanh> list = (from p in db.Tinhthanhs where p.TangName == obk.TangName orderby p.ID descending select p).ToList();
                                if (list.Count > 2)
                                {
                                    var hasTagName = db.Tinhthanhs.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text);
                                }
                                else
                                {
                                    if (MoreAll.AddURL.SeoURL(item[0].Name) != MoreAll.AddURL.SeoURL(txt_title.Text)) { var hasTagName = db.Tinhthanhs.Where(s => s.TangName == MoreAll.AddURL.SeoURL(txt_title.Text)).FirstOrDefault(); TagName = hasTagName != null ? MoreAll.AddURL.SeoURL(txt_title.Text) + "-" + obk.ID : MoreAll.AddURL.SeoURL(txt_title.Text); } else { TagName = item[0].TangName; }
                                }
                                obk.TangName = TagName;
                                db.SubmitChanges();
                            }

                            #endregion
                            #region MyRegion
                            obj.ID = int.Parse(hd_page_edit_id.Value.Trim());
                            obj.Parent_ID = int.Parse(ddlquanhuyen.SelectedValue);
                            obj.capp = More.KG;
                            obj.Type = int.Parse(ddlquanhuyen.SelectedValue);
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                            obj.Link = txttu.Text.Trim();
                            obj.Styleshow = txtden.Text.Trim();
                            obj.Equals = 0;
                            obj.Images = "";
                            obj.Description = "";
                            obj.Create_Date = DateTime.Now;
                            obj.Views = int.Parse(ddltinhthanh.SelectedValue);
                            obj.ShowID = 0;
                            obj.Orders = int.Parse(txt_order.Text);
                            obj.Level = 0;
                            obj.News = int.Parse(chknews.Checked ? "1" : "0");
                            obj.page_Home = int.Parse(chkTrangChu.Checked ? "1" : "0");
                            obj.Status = int.Parse(chck_Enable.Checked ? "1" : "0");
                            obj.Titleseo = "";
                            obj.Meta = "";
                            obj.Keyword = "";
                            obj.Check_01 = 0;
                            obj.Check_02 = 0;
                            obj.Check_03 = 0;
                            obj.Check_04 = 0;
                            obj.Check_05 = 0;
                            obj.Noidung1 = txttu.Text.Trim();
                            obj.Noidung2 = txtden.Text.Trim();
                            obj.Noidung3 = txtnhanh.Text.Trim();
                            obj.Noidung4 = txtcham.Text;
                            obj.Noidung5 = "";
                            obj.Module = 24;
                            obj.TangName = TagName;
                            #endregion
                            STinhthanh.UPDATE(obj);
                        }
                    }
                    this.UpdateList();
                    this.pn_list.Visible = true;
                    this.pn_insert.Visible = false;
                    this.hd_insertupdate.Value = "";
                    this.txt_title.Text = "";
                    this.txt_order.Text = "";
                    this.lblmsg.Text = "";
                    this.txttu.Text = "";
                    txtden.Text = "";
                    txtnhanh.Text = "";
                    txtcham.Text = "";
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
            this.hdFileName.Value = "";
            this.lblmsg.Text = "";
            this.txttu.Text = "";
            this.txttu.Text = "";
            txtden.Text = "";
            txtnhanh.Text = "";
            txtcham.Text = "";

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
            this.hdFileName.Value = "";
            this.lblmsg.Text = "";
            this.txt_title.Text = "";
            this.txttu.Text = "";
            this.txttu.Text = "";
            txtden.Text = "";
            txtnhanh.Text = "";
            txtcham.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.KG, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.KG, this.lang, hd_id.Value).ToString();
            }
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcountry, this.ddltinhthanh.SelectedValue);
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstate, this.ddlquanhuyen.SelectedValue);
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;

            switch (e.CommandName)
            {
                case "EditDetail":
                    List<Entity.Tinhthanh> table = STinhthanh.Detail(str2);
                    if (table.Count > 0)
                    {
                        this.btn_InsertUpdate.Text = this.label("l_update");
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
                            this.txttu.Text = table[0].Noidung1.ToString().Trim();
                            this.txtden.Text = table[0].Noidung2.ToString().Trim();

                            this.txtnhanh.Text = table[0].Noidung3.ToString().Trim();
                            this.txtcham.Text = table[0].Noidung4.ToString().Trim();

                            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddltinhthanh, table[0].Views.ToString());
                            Bind_Quanhuyen();
                            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlquanhuyen, table[0].Parent_ID.ToString());

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
                        }
                    }
                    return;
                case "Delete":
                    {
                        try
                        {
                            STinhthanh.DELETE(Sub_Menu(More.KG, str2));
                            this.UpdateList();
                            this.ltmsg.Text = "";
                        }
                        catch (Exception)
                        {
                        }
                    }
                    return;
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
                case "ChangeStatus":
                    {
                        string str3;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str3 = "0"; }
                        else { str3 = "1"; }
                        STinhthanh.UPDATESTATUS(str2, str3);
                        this.UpdateList();
                    }
                    return;
                case "ChangeTrangChu":
                    {
                        string str33;
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        { str33 = "0"; }
                        else { str33 = "1"; }
                        STinhthanh.UPDATESTATUS(str2, str33);
                        this.UpdateList();
                    }
                    return;
                case "Tang":
                    STinhthanh.UPDATEVIEWS_T(str2);
                    this.UpdateList();
                    return;
                case "Giam":
                    STinhthanh.UPDATEVIEWS_G(str2);
                    this.UpdateList();
                    return;
            }
        }

        private void UpdateList()
        {
            if (this.hd_id.Value.Equals(""))
            {
                this.hd_id.Value = "-1";
            }
            List<Entity.Tinhthanh> table = new List<Entity.Tinhthanh>();
            if (ddlstate.SelectedValue != "0")
            {
                table = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='KG' and Lang='" + lang + "'  and Parent_ID in (" + Sub_Menu(More.KG, ddlstate.SelectedValue) + ")  order by ID asc,Orders desc");
            }
            else
            {
                table = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='KG' and Lang='" + lang + "'  order by ID asc,Orders desc");
            }

            this.rp_pagelist.DataSource = table;
            this.rp_pagelist.DataBind();
            if (this.hd_id.Value.Equals("-1"))
            {
                this.lbl_curpage.Text = this.label("l_rootcate");
            }
            else
            {
                table = STinhthanh.Detail(this.hd_id.Value.Trim());
                if (table.Count > 0)
                {
                    this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                }
            }
        }

        public string Sub_Menu(string Capp, string cid)
        {
            string submn = cid;
            List<Entity.Tinhthanh> dt = STinhthanh.DETAIL_CAPP_PARENTID(cid, Capp);
            for (int i = 0; i < dt.Count; i++)
            {
                submn = submn + "," + Sub_Menu(Capp, dt[i].ID.ToString());
            }
            return submn;
        }
        public string Name(string ID)
        {
            string submn = "";
            List<Entity.Tinhthanh> dt = STinhthanh.Detail(ID);
            if (dt.Count > 0)
            {
                submn = dt[0].Name.ToString();
            }
            return submn;
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
                        STinhthanh.DELETE(Sub_Menu(More.KG, id.Value));
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert> : " + label("lt_youmustdeleteallitemsinthiscategoryfirst") + "</span>";
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
            STinhthanh.UPDATEIMG(hdid.Value, "");
            this.UpdateList();
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
            this.hdFileName.Value = "";
            this.lblmsg.Text = "";
            this.txttu.Text = "";
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcountry, this.ddltinhthanh.SelectedValue);
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstate, this.ddlquanhuyen.SelectedValue);
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.KG, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.KG, this.lang, hd_id.Value).ToString();
            }

        }
    }
}