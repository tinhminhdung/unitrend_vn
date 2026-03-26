using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Entity;
using Services;
using System.Data;

namespace VS.E_Commerce.cms.Admin.languages
{
    public partial class languages : System.Web.UI.UserControl
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
                List<Lans> str = new List<Lans>();
                str = SLang.ALL();
                this.rp_lans.DataSource = str;
                this.rp_lans.DataBind();
                this.btn_cancel.Text = this.btncancelvalue.Text = this.label("l_cancel");
                this.btnupdatevalue.Text = this.label("l_update");
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            this.hd_insertnew.Value = "";
            this.pn_list.Visible = true;
            this.pn_detail.Visible = false;
            this.lt_info.Text = "";
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            if (((this.txt_showinvie.Text.Trim().Length >= 1) && (this.txt_name_inother.Text.Trim().Length >= 1)) && ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
            {
                int locked = 0;
                if (this.chk_show.Checked)
                {
                    locked = 1;
                }
                int MacDinh = 0;
                if (this.chk_MacDinh.Checked)
                {
                    MacDinh = 1;
                }
                Lans obj = new Lans();
                #region MyRegion

                #endregion
                if (this.hd_insertnew.Value.Equals("Update"))
                {
                    obj.ilanid = int.Parse(this.id.Value.Trim());
                    obj.VLAN_ID = this.txt_name_inother.Text.Trim();
                    obj.VLAN_NAME = this.txt_showinvie.Text.Trim();
                    obj.VLAN_NAME_VIE = this.txt_showinvie.Text.Trim();
                    obj.ILAN_ORDER = int.Parse(this.txt_order.Text.Trim());
                    obj.ILAN_LOCKED = locked;
                    obj.MacDinh = MacDinh;
                    SLang.UPDATE(obj);
                }
                else
                {

                    obj.VLAN_ID = this.txt_name_inother.Text.Trim();
                    obj.VLAN_NAME = this.txt_showinvie.Text.Trim();
                    obj.VLAN_NAME_VIE = this.txt_showinvie.Text.Trim();
                    obj.ILAN_ORDER = int.Parse(this.txt_order.Text.Trim());
                    obj.ILAN_LOCKED = locked;
                    obj.MacDinh = MacDinh;
                    SLang.INSERT(obj);
                }
                this.hd_insertnew.Value = "";
                this.pn_detail.Visible = false;
                this.pn_list.Visible = true;
                this.txt_showinvie.Text = "";
                this.load_lang();
                this.lt_info.Text = "";
            }
        }

