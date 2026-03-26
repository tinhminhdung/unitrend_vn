using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Detail : System.Web.UI.UserControl
    {
        string pid = "-1";
        string cid = "-1";
        // string hp = "";
        string ipid = "";
        int iEmptyIndex = 0;
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (System.Web.HttpContext.Current.Session["language"] != null)
        //    {
        //        this.language = System.Web.HttpContext.Current.Session["language"].ToString();
        //    }
        //    else
        //    {
        //        System.Web.HttpContext.Current.Session["language"] = this.language;
        //        this.language = System.Web.HttpContext.Current.Session["language"].ToString();
        //    }
        //    #region Requesthp
        //    if (Request["ipid"] != null && !Request["ipid"].Equals(""))
        //    {
        //        ipid = Request["ipid"].ToString();
        //    }
        //    #endregion
        //    if (!IsPostBack)
        //    {
        //        Session["ddlcountry"] = "";
        //        Session["ddlstate"] = "";
        //        List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid= " + ipid + "");
        //        if (dt.Count > 0)
        //        {
        //            cid = dt[0].icid.ToString();
        //            pid = dt[0].ipid.ToString();
        //            #region Đã xem
        //            try
        //            {
        //                string viewedPids = Request.Cookies["ViewedPids"]?.Value ?? "";
        //                List<string> viewedList = viewedPids.Split(',').ToList();
        //                if (!viewedList.Contains(pid))
        //                {
        //                    viewedList.Add(pid);
        //                    string updatedViewedPids = string.Join(",", viewedList);

        //                    HttpCookie cookie = new HttpCookie("ViewedPids", updatedViewedPids);
        //                    cookie.Expires = DateTime.Now.AddDays(7); // Lưu trong 7 ngày
        //                    Response.Cookies.Add(cookie);
        //                }
        //            }
        //            catch (Exception)
        //            { }
        //            #endregion

        //            #region rp_tailieu
        //            try
        //            {
        //                List<objTaiLieuSP> ttl = BaseConnectionSql.objTaiLieuSP_Text("get_TaiLieu_SanPham", dt[0].ipid);
        //                if (ttl.Count > 0)
        //                {
        //                    rp_tailieu.DataSource = ttl;
        //                    rp_tailieu.DataBind();
        //                }
        //            }
        //            catch (Exception)
        //            { }
        //            #endregion

        //            #region ThuongHieu
        //            try
        //            {
        //                List<Entity.Menu> th = SMenu.Name_Text("select * from  Menu where ID=" + dt[0].ThuongHieu.ToString() + "");
        //                if (th.Count > 0)
        //                {
        //                    ThuongHieu.Text = th[0].Name;
        //                }
        //                List<Entity.Menu> tgbh = SMenu.Name_Text("select * from  Menu where ID=" + dt[0].ThoiGianBaoHanh.ToString() + "");
        //                if (tgbh.Count > 0)
        //                {
        //                    ThoiGianBaoHanh.Text = tgbh[0].Name;
        //                }
        //            }
        //            catch (Exception)
        //            { }

        //            #endregion


        //            ltmeta.Text += "  <meta itemprop=\"url\" content=\"/" + dt[0].TangName + "\">";
        //            ltmeta.Text += "<meta itemprop=\"image\" content=\"/" + dt[0].Images + "\">";

        //            ltaddcompare.Text = "<a onclick=\"btnaddcompare('" + pid + "','" + cid + "','" + dt[0].Name + "','" + dt[0].ImagesSmall + "','" + dt[0].Price + "','" + Show_menu(dt[0].icid.ToString()) + "')\" class=\"button nenbt\">So Sánh <span>Với các sản phẩm khác cùng loại</span></a>";

        //            hdipid.Value = dt[0].ipid.ToString();
        //            ltname.Text = dt[0].Name;
        //            ltname2.Text = dt[0].Name;
        //            ltimg.Text += "<img src=\"" + dt[0].Images + "\" alt=\"" + dt[0].Name + "\"  />";


        //            if (dt[0].Noidung4.ToString() == "0")
        //            {
        //                lttengiaban_css.Text = "<style> .giabanVAT { display:none } </style>";
        //            }
        //            else
        //            {
        //                lttengiaban.Text = "<small>(Chưa VAT)</small>";
        //                lttengiaban2.Text = "<small>(VAT " + dt[0].Noidung4.ToString() + " %)</small>";

        //                double price = Convert.ToDouble(dt[0].Price);
        //                double vatPercent = Convert.ToDouble(dt[0].Noidung4); // 10 hoặc 8
        //                double tongtien = price * (1 + vatPercent / 100.0);    // Cộng thêm VAT
        //                ltprices2.Text = MorePro.FormatMoney_Cart_Total(tongtien.ToString());
        //            }

        //            if (dt[0].Check_02 == 1)
        //            {
        //                TrangThaiHang.Text = "<span class='ngungsanxuat'>Ngừng sản xuất</span>";
        //                ltcss.Text = "<style> .chitietsp .primary-button { background-color: #fff !important; color: #000 !important; border:1px solid #557f00 !important; } </style>";
        //            }
        //            else if (dt[0].TrangThaiHang != "")
        //            {
        //                TrangThaiHang.Text = dt[0].TrangThaiHang;
        //            }
        //            else
        //            {
        //                TrangThaiHang.Text = "Chưa cập nhật";
        //            }

        //            if (dt[0].LinkSPNgungBan.Length > 0)
        //            {
        //                ltsanphamthaythe.Text = sanphamthaythe(dt[0].LinkSPNgungBan);
        //            }
        //            lstsosanh.Text = ViewSoSanh(dt[0].ipid.ToString());

        //            Model.Text = dt[0].Model;
        //            XuatXu.Text = dt[0].XuatXu;

        //            ltdesc.Text = dt[0].Brief;
        //            ltdetail.Text = dt[0].Contents;
        //            ltprice.Text = MorePro.Detail_Price(dt[0].Price.ToString());
        //            ltprices.Text = MorePro.FormatMoney_Cart_Total(dt[0].Price.ToString());
        //            ltdonvi.Text = dt[0].Noidung3.ToString();
        //            ltdonvi2.Text = dt[0].Noidung3.ToString();
        //            if (dt[0].Noidung1 != null && dt[0].Noidung1 != "")
        //            {
        //                string strt = "<i class=\"fa fa-tags\"></i> <b>Tags:</b>";
        //                string tag = dt[0].Noidung1;
        //                tag = tag.Trim();
        //                string[] arrTag = tag.Split(Convert.ToChar(","));
        //                if (arrTag.Count() > 1)
        //                {
        //                    for (int i = 0; i < arrTag.Count(); i++)
        //                    {
        //                        string t = arrTag[i].Replace(" ", "-");
        //                        strt += "<a rel='tagn' href='/tag/" + RewriteURL.GetNewTitle(t) + ".html'>" + t + "</a>";
        //                    }
        //                }
        //                else
        //                {
        //                    tag = tag.Replace(",", "");
        //                    strt += "<a rel='tagn' href='/tag/" + RewriteURL.GetNewTitle(tag) + ".html'>" + tag + "</a>";
        //                }
        //                ltrTag.Text = strt;
        //            }
        //            else
        //            {
        //                ltrTag.Text = "";
        //            }

        //            dt = SProducts.NewxTopNewsAfterNews(cid, pid, int.Parse(MorePro.proother()), language);
        //            if (dt.Count > 0)
        //            {
        //                rpcates.DataSource = dt;
        //                rpcates.DataBind();
        //            }
        //            else
        //            {
        //                List<Entity.Products> dt22 = SProducts.Name_Text("select top " + int.Parse(MorePro.proother()) + " * from products where icid= " + cid + "  and lang= '" + language + "'  and Status=1 and (Create_Date<=getdate() and getdate()<=Modified_Date) order by Create_Date desc");
        //                rpcates.DataSource = dt22;
        //                rpcates.DataBind();
        //            }
        //        }
        //    }
        //    if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.pid))
        //    {
        //        SProducts.UpdateViewTimes(this.pid);
        //        MoreAll.MoreAll.SetCookie("views", this.pid);
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                else
                {
                    Show404();
                    return;
                }
                #endregion

                if (!int.TryParse(ipid, out int ipidInt))
                {
                    Show404();
                    return;
                }

                if (!IsPostBack)
                {
                    Session["ddlcountry"] = "";
                    Session["ddlstate"] = "";

                    List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products] where ipid= " + ipidInt);

                    if (dt == null || dt.Count == 0)
                    {
                        Show404();
                        return;
                    }

                    cid = dt[0].icid.ToString();
                    pid = dt[0].ipid.ToString();

                    #region Đã xem
                    try
                    {
                        string viewedPids = Request.Cookies["ViewedPids"]?.Value ?? "";
                        List<string> viewedList = viewedPids.Split(',').ToList();
                        if (!viewedList.Contains(pid))
                        {
                            viewedList.Add(pid);
                            string updatedViewedPids = string.Join(",", viewedList);

                            HttpCookie cookie = new HttpCookie("ViewedPids", updatedViewedPids);
                            cookie.Expires = DateTime.Now.AddDays(7);
                            Response.Cookies.Add(cookie);
                        }
                    }
                    catch { }
                    #endregion

                    #region rp_tailieu
                    try
                    {
                        List<objTaiLieuSP> ttl = BaseConnectionSql.objTaiLieuSP_Text("get_TaiLieu_SanPham", dt[0].ipid);
                        if (ttl.Count > 0)
                        {
                            rp_tailieu.DataSource = ttl;
                            rp_tailieu.DataBind();
                        }
                    }
                    catch { }
                    #endregion

                    #region ThuongHieu
                    try
                    {
                        List<Entity.Menu> th = SMenu.Name_Text("select * from Menu where ID=" + dt[0].ThuongHieu);
                        if (th.Count > 0) ThuongHieu.Text = th[0].Name;

                        List<Entity.Menu> tgbh = SMenu.Name_Text("select * from Menu where ID=" + dt[0].ThoiGianBaoHanh);
                        if (tgbh.Count > 0) ThoiGianBaoHanh.Text = tgbh[0].Name;
                    }
                    catch { }
                    #endregion

                    ltmeta.Text += "  <meta itemprop=\"url\" content=\"/" + dt[0].TangName + "\">";
                    ltmeta.Text += "<meta itemprop=\"image\" content=\"/" + dt[0].Images + "\">";

                    ltaddcompare.Text = "<a onclick=\"btnaddcompare('" + pid + "','" + cid + "','" + dt[0].Name + "','" + dt[0].ImagesSmall + "','" + dt[0].Price + "','" + Show_menu(dt[0].icid.ToString()) + "')\" class=\"button nenbt\">So Sánh <span>Với các sản phẩm khác cùng loại</span></a>";

                    hdipid.Value = dt[0].ipid.ToString();
                    ltname.Text = dt[0].Name;
                    ltname2.Text = dt[0].Name;
                    ltimg.Text += "<img src=\"" + dt[0].Images + "\" alt=\"" + dt[0].Name + "\"  />";


                    if (dt[0].Noidung4.ToString() == "0")
                    {
                        lttengiaban_css.Text = "<style> .giabanVAT { display:none } </style>";
                    }
                    else
                    {
                        lttengiaban.Text = "<small>(Chưa VAT)</small>";
                        lttengiaban2.Text = "<small>(VAT " + dt[0].Noidung4.ToString() + " %)</small>";

                        double price = Convert.ToDouble(dt[0].Price);
                        double vatPercent = Convert.ToDouble(dt[0].Noidung4); // 10 hoặc 8
                        double tongtien = price * (1 + vatPercent / 100.0);    // Cộng thêm VAT
                        ltprices2.Text = MorePro.FormatMoney_Cart_Total(tongtien.ToString());
                    }

                    if (dt[0].Check_02 == 1)
                    {
                        TrangThaiHang.Text = "<span class='ngungsanxuat'>Ngừng sản xuất</span>";
                        ltcss.Text = "<style> .chitietsp .primary-button { background-color: #fff !important; color: #000 !important; border:1px solid #557f00 !important; } </style>";
                    }
                    else if (dt[0].TrangThaiHang != "")
                    {
                        TrangThaiHang.Text = dt[0].TrangThaiHang;
                    }
                    else
                    {
                        TrangThaiHang.Text = "Chưa cập nhật";
                    }

                    if (dt[0].LinkSPNgungBan.Length > 0)
                    {
                        ltsanphamthaythe.Text = sanphamthaythe(dt[0].LinkSPNgungBan);
                    }
                    lstsosanh.Text = ViewSoSanh(dt[0].ipid.ToString());

                    Model.Text = dt[0].Model;
                    XuatXu.Text = dt[0].XuatXu;

                    ltdesc.Text = dt[0].Brief;
                    ltdetail.Text = dt[0].Contents;
                    ltprice.Text = MorePro.Detail_Price(dt[0].Price.ToString());
                    ltprices.Text = MorePro.FormatMoney_Cart_Total(dt[0].Price.ToString());
                    ltdonvi.Text = dt[0].Noidung3.ToString();
                    ltdonvi2.Text = dt[0].Noidung3.ToString();
                    if (dt[0].Noidung1 != null && dt[0].Noidung1 != "")
                    {
                        string strt = "<i class=\"fa fa-tags\"></i> <b>Tags:</b>";
                        string tag = dt[0].Noidung1;
                        tag = tag.Trim();
                        string[] arrTag = tag.Split(Convert.ToChar(","));
                        if (arrTag.Count() > 1)
                        {
                            for (int i = 0; i < arrTag.Count(); i++)
                            {
                                string t = arrTag[i].Replace(" ", "-");
                                strt += "<a rel='tagn' href='/tag/" + RewriteURL.GetNewTitle(t) + ".html'>" + t + "</a>";
                            }
                        }
                        else
                        {
                            tag = tag.Replace(",", "");
                            strt += "<a rel='tagn' href='/tag/" + RewriteURL.GetNewTitle(tag) + ".html'>" + tag + "</a>";
                        }
                        ltrTag.Text = strt;
                    }
                    else
                    {
                        ltrTag.Text = "";
                    }

                    dt = SProducts.NewxTopNewsAfterNews(cid, pid, int.Parse(MorePro.proother()), language);
                    if (dt.Count > 0)
                    {
                        rpcates.DataSource = dt;
                        rpcates.DataBind();
                    }
                    else
                    {
                        List<Entity.Products> dt22 = SProducts.Name_Text("select top " + int.Parse(MorePro.proother()) + " * from products where icid= " + cid + "  and lang= '" + language + "'  and Status=1 and (Create_Date<=getdate() and getdate()<=Modified_Date) order by Create_Date desc");
                        rpcates.DataSource = dt22;
                        rpcates.DataBind();
                    }
                }

                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.pid))
                {
                    SProducts.UpdateViewTimes(this.pid);
                    MoreAll.MoreAll.SetCookie("views", this.pid);
                }
            }
            catch (SqlException)
            {
                Show404();
            }
            catch (Exception)
            {
                Show404();
            }
        }
        private void Show404()
        {
            Response.StatusCode = 404;
            Response.Redirect("/page-404.html", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        public string Viewprodetail()
        {
            string bReturn = "";
            List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where ipid=" + ipid + "");
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
            return bReturn;
        }
        public string Ngungbanhang()
        {
            string bReturn = "";
            List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where ipid=" + ipid + "");
            if (dbPro.Count > 0)
            {
                if (dbPro[0].Check_02 == 1)
                {
                    bReturn = "opacity: 0.5; cursor: not-allowed;  pointer-events: none; ";
                }
            }
            return bReturn;
        }
        public string sanphamthaythe(string id)
        {
            string bReturn = "";
            List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where ipid=" + id + "");
            if (dbPro.Count > 0)
            {
                bReturn += " <div class=\"product-box\">";
                bReturn += " <a href='/" + dbPro[0].TangName + "_id" + dbPro[0].ipid + ".html'><img src=\"" + dbPro[0].ImagesSmall + "\" class=\"anhspthaythe\" alt=\"" + dbPro[0].Name + "\"></a>";
                bReturn += "    <div class=\"product-info\">";
                bReturn += "        <div class=\"product-title\">MODEL THAY THẾ</div>";
                bReturn += "        <div class=\"product-name\"><a href='/" + dbPro[0].TangName + "_id" + dbPro[0].ipid + ".html'>" + dbPro[0].Name + "</a></div>";
                bReturn += "        <div class=\"product-price\" > Giá bán: <span> " + MoreAll.MorePro.Detail_Price(dbPro[0].Price) + " đ </ span ></div>";
                bReturn += "    </div>";
                bReturn += "</div>";
            }
            return bReturn;
        }
        protected string Show_menu(string id)
        {
            StringBuilder str = new StringBuilder();
            List<Entity.Menu> dt = SMenu.Detail(id);
            if (dt.Count > 0)
            {
                str.Append(dt[0].TangName + ".html");
            }
            return str.ToString();
        }
        protected string ViewSoSanh(string ipidParam)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            var ss = BaseConnectionSql.ExecuteList_V1<Obj_sosanh_sanphamdetail>("gget_thuoctinh_sosanh_chitiet_view", ipidParam);
            if (ss.Count > 0)
            {
                htmlBuilder.Append("<div class=\"specifications\">\n");

                // Nhóm duy nhất các tiêu đề chính (Parent_ID = -1) để tránh bị lặp
                var mainGroups = ss.Where(x => x.Parent_ID == -1).GroupBy(x => x.Name).Select(g => g.First()).ToList();

                foreach (var group in mainGroups)
                {


                    // Lấy danh sách sản phẩm thuộc nhóm
                    var products = ss.Where(x => x.Parent_ID == group.id).ToList();

                    // Nhóm sản phẩm theo ID sản phẩm (ipid)
                    var groupedProducts = products.GroupBy(p => p.ipid).ToList();


                    var attributeNames = products.Select(p => p.Name).Distinct().ToList();

                    if (attributeNames.Count > 0)
                    {
                        htmlBuilder.Append($"    <h3>{group.Name}</h3>\n");
                        htmlBuilder.Append("    <table border=\"1\">\n");
                    }

                    foreach (var attribute in attributeNames)
                    {
                        htmlBuilder.Append("        <tr>\n");
                        htmlBuilder.Append($"            <td>{attribute}</td>\n");

                        foreach (var product in groupedProducts)
                        {
                            var value = product.FirstOrDefault(p => p.Name == attribute)?.NoiDungSoSanh ?? "-";
                            htmlBuilder.Append($"            <td>{value}</td>\n");
                        }

                        htmlBuilder.Append("        </tr>\n");
                    }

                    if (attributeNames.Count > 0)
                    {
                        htmlBuilder.Append("    </table><div style=\"clear:both;height:15px\"></div>");
                    }
                }

                htmlBuilder.Append("</div>");

            }
            return htmlBuilder.ToString();
        }

        public class Obj_sosanh_sanphamdetail
        {
            public int ipid { get; set; }
            public int icid { get; set; }
            public int id { get; set; }
            public int Parent_ID { get; set; }
            public string NoiDungSoSanh { get; set; }
            public string idthuoctinh_cha { get; set; }
            public string Name { get; set; }
            public string idthuoctinh { get; set; }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
        protected void lnkaddtocart_Click(object sender, EventArgs e)
        {
            string Kichco = "0";
            string Mausac = "0";
            SessionCarts.ShoppingCart_AddProduct(hdipid.Value, Convert.ToInt32(idsoluong3.Value));
            Response.Redirect("/gio-hang.html");
        }
        protected void lnkaddtocartgh_Click(object sender, EventArgs e)
        {
            SessionCarts.ShoppingCart_AddProduct(hdipid.Value, Convert.ToInt32(idsoluong3.Value));
            // Response.Write("<script type=\"text/javascript\">alert('" + label("themvaogh") + "')</script>");
        }
    }
}