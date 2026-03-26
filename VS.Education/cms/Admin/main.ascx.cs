using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Admin
{
    public partial class main : System.Web.UI.UserControl
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
            // try
            // {
            #region Case
            string u = Request.QueryString["u"];
            switch (u)
            {
                case "BaoGia":
                    phcontrol.Controls.Add(LoadControl("YCBaoGia/YCBaoGia.ascx"));
                    break;
                case "tuvan":
                    phcontrol.Controls.Add(LoadControl("YCBaoGia/TuVanSanPhamV.ascx"));
                    break;
                case "info":
                    phcontrol.Controls.Add(LoadControl("NewsFooter/Control.ascx"));
                    break;
                case "Dichvu":
                    phcontrol.Controls.Add(LoadControl("DDichvu/DDichvu.ascx"));
                    break;
                case "Gioithieu":
                    phcontrol.Controls.Add(LoadControl("GioiThieu/GioiThieu.ascx"));
                    break;
                case "Thanhvien":
                    phcontrol.Controls.Add(LoadControl("Member/Members.ascx"));
                    break;
                case "faq":
                    phcontrol.Controls.Add(LoadControl("Faq/Control.ascx"));
                    break;
                case "Sitemap":
                    phcontrol.Controls.Add(LoadControl("Sitemap/Control.ascx"));
                    break;
                case "Menuchinh":
                    phcontrol.Controls.Add(LoadControl("Tinhthanhqh/Tinhtqh.ascx"));
                    break;
                case "Album":
                    phcontrol.Controls.Add(LoadControl("Album/Control.ascx"));
                    break;
                case "Marketing":
                    phcontrol.Controls.Add(LoadControl("Marketing/Control.ascx"));
                    break;
                case "Tienich":
                    phcontrol.Controls.Add(LoadControl("Tienich/Control.ascx"));
                    break;
                case "Video":
                    phcontrol.Controls.Add(LoadControl("Video/Control.ascx"));
                    break;
                case "Download":
                    phcontrol.Controls.Add(LoadControl("Download/Control.ascx"));
                    break;
                case "Contacts":
                    phcontrol.Controls.Add(LoadControl("Contacts/Control.ascx"));
                    break;
                case "Advertisings":
                    phcontrol.Controls.Add(LoadControl("Advertisings/Control.ascx"));
                    break;
                case "pro":
                    phcontrol.Controls.Add(LoadControl("products/Control.ascx"));
                    break;
                case "carts":
                    phcontrol.Controls.Add(LoadControl("ProductsCarts/cart.ascx"));
                    break;

                case "news":
                    phcontrol.Controls.Add(LoadControl("CNews/Control.ascx"));
                    break;
                case "set":
                    phcontrol.Controls.Add(LoadControl("settings/Control.ascx"));
                    break;
                case "WebAnalytics":
                    phcontrol.Controls.Add(LoadControl("WebAnalytics/Control.ascx"));
                    break;
                case "":
                default:
                    phcontrol.Controls.Add(LoadControl("index.ascx"));
                    break;
            }
            #endregion
            if (!base.IsPostBack)
            {
                #region Role
                if (MoreAll.MoreAll.GetCookies("URole") != null)
                {
                    string[] strArray = MoreAll.MoreAll.GetCookies("URole").ToString().Trim().Split(new char[] { '|' });
                    //Reset_Checkbox();
                    if (strArray.Length > 0)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].ToString().Equals("1"))
                            {
                                lnksettings.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("2"))
                            {
                                //lnknew.Visible = true;
                                //lnkGioithieu.Visible = true;
                                //lnkthongtin.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("3"))
                            {
                                //lnkpro.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("5"))
                            {
                                // lnklienhe.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("6"))
                            {
                                // lnkAdvertisings.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("7"))
                            {
                                //lnkDownloadFile.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("8"))
                            {
                            }
                            if (strArray[i].ToString().Equals("9"))
                            {
                                // lnkTienich.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("10"))
                            {
                            }
                            if (strArray[i].ToString().Equals("11"))
                            {
                                //ltthanhvien.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("12"))
                            {
                                // lnkMarketing.Visible = true;
                            }
                            if (strArray[i].ToString().Equals("13"))
                            {
                            }
                            if (strArray[i].ToString().Equals("15"))
                            {

                            }
                            if (strArray[i].ToString().Equals("16"))
                            {
                            }
                            if (strArray[i].ToString().Equals("17"))
                            {
                            }
                            if (strArray[i].ToString().Equals("18"))
                            {

                            }
                            if (strArray[i].ToString().Equals("19"))
                            {

                            }
                            if (strArray[i].ToString().Equals("20"))
                            {
                            }
                            if (strArray[i].ToString().Equals("21"))
                            {
                                //lnkWebAnalytics.Visible = true;
                            }
                        }
                    }
                }
                #endregion
            }
            // }
            // catch (Exception) { }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_exit_Click(object sender, EventArgs e)
        {
            #region Exit
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            MoreAll.MoreAll.SetCookie("URole", "", -1);
            MoreAll.MoreAll.SetCookie("UName", "", -1);
            Response.Redirect(Request.Url.ToString());
            #endregion
        }

        private void Refresh()
        {
            Response.Redirect(Request.Url.ToString());
        }

        protected void lnknew_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=news&su=items");
        }

        protected void lnkpro_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=pro");
        }

        protected void lnksettings_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=set");
        }

        protected void lnkAdvertisings_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Advertisings");
        }

        protected void lnklienhe_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Contacts");
        }

        protected void lnkDownloadFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Download");
        }

        protected void lnkVideo_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Video");
        }

        protected void lnkTienich_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Tienich");
        }

        protected void lnkMarketing_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Marketing");
        }

        protected void lnkAlbum_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Album");
        }

        protected void lnkWebAnalytics_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=WebAnalytics");
        }

        protected void lnkhompage_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void lnkmenuchinh_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Menuchinh");
        }

        protected void lnkSitemap_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Sitemap");
        }

        private void InitializeComponent()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        protected void Lnkfaq_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=faq");
        }
        protected void lnkGioithieu_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Gioithieu");
        }
        protected void ltthanhvien_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Thanhvien");
        }
        protected void lnkDichvu_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=Dichvu");
        }

        protected void lnkthongtin_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx?u=info");
        }

    }
}