using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.Menus
{
    public partial class u_menu_mainbottom : System.Web.UI.UserControl
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
                this.UpdateList();
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
                int status = 0;
                if (this.chck_Enable.Checked)
                {
                    status = 1;
                }
                Entity.Menu obj = new Entity.Menu();
                string str2 = this.hd_insertupdate.Value.Trim();
                if (str2 != null)
                {
                    if (!(str2 == "update"))
                    {
                        if (str2 == "insert")
                        {
                            #region MyRegion
                            obj.Parent_ID = Convert.ToInt32(this.hd_page_edit_id.Value.Trim());
                            obj.capp = More.TM;
                            obj.Type = Convert.ToInt32(this.ddlopentype.SelectedValue);
                            obj.Lang = this.lang;
                            obj.Name = txt_title.Text.Trim();
                            obj.Url_Name = RewriteURL.GetNewTitle(txt_title.Text.Trim());
                            obj.Link = txturl.Text;
                            obj.Styleshow = "";
                            obj.Equals = 100;
                            obj.Images = "";
                            obj.Description = "";
                            obj.Create_Date =   DateTime.Now;
                            obj.Views = 0;
                            obj.ShowID = 100;
                            obj.Orders = Convert.ToInt32(txt_order.Text.Trim());
                            obj.Level = 100;
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
                        obj.Parent_ID = Convert.ToInt32(this.hd_par_id.Value.Trim());
                        obj.capp = More.TM;
                        obj.Type = Convert.ToInt32(this.ddlopentype.SelectedValue);
                        obj.Lang = this.lang;
                        obj.Name = txt_title.Text.Trim();
                        obj.Url_Name = RewriteURL.GetNewTitle(txt_title.Text.Trim());
                        obj.Link = txturl.Text;
                        obj.Styleshow = "";
                        obj.Equals = 100;
                        obj.Images = "";
                        obj.Description = "";
                        obj.Create_Date = Convert.ToDateTime(string.Empty);
                        obj.Views = 0;
                        obj.ShowID = 100;
                        obj.Orders = Convert.ToInt32(txt_order.Text.Trim());
                        obj.Level = 100;
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
                this.txt_order.Text = "";
                txturl.Text = "";
            }
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
            txturl.Text = "";
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Delete this?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = " - " + this.label("l_createnew");
            this.btn_InsertUpdate.Text = this.label("l_insert");
            this.pn_list.Visible = false;
            this.pn_insert.Visible = true;
            this.hd_insertupdate.Value = "insert";
            this.hd_page_edit_id.Value = "-1";
            txturl.Text = "";
            this.chkupdateimg.Visible = false;
            if (hd_id.Value.Equals(""))
            {
                this.txt_order.Text = More.GetNextCateOrder(More.TM, this.lang, "-1").ToString();
            }
            else
            {
                this.txt_order.Text = More.GetNextCateOrder(More.TM, this.lang, hd_id.Value).ToString();
            }
        }

        protected void rp_pagelist_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string str2 = e.CommandArgument.ToString().Trim();
            string str4 = str;
            if (str4 != null)
            {
                if (!(str4 == "EditDetail"))
                {
                    if (!(str4 == "ChooseIt"))
                    {
                        if (!(str4 == "ListChildren"))
                        {
                            string str3;
                            if (!(str4 == "ChangeStatus"))
                            {
                                if (str4 == "Delete")
                                {
                                    try
                                    {
                                        SMenu.DELETE(str2);
                                        this.UpdateList();
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
                                str3 = "0";
                            }
                            else
                            {
                                str3 = "1";
                            }
                            SMenu.UPDATESTATUS(str2, str3);
                            this.UpdateList();
                            return;
                        }
                        this.hd_id.Value = str2;
                        this.UpdateList();
                        return;
                    }
                }
                else
                {
                    this.btn_InsertUpdate.Text = this.label("l_update");
                    this.lt_info.Text = " - " + this.label("lt_edit");
                    this.pn_list.Visible = false;
                    this.pn_insert.Visible = true;
                    this.hd_insertupdate.Value = "update";
                    this.hd_page_edit_id.Value = str2.Trim();
                    List<Entity.Menu> table = new List<Entity.Menu>();
                    table = SMenu.GETBYID(str2);
                    if (table.Count > 0)
                    {
                        this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                        this.txt_title.Text = table[0].Name.ToString().Trim();
                        this.txt_order.Text = table[0].Orders.ToString().Trim();
                        this.txturl.Text = table[0].Link.ToString();
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlopentype, table[0].Type.ToString());
                        if (table[0].Status.ToString().Trim().Equals("0"))
                        {
                            this.chck_Enable.Checked = false;
                            return;
                        }
                        if (!table[0].Status.ToString().Equals("1"))
                        {
                            return;
                        }
                        this.chck_Enable.Checked = true;
                    }
                    return;
                }
                this.UpdateList();
            }
        }

        private void SetSelectedIndexInDropDownList(ref DropDownList ddl, string selectedvalue)
        {
            if (ddl != null)
            {
                selectedvalue = selectedvalue.Trim();
                int count = ddl.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if (ddl.Items[i].Value.Equals(selectedvalue))
                    {
                        ddl.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void UpdateList()
        {
            if (this.hd_id.Value.Equals(""))
            {
                this.hd_id.Value = "-1";
            }
            List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.TM, this.lang, this.hd_id.Value.Trim());
            this.rp_pagelist.DataSource = table;
            this.rp_pagelist.DataBind();
            {
                table = SMenu.GETBYID(this.hd_id.Value.Trim());
                if (table.Count > 0)
                {
                    this.hd_par_id.Value = table[0].Parent_ID.ToString().Trim();
                }
            }
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
                        SMenu.DELETE(More.Sub_Menu(More.TM, id.Value));
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