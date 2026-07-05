using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;
using Framework;
using System.Xml;
using System.Text;
using System.IO;

namespace VS.E_Commerce.cms.Admin.settings
{
    public partial class u_adm_systemsetting : System.Web.UI.UserControl
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
                            this.chkChangePass.Text = this.label("lt_updatepass").ToString();
                            this.binddata();
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

        public void binddata()
        {
            FSetting DB = new FSetting();
            List<Setting> str = DB.GETBYALL(lang);
            ltmsg.Text = string.Empty;
            if (str.Count >= 1)
            {
                foreach (Setting its in str)
                {
                    if (its.Properties == "smtpport")
                    {
                        this.txtsmtpport.Text = its.Value;
                    }
                    else if (its.Properties == "smtp")
                    {
                        this.txtsmtp.Text = its.Value;
                    }
                    else if (its.Properties == "sysemail")
                    {
                        this.txtsysemail.Text = its.Value;
                    }
                    else if (its.Properties == "sysemailpass")
                    {
                        this.txtsysemailpass.Text = its.Value;
                    }
                    else if (its.Properties == "searchkeyword")
                    {
                        this.txtsearchkeyword.Text = its.Value;
                    }
                    else if (its.Properties == "keyworddescription")
                    {
                        this.txtsitekeyworddescription.Text = its.Value;
                    }
                    else if (its.Properties == "webname")
                    {
                        this.txtwebname.Text = its.Value;
                    }
                    else if (its.Properties == "Facebook")
                    {
                        this.txtfacebook.Text = its.Value;
                    }
                    else if (its.Properties == "Hotline")
                    {
                        this.txthostline.Text = its.Value;
                    }
                    else if (its.Properties == "Seo")
                    {
                        this.txtseo.Text = its.Value;
                    }
                    else if (its.Properties == "Livechat")
                    {
                        this.txtLivechat.Text = its.Value;
                    }
                    else if (its.Properties == "txtGoogle")
                    {
                        //this.txtGoogle.Text = its.Value;
                    }
                    else if (its.Properties == "txtFacebooks")
                    {
                        //this.txtFacebooks.Text = its.Value;
                    }
                    else if (its.Properties == "txtYoutube")
                    {
                        // this.txtYoutube.Text = its.Value;
                    }
                    else if (its.Properties == "Editor1")
                    {
                        this.Editor1.Text = its.Value;
                    }
                    else if (its.Properties == "txtfbapp_id")
                    {
                        this.txtfbapp_id.Text = its.Value;
                    }
                    else if (its.Properties == "txtfbwidth")
                    {
                        this.txtfbwidth.Text = its.Value;
                    }
                    else if (its.Properties == "txtfbheight")
                    {
                        this.txtfbheight.Text = its.Value;
                    }
                    else if (its.Properties == "twitter")
                    {
                        // this.twitter.Text = its.Value;
                    }
                    else if (its.Properties == "pinterest")
                    {
                        // this.pinterest.Text = its.Value;
                    }
                    else if (its.Properties == "txthdmuahang")
                    {
                        this.txthdmuahang.Text = its.Value;
                    }
                    else if (its.Properties == "txthdthanhtoan")
                    {
                        this.txthdthanhtoan.Text = its.Value;
                    }
                    else if (its.Properties == "txthinhthucvanchuyen")
                    {
                        this.txthinhthucvanchuyen.Text = its.Value;
                    }
                    else if (its.Properties == "txttttk")
                    {
                        this.txttttk.Text = its.Value;
                    }
                    else if (its.Properties == "txtgiolamviec")
                    {
                        this.txtgiolamviec.Text = its.Value;
                    }
                    else if (its.Properties == "ZALO")
                    {
                        this.ZALO.Text = its.Value;
                    }
                }
            }
            this.btnsetup.Text = this.label("l_update");
        }

