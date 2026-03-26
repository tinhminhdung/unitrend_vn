using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Framework;
using System.Web.UI.HtmlControls;
using Services;
using MoreAll.Templates;
using System.Net;
using System.Data;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Entity;
using AjaxPro;
using System.Web.Services;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.ComponentModel;
using System.Data.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Math;
using Newtonsoft.Json;


namespace VS.E_Commerce
{
    public partial class index1 : System.Web.UI.Page
    {
        public static int counter;
        public string hp = "";
        public string ipid = "0";
        public string Modul = "";
        int iEmptyIndex = 0;
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (!base.IsPostBack)
            {
                #region Request["hp"]
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
                try
                {
                    if (Request["e"] != null && Request["su"] != "Page")
                    {
                        if (Request["e"].ToString() == "load")
                        {
                            string chuoi = "";
                            try
                            {
                                List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid= " + ipid + "");
                                if (dt.Count > 0)
                                {
                                    Modul = "21";
                                    chuoi = "21";
                                }
                            }
                            catch (Exception)
                            { }
                            if (chuoi != "21")
                            {
                                if (Request["e"].ToString() == "load")
                                {
                                    Modul = MoreAll.Other.RequestMenu(Request["hp"]);
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

                //// Lấy dữ liệu từ database
                //List<Product_search> dtk = BaseConnectionSql.ExecuteList_V1<Product_search>("get_products_timkiem", "0");
                //// Convert dữ liệu thành JSON
                //string jsonData = JsonConvert.SerializeObject(dtk);
                //// Đổ dữ liệu ra Literal
                //lttimkiems.Text = $"<script>let allProducts = {jsonData}; console.log('Products:', allProducts);</script>";


                List<Product_search> dtk =BaseConnectionSql.ExecuteList_V1<Product_search>("get_products_timkiem", "0");
                foreach (var x in dtk)
                {
                    x.TangName = MoreAll.AddURL.ToSlug(x.TangName ?? "");
                }
                string jsonData = JsonConvert.SerializeObject(dtk);
                lttimkiems.Text = $"<script>let allProducts = {jsonData}; console.log(allProducts);</script>";


                #region MetaFacebook
                ltFacebook.Text += MoreAll.Templates.Templates.Facebook("https://" + Request.Url.Host, hp, Modul);
                ltFacebook.Text += "<meta property=\"article:author\" content=\"" + MoreAll.Other.Facebook() + "\" />";
                if (Request["su"] == null && Request["e"] == null)
                {
                    ltFacebook.Text += "<link  rel=\"canonical\" href=\"https://" + Request.Url.Host + "\" />";
                }
                else
                {
                    ltFacebook.Text += "<link  rel=\"canonical\" href=\"https://" + Request.Url.Host + "/" + hp + ".html\" />";
                }

                string fbapp = MoreAll.Other.Giatri("txtfbapp_id") != "0" ? MoreAll.Other.Giatri("txtfbapp_id") : "429741320382398";
                ltcFacebook.Text = "<div id=\"fb-root\"></div><script>(function(d, s, id) { var js, fjs = d.getElementsByTagName(s)[0]; if (d.getElementById(id)) return; js = d.createElement(s); js.id = id; js.src = \"https://connect.facebook.net/vi_VN/sdk.js#xfbml=1&version=v2.6&appId=" + fbapp + "\"; fjs.parentNode.insertBefore(js, fjs); }(document, 'script', 'facebook-jssdk'));</script>";
                #endregion

                #region GoogleAnalytics
                LiteralControl control = new LiteralControl(this.GoogleAnalytics());
                this.Page.Header.Controls.Add(control);
                #endregion

                #region Thống kê truy cập
                counter++;
                if (!base.IsPostBack && MoreAll.MoreAll.GetCookie("Counter").Equals(""))
                {
                    Fweb_statistic obj = new Fweb_statistic();
                    obj.UpdateCounter();
                    MoreAll.MoreAll.SetCookie("Counter", "1", 1);
                }
                if ((counter % 50) == 0)
                {
                    Fweb_statistic obj = new Fweb_statistic();
                    obj.UpdateHitsCounter();
                }
                #endregion

                #region Counter
                //if (System.Web.HttpContext.Current.Session["Counter"] != "Update")
                //{
                //    F_web_statistic obj = new F_web_statistic();
                //    obj.Web_Statistic_UpdateCounter();
                //    System.Web.HttpContext.Current.Session["Counter"] = "Update";
                //}
                #endregion

                #region OnOffs
                if (OnOffs.StatusOnOff().Equals("1"))
                {
                    Response.Redirect("/cms/display/OnOff/index.aspx");
                }
                #endregion

                #region Quảng cáo chạy 2 bên
                System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser; if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice) { }
                else
                {
                    loadScreen();
                    PopUp();
                }
                #endregion

                #region icon
                string str = Other.Icon();
                if (str.Length > 0)
                {
                    LiteralControl lticon = new LiteralControl("<link rel='icon' href='/Uploads/pic/web/icon/" + str + "' type='image/x-icon' /><link rel='shortcut icon' href='/Uploads/pic/web/icon/" + str + "' type='image/x-icon' />");
                    Page.Header.Controls.Add(lticon);
                }
                #endregion

                #region HtmlMeta
                HtmlMeta child = new HtmlMeta();
                child.Name = "keywords";
                child.Content = Templates.Keyword(hp, ipid, Modul);
                base.Header.Controls.Add(child);
                HtmlMeta meta2 = new HtmlMeta();
                meta2.Name = "description";
                meta2.Content = Templates.Description(hp, ipid, Modul);
                base.Header.Controls.Add(meta2);
                #endregion


            }
        }


        public void loadScreen()
        {
            #region Screen
            try
            {
                #region Setting
                string str01 = MoreAll.Other.Giatri("Screenlink");
                string str02 = MoreAll.Other.Giatri("Screenwidth");
                string str03 = MoreAll.Other.Giatri("Screenheight");
                string str06 = MoreAll.Other.Giatri("Screenlink2");
                string str07 = MoreAll.Other.Giatri("Screenwidth2");
                string str08 = MoreAll.Other.Giatri("Screenheight2");
                string str10 = MoreAll.Other.Giatri("Screen_option");
                string Screenpath = MoreAll.Other.Giatri("Screenpath");
                string Screenpath2 = MoreAll.Other.Giatri("Screenpath2");
                string Status = MoreAll.Other.Giatri("Screen_TrangThai");
                #endregion
                if (Status.Equals("1"))
                {
                    string str04 = "/Uploads/pic/advs/" + Screenpath;
                    string str09 = "/Uploads/pic/advs/" + Screenpath2;
                    ltscreen.Text = "<div id='floatdiv' style='position:absolute; width:auto;top:10px;right:0px; z-index:100;'><a target=" + Advertisings.Ad_vertisings.targets(str10) + " href='" + str01 + "'><img    style='" + MoreAll.MoreAll.Style_Width((str02)) + ";" + MoreAll.MoreAll.Style_Height((str03)) + "'   src='" + str04 + "' /></a></div> <div id='floatdivleftpage' style='position:absolute; width:auto;top:10px; left:10px; z-index:100;'><a target=" + Advertisings.Ad_vertisings.targets(str10) + " href='" + str06 + "'><img  style='" + MoreAll.MoreAll.Style_Width((str07)) + ";" + MoreAll.MoreAll.Style_Height((str08)) + "'   src='" + str09 + "' /></a></div>";
                }
            }
            catch (Exception) { }
            #endregion
        }

        public void PopUp()
        {
            #region PopUp
            #region Setting
            string Popup = MoreAll.Other.Giatri("Popup_TrangThai");
            string str2 = MoreAll.Other.Giatri("Popuplink");
            string str3 = MoreAll.Other.Giatri("Popupwidth");
            string str4 = MoreAll.Other.Giatri("Popupheight");
            string Popuppath = MoreAll.Other.Giatri("Popuppath");
            string str6 = MoreAll.Other.Giatri("Popup_option");
            #endregion
            #region Session
            if (Popup.Equals("1"))
            {
                if (System.Web.HttpContext.Current.Session["Popup"] != "a")
                {
                    ltpopup.Text = "<script type=\"text/javascript\">window.onload = function(){loadPopup();}</script>";
                    System.Web.HttpContext.Current.Session["Popup"] = "a";
                }
            }
            #endregion
            #region PopUp
            try
            {
                if (Popup.Equals("1"))
                {
                    string str5 = "/Uploads/pic/advs/" + Popuppath;
                    ltclose.Text = "<div id='popupContact' style='width:" + str3 + "px; height:auto'><div><a id='popupContactClose'><img src='/Resources/js/popUp/b_close.png' /></a></div>";
                    ltimg.Text = "<div style=' z-index:100'><a target=" + Advertisings.Ad_vertisings.targets(str6) + " href='" + str2 + "'><img src='" + str5 + "' border=0  style='" + MoreAll.MoreAll.Style_Width((str3)) + ";" + MoreAll.MoreAll.Style_Height((str4)) + "'  /></a></div></div><div id='backgroundPopup'></div>";
                }
            }
            catch (Exception) { }
            #endregion
            #endregion
        }

        protected string GoogleAnalytics()
        {
            try
            {
                return Other.GoogleAnalytics();
            }
            catch
            {
                return "";
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        public class Obj_sosanh_sanpham_db
        {
            public int ipid { get; set; }
            public int icid { get; set; }
            public int id { get; set; }
            public int Parent_ID { get; set; }
            public string NoiDungSoSanh { get; set; }
            public string idthuoctinh_cha { get; set; }
            public string Name { get; set; }
            public string idthuoctinh { get; set; }
            public int Orders { get; set; }
        }

        #region SoSanh


        [WebMethod]
        public static string Get_SoSanh(string id, string icid)
        {
            StringBuilder str = new StringBuilder();
            DatalinqDataContext db = new DatalinqDataContext();

            // Lấy danh sách từ cơ sở dữ liệu
            var items = BaseConnectionSql.ExecuteList_V1<Obj_sosanh_sanpham_db>("get_thuoctinh_sosanh_admin", id, icid);

            // Sắp xếp danh sách theo Orders (nếu là kiểu int)
            var sortedItems = items
                .OrderBy(x => x.Orders) // Không cần kiểm tra null vì Orders là int
                .ToList();

            if (sortedItems.Any())
            {
                int i = 1;

                // Lặp qua các phần tử cha (Parent_ID == -1)
                foreach (var item0 in sortedItems.Where(x => x.Parent_ID == -1))
                {
                    str.Append("<tr id=\"rowlienquan_" + i + "\">");
                    str.Append("<td style=\"width: 14%;\" colspan=\"3\">");
                    str.Append("<input value=\"" + item0.id + "\" type=\"hidden\" name=\"idthuoctinh\">");
                    str.Append("<input value=\"" + item0.NoiDungSoSanh + "\" style=\"width: 98% !important\" type=\"hidden\" name=\"NoiDungSoSanh\" class=\"form-control\">");
                    str.Append("<span class='TieuDeCha'>" + item0.Name + "</span>");
                    str.Append("</td></tr>");
                    i++;

                    // Lặp qua các phần tử con và sắp xếp theo Orders
                    var children = sortedItems
                        .Where(x => x.Parent_ID == item0.id)
                        .OrderBy(x => x.Orders)
                        .ToList();

                    foreach (var item in children)
                    {
                        str.Append("<tr id=\"rowlienquan_" + i + "\">");
                        str.Append("<td style=\"width: 14%;\">");
                        str.Append("<input value=\"" + item.id + "\" type=\"hidden\" name=\"idthuoctinh\">");
                        str.Append("<input value=\"" + item.Name + "\" style=\"width: 98% !important\" type=\"text\" disabled name=\"TieuDe\" class=\"form-control\">");
                        str.Append("</td>");
                        str.Append("<td style=\"width: 14%;\">");
                        str.Append("<input value=\"" + item.NoiDungSoSanh + "\" style=\"width: 98% !important\" type=\"text\" name=\"NoiDungSoSanh\" class=\"form-control\">");
                        str.Append("</td>");
                        str.Append("<td style=\"text-align: center; width: 3%;\" class=\"btn_add\">");
                        str.Append("<a href=\"javascript:void(0);\" onclick=\"deleteRow_SoSanh(this);\" class=\"btn_add\">");
                        str.Append("<img src=\"/Resources/admin/images/del.png\">");
                        str.Append("</a>");
                        str.Append("</td>");
                        str.Append("</tr>");
                        i++;
                    }
                }
            }

            return str.ToString();
        }


        public class Obj_sosanh_sanpham
        {
            public int ipid { get; set; }
            public int icid { get; set; }
            public int idthuoctinh { get; set; }
            public string NoiDungSoSanh { get; set; }
        }

        [WebMethod]
        public static string Save_SoSanh_Sanpham(List<Obj_sosanh_sanpham> info)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            // Xóa toàn bộ có mã ID sản phẩm
            // Thêm mới vào db 
            try
            {
                var c = BaseConnectionSql.Execute_Update_Insert_V1("delete_sosanh_SanPham", info[0].ipid.ToString(), info[0].icid.ToString());
            }
            catch (Exception)
            { }

            foreach (var item in info)
            {
                if (item.idthuoctinh != 0)
                {
                    var d = BaseConnectionSql.Execute_Update_Insert_V1("sp_Insert_SoSanh_SanPham", item.ipid, item.icid, item.idthuoctinh, item.NoiDungSoSanh, MoreAll.MoreAll.GetCookies("UName").ToString());
                }
            }
            return "1";
        }

        #endregion

        #region lienquan
        public class Obj_lienquan_sanpham
        {
            public int ipid { get; set; }
            public int ipid_lienquan { get; set; }
        }
        [WebMethod]
        public static string Save_lienquan_Sanpham(List<Obj_lienquan_sanpham> info)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            // Xóa toàn bộ có mã ID sản phẩm
            //Thêm mới vào db
            try
            {
                var c = BaseConnectionSql.Execute_Update_Insert_V1("delete_LienQuan_SanPham", info[0].ipid.ToString());
            }
            catch (Exception)
            { }

            foreach (var item in info)
            {
                if (item.ipid_lienquan != 0)
                {
                    var d = BaseConnectionSql.Execute_Update_Insert_V1("save_LienQuan_SanPham", item.ipid, item.ipid_lienquan, MoreAll.MoreAll.GetCookies("UName").ToString());
                }
            }
            return "1";
        }

        [WebMethod]
        public static string Get_lienquan(string id)
        {
            string str = "";
            DatalinqDataContext db = new DatalinqDataContext();
            List<LienQuan_SanPham> items = db.LienQuan_SanPhams.Where(s => s.ipid == int.Parse(id)).OrderBy(s => s.Create_date).ToList();
            if (items.Count > 0)
            {
                int i = 1;
                foreach (var item in items)
                {
                    str += "<tr id=\"rowlienquan_" + i + "\">";
                    str += "<td style=\"width: 14%;\">";
                    str += "<input value=\"" + item.ipid_lienquan + "\" style=\"width: 100% !important\" type=\"text\" name=\"ipid_lienquan\" class=\"form-control\">";
                    str += "</td>";
                    str += "<td style=\"text-align: center; width: 3%;\" class=\"btn_add\">";
                    str += "<a href=\"javascript:void(0);\" onclick=\"deleteRow_LienQuan(this);\" class=\"btn_add\">";
                    str += "    <img src=\"/Resources/admin/images/del.png\">";
                    str += "</a>";
                    str += "</td>";
                    str += "</tr>";
                    i++;
                }
            }
            return str;
        }

        #endregion

        #region tailieu

        public class Obj_tailieu_sanpham
        {
            public int IDSP { get; set; }
            public int icidphanmen { get; set; }
            public string Link { get; set; }
        }
        [WebMethod]
        public static string Save_Tailieu_Sanpham(List<Obj_tailieu_sanpham> info)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            // Xóa toàn bộ có mã ID sản phẩm
            // Thêm mới vào db 
            try
            {
                List<TaiLieu_SanPham> del = db.TaiLieu_SanPhams.Where(s => s.IDSP == int.Parse(info[0].IDSP.ToString())).ToList();// xóa nhiều
                db.TaiLieu_SanPhams.DeleteAllOnSubmit(del);
                db.SubmitChanges();
            }
            catch (Exception)
            { }

            foreach (var item in info)
            {
                if (item.icidphanmen != 0)
                {
                    TaiLieu_SanPham bt = new TaiLieu_SanPham();
                    bt.IDSP = item.IDSP;
                    bt.icidphanmen = item.icidphanmen;
                    bt.Link = item.Link;
                    bt.Create_By = MoreAll.MoreAll.GetCookies("UName").ToString();
                    bt.Create_date = DateTime.Now;
                    db.TaiLieu_SanPhams.InsertOnSubmit(bt);
                    db.SubmitChanges();
                }
            }
            return "1";
        }

        [WebMethod]
        public static string Get_TaiLieu(string id)
        {
            string str = "";
            DatalinqDataContext db = new DatalinqDataContext();
            List<TaiLieu_SanPham> items = db.TaiLieu_SanPhams.Where(s => s.IDSP == int.Parse(id)).OrderBy(s => s.Create_date).ToList();
            if (items.Count > 0)
            {
                int i = 1;
                foreach (var item in items)
                {
                    str += "<tr id=\"rowPrice_" + i + "\">";
                    str += "<td style=\"width: 14%;\">";

                    str += "<select style=\"width: 100% !important;max-width: 100% !important;text-align: left;\"  name=\"icidphanmen\" class=\"form-control selectpicker\"  data-live-search=\"true\">";
                    str += "<option value=\"\">-- Chọn nhóm phần mềm --</option>";
                    List<Entity.Menu> nhomttailieu = SMenu.LOAD_CATESPARENT_ID(More.TL, Captionlanguage.Language, "-1", "1");
                    foreach (var item1 in nhomttailieu)
                    {
                        str += "<option " + (item.icidphanmen == item1.ID ? "selected" : "") + " value =\"" + item1.ID + "\">" + item1.Name + "</option>";
                    }
                    str += "</select>";
                    str += "<td style=\"width: 14%;\">";
                    str += "<input value=\"" + item.Link + "\" style=\"width: 98% !important\" type=\"text\" name=\"Link\" class=\"form-control\">";
                    str += "</td>";
                    str += "<td style=\"text-align: center; width: 3%;\" class=\"btn_add\">";
                    str += "<a href=\"javascript:void(0);\" onclick=\"deleteRow_Price(this);\" class=\"btn_add\">";
                    str += "    <img src=\"/Resources/admin/images/del.png\">";
                    str += "</a>";
                    str += "</td>";
                    str += "</tr>";
                    i++;
                }
            }
            return str;
        }
        #endregion

        #region tuvan
        public class Obj_fromtuvan
        {
            public string productName { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
            public string email { get; set; }
            public string message { get; set; }
        }

        [WebMethod]
        public static string Save_TuVan_SanPham(Obj_fromtuvan info)
        {
            DatalinqDataContext db = new DatalinqDataContext();
            TuVan_SanPham bt = new TuVan_SanPham();
            bt.vtitle = info.productName;
            bt.vname = info.name;
            bt.vphone = info.phone;
            bt.vemail = info.email;
            bt.vcontent = info.message;
            bt.dcreatedate = DateTime.Now;
            db.TuVan_SanPhams.InsertOnSubmit(bt);
            db.SubmitChanges();
            return "1";
        }

        #endregion



        [WebMethod]
        public static string Updatequantity(string id, string quantity)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            return Cart_Updatequantity(ref dtcart, id, quantity);
        }

        protected static string Cart_Updatequantity(ref DataTable dtcart, string pid, string quantity)
        {
            if (dtcart.Rows.Count > 0)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                    {
                        dtcart.Rows[i]["quantity"] = quantity;
                        dtcart.Rows[i]["Money"] = Convert.ToInt32(quantity) * Convert.ToDouble(dtcart.Rows[i]["Price"].ToString());
                        // return "";
                    }
                }
            }
            return "";
        }

