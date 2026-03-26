using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using System.IO;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.settings
{
    public partial class SettingLogo : System.Web.UI.UserControl
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
            if (!base.IsPostBack)
            {
                this.binddata();
            }
        }

        private void binddata()
        {
            string str5 = "";
            string Width = "";
            string Height = "";

            string str55 = "";
            string Width2 = "";
            string Height2 = "";

            #region Setting
            List<Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "Noimgwidth")
                    {
                        this.txtbannerwidth.Text = its.Value;
                        Width = its.Value;
                    }
                    else if (its.Properties == "Noimgheight")
                    {
                        this.txtbannerheight.Text = its.Value;
                        Height = its.Value;
                    }
                    else if (its.Properties == "Noimgpath")
                    {
                        str5 = its.Value;
                    }

                }
            }
            #endregion
            #region IMG 01
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
                    this.ltcurrentpic.Text = "<img src='Uploads/pic/Noimg/" + str5 + "' border=0 style='border:1px solid #9EC3CB;" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "' /><br>";
                }
                else if (str6.Equals(".swf"))
                {
                    this.ltcurrentpic.Text = "<embed  style='" + MoreAll.MoreAll.Style_Width(Width) + ";" + MoreAll.MoreAll.Style_Height(Height) + "'  align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='Uploads/pic/Noimg/" + str5 + "'>";
                }
            }
            this.hdimage.Value = str5;
            #endregion

        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            #region IMG01
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
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Noimg/" + this.hdimage.Value);
                    }
                    catch (Exception)
                    {
                    }
                }
                vvalue = DateTime.Now.Ticks.ToString() + str3;
                this.flimg.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Noimg/" + vvalue);
            }
            else
            {
                vvalue = this.hdimage.Value;
            }
            #endregion


            Setting obj = new Setting();
            obj.Lang = lang;
            obj.Properties = "Noimgpath";
            obj.Value = vvalue;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Noimgwidth";
            obj.Value = txtbannerwidth.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Noimgheight";
            obj.Value = txtbannerheight.Text;
            SSetting.UPDATE(obj);


            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";

        }

        protected void lnkbannerdelete_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Noimg/" + this.hdimage.Value);
            }
            catch (Exception)
            {
            }
            #region Setting
            Setting obj = new Setting();
            obj.Lang = lang;
            obj.Properties = "Noimgpath";
            obj.Value = "0";
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Noimgwidth";
            obj.Value = "0";
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Noimgheight";
            obj.Value = "0";
            SSetting.UPDATE(obj);
            #endregion
            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            base.Response.Redirect(base.Request.Url.ToString());
        }

        protected void lnkbannerdelete2_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Noimg/" + this.hdimage2.Value);
            }
            catch (Exception)
            {
            }
            #region Setting
            Setting obj = new Setting();
            obj.Lang = lang;
            obj.Properties = "imgpath";
            obj.Value = "0";
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "imgwidth";
            obj.Value = "0";
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "imgheight";
            obj.Value = "0";
            SSetting.UPDATE(obj);
            #endregion
            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            base.Response.Redirect(base.Request.Url.ToString());
        }
    }
}