        protected void btncancelvalue_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btnupdatevalue_Click(object sender, EventArgs e)
        {
            if (this.txtvalues.Text.Length < 1)
            {
                this.ltmsg.Text = this.label("");
                this.ltmsg.Visible = true;
            }
            else
            {
                this.ltmsg.Visible = false;
                Captionlanguage.UpdateLanguageList(this.hdvalue.Value, this.hdlangid.Value, this.txtvalues.Text);
                this.LoadValue(this.hdlangid.Value);
                this.MultiView1.ActiveViewIndex = 0;
            }
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn chắc chắn là bạn muốn xóa ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_back_Click(object sender, EventArgs e)
        {
            this.pnvalue.Visible = false;
            this.pn_detail.Visible = false;
            this.pn_list.Visible = true;
        }

        protected void lnk_insertnewlanguage_Click(object sender, EventArgs e)
        {
            this.hd_insertnew.Value = "insert";
            this.pn_list.Visible = false;
            this.pn_detail.Visible = true;
            this.txt_shortname.Enabled = true;
            this.lt_info.Text = " - " + this.label("lt_admnewlanguage");
            this.btn_update.Text = this.label("l_insert");
        }

        private void load_lang()
        {
            this.rp_lans.DataSource = SLang.ALL();
            this.rp_lans.DataBind();
        }

        private void LoadValue(string lang)
        {
            DataTable table = Captionlanguage.LoadLanguageList_(lang);
            this.rpvalues.DataSource = table;
            this.rpvalues.DataBind();
        }

        protected void rp_lans_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string lang = e.CommandArgument.ToString();
            this.hdlangid.Value = lang;
            string str3 = str;
            if (str3 != null)
            {
                if (!(str3 == "Update"))
                {
                    if (!(str3 == "ValuesList"))
                    {
                        if (!(str3 == "Delete"))
                        {
                            if (!(str3 == "ChangeStatus"))
                            {
                                return;
                            }
                            return;
                        }
                        SLang.DELETE(lang);
                        base.Response.Redirect(base.Request.Url.ToString());
                        return;
                    }
                }
                else
                {
                    this.btn_update.Text = this.label("l_update");
                    this.lt_info.Text = " - " + this.label("lt_edit") + " " + this.label("l_language");
                    this.id.Value = lang;
                    this.pn_list.Visible = false;
                    this.pn_detail.Visible = true;
                    this.txt_shortname.Enabled = false;
                    List<Lans> table = SLang.GET_BY_ID(lang);
                    if (table.Count > 0)
                    {
                        WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.txt_shortname, table[0].VLAN_ID.ToString().Trim());
                        this.txt_showinvie.Text = table[0].VLAN_NAME_VIE.ToString().Trim();
                        this.txt_name_inother.Text = table[0].VLAN_NAME.ToString().Trim();
                        this.txt_order.Text = table[0].ILAN_ORDER.ToString().Trim();
                        if (table[0].ILAN_LOCKED.ToString().Trim().Equals("0"))
                        {
                            this.chk_show.Checked = false;
                        }
                        else if (table[0].ILAN_ORDER.ToString().Equals("1"))
                        {
                            this.chk_show.Checked = true;
                        }
                        if (table[0].MacDinh.ToString().Trim().Equals("0"))
                        {
                            this.chk_MacDinh.Checked = false;
                        }
                        else if (table[0].MacDinh.ToString().Equals("1"))
                        {
                            this.chk_MacDinh.Checked = true;
                        }
                    }
                    this.hd_insertnew.Value = "Update";
                    this.LoadValue(lang);
                    return;
                }
                this.pnvalue.Visible = true;
                this.pn_list.Visible = false;
                this.pn_detail.Visible = false;
                this.MultiView1.ActiveViewIndex = 0;
                this.LoadValue(lang);
            }
        }

        protected void rpvalues_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            this.hdvalue.Value = e.CommandArgument.ToString();
            this.txtvalues.Text = Captionlanguage.GetLabel(e.CommandArgument.ToString(), this.hdlangid.Value);
            this.MultiView1.ActiveViewIndex = 1;
        }

        #region MyRegion
        //{
        //    private string lang = captionlanguage.Language;
        //    protected void Page_Load(object sender, EventArgs e)
        //    {
        //        if (System.Web.HttpContext.Current.Session["lang"] != null)
        //        {
        //            this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
        //        }
        //        else
        //        {
        //            System.Web.HttpContext.Current.Session["lang"] = this.lang;
        //            this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
        //        }
        //        if (!base.IsPostBack)
        //        {
        //            List<Library.Entity.Lans> str = SLang.All();
        //            this.rp_lans.DataSource = str;
        //            this.rp_lans.DataBind();

        //            this.btn_cancel.Text = this.btncancelvalue.Text = this.label("l_cancel");
        //            this.btnupdatevalue.Text = this.label("l_update");
        //        }
        //    }
        //    protected void btn_cancel_Click(object sender, EventArgs e)
        //    {
        //        this.hd_insertnew.Value = "";
        //        this.pn_list.Visible = true;
        //        this.pn_detail.Visible = false;
        //        this.lt_info.Text = "";
        //    }
        //    protected void btn_update_Click(object sender, EventArgs e)
        //    {
        //        if (((this.txt_showinvie.Text.Trim().Length >= 1) && (this.txt_name_inother.Text.Trim().Length >= 1)) && ValidateUtilities.IsValidInt(this.txt_order.Text.Trim()))
        //        {
        //            string locked = "0";
        //            if (this.chk_show.Checked)
        //            {
        //                locked = "1";
        //            }
        //            string MacDinh = "0";
        //            if (this.chk_MacDinh.Checked)
        //            {
        //                MacDinh = "1";
        //            }
        //            Lans obj = new Lans();
        //            obj.ilanid = this.id.Value.Trim();
        //            obj.VLAN_ID = lang;
        //            obj.VLAN_NAME = txt_shortname.Text;
        //            obj.VLAN_NAME_VIE = txt_showinvie.Text;
        //            obj.ILAN_ORDER = txt_order.Text;
        //            obj.ILAN_LOCKED = locked;
        //            obj.MacDinh = MacDinh;
        //            if (this.hd_insertnew.Value.Equals("Update"))
        //            {
        //                SLang.lans_Update(obj);
        //            }
        //            else
        //            {
        //                SLang.lans_Insert(obj);
        //            }
        //            this.hd_insertnew.Value = "";
        //            this.pn_detail.Visible = false;
        //            this.pn_list.Visible = true;
        //            this.txt_showinvie.Text = "";
        //            this.load_lang();
        //            this.lt_info.Text = "";
        //        }
        //    }
        //    protected void btncancelvalue_Click(object sender, EventArgs e)
        //    {
        //        this.MultiView1.ActiveViewIndex = 0;
        //    }
        //    protected void btnupdatevalue_Click(object sender, EventArgs e)
        //    {
        //        if (this.txtvalues.Text.Length < 1)
        //        {
        //            this.ltmsg.Text = this.label("");
        //            this.ltmsg.Visible = true;
        //        }
        //        else
        //        {
        //            this.ltmsg.Visible = false;
        //            captionlanguage.UpdateLanguageList(this.hdvalue.Value, this.hdlangid.Value, this.txtvalues.Text);
        //            this.LoadValue(this.hdlangid.Value);
        //            this.MultiView1.ActiveViewIndex = 0;
        //        }
        //    }
        //    protected void Delete_Load(object sender, EventArgs e)
        //    {
        //        ((LinkButton)sender).Attributes["onclick"] = "return confirm('Bạn chắc chắn là bạn muốn xóa ?')";
        //    }
        //    protected string label(string id)
        //    {
        //        return captionlanguage.GetLabel(id, this.lang);
        //    }
        //    protected void lnk_back_Click(object sender, EventArgs e)
        //    {
        //        this.pnvalue.Visible = false;
        //        this.pn_detail.Visible = false;
        //        this.pn_list.Visible = true;
        //    }
        //    protected void lnk_insertnewlanguage_Click(object sender, EventArgs e)
        //    {
        //        this.hd_insertnew.Value = "insert";
        //        this.pn_list.Visible = false;
        //        this.pn_detail.Visible = true;
        //        this.txt_shortname.Enabled = true;
        //        this.lt_info.Text = " - " + this.label("lt_admnewlanguage");
        //        this.btn_update.Text = this.label("l_insert");
        //    }
        //    private void load_lang()
        //    {
        //        List<Library.Entity.Lans> str = SLang.All();
        //        this.rp_lans.DataSource = str;
        //        this.rp_lans.DataBind();
        //    }
        //    private void LoadValue(string lang)
        //    {
        //        List<Library.Entity.Lans> str = SLang.lang(lang);
        //        this.rpvalues.DataSource = str;
        //        this.rpvalues.DataBind();
        //    }
        //    protected void rp_lans_ItemCommand(object source, RepeaterCommandEventArgs e)
        //    {
        //        string str = e.CommandName.Trim();
        //        string lang = e.CommandArgument.ToString();
        //        this.hdlangid.Value = lang;
        //        string str3 = str;
        //        if (str3 != null)
        //        {
        //            if (!(str3 == "Update"))
        //            {
        //                if (!(str3 == "ValuesList"))
        //                {
        //                    if (!(str3 == "Delete"))
        //                    {
        //                        if (!(str3 == "ChangeStatus"))
        //                        {
        //                            return;
        //                        }
        //                        return;
        //                    }
        //                    SLang.lans_Delete(e.CommandArgument.ToString());
        //                    base.Response.Redirect(base.Request.Url.ToString());
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                this.btn_update.Text = this.label("l_update");
        //                this.lt_info.Text = " - " + this.label("lt_edit") + " " + this.label("l_language");
        //                this.id.Value = lang;
        //                this.pn_list.Visible = false;
        //                this.pn_detail.Visible = true;
        //                this.txt_shortname.Enabled = false;
        //                List<Library.Entity.Lans> table = SLang.lans_GetById(lang);
        //                if (table.Count > 0)
        //                {
        //                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.txt_shortname, table[0].VLAN_ID.ToString().Trim());
        //                    this.txt_showinvie.Text = table[0].VLAN_NAME_VIE.ToString().Trim();
        //                    this.txt_name_inother.Text = table[0].VLAN_NAME.ToString().Trim();
        //                    this.txt_order.Text = table[0].ILAN_ORDER.ToString().Trim();
        //                    if (table[0].ILAN_LOCKED.ToString().Trim().Equals("0"))
        //                    {
        //                        this.chk_show.Checked = false;
        //                    }
        //                    else if (table[0].ILAN_LOCKED.ToString().Equals("1"))
        //                    {
        //                        this.chk_show.Checked = true;
        //                    }
        //                    if (table[0].MacDinh.ToString().Trim().Equals("0"))
        //                    {
        //                        this.chk_MacDinh.Checked = false;
        //                    }
        //                    else if (table[0].MacDinh.ToString().Equals("1"))
        //                    {
        //                        this.chk_MacDinh.Checked = true;
        //                    }
        //                }
        //                this.hd_insertnew.Value = "Update";
        //                this.LoadValue(lang);
        //                return;
        //            }
        //            this.pnvalue.Visible = true;
        //            this.pn_list.Visible = false;
        //            this.pn_detail.Visible = false;
        //            this.MultiView1.ActiveViewIndex = 0;
        //            this.LoadValue(lang);
        //        }
        //    }
        //    protected void rpvalues_ItemCommand(object source, RepeaterCommandEventArgs e)
        //    {
        //        this.hdvalue.Value = e.CommandArgument.ToString();
        //        this.txtvalues.Text = captionlanguage.GetLabel(e.CommandArgument.ToString(), this.hdlangid.Value);
        //        this.MultiView1.ActiveViewIndex = 1;
        //    } 
        #endregion
    }
}