        [WebMethod]
        public static string DeleteShopCart(string id, string quantity)
        {
            return ShoppingCart_RemoveProduct(id.ToString());
        }

        protected static string ShoppingCart_RemoveProduct(string pid)
        {
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];

            for (int i = 0; i < dtcart.Rows.Count; i++)
            {
                if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                {
                    dtcart.Rows.RemoveAt(i);
                    break;
                }
            }
            System.Web.HttpContext.Current.Session["cart"] = dtcart;
            return "";
        }

        [WebMethod]
        public static string Up_Order(string id, string quantity)
        {
            return ShoppingCart_AddProduct(id.ToString(), int.Parse(quantity));
        }

        protected static string ShoppingCart_AddProduct(string pid, int quantity)
        {
            if (System.Web.HttpContext.Current.Session["cart"] == null)
            {
                SessionCarts.ShoppingCreateCart();
                ShoppingCart_AddProduct(pid, quantity);
            }
            else
            {
                List<Products> dt = new List<Products>();
                // lay chi tiet san pham.
                //TongTrongluong =Price
                //TienTrongluong=Money
                dt = SProducts.GetById(pid);
                if (dt.Count > 0)
                {
                    string vimg = dt[0].Images.ToString();
                    string name = dt[0].Name.ToString();
                    string Trongluong = "";
                    Trongluong = dt[0].Noidung2;
                    if (!dt[0].Price.ToString().Equals(""))
                    {
                        //Tongsocan
                        float Kg = 0;
                        if (quantity.ToString().Length > 0)
                        {
                            Kg = Convert.ToSingle(dt[0].Noidung2);
                        }
                        float Can = Kg * quantity;
                        float price = Convert.ToSingle(dt[0].Price);
                        float TongTrongluong = 0;
                        TongTrongluong = Convert.ToSingle(dt[0].Noidung2);
                        float money = price * quantity;
                        float TienTrongluong = TongTrongluong * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                dtcart.Rows[i]["TienTrongluong"] = quantity * Convert.ToSingle(dtcart.Rows[i]["TongTrongluong"]);
                                dtcart.Rows[i]["Tongsocan"] = quantity * Convert.ToSingle(Kg);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Trongluong"] = Trongluong;
                                dr["TongTrongluong"] = TongTrongluong;
                                dr["TienTrongluong"] = TienTrongluong;
                                dr["Tongsocan"] = Kg;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                    else
                    {
                        float Kg = Convert.ToSingle(0);
                        if (dt[0].Noidung2.Length > 0 || dt[0].Noidung2.Length != 0)
                        {
                            Kg = Convert.ToSingle(dt[0].Noidung2);
                        }
                        float Can = Kg * quantity;
                        float price = Convert.ToSingle(0);
                        float TongTrongluong = Convert.ToSingle(0);
                        float money = price * quantity;
                        float TienTrongluong = TongTrongluong * quantity;
                        DataTable dtcart = new DataTable();
                        dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                        bool hasincart = false;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            if (dtcart.Rows[i]["PID"].ToString().Equals(pid))
                            {
                                hasincart = true;
                                // cap nhat thong tin cua cart.
                                quantity += Convert.ToInt32(dtcart.Rows[i]["Quantity"]);
                                dtcart.Rows[i]["Quantity"] = quantity;
                                dtcart.Rows[i]["Money"] = quantity * Convert.ToSingle(dtcart.Rows[i]["Price"]);
                                dtcart.Rows[i]["TienTrongluong"] = quantity * Convert.ToSingle(dtcart.Rows[i]["TongTrongluong"]);
                                dtcart.Rows[i]["Tongsocan"] = quantity * Convert.ToSingle(Kg);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                                break;
                            }
                        }
                        if (hasincart == false)
                        {
                            if (dtcart != null)
                            {
                                DataRow dr = dtcart.NewRow();
                                dr["PID"] = pid;
                                dr["Vimg"] = vimg;
                                dr["Name"] = name;
                                dr["Price"] = price;
                                dr["Quantity"] = quantity;
                                dr["Money"] = money;
                                dr["Trongluong"] = Trongluong;
                                dr["TongTrongluong"] = TongTrongluong;
                                dr["TienTrongluong"] = TienTrongluong;
                                dr["Tongsocan"] = Kg;
                                dtcart.Rows.Add(dr);
                                System.Web.HttpContext.Current.Session["cart"] = dtcart;
                            }
                        }
                    }
                }
            }


            return "";
        }