        protected void btnsetup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Setting obj = new Setting();
                if (this.chkChangePass.Checked && (this.txtsysemailpass.Text.Length == 0))
                {
                    this.ltmsg.Text = "Mật khẩu kh\x00f4ng được để trống";
                }
                else
                {
                    if (this.chkChangePass.Checked)
                    {
                        obj.Lang = lang;
                        obj.Properties = "sysemailpass";
                        obj.Value = txtsysemailpass.Text;
                        SSetting.UPDATE(obj);
                    }
                    obj.Lang = lang;
                    obj.Properties = "webname";
                    obj.Value = txtwebname.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "searchkeyword";
                    obj.Value = txtsearchkeyword.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "keyworddescription";
                    obj.Value = txtsitekeyworddescription.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "smtp";
                    obj.Value = txtsmtp.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "smtpport";
                    obj.Value = txtsmtpport.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "sysemail";
                    obj.Value = txtsysemail.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Hotline";
                    obj.Value = txthostline.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Facebook";
                    obj.Value = txtfacebook.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Seo";
                    obj.Value = txtseo.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Livechat";
                    obj.Value = txtLivechat.Text;
                    SSetting.UPDATE(obj);

                    //obj.Lang = lang;
                    //obj.Properties = "txtGoogle";
                    //obj.Value = txtGoogle.Text;
                    //SSetting.UPDATE(obj);
                    //obj.Lang = lang;

                    //obj.Properties = "txtFacebooks";
                    //obj.Value = txtFacebooks.Text;
                    //SSetting.UPDATE(obj);

                    //obj.Lang = lang;
                    //obj.Properties = "txtYoutube";
                    //obj.Value = txtYoutube.Text;
                    //SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "Editor1";
                    obj.Value = Editor1.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtfbapp_id";
                    obj.Value = txtfbapp_id.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtfbwidth";
                    obj.Value = txtfbwidth.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtfbheight";
                    obj.Value = txtfbheight.Text;
                    SSetting.UPDATE(obj);

                    //obj.Lang = lang;
                    //obj.Properties = "twitter";
                    //obj.Value = twitter.Text;
                    //SSetting.UPDATE(obj);

                    //obj.Lang = lang;
                    //obj.Properties = "pinterest";
                    //obj.Value = pinterest.Text;
                    //SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txthdmuahang";
                    obj.Value = txthdmuahang.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txthdthanhtoan";
                    obj.Value = txthdthanhtoan.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txthinhthucvanchuyen";
                    obj.Value = txthinhthucvanchuyen.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txttttk";
                    obj.Value = txttttk.Text;
                    SSetting.UPDATE(obj);

                    obj.Lang = lang;
                    obj.Properties = "txtgiolamviec";
                    obj.Value = txtgiolamviec.Text;
                    SSetting.UPDATE(obj);

                     obj.Lang = lang;
                    obj.Properties = "ZALO";
                    obj.Value = ZALO.Text;
                    SSetting.UPDATE(obj);


                    this.binddata();
                    this.ltmsg.Text = "Thiết lập th\x00e0nh c\x00f4ng!";
                }
            }
        }

        //protected void btsitemap_Click(object sender, EventArgs e)
        //{
        //    string dsd = Server.MapPath("~");
        //    string Url = "http://" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/";
        //    XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
        //    using (XmlWriter writer = XmlWriter.Create(dsd + "\\sitemap.xml", settings))
        //    {
        //        writer.WriteStartDocument();
        //        writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
        //        writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
        //        writer.WriteAttributeString("xsi", "schemaLocation", null, "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

        //        #region Home
        //        writer.WriteStartElement("url");
        //        writer.WriteStartElement("loc");
        //        writer.WriteString(Url);
        //        writer.WriteEndElement();
        //        writer.WriteStartElement("priority");
        //        writer.WriteString("1.0");
        //        writer.WriteEndElement();
        //        writer.WriteStartElement("changefreq");
        //        writer.WriteString("weekly");
        //        writer.WriteEndElement();
        //        writer.WriteEndElement();
        //        #endregion

        //        #region Video
        //        List<Entity.VideoClip> list6 = SVideoClip.GET_BY_ALL(lang);
        //        foreach (var its in list6)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + its.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region Produws
        //        List<Entity.Products> list1 = SProducts.GetByAll(lang);
        //        foreach (var its in list1)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + its.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region MenuBase
        //        List<Entity.News> list45 = SNews.GETBYALL(lang);
        //        foreach (var its in list45)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + its.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region Tin tuc
        //        List<Entity.Menu> list = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
        //        foreach (var item in list)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + item.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region Nhoms san pham
        //        List<Entity.Menu> list2 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
        //        foreach (var item in list2)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + item.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region Hang san pham
        //        List<Entity.Menu> list3 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.HG + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
        //        foreach (var item in list3)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + item.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region Video nhoms
        //        List<Entity.Menu> list4 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.VD + "' and Lang='" + lang + "'  and Status=1 order by Orders asc");
        //        foreach (var item in list4)
        //        {
        //            #region link
        //            writer.WriteStartElement("url");
        //            writer.WriteStartElement("loc");
        //            writer.WriteString(Url + item.TangName.ToString() + ".html");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("priority");
        //            writer.WriteString("1.0");
        //            writer.WriteEndElement();
        //            writer.WriteStartElement("changefreq");
        //            writer.WriteString("weekly");
        //            writer.WriteEndElement();
        //            writer.WriteEndElement();
        //            #endregion
        //        }
        //        #endregion

        //        #region lien-he
        //        writer.WriteStartElement("url");
        //        writer.WriteStartElement("loc");
        //        writer.WriteString(Url + "lien-he.html");
        //        writer.WriteEndElement();
        //        writer.WriteStartElement("priority");
        //        writer.WriteString("1.0");
        //        writer.WriteEndElement();
        //        writer.WriteStartElement("changefreq");
        //        writer.WriteString("weekly");
        //        writer.WriteEndElement();
        //        writer.WriteEndElement();
        //        #endregion

        //        writer.WriteEndElement();
        //        writer.WriteEndDocument();
        //    }
        //    this.ltmsg.Text = "Bạn đã cập nhật sitemap thành công!";
        //}


        protected void btsitemap_Click(object sender, EventArgs e)
        {
            string rootPath = Server.MapPath("~");
            string baseUrl = "https://" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/";
            string filePath = Path.Combine(rootPath, "sitemap.xml");

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
                writer.WriteAttributeString("xsi", "schemaLocation", null,
                    "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd");

                // HOME
                WriteUrl(writer, baseUrl, "1.0", "daily");

                // VIDEO
                foreach (var item in SVideoClip.GET_BY_ALL(lang))
                    WriteUrl(writer, baseUrl + MoreAll.AddURL.ToSlug(item.TangName) + ".html", GetPriority(item.Create_Date, 0.6), "weekly");

                // PRODUCTS
                foreach (var item in SProducts.GetByAll(lang))
                    WriteUrl(writer, baseUrl + MoreAll.AddURL.ToSlug(item.TangName) + "_id" + item.ipid + ".html", GetPriority(item.Create_Date, 0.7), "weekly");

                // NEWS
                foreach (var item in SNews.GETBYALL(lang))
                    WriteUrl(writer, baseUrl + MoreAll.AddURL.ToSlug(item.TangName) + ".html", GetPriority(item.Create_Date, 0.6), "weekly");

                // MENU GROUPS
                WriteMenuGroup(writer, baseUrl, More.NS, 0.8);
                WriteMenuGroup(writer, baseUrl, More.PR, 0.8);
                WriteMenuGroup(writer, baseUrl, More.HG, 0.8);
                WriteMenuGroup(writer, baseUrl, More.VD, 0.8);

                // CONTACT
                WriteUrl(writer, baseUrl + "lien-he.html", "0.5", "yearly");

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            ltmsg.Text = "Bạn đã cập nhật sitemap thành công!";
        }

        #region Helpers

        private void WriteUrl(XmlWriter writer, string url, string priority, string changefreq)
        {
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", url);
            writer.WriteElementString("priority", priority);
            writer.WriteElementString("changefreq", changefreq);
            writer.WriteEndElement();
        }

        private void WriteMenuGroup(XmlWriter writer, string baseUrl, string capp, double defaultPriority)
        {
            string sql = $"SELECT * FROM [Menu] WHERE capp='{capp}' AND Lang='{lang}' AND Status=1 ORDER BY Orders ASC";
            var list = SMenu.Name_Text(sql);

            foreach (var item in list)
                WriteUrl(writer, baseUrl + MoreAll.AddURL.ToSlug(item.TangName) + ".html", defaultPriority.ToString("0.0"), "weekly");
        }

        /// <summary>
        /// Tính priority theo ngày cập nhật
        /// </summary>
        private string GetPriority(DateTime? modifiedDate, double basePriority)
        {
            if (modifiedDate == null) return basePriority.ToString("0.0");

            int days = (DateTime.Now - modifiedDate.Value).Days;

            if (days <= 7) return (basePriority + 0.2).ToString("0.0");   // mới
            if (days <= 30) return (basePriority + 0.1).ToString("0.0");  // gần đây
            if (days > 180) return (basePriority - 0.2).ToString("0.0");  // cũ

            return basePriority.ToString("0.0");
        }

        #endregion
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
    }
}