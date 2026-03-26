using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using System.IO;
using MoreAll;

namespace VS.E_Commerce.cms.Admin.Sitemap
{
    public partial class u_nws_setting : System.Web.UI.UserControl
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
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnsetup);
                #endregion
                this.binddata();
            }
        }

        private void binddata()
        {
            string str5 = "";
            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "Degrees")
                    {
                        this.txttoado.Text = its.Value;
                    }

                    if (its.Properties == "Zoom")
                    {
                        this.txtzoom.Text = its.Value;
                    }

                    if (its.Properties == "MapGooglepath")
                    {
                        str5 = its.Value;
                    }
                }
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
                    this.ltcurrentpic.Text = "<img src='Uploads/pic/Map/" + str5 + "' border=0 style='border:1px solid #9EC3CB;' style='Width:auto;Height:auto' /><br>";
                }
                else if (str6.Equals(".swf"))
                {
                    this.ltcurrentpic.Text = "<embed  style='Width:auto;Height:auto'  align='middle'  quality='high' wmode='transparent' allowscriptaccess='always'  type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer'  src='Uploads/pic/Map/" + str5 + "'>";
                }
            }
            this.hdimage.Value = str5;

        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
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
                        File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Map/" + this.hdimage.Value);
                    }
                    catch (Exception)
                    {
                    }
                }
                vvalue = DateTime.Now.Ticks.ToString() + str3;
                this.flimg.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Map/" + vvalue);
            }
            else
            {
                vvalue = this.hdimage.Value;
            }

            Entity.Setting obj = new Entity.Setting();
            obj.Lang = lang;
            obj.Properties = "MapGooglepath";
            obj.Value = vvalue;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Degrees";
            obj.Value = txttoado.Text;
            SSetting.UPDATE(obj);

            obj.Lang = lang;
            obj.Properties = "Zoom";
            obj.Value = txtzoom.Text;
            SSetting.UPDATE(obj);
            this.binddata();
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
        }

        protected void lnkbannerdelete_Click(object sender, EventArgs e)
        {
            string MapGooglepath = "";
            List<Entity.Setting> str = SSetting.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "MapGooglepath")
                    {
                        MapGooglepath = its.Value;
                        try
                        {
                            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "/Uploads/pic/Map/" + this.hdimage.Value);
                        }
                        catch (Exception)
                        {
                        }
                    }

                }
            }
            Entity.Setting obj = new Entity.Setting();
            obj.Lang = lang;
            obj.Properties = "MapGooglepath";
            obj.Value = "-1";
            SSetting.UPDATE(obj);
            this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
            this.binddata();
            base.Response.Redirect(base.Request.Url.ToString());
        }
    }
}