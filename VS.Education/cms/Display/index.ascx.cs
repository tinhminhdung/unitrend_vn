using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Data;
using System.Text;

namespace VS.E_Commerce.cms.Display
{
    public partial class index : System.Web.UI.UserControl
    {
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
            if (!base.IsPostBack)
            {
                Session["ddlcountry"] = "";
                Session["ddlstate"] = "";

                List<Entity.Products> dt2 = SProducts.Name_Text("select  top " + MorePro.HomePage() + " * from  products where  News=1 and Status=1 and  lang='" + language + "' order by Create_Date desc");
                rpmoi.DataSource = dt2;
                rpmoi.DataBind();

                //List<Entity.Products> dt3 = SProducts.Name_Text("select top " + MorePro.HomePage() + " * from  products where  Check_01=1 and Status=1 and lang='" + language + "' order by Create_Date desc");
                //rpbanchay.DataSource = dt3;
                //rpbanchay.DataBind();

                List<Entity.Menu> dt = SMenu.Pages_Home(More.PR, language, "1");
                rpcates.DataSource = dt;
                rpcates.DataBind();
            }
        }
        protected List<Entity.Products> NewProductInCate(string icid)
        {
            return SProducts.GetTopProductInCategory(MorePro.HomePage(), icid, More.Sub_Menu(More.PR, icid));
        }
        protected string Menu_Pro(string id)
        {
            StringBuilder str = new StringBuilder();
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                int count = dt.Count;
                int index = 0;

                foreach (Entity.Menu item in dt)
                {
                    index++;
                    str.Append("<span class='menusspcpn'><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</span>");

                    if (index < count) // Chỉ thêm " | " nếu chưa phải phần tử cuối
                    {
                        str.Append(" | ");
                    }
                }
            }
            return str.ToString();
        }
        protected string News()
        {
            string str = "";
            List<Entity.News> dt = SNews.Name_Text("select * from  News where new=1 and Status=1  and lang='" + language + "' order by Create_Date desc");
            if (dt.Count > 0)
            {
                for (int i = 0; i < dt.Count; i++)
                {
                    if (i == 0)
                    {
                        str += "<div class=\"post-article clearfix\">";
                        str += "    <div class=\"col-md-5 col-sm-5 col-xs-12 no-padding\">";
                        str += "        <div class=\"blog-img\">";
                        str += "            <a href=\"" + dt[i].TangName + ".html\">";
                        str += MoreAll.MoreImage.Image_width_height_Title_Alt_css("img-responsive", dt[i].ImagesSmall.ToString(), "240", "135", dt[i].Title.ToString(), dt[i].Title.ToString());
                        str += "            </a>";
                        str += "        </div>";
                        str += "    </div>";
                        str += "    <div class=\"col-md-7 col-sm-7 col-xs-12 no-padding-right\">";
                        str += "        <div class=\"more-info\">";
                        str += "            <h3><a href=\"" + dt[i].TangName + ".html\">" + dt[i].Title + "</a></h3>";
                        str += "            <p class=\"blog-description\"> " + MoreAll.MoreNews.Substring_Mota(dt[i].Brief.ToString()) + "</p>";
                        str += "        </div>";
                        str += "    </div>";
                        str += "</div>";
                    }
                    else
                    {
                        str += "<div class=\"post-article clearfix\">";
                        str += "    <h3 class=\"blog-home-name\"><a href=\"" + dt[i].TangName + ".html\">" + dt[i].Title + "</a></h3>";
                        str += "</div>";
                    }
                }
            }
            return str;
        }
        protected string VideoTab()
        {
            string str = "";
            List<Entity.VideoClip> dt = SVideoClip.Name_Text("select top 5 * from VideoClip where  lang='" + language + "'  and Status=1 order by Create_Date desc");
            if (dt.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dt.Count; i++)
                {
                    if (i == 0)
                    {
                        str += "<div class=\"tab-pane fade active in\" id=\"tab-video" + j++ + "\">";
                        str += "<div class=\"col-md-6 col-sm-6 col-xs-12 no-padding\">";
                        str += "<iframe width=\"100%\" height=\"200\" src=\"https://www.youtube.com/embed/" + dt[i].Contents + "\" frameborder=\"0\" allowfullscreen></iframe>";
                        str += "<p>" + dt[i].Brief + "</p>";
                        str += "</div>";
                        str += "</div>";
                    }
                    else
                    {
                        str += "<div class=\"tab-pane fade in\" id=\"tab-video" + j++ + "\">";
                        str += "<div class=\"col-md-6 col-sm-6 col-xs-12 no-padding\">";
                        str += "<iframe width=\"100%\" height=\"200\" src=\"https://www.youtube.com/embed/" + dt[i].Contents + "\" frameborder=\"0\" allowfullscreen></iframe>";
                        str += "<p>" + dt[i].Brief + "</p>";
                        str += "</div>";
                        str += "</div>";

                    }
                }
            }
            return str;
        }
        protected string VideoTabVideo()
        {
            string str = "";
            List<Entity.VideoClip> dt = SVideoClip.Name_Text("select top 5 * from VideoClip where  lang='" + language + "'  and Status=1 order by Create_Date desc");
            if (dt.Count > 0)
            {
                int j = 1;
                for (int i = 0; i < dt.Count; i++)
                {
                    if (i == 0)
                    {
                        str += "<li class=\"active\"><a href=\"#tab-video" + j++ + "\" data-toggle=\"tab\">" + dt[i].Title + "</a></li>";
                    }
                    else
                    {
                        str += "<li><a href=\"#tab-video" + j++ + "\" data-toggle=\"tab\">" + dt[i].Title + "</a></li>";
                    }
                }
            }
            return str;
        }

        //protected string Detail(string id, string quantity)
        //{
        //    System.Text.StringBuilder strb = new System.Text.StringBuilder();
        //    strb.AppendLine("<div class=\"container\">");
        //    strb.AppendLine("<div class=\"row\">");
        //    strb.AppendLine("<div class=\"col-md-9\">");
        //    strb.AppendLine("<div class=\"pd-top\">");
        //    strb.AppendLine("<div class=\"row\">");
        //    strb.AppendLine("    <div class=\"col-md-6\">");
        //    strb.AppendLine("        <div class=\"prod-image clearfix\">");
        //    strb.AppendLine("        <div class=\"sp-loading\"><img src=\"/Resources/images/sp-loading.gif\" alt=\"\"><br>LOADING IMAGES</div>");
        //    strb.AppendLine("        <div class=\"sp-wrap\">");
        //    string bReturn = "";
        //    List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where ipid=" + id + "");
        //    if (dbPro.Count > 0)
        //    {
        //        bReturn += " <a href=\"" + dbPro[0].Images + "\"><img src=\"" + dbPro[0].Images + "\" alt=\"" + dbPro[0].Name + "\"  /></a>";
        //        if (dbPro[0].Anh.ToString().Length > 5)
        //        {
        //            string[] strArray = dbPro[0].Anh.ToString().Split(new char[] { ',' });
        //            for (int i = 0; i < strArray.Length; i++)
        //            {
        //                bReturn += "<a href=\"" + strArray[i].ToString() + "\"><img alt='" + dbPro[0].Name.ToString() + "'src=\"" + strArray[i].ToString().Replace("uploads", "uploads/_thumbs") + "\"/></a>";
        //            }
        //        }
        //    }
        //    strb.AppendLine(bReturn);
        //    strb.AppendLine("        </div>");
        //    strb.AppendLine("        </div>");
        //    strb.AppendLine("    </div>");
        //    strb.AppendLine("    <div class=\"col-md-6\">");
        //    if (dbPro.Count > 0)
        //    {
        //        strb.AppendLine("        <h1 itemprop=\"name\" class=\"pd-name\">" + dbPro[0].Name + "</h1>");
        //        strb.AppendLine("        <div class=\"prod-price clearfix\">");
        //        strb.AppendLine("        <b>Giá: </b> <span class=\"price pd-price\">Hết hàng</span> ");
        //        strb.AppendLine("        <span class=\"compare-price\"><b>GNY: </b> <del>350.000₫</del></span>");
        //        strb.AppendLine("        <span class=\"availability in-stock pull-right\">Còn hàng</span>");
        //        strb.AppendLine("        </div>");
        //        strb.AppendLine("        <div class=\"pd-description-mini\"><p><strong>Hãng sản xuất:</strong> Samsung</p>");
        //        strb.AppendLine("        <p><strong>Xuất xứ:</strong> Trung Quốc</p>");
        //        strb.AppendLine("        <p><strong>Bảo hành:</strong> 1 năm</p>");
        //        strb.AppendLine("        <p><strong>Giới thiệu:</strong>&nbsp;Điện thoại Sam sung&nbsp;IC-F2000 có độ dày chỉ 24,5mm(0,96 in) với vỏ chống nước chuẩn IP67. Máy thu phát vô tuyến chịu được độ sâu 1m nước trong vòng 30 phút. Cấu trúc kín bụi ngăn xập nhập và đáp ứng tiêu chuẩn MIL STD 810.</p></div>  ");

        //    }
        //    strb.AppendLine("    </div>");
        //    strb.AppendLine("</div>");
        //    strb.AppendLine("</div>");
        //    strb.AppendLine("</div>");
        //    strb.AppendLine("</div>");
        //    strb.AppendLine("</div>");
        //    return strb.ToString();
        //}
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}