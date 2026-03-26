using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.Sitemap
{
    public partial class sitemaps : System.Web.UI.UserControl
    {
        private string lang = Captionlanguage.Language;
       

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
            if (this.txt_title.Text.Trim().Length < 1)
            {
                this.lblmsg.Text = "Please check your input data!";
            }
            else if (!ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
            {
                this.lblmsg.Text = "Please check your input data!";
            }
            else
            {
                int status = 0;
                if (this.chck_Enable.Checked)
                {
                    status = 0;
                }
                string Link = "";
                int Type = 0;
                if (this.rdmain.Checked)
                {
                    Type = 0;
                    Link = this.ddlmain.SelectedValue;
                }
                else if (this.rdurl.Checked)
                {
                    Type = 1;
                    Link = this.txturl.Text;
                }
                Entity.Menu obj = new Entity.Menu();
                string str4 = this.hd_insertupdate.Value.Trim();
                if (str4 != null)
                {
                    if (!(str4 == "update"))
                    {
                        if (str4 == "insert")
                        {
                            #region MyRegion
                            obj.Parent_ID = Convert.ToInt32(this.hd_id.Value.Trim());
                            obj.capp = More.SM;
                            obj.Type = Type;
                            obj.Lang = lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                            obj.Link = Link;
                            obj.Styleshow = this.ddlopen.SelectedValue;
                            obj.Equals = 100;
                            obj.Images = "";
                            obj.Description = "";
                            obj.Create_Date = DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = 100;
                            obj.Orders = Convert.ToInt32(this.txt_order.Text.Trim());
                            obj.Level = 0;
                            obj.News = 100;
                            obj.page_Home = 100;
                            obj.Status = status;
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
                        obj.ID = Convert.ToInt32(this.hd_page_edit_id.Value);
                        obj.Parent_ID = Convert.ToInt32(this.hd_id.Value.Trim());
                        obj.capp = More.SM;
                        obj.Type = Type;
                        obj.Lang = lang;
                        obj.Name = txt_title.Text.Trim();
                        obj.Url_Name = RewriteURL.GetNewTitle(this.txt_title.Text.Trim());
                        obj.Link = Link;
                        obj.Styleshow = this.ddlopen.SelectedValue;
                        obj.Equals = 100;
                        obj.Images = "";
                        obj.Description = "";
                        obj.Create_Date = DateTime.Now;
                        obj.Views = 0;
                        obj.ShowID = 100;
                        obj.Orders = Convert.ToInt32(this.txt_order.Text.Trim());
                        obj.Level = 0;
                        obj.News = 100;
                        obj.page_Home = 100;
                        obj.Status = status;
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

            }
        }

        private void btn_link_cancel_Click(object sender, EventArgs e)
        {
            this.pn_list.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = "";
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.hd_insertupdate.Value = "";
            this.pn_list.Visible = true;
            this.pn_insert.Visible = false;
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete this?')";
        }

        protected string Enable(string enable)
        {
            if (enable.Trim().Equals("0"))
            {
                return "<img src='Uploads/pic/web/icon/action_delete.gif' border='0'>";
            }
            return "<img src='Uploads/pic/web/icon/action_check.gif'  border='0'>";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = "";
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.SM, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.SM, this.lang, hd_id.Value).ToString();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.UpdateList();
                this.btn_back.Text = this.label("l_back");
                this.btn_Homepage.Text = this.label("l_rootcate");
                this.btnCancel.Text = this.label("l_cancel");
                // this.loadmodule();
            }
        }

        protected void rdmain_CheckedChanged(object sender, EventArgs e)
        {
            this.txturl.Visible = false;
            this.ddlmain.Visible = true;
        }

        protected void rdurl_CheckedChanged(object sender, EventArgs e)
        {
            this.ddlmain.Visible = false;
            this.txturl.Visible = true;
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str6 = str;
            if (str6 != null)
            {
                if (!(str6 == "EditDetail"))
                {
                    if (!(str6 == "ListChildren"))
                    {
                        string str5;
                        if (!(str6 == "ChangeStatus"))
                        {
                            if (str6 == "Delete")
                            {
                                try
                                {
                                    SMenu.DELETE(More.Sub_Menu(More.SM, str2));
                                    this.UpdateList();
                                    this.ltmsg.Text = "";
                                }
                                catch (Exception)
                                {
                                }
                            }
                            return;
                        }
                        str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str5 = "0";
                        }
                        else
                        {
                            str5 = "1";
                        }
                        SMenu.UPDATESTATUS(str2, str5);
                        this.UpdateList();
                        return;
                    }
                }
                else
                {
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "update";
                    this.hd_page_edit_id.Value = str2.Trim();
                    List<Entity.Menu> table = SMenu.GETBYID(str2);
                    if (table.Count > 0)
                    {
                        this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                        this.txt_title.Text = table[0].Name.ToString().Trim();
                        this.txt_order.Text = table[0].Orders.ToString().Trim();
                        if (table[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chck_Enable.Checked = false;
                        }
                        else if (table[0].Status.ToString().Equals("1"))
                        {
                            this.chck_Enable.Checked = true;
                        }
                        if (!table[0].Styleshow.ToString().Equals(""))
                        {
                            this.ddlopen.SelectedValue = table[0].Styleshow.ToString();
                        }
                        string str3 = table[0].Type.ToString();
                        string str4 = table[0].Link.ToString();
                        if (str3.Equals("0"))
                        {
                            this.rdmain.Checked = true;
                            this.rdurl.Checked = false;
                            this.ddlmain.Visible = true;
                            this.txturl.Visible = false;
                            this.ddlmain.SelectedValue = str4;
                            return;
                        }
                        if (!str3.Equals("1"))
                        {
                            return;
                        }
                        this.rdurl.Checked = true;
                        this.rdmain.Checked = false;
                        this.txturl.Visible = true;
                        this.ddlmain.Visible = false;
                        this.txturl.Text = str4;
                    }
                    return;
                }
                this.hd_id.Value = str2;
                List<Entity.Menu> table2 = SMenu.GETBYID(str2);
                if ((table2.Count > 0) && table2[0].Type.ToString().Equals("1"))
                {
                    this.UpdateList();
                }
            }
        }

        private void UpdateList()
        {
            if (this.hd_id.Value.Equals(""))
            {
                this.hd_id.Value = "-1";
            }
            List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.SM, this.lang, this.hd_id.Value.Trim());
            this.rp_pagelist.DataSource = table;
            this.rp_pagelist.DataBind();
            if (this.hd_id.Value.Equals("-1"))
            {
                this.lbl_curpage.Text = "Root Category";
            }
            else
            {
                table = SMenu.GETBYID(this.hd_id.Value.Trim());
                if (table.Count > 0)
                {
                    this.lbl_curpage.Text = table[0].Name.ToString().Trim();
                    this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                }
            }
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
                        SMenu.DELETE(More.Sub_Menu(More.MN, id.Value));
                    }
                }
                UpdateList();
            }
            catch (Exception)
            {

            }
        }
    }
}