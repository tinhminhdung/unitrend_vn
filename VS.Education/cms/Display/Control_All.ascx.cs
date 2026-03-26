using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using System.Text;

namespace VS.E_Commerce.cms.Display
{
    public partial class Control_All : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        #endregion
        string ipid = "0";
        string hp = "";
        int iEmptyIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!WebFirewall.IsValidRequest(Request))
                {
                    WebFirewall.Show400(Context);
                    return;
                }
           


            DatalinqDataContext db = new DatalinqDataContext();
            #region #
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = this.language;
                this.language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            #endregion

            if (!base.IsPostBack)
            {
            }

            #region Requesthp
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            if (Request["ipid"] != null && !Request["ipid"].Equals(""))
            {
                ipid = Request["ipid"].ToString();
            }

            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            #endregion
            #region Request_e
            try
            {

                if (Request["e"] != null && Request["su"] != "Page")
                {
                    if (Request["e"].ToString() == "load")
                    {
                        string request = Request["hp"] != null ? Request["hp"].ToString() : Request.Path;
                        string t = Request["hp"].ToString() + ".html";

                        bool ischek = true;
                        List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid= " + ipid + "");
                        if (dt.Count > 0)
                        {
                            ischek = false;
                            switch ("21")
                            {
                                case "21":
                                    phcontrol.Controls.Add(LoadControl("Products/Detail.ascx"));
                                    break;
                            }
                        }
                        if (ischek == true)
                        {
                            if (!request.ToLower().Contains("index.aspx"))
                            {
                                string Moldul = "";
                                Moldul = MoreAll.Other.RequestMenu(Request["hp"]);
                                switch (Moldul)
                                {
                                    //GioiThieu
                                    case "0":
                                        phcontrol.Controls.Add(LoadControl("Contents/Content.ascx"));
                                        break;
                                    //GioiThieu
                                    case "100":
                                        phcontrol.Controls.Add(LoadControl("Contents/Detail.ascx"));
                                        break;

                                    //News
                                    case "1":
                                        Menu Vitri = db.Menus.FirstOrDefault(l => l.TangName == hp);
                                        if (Vitri.News == 0)
                                            phcontrol.Controls.Add(LoadControl("News/Category.ascx"));
                                        else
                                            phcontrol.Controls.Add(LoadControl("News/DCategory.ascx"));
                                        break;
                                    case "2":
                                        phcontrol.Controls.Add(LoadControl("News/Detail.ascx"));
                                        break;

                                    //NewsFooter
                                    case "3":
                                        phcontrol.Controls.Add(LoadControl("NewsFooter/Category.ascx"));
                                        break;
                                    case "4":
                                        phcontrol.Controls.Add(LoadControl("NewsFooter/Detail.ascx"));
                                        break;

                                    //Allbum
                                    case "5":
                                        phcontrol.Controls.Add(LoadControl("Allbums/Category.ascx"));
                                        break;
                                    case "6":
                                        phcontrol.Controls.Add(LoadControl("Allbums/Detail.ascx"));
                                        break;

                                    //Video
                                    case "7":
                                        phcontrol.Controls.Add(LoadControl("Videos/Category.ascx"));
                                        break;
                                    case "8":
                                        phcontrol.Controls.Add(LoadControl("Videos/Detail.ascx"));
                                        break;

                                    //Download

                                    case "10":
                                        phcontrol.Controls.Add(LoadControl("Download/Detail.ascx"));
                                        break;

                                    //GioiThieu
                                    case "11":
                                        phcontrol.Controls.Add(LoadControl("GioiThieu/GioiThieu.ascx"));
                                        break;

                                    //Faq
                                    case "12":
                                        phcontrol.Controls.Add(LoadControl("Faq/Detail.ascx"));
                                        break;

                                    //GioiThieu
                                    case "13":
                                        phcontrol.Controls.Add(LoadControl("Dichvu/Detail.ascx"));
                                        break;

                                    //Products
                                    case "23":
                                        phcontrol.Controls.Add(LoadControl("Products/Hangsanpham.ascx"));
                                        break;
                                    case "20":
                                        // Menu Vitris = db.Menus.FirstOrDefault(l => l.TangName == hp);
                                        //if (Vitris.Parent_ID == -1)
                                        // phcontrol.Controls.Add(LoadControl("Products/DCategory.ascx"));
                                        // else
                                        phcontrol.Controls.Add(LoadControl("Products/Category.ascx"));
                                        break;
                                    case "21":
                                        phcontrol.Controls.Add(LoadControl("Products/Detail.ascx"));
                                        break;
                                }
                            }
                        }

                    }

                }
            }
            catch (Exception)
            {
                //Response.Redirect("/page-404.html");
            }
            #endregion
            #region Request_su
            switch (Request["su"])
            {
                case "Page":
                    phcontrol.Controls.Add(LoadControl("Page_404.ascx"));
                    break;
                case "Searchtag":
                    phcontrol.Controls.Add(LoadControl("Products/Search_tag.ascx"));
                    break;
                //Products
                case "Banchay":
                    phcontrol.Controls.Add(LoadControl("Products/Banchay.ascx"));
                    break;
                case "sanphamoi":
                    phcontrol.Controls.Add(LoadControl("Products/sanphamoi.ascx"));
                    break;
                case "prd":
                    phcontrol.Controls.Add(LoadControl("Products/index.ascx"));
                    break;
                case "viewcart":
                    phcontrol.Controls.Add(LoadControl("Products/Cart.ascx"));
                    break;
                case "msg":
                    phcontrol.Controls.Add(LoadControl("Products/Message.ascx"));
                    break;
                case "Search":
                    phcontrol.Controls.Add(LoadControl("Products/Search.ascx"));
                    break;

                case "DetailSoSanh":
                    phcontrol.Controls.Add(LoadControl("Products/DetailSoSanh.ascx"));
                    break;

                //contact
                case "contact":
                    phcontrol.Controls.Add(LoadControl("contact/contact.ascx"));
                    break;
                //contact
                case "baogia":
                    phcontrol.Controls.Add(LoadControl("BaoGia/Baogias.ascx"));
                    break;

                //News
                case "nws":
                    phcontrol.Controls.Add(LoadControl("News/Index.ascx"));
                    break;

                // mấy mục này chưa tạo Category , chẳng qua gọi sẵn ra đến lúc cần thì chỉ cần tạo Category là dc , còn chi tiết đã có mã số theo ID ở trên requet e rồi
                //Download
                case "Download":
                    phcontrol.Controls.Add(LoadControl("Download/Category.ascx"));
                    break;

                //GioiThieu
                case "GioiThieu":
                    phcontrol.Controls.Add(LoadControl("GioiThieu/GioiThieu.ascx"));
                    break;

                //Faq
                case "Faq":
                    phcontrol.Controls.Add(LoadControl("Faq/Category.ascx"));
                    break;

                //GioiThieu
                case "Dichvu":
                    phcontrol.Controls.Add(LoadControl("Dichvu/Category.ascx"));
                    break;

                //Allbums
                case "Thuvien":
                    phcontrol.Controls.Add(LoadControl("Allbums/Index.ascx"));
                    break;




                //Videos
                case "Videos":
                    phcontrol.Controls.Add(LoadControl("Videos/Index.ascx"));
                    break;

                //Members
                case "Register":
                    phcontrol.Controls.Add(LoadControl("Members/Register.ascx"));
                    break;
                case "Infos":
                    if (HttpContext.Current.Request.Cookies["Members"] != null)
                    {
                        phcontrol.Controls.Add(LoadControl("Members/Info.ascx"));
                    }
                    else
                    {
                        phcontrol.Controls.Add(LoadControl("Members/Login.ascx"));
                    }
                    break;
                case "changepass":
                    if (HttpContext.Current.Request.Cookies["Members"] != null)
                    {
                        this.phcontrol.Controls.Add(LoadControl("Members/Changepassword.ascx"));
                    }
                    else
                    {
                        phcontrol.Controls.Add(LoadControl("Members/Login.ascx"));
                    }
                    return;
                case "changinfo":
                    if (HttpContext.Current.Request.Cookies["Members"] != null)
                    {
                        this.phcontrol.Controls.Add(LoadControl("Members/Changinfo.ascx"));
                    }
                    else
                    {
                        phcontrol.Controls.Add(LoadControl("Members/Login.ascx"));
                    }
                    return;
                case "resetpassword":
                    phcontrol.Controls.Add(LoadControl("Members/Resetpassword.ascx"));
                    break;
                case "Login":
                    phcontrol.Controls.Add(LoadControl("Members/Login.ascx"));
                    break;
                case "info":
                    this.phcontrol.Controls.Add(base.LoadControl("Contents/Content.ascx"));
                    break;
                case "infoco":
                    phcontrol.Controls.Add(LoadControl("Contents/Detail.ascx"));
                    break;
                case "TrackOrder":
                    phcontrol.Controls.Add(LoadControl("CheckDonHang/Detail.ascx"));
                    break;
                case "Listcart":
                    if (HttpContext.Current.Request.Cookies["Members"] != null)
                    {
                        phcontrol.Controls.Add(LoadControl("CheckDonHang/Listcart.ascx"));
                    }
                    else
                    {
                        phcontrol.Controls.Add(LoadControl("Members/Login.ascx"));
                    }
                    break;
            }
                #endregion
            }
            catch (System.Data.SqlClient.SqlException)
            {
              //  WebFirewall.Show400(Context);
            }
            catch (Exception)
            {
               // WebFirewall.Show400(Context);
            }

        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}