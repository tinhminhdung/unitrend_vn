using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Math;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display
{
    public partial class Nav_conten : System.Web.UI.UserControl
    {
        string hp = "";
        string ipid = "0";
        int iEmptyIndex = 0;
        string nav = "";
        string u = "";
        int _cid = -1;
        DatalinqDataContext db = new DatalinqDataContext();
        private string language = Captionlanguage.Language;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            #region Requesthp
            if (Request["ipid"] != null && !Request["ipid"].Equals(""))
            {
                ipid = Request["ipid"].ToString();
            }  
            
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            #endregion
            try
            {
                if (Request["e"] != null)
                {
                    if (Request["e"].ToString() == "load")
                    {
                        string chuoi = "";
                        try
                        {
                            List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid= " + ipid + "");
                            if (dt.Count > 0)
                            {
                                u = "21";
                                chuoi = "21";
                            }
                        }
                        catch (Exception)
                        { }
                        if (chuoi != "21")
                        {
                            if (Request["e"].ToString() == "load")
                            {
                                u = MoreAll.Other.RequestMenu(Request["hp"]);
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            if (!IsPostBack)
            {
                Nav_Content();
            }
        }

        private void Nav_Content()
        {
            string strReturn = "";
            strReturn += "";
            switch (u)
            {
                case "1":// nhom tin tuc
                    if (int.TryParse(More.TangNameicid(hp), out _cid)) { strReturn += LoadNav(_cid); }
                    break;
                case "3":// nhom chan trang
                    if (int.TryParse(More.TangNameicid(hp), out _cid)) { strReturn += LoadNav(_cid); }
                    break;
                case "5":// nhom Album
                    if (int.TryParse(More.TangNameicid(hp), out _cid)) { strReturn += LoadNav(_cid); }
                    break;
                case "7":// nhom Video
                    if (int.TryParse(More.TangNameicid(hp), out _cid)) { strReturn += LoadNav(_cid); }
                    break;
                case "20"://// nhom san pham
                    if (int.TryParse(More.TangNameicid(hp), out _cid)) { strReturn += LoadNav(_cid); }
                    break;
                // Chi tiet

                case "2":
                    strReturn += LoadNavNews();
                    break;
                case "4":
                    strReturn += LoadNavNewsFooter();
                    break;
                case "6":
                    strReturn += LoadNavAllbums();
                    break;
                case "8":
                    strReturn += LoadNavVideos();
                    break;
                case "21":
                    strReturn += LoadNavProduts();
                    break;

            }
            if (Request["su"] != null && !Request["su"].Equals(""))
            {
                if (Request["su"].ToString() == "viewcart" || Request["su"].ToString() == "msg" || Request["su"].ToString() == "msg")
                {
                    strReturn += "<li><a href=\"/gio-hang.html\">" + label("lt_cartbox") + "</a></li>";
                }
                if (Request["su"].ToString() == "contact")
                {
                    strReturn += "<li><a href=\"/lien-he.html\">" + label("l_contact") + "</a></li>";
                }
                if (Request["su"].ToString() == "nws")
                {
                    strReturn += "<li><a href=\"/tin-tuc.html\">" + label("l_news") + "</a></li>";
                }
                if (Request["su"].ToString() == "Allbums")
                {
                    strReturn += "<li><a href=\"/thu-vien-anh.html\">Thư viện ảnh</a></li>";
                }
                if (Request["su"].ToString() == "Videos")
                {
                    strReturn += "<li><a href=\"/thu-vien-video.html\">Thư viện video</a></li>";
                }
                if (Request["su"].ToString() == "prd")
                {
                    strReturn += "<li><a href=\"/san-pham.html\">" + label("lproducts") + "</a></li>";
                }
                if (Request["su"].ToString() == "Download")
                {
                    strReturn += "<li><a href=\"/tai-du-lieu.html\">Download</a></li>";
                }
                if (Request["su"].ToString() == "GioiThieu")
                {
                    strReturn += "<li><a href=\"/giai-phap.html\">" + label("giaiphap") + "</a></li>";
                }
                if (Request["su"].ToString() == "Search")
                {
                    strReturn += "<li><a href=\"#\">" + label("l_search") + "</a></li>";
                }
                if (Request["su"].ToString() == "Register")
                {
                    strReturn += "<li><a href=\"/Dang-ky.html\">" + label("dangkythanhvien") + "</a></li>";
                }
                if (Request["su"].ToString() == "resetpassword")
                {
                    strReturn += "<li><a href=\"/Doi-mat-khau.html\">" + label("lt_changepassword") + "</a></li>";
                }
                if (Request["su"].ToString() == "Infos")
                {
                    strReturn += "<li><a href=\"/thong-tin-thanh-vien.html\">" + label("ttthanhvien") + "</a></li>";
                }
                if (Request["su"].ToString() == "changinfo")
                {
                    strReturn += "<li><a href=\"/xem-thong-tin-thanh-vien.html\">" + label("capthanhvien") + "</a></li>";
                }
                if (Request["su"].ToString() == "changepass")
                {
                    strReturn += "<li><a href=\"/thay-doi-mat-khau.html\">" + label("thaydoimk") + "</a></li>";
                }
                if (Request["su"].ToString() == "Login")
                {
                    strReturn += "<li><a href=\"/Dang-nhap.html\">" + label("l_login") + "</a></li>";
                } 
                if (Request["su"].ToString() == "baogia")
                {
                    strReturn += "<li><a href=\"/bao-gia.html\">Báo giá</a></li>";
                }
            }
            ltrnav.Text = strReturn;
        }

        private string LoadNavNews()
        {
            List<Entity.News> dt = SNews.Name_Text("SELECT * FROM [News]  where TangName=N'" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].icid.ToString()));
                nav = "<li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavNewsFooter()
        {
            List<Entity.Nfooter> dt = SNfooter.Name_Text("SELECT * FROM [Nfooter]  where TangName=N'" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].icid.ToString()));
                nav = "<li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavAllbums()
        {
            List<Entity.Album> dt = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName=N'" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].Menu_ID.ToString()));
                nav = "<li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavVideos()
        {
            List<Entity.VideoClip> dt = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName=N'" + hp + "'");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].Menu_ID.ToString()));
                nav = "<li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNavProduts()
        {
            List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid=" + ipid + "");
            if (dt.Count > 0)
            {
                var item = db.Menus.FirstOrDefault(s => s.ID == int.Parse(dt[0].icid.ToString()));
                nav = "<li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        private string LoadNav(int ID)
        {
            var item = db.Menus.FirstOrDefault(s => s.ID == ID);
            if (item != null)
            {
                nav = "<li><a href=\"" + item.TangName.ToString() + ".html\">" + item.Name + "</a></li>" + nav;
                if (item.Parent_ID != -1)
                {
                    LoadNav(Convert.ToInt32(item.Parent_ID));
                }
            }
            return nav;
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}