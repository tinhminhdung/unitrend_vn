using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Admin.Vote
{
    public partial class Vote : System.Web.UI.UserControl
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
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn_InsertUpdate);
                #endregion
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
                    
                    Entity.Menu obj = new Entity.Menu();
                    string str5 = this.hd_insertupdate.Value.Trim();
                    if (str5 != null)
                    {
                        if (!(str5 == "update"))
                        {
                            if (str5 == "insert")
                            {
                                #region MyRegion
                                obj.Parent_ID = Convert.ToInt32(this.hd_id.Value.Trim());
                                obj.capp = More.VO;
                                obj.Type = -1;
                                obj.Lang = lang;
                                obj.Name = txt_title.Text.Trim();
                                obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                                obj.Link = "";
                                obj.Styleshow = "";
                                obj.Equals = 0;
                                obj.Images = "";
                                obj.Description = ddlcolor.SelectedValue;
                                obj.Create_Date = DateTime.Now;
                                obj.Views = 0;
                                obj.ShowID = 100;
                                obj.Orders = Convert.ToInt32(txt_order.Text);
                                obj.Level = 100;
                                obj.News = Convert.ToInt32(chknews.Checked ? "1" : "0");
                                obj.page_Home = Convert.ToInt32(chkTrangChu.Checked ? "1" : "0");
                                obj.Status = Convert.ToInt32(chck_Enable.Checked ? "1" : "0");
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
                                obj.TangName = "";
                                #endregion
                                SMenu.Insert(obj);
                            }
                        }
                        else
                        {
                            
                            #region MyRegion
                            obj.ID = Convert.ToInt32(hd_page_edit_id.Value);
                            obj.Parent_ID = Convert.ToInt32(this.hd_id.Value.Trim());
                            obj.capp = More.VO;
                            obj.Type = -1;
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                            obj.Link = "";
                            obj.Styleshow = "";
                            obj.Equals = 0;
                            obj.Images = "";
                            obj.Description = ddlcolor.SelectedValue;
                            obj.Create_Date = DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = 100;
                            obj.Orders = Convert.ToInt32(txt_order.Text);
                            obj.Level = 100;
                            obj.News = Convert.ToInt32(chknews.Checked ? "1" : "0");
                            obj.page_Home = Convert.ToInt32(chkTrangChu.Checked ? "1" : "0");
                            obj.Status = Convert.ToInt32(chck_Enable.Checked ? "1" : "0");
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
                            obj.TangName = "";
                            #endregion
                            SMenu.UPDATE(obj);
                        }
                    }
                    this.UpdateList();
                    this.pn_list.Visible = true;
                    this.pn_insert.Visible = false;
                    this.hd_insertupdate.Value = "";
                    this.txt_title.Text = "";
                    this.hdFileName.Value = "";
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
            this.hdFileName.Value = "";
            this.lblmsg.Text = "";
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
            //this.lt_info.Text = " - " + this.label("l_createnew");
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            
            this.hdFileName.Value = "";
          
            this.lblmsg.Text = "";
            this.txt_title.Text = "";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VO, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VO, this.lang, hd_id.Value).ToString();
            }
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
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
                            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcolor, table[0].Description.ToString().Trim());
                            hdFileName.Value = table[0].Images.ToString();
                            chck_Enable.Checked = table[0].Status == 1;
                            chknews.Checked = table[0].News == 1;
                            chkTrangChu.Checked = table[0].page_Home == 1;
                            
                        }
                    }
                    return;
                #endregion
                #region Delete
                case "Delete":
                    SMenu.DELETE(More.Sub_Menu(More.VO, str2));
                    this.UpdateList();
                    this.ltmsg.Text = "";
                    return;
                case "ListChildren":
                    this.hd_id.Value = str2;
                    this.UpdateList();
                    return;
                case "ChangeStatus":
                    string str3;
                    str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                    { str3 = "0"; }
                    else { str3 = "1"; }
                    SMenu.UPDATESTATUS(str2, str3);
                    this.UpdateList();
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
                List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.VO, this.lang, this.hd_id.Value.Trim());
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
                        this.lbl_curpage.Text = this.label("l_rootcate") + " : " + table[0].Name.ToString().Trim();
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
                        SMenu.DELETE(More.Sub_Menu(More.VO, id.Value));
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {
                this.ltmsg.Text = "<span class=alert>Xóa danh sách tin trước khi xóa danh mục</span>";
            }
        }

        protected string Color(string color)
        {
            return " <div style='width:50px; height:5px; background-color:#" + color + "'></div>";
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
            this.chknews.Checked = false;
            this.chkTrangChu.Checked = false;
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VO, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.VO, this.lang, hd_id.Value).ToString();
            }

        }
    }
}