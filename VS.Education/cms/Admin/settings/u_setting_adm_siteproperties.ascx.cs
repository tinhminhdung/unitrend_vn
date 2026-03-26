using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Services;
using Entity;
using Framework;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.settings
{
    public partial class u_setting_adm_siteproperties : System.Web.UI.UserControl
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
            this.Page.Form.DefaultButton = btnsetup.UniqueID;
            bool ischeck = false;
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i].ToString().Equals("1"))
                    {
                        if (!IsPostBack)
                        {
                            this.load();
                        }
                        ischeck = true;
                    }
                }
            }
            if (ischeck == false)
            {
                Response.Redirect("/admin.aspx");
            }
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                #region Logo
                string vvalue = "";
                if ((this.flimg.FileName.Trim().Length > 0) && (this.flimg.PostedFile.ContentLength > 0))
                {
                    string fileName = Path.GetFileName(this.flimg.PostedFile.FileName);
                    string str3 = "";
                    str3 = Path.GetExtension(fileName).ToLower();
                    if ((!str3.Equals(".jpg") && !str3.Equals(".gif")) && !str3.Equals(".png") && !str3.Equals(".swf"))
                    {
                        this.ltmsg.Text = "Chỉ hỗ trợ định dạng .gif hoặc .jpg hoặc .png hoặc .swf";
                        return;
                    }
                    if (!this.hdimage.Equals("-1"))
                    {
                        try
                        {
                            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/web/logo/" + this.hdimage.Value);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    vvalue = DateTime.Now.Ticks.ToString() + str3;
                    this.flimg.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/web/logo/" + vvalue);
                }
                else
                {
                    vvalue = this.hdimage.Value;
                }
                #endregion

                #region Icon
                string vvalue2 = "";
                if ((this.flimgicon.FileName.Trim().Length > 0) && (this.flimgicon.PostedFile.ContentLength > 0))
                {
                    string fileName = Path.GetFileName(this.flimgicon.PostedFile.FileName);
                    string str33 = "";
                    str33 = Path.GetExtension(fileName).ToLower();
                    if (!str33.Equals(".ico"))
                    {
                        this.ltmsg.Text = "Chỉ hỗ trợ định dạng .ico";
                        return;
                    }
                    if (!this.hdicon.Equals("-1"))
                    {
                        try
                        {
                            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/web/icon/" + this.hdicon.Value);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    vvalue2 = DateTime.Now.Ticks.ToString() + str33;
                    this.flimgicon.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/web/icon/" + vvalue2);
                }
                else
                {
                    vvalue2 = this.hdicon.Value;
                }
                #endregion

                #region Setting

                Setting obj = new Setting();
                obj.Lang = lang;
                obj.Properties = "FooTer";
                obj.Value = txtfootercontent.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "LienHe";
                obj.Value = txtcontactcontent.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "GioHang";
                obj.Value = txtgiohang.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "Icon";
                obj.Value = vvalue2;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "bannerpath";
                obj.Value = vvalue;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "bannerwidth";
                obj.Value = txtbannerwidth.Text;
                SSetting.UPDATE(obj);

                obj.Lang = lang;
                obj.Properties = "bannerheight";
                obj.Value = txtbannerheight.Text;
                SSetting.UPDATE(obj);
                #endregion
            }
            this.load();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnkbannerdelete_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/web/logo/" + this.hdimage.Value);
            }
            catch (Exception)
            {
            }
            #region Setting
            Setting obj = new Setting();
            obj.Lang = lang;
            obj.Properties = "bannerpath";
            obj.Value = "";
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "bannerwidth";
            obj.Value = "0";
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "bannerheight";
            obj.Value = "0";
            SSetting.UPDATE(obj);

            #endregion
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            this.load();
            base.Response.Redirect(base.Request.Url.ToString());
        }

        private void load()
        {
            string Width = "";
            string Height = "";
            string str5 = "";
            FSetting DB = new FSetting();
            List<Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "FooTer")
                    {
                        this.txtfootercontent.Text = its.Value;
                    }
                    else if (its.Properties == "LienHe")
                    {
                        this.txtcontactcontent.Text = its.Value;
                    }
                    else if (its.Properties == "GioHang")
                    {
                        this.txtgiohang.Text = its.Value;
                    }
                    else if (its.Properties == "bannerwidth")
                    {
                        Width = its.Value;
                        this.txtbannerwidth.Text = its.Value;
                    }
                    if (its.Properties == "bannerheight")
                    {
                        Height = its.Value;
                        this.txtbannerheight.Text = its.Value;
                    }
                    #region Banner
                    if (its.Properties == "bannerpath")
                    {
                        str5 = its.Value;
                    }
                    if (str5.Equals("-1"))
                    {
                        this.ltcurrentpic.Text = "";
                    }
                    else if (str5.Equals(""))
                    {
                        this.ltcurrentpic.Text = "";
                    }
                    else if (str5.Length > 4)
                    {
                        string str6 = str5.Substring(str5.IndexOf(".")).ToLower();
                        if ((str6.Equals(".jpg") || str6.Equals(".gif")) || str6.Equals(".png"))
                        {
                            this.ltcurrentpic.Text = "<img src='Uploads/pic/web/logo/" + str5 + "' border=0 style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width((Width)) + ";" + MoreAll.MoreAll.Style_Height((Height)) + "' /><br>";
                        }
                        else if (str6.Equals(".swf"))
                        {
                            this.ltcurrentpic.Text = "<embed style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "' align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='Uploads/pic/web/logo/" + str5 + "'>";
                        }
                    }
                    this.hdimage.Value = str5;
                    #endregion

                    #region ICon
                    if (its.Properties == "Icon")
                    {
                        string str55 = its.Value;
                        if (str55.Equals("-1"))
                        {
                            this.lticon.Text = "Icon chưa được tạo";
                        }
                        else if (str55.Equals(""))
                        {
                            this.lticon.Text = "Hiện tại chưa có icon";
                        }
                        if (str55.Length > 3)
                        {
                            string str66 = str55.Substring(str55.IndexOf(".")).ToLower();
                            if ((str66.Equals(".ico")))
                            {
                                this.lticon.Text = "<img src='Uploads/pic/web/icon/" + str55 + "' border=0 style='border:1px solid #9EC3CB;'/><br>";
                            }
                        }
                        this.hdicon.Value = str55;
                    }
                    #endregion
                    this.btnsetup.Text = this.label("l_update");
                }
            }
        }

        protected void lnkDeleteicon_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/web/icon/" + this.hdicon.Value);
            }
            catch (Exception)
            {
            }
            #region Setting
            Setting obj = new Setting();
            obj.Lang = lang;
            obj.Properties = "Icon";
            obj.Value = "";
            SSetting.UPDATE(obj);
            #endregion
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            this.load();
            base.Response.Redirect(base.Request.Url.ToString());
        }
    }
}