        [WebMethod]
        public static string LogonGoogle(string ID, string FullName, string Email, string Image)
        {
            System.Web.HttpContext.Current.Session["Google"] = ID + ";" + FullName + ";" + Email + ";" + Image;

            return "";
        }

        [WebMethod]
        public static string Up_KichCo(string id, string quantity)
        {
            return Session_Size(id.ToString());
        }

        protected static string Session_Size(string pid)
        {
            System.Web.HttpContext.Current.Session["Session_Size"] = pid.ToString();
            System.Web.HttpContext.Current.Session["GSession_Size"] = pid.ToString();
            return "";
        }

        [WebMethod]
        public static string Up_MauSac(string id, string quantity)
        {
            return Session_MauSac(id.ToString());
        }

        protected static string Session_MauSac(string pid)
        {
            System.Web.HttpContext.Current.Session["Session_MauSac"] = pid.ToString();
            System.Web.HttpContext.Current.Session["GSession_MauSac"] = pid.ToString();
            return "";
        }


        [WebMethod]
        public static string Detail(string id, string quantity)
        {
            string language = Captionlanguage.Language;
            if (System.Web.HttpContext.Current.Session["language"] != null)
            {
                language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["language"] = language;
                language = System.Web.HttpContext.Current.Session["language"].ToString();
            }
            string str = "";
            str += ("<div class=\"Dzomanh\">");
            str += "<div id=\"Loadingshop\">";
            str += "<div class=\"inner\"><img src=\"/Resources/ShopCart/images/ajax-loader_2.gif\"><p>" + Captionlanguage.GetLabel("dangxuly", language) + "...</p></div>";
            str += "</div>";
            str += ("<div class=\"row\">");
            str += ("<div class=\"\">");
            str += ("<div class=\"pd-top\">");
            str += ("<div class=\"row\">");
            str += ("    <div class=\"col-md-6\">");
            str += ("        <div class=\"prod-images clearfix\">");
            str += ("        <div class=\"pa-loading\"><img src=\"/Resources/images/sp-loading.gif\" alt=\"\"><br>LOADING IMAGES</div>");
            str += ("        <div class=\"phonganhct\">");
            string bReturn = "";
            List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where ipid=" + id + "");
            if (dbPro.Count > 0)
            {
                bReturn += " <a href=\"" + dbPro[0].Images + "\"><img src=\"" + dbPro[0].Images + "\" alt=\"" + dbPro[0].Name + "\"  /></a>";
                if (dbPro[0].Anh.ToString().Length > 5)
                {
                    string[] strArray = dbPro[0].Anh.ToString().Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        bReturn += "<a href=\"" + strArray[i].ToString() + "\"><img alt='" + dbPro[0].Name.ToString() + "'src=\"" + strArray[i].ToString() + "\"/></a>";
                    }
                }
            }
            str += (bReturn);
            str += ("        </div>");
            str += ("        </div>");
            str += ("    </div>");
            str += ("    <div class=\"col-md-6\">");
            if (dbPro.Count > 0)
            {
                str += ("<h1 itemprop=\"name\" class=\"pd-name\">" + dbPro[0].Name + "</h1>");
                str += "<p><strong>" + Captionlanguage.GetLabel("l_productid", language) + ":</strong> " + dbPro[0].Code + "</p>";
                string trongluong = "";
                trongluong = dbPro[0].Noidung2;
                str += " <p><strong>" + Captionlanguage.GetLabel("cannang", language) + ":</strong> " + trongluong + " Gram</p>";
                str += "<div class=\"pdid\">" + dbPro[0].Brief + "</div>";
                str += "<div class=\"prod-price clearfix\">";
                str += "<span class=\"price pd-price\"><b>" + Captionlanguage.GetLabel("lprice", language) + ": </b>" + MorePro.Detail_Price(dbPro[0].Price.ToString()) + " /" + dbPro[0].Noidung3 + "</span>";
                //str += "<span class=\"availability in-stock pull-right\">Còn hàng</span>";
                str += "<span class=\"compare-price\"><b>" + Captionlanguage.GetLabel("Niemyet", language) + ": </b> <del>" + MorePro.Detail_Price(dbPro[0].OldPrice.ToString()) + " đ</del></span>";
                str += "</div>";

                if (dbPro[0].Check_02 == 0)
                {
                    str += "<p class=\"prod_text\">" + Captionlanguage.GetLabel("lquantity", language) + ": <input type=\"number\" max=\"999\" min=\"0\" name='" + dbPro[0].ipid + "' id='" + dbPro[0].ipid + "' value=\"1\" class=\"input\"></p>";
                    str += " <div class=\"frmbuy\" style='margin-top: 16px;'>";
                    str += "<a class=\"product-atc\"  href=\"javascript:void(0)\" style='margin-right: 2px;'  onclick=\"Dathang(" + dbPro[0].ipid + ",'" + dbPro[0].Name + "')\">" + Captionlanguage.GetLabel("l_order", language) + "</a>";
                    str += "<a href=\"javascript:void(0)\" class='product-orders'  onclick=\"UpdateOrder(" + dbPro[0].ipid + ",'" + dbPro[0].Name + "')\">" + Captionlanguage.GetLabel("Themvaogiohang", language) + "</a>";
                    str += "</div>";
                }
            }
            str += ("    </div>");
            str += ("</div>");
            str += ("</div>");
            str += ("</div>");
            str += ("</div>");
            str += ("</div>");
            return str.ToString();
        }
        [WebMethod]
        public static string ShowCart()
        {
            string str = "";
            string tongien = "0";
            string sosp = "0";
            string inumofproducts = "0";
            string totalvnd = "0";
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    str += "<div class=\"shop_cart ajax\">";
                    str += "<div id=\"Loadingshop\">";
                    str += "<div class=\"inner\"><img src=\"/Resources/ShopCart/images/ajax-loader_2.gif\"><p>Đang xử lý...</p></div>";
                    str += "</div>";
                    str += "<div class=\"title\">";
                    str += "<div class=\"tl txt_b\">Giỏ hàng của bạn (<span class=\"shopping_cart_item\">" + Services.SessionCarts.LoadCart() + "</span> sản phẩm)</div>";
                    str += "<input id=\"temp_total\" value=\"0\" type=\"hidden\">";
                    str += "</div>";
                    str += "<table class=\"tbl_cart\" style=\"\" cellpadding=\"5\">";
                    str += "<tbody>";
                    str += "<tr id=\"shopping-cart-first-row\" class=\"txt_u txt_14 txt_b\">";
                    str += "<td style=\"\">Sản phẩm</td>";
                    str += "<td style=\"\" class=\"shopping-cart-price-col\">Đơn giá</td>";
                    str += "<td class=\"shopping-cart-quantity-col center\">Số lượng</td>";
                    str += "<td style=\"text-align: right;\" class=\"shopping-cart-sum-col\">Thành tiền</td>";
                    str += "</tr>";
                    if (dtcart.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                            num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    tongien = MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
                    sosp = inumofproducts;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        str += "<tr id=\"itm17876\">";
                        str += "<td style=\"text-align: left;\">";
                        str += "<div class=\"cartInfo-img fl\">";
                        str += "<img src=\"" + dtcart.Rows[i]["Vimg"].ToString() + "\" style=\"vertical-align: middle; margin-right: 10px;width:60px;\">";
                        str += "</div>";
                        str += "<div class=\"sum\">";
                        str += "<div class=\"cartInfo-name\">";
                        str += "<a class=\"\" target=_blank href=\"" + MoreAll.MorePro.LoadLink(dtcart.Rows[i]["PID"].ToString()) + "\"><b>" + dtcart.Rows[i]["Name"].ToString() + "</b></a>";
                        str += "<br>";
                        str += "</div>";
                        str += "<a class=\"i-del shows\" onclick=\"AJdeleteShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "')\"><img src=\"/Resources/ShopCart/images/xoa.png\" /> Bỏ sản phẩm</a>";
                        str += "</div>";
                        str += "</td>";
                        str += "<td style=\"\">";
                        str += "<span id=\"sell_price_pro_17876\">" + MoreAll.MorePro.FormatMoneyCart(dtcart.Rows[i]["Price"].ToString()) + "</span>";
                        str += "<br><span class=\"txt_d\">" + ShopGiacu(dtcart.Rows[i]["PID"].ToString()) + "</span>";
                        str += "<br><span class=\"txt_pink\">" + MoreAll.MorePro.Tietkiem(dtcart.Rows[i]["PID"].ToString()) + "</span>";
                        str += "</td>";
                        str += "<td class=\"center\">";
                        //data-abc='123'
                        str += "<input type=\"number\" max=\"999\" min=\"0\" style=\" width:50px\"  value=\"" + dtcart.Rows[i]["Quantity"].ToString() + "\" onchange=\"AddShoppingCartItem(" + dtcart.Rows[i]["PID"].ToString() + ",'" + dtcart.Rows[i]["Name"].ToString() + "',$(this))\" class=\"txt_center cor3px shows\">";
                        str += "</td>";
                        str += "<td style=\"text-align: right;\">";
                        str += "<span id=\"price_pro_17876\">" + MoreAll.MorePro.FormatMoneyCart(dtcart.Rows[i]["Money"].ToString()) + "</span>";
                        str += "</td>";
                        str += "</tr>";
                    }

                    str += "<tr>";
                    str += "<td colspan=\"5\" class=\"txt_right\">";
                    str += "<div style=\"line-height: 26px;\">";
                    str += "Tổng cộng : <span class=\"sub1 txt_18 txt_pink total_value_step txt_b\" id=\"total_value\" data-value=\"" + tongien + "\">" + tongien + "</span><br>";
                    str += "<span id=\"other-discount\">Tổng số sản phẩm: <span data-discount=\"0\" id=\"price-discount\" class=\"txt_pink\">" + sosp + "</span></span><br>";
                    str += "<span>Thanh toán: <span id=\"total_shopping_price\" class=\"txt_pink txt_b total_value_step\">" + tongien + "</span></span>";
                    str += "<br>Giá đã bao gồm VAT";
                    str += "</div>";
                    str += "</td>";
                    str += "</tr>";
                    str += "<tr>";
                    str += "<td colspan=\"4\" class=\"txt_right\">";
                    str += "<a href=\"/\" class=\"txt_pink txt_18 txt_b\" style=\"float:left;\"><i class=\"fa fa-angle-left\"></i> Tiếp tục mua hàng</a>";
                    str += "<div style=\"float:right;\">";
                    //str += "<a class=\"btn bg_pink txt_center txt_20 txt_u\" href=\"/gio-hang.html\" style=\"padding:5px 50px;\">";
                    //str += "MUA ONLINE<br> <span class=\"txt_12\" style=\"text-transform: none;\">(giao hàng tận nơi)</span>";
                    //str += "</a>";
                    str += "<a class=\"adrbutton tienhanh\" href=\"/gio-hang.html\" >Tiến hành đặt hàng</a>";
                    str += "</div>";
                    str += "</td>";
                    str += "</tr>";
                    str += "</tbody>";
                    str += "</table>";
                    str += "</div> ";
                }
                else
                {
                    str += "<div class=\"shop_cart ajax\">";
                    str += "  <div class=\"num0\">";
                    str += " <div class=\"modalbodys cart_body\">";
                    str += "<i class=\"icon_cart\"></i>";
                    str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
                    str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
                    str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
                    str += " </div>";
                    str += "  </div>";
                    str += "</div> ";
                }
            }
            else
            {
                str += "<div class=\"shop_cart ajax\">";
                str += "  <div class=\"num0\">";
                str += " <div class=\"modalbodys cart_body\">";
                str += "<i class=\"icon_cart\"></i>";
                str += "<h2>Giỏ hàng của bạn hiện đang trống</h2>";
                str += "<p>Hãy nhanh tay sở hữu những sản phẩm yêu thích của bạn</p>";
                str += "<a class=\"adrbutton\" href=\"/\">Tiếp tục mua sắm</a>";
                str += " </div>";
                str += "  </div>";
                str += "</div> ";
            }
            return str.ToString();
        }

        public static string ShopGiacu(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                if (dt[0].OldPrice.ToString().Length > 0)
                {
                    str = MorePro.Detail_Price(dt[0].OldPrice.ToString()) + " đ";
                }
            }
            return str.ToString();
        }

        [WebMethod]
        public static string LoadCart()
        {
            if (System.Web.HttpContext.Current.Session["cart"] != null)
            {
                DataTable cartdetail = (DataTable)System.Web.HttpContext.Current.Session["cart"];
                if (cartdetail.Rows.Count > 0)
                {
                    string inumofproducts = "";
                    string totalvnd = "";
                    if (cartdetail.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        for (int i = 0; i < cartdetail.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(cartdetail.Rows[i]["Money"].ToString());
                            num2 += Convert.ToInt32(cartdetail.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                    }
                    return inumofproducts;
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }

        //[WebMethod]
        //public static string[] GetCustomers(string prefix, string condition)
        //{
        //    List<string> customers = new List<string>();
        //    string strWhere = "";

        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //        using (SqlCommand cmd = new SqlCommand())
        //        {
        //            cmd.CommandText = "Select  top 15  Name from products where dbo.fuConvertToUnsign(Name) LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(prefix)) + "'" + strWhere;
        //            cmd.Connection = conn;
        //            conn.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    customers.Add(sdr["Name"].ToString());
        //                }
        //            }
        //            conn.Close();
        //        }
        //    }
        //    return customers.ToArray();
        //}

        [WebMethod]
        public static List<resultAutocomplete> GetAutocomplete(string prefix, string condition)
        {
            List<resultAutocomplete> customers = new List<resultAutocomplete>();
            string strWhere = "";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "Select  top 15  TangName,Name,ImagesSmall,Price,OldPrice from products where dbo.fuConvertToUnsign(Name) LIKE N'" + SearchApproximate.Exec(ConvertVN.Convert(prefix)) + "'" + strWhere;
                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            resultAutocomplete obj = new resultAutocomplete();
                            obj.TangName = MoreAll.AddURL.ToSlug(sdr["TangName"].ToString());
                            obj.Name = sdr["Name"].ToString();
                            obj.ImagesSmall = sdr["ImagesSmall"].ToString();
                            obj.Price = MoreAll.MorePro.FormatMoney_Cart_Total(sdr["Price"].ToString());
                            obj.OldPrice = MoreAll.MorePro.FormatMoney_Cart_Total(sdr["OldPrice"].ToString());
                            customers.Add(obj);
                        }
                    }
                    conn.Close();
                }
            }
            return customers.ToList();
        }
        public class resultAutocomplete
        {
            public string TangName { get; set; }
            public string Name { get; set; }
            public string ImagesSmall { get; set; }
            public string Price { get; set; }
            public string OldPrice { get; set; }
        }

        public class SearchApproximate
        {
            // Phương thức chuyển đổi một chuỗi ký tự: Nếu chuỗi đó có ký tự " " sẽ thay thế bằng "%"
            public static string Exec(string keyWord)
            {
                string[] arrWord = keyWord.Split(' ');
                StringBuilder str = new StringBuilder("%");
                for (int i = 0; i < arrWord.Length; i++)
                {
                    str.Append(arrWord[i] + "%");
                }
                return str.ToString();
            }
        }

        public class ConvertVN
        {
            // Phương thức Convert một chuỗi ký tự Có dấu sang Không dấu
            public static string Convert(string chucodau)
            {
                const string FindText = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
                const string ReplText = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
                int index = -1;
                char[] arrChar = FindText.ToCharArray();
                while ((index = chucodau.IndexOfAny(arrChar)) != -1)
                {
                    int index2 = FindText.IndexOf(chucodau[index]);
                    chucodau = chucodau.Replace(chucodau[index], ReplText[index2]);
                }
                return chucodau;
            }
        }

        //void CheckBrowserCaps()
        //{
        //    System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
        //    if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
        //    {
        //        //labelText = "Trình duyệt là một thiết bị di động.";
        //        Response.Redirect("Mobile.aspx");
        //    }
        //}

        //protected override void Render(HtmlTextWriter writer)
        //{
        //    //html minifier & JS at bottom
        //    // not tested
        //    if (this.Request.Headers["X-MicrosoftAjax"] != "Delta=true")
        //    {
        //        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"<script[^>]*>[\w|\t|\r|\W]*?</script>");
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        System.IO.StringWriter sw = new System.IO.StringWriter(sb);
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);
        //        base.Render(hw);
        //        string html = sb.ToString();
        //        System.Text.RegularExpressions.MatchCollection mymatch = reg.Matches(html);
        //        html = reg.Replace(html, string.Empty);
        //        reg = new System.Text.RegularExpressions.Regex(@"(?<=[^])\t{2,}|(?<=[>])\s{2,}(?=[<])|(?<=[>])\s{2,11}(?=[<])|(?=[\n])\s{2,}|(?=[\r])\s{2,}");
        //        html = reg.Replace(html, string.Empty);
        //        reg = new System.Text.RegularExpressions.Regex(@"</body>");
        //        string str = string.Empty;
        //        foreach (System.Text.RegularExpressions.Match match in mymatch)
        //        {
        //            str += match.ToString();
        //        }
        //        html = reg.Replace(html, str + "</body>");
        //        writer.Write(html);
        //    }
        //    else
        //        base.Render(writer);
        //}

    }
}
