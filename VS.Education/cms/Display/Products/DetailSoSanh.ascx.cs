using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Wordprocessing;
using MoreAll;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VS.E_Commerce.cms.Admin.Products;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class DetailSoSanh : System.Web.UI.UserControl
    {
        private string pid = "-1";
        string hp = "";
        int iEmptyIndex = 0;
        private string language = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
        private const string SessionKey = "CompareProducts";
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
            string rawUrl = Request.RawUrl;

            // Tách phần query string (sau dấu ?)
            string queryString = rawUrl.Contains("?") ? rawUrl.Split('?')[1] : "";

            // Parse query string để lấy giá trị ipid
            string ipidParam = HttpUtility.ParseQueryString(queryString).Get("ipid");

            if (!IsPostBack)
            {
                try
                {
                    if (!string.IsNullOrEmpty(ipidParam))
                    {
                        List<Entity.Products> dbPro = SProducts.Name_Text("SELECT * FROM [Products]  where ipid in (" + ipidParam + ") ");
                        if (dbPro != null && dbPro.Count > 0)
                        {
                            // Xóa danh sách cũ trong session
                            List<ProductCompare> compareList = new List<ProductCompare>();
                            foreach (var item in dbPro)
                            {
                                MoreAll.MoreAll.SetCookie("Link", Show_menu(item.icid.ToString()), 5000);
                                compareList.Add(new ProductCompare
                                {
                                    ipid = item.ipid,
                                    icid = item.icid,
                                    name = item.Name,
                                    Price = item.Price, // Giả sử giá trị sản phẩm lưu ở đây
                                    link = Show_menu(item.icid.ToString()), // Nếu có link, bạn cần lấy từ cột tương ứng
                                    image = item.ImagesSmall // Nếu có ảnh, bạn cần lấy từ cột tương ứng
                                });
                            }

                            // Cập nhật lại Session
                            HttpContext.Current.Session[SessionKey] = compareList;
                        }

                        //var ss = BaseConnectionSql.ExecuteList_V1<Obj_sosanh_sanphamdetail>("get_thuoctinh_sosanh_chitiet", ipidParam);
                        //if (ss.Count > 0)
                        //{
                        //    StringBuilder htmlBuilder = new StringBuilder();
                        //    htmlBuilder.Append("<div class=\"specifications\">\n");

                        //    // Nhóm duy nhất các tiêu đề chính (Parent_ID = -1) để tránh bị lặp
                        //    var mainGroups = ss.Where(x => x.Parent_ID == -1).GroupBy(x => x.Name).Select(g => g.First()).ToList();

                        //    foreach (var group in mainGroups)
                        //    {
                        //        htmlBuilder.Append($"    <h3>{group.Name}</h3>\n");
                        //        htmlBuilder.Append("    <table border=\"1\">\n");

                        //        // Lấy danh sách sản phẩm thuộc nhóm
                        //        var products = ss.Where(x => x.Parent_ID == group.id).ToList();

                        //        // Nhóm sản phẩm theo ID sản phẩm (ipid)
                        //        var groupedProducts = products.GroupBy(p => p.ipid).ToList();

                        //        // Hàng tiêu đề sản phẩm (chỉ hiển thị 1 lần)
                        //        //htmlBuilder.Append("        <tr style='background-color: blue; color: white;'>\n");
                        //        //htmlBuilder.Append("            <th>Thông số</th>\n");

                        //        //foreach (var product in groupedProducts)
                        //        //{
                        //        //    string productName = product.First().Name; // Lấy tên từ nhóm
                        //        //    htmlBuilder.Append($"            <th>{productName}</th>\n");
                        //        //}
                        //        //htmlBuilder.Append("        </tr>\n");

                        //        // Lấy danh sách thuộc tính và tránh lặp lại
                        //        var attributeNames = products.Select(p => p.Name).Distinct().ToList();

                        //        foreach (var attribute in attributeNames)
                        //        {
                        //            htmlBuilder.Append("        <tr>\n");
                        //            htmlBuilder.Append($"            <td>{attribute}</td>\n");

                        //            foreach (var product in groupedProducts)
                        //            {
                        //                var value = product.FirstOrDefault(p => p.Name == attribute)?.NoiDungSoSanh ?? "-";
                        //                htmlBuilder.Append($"            <td>{value}</td>\n");
                        //            }

                        //            htmlBuilder.Append("        </tr>\n");
                        //        }

                        //        htmlBuilder.Append("    </table>\n");
                        //    }

                        //    htmlBuilder.Append("</div>\n");
                        //    lstsosanh.Text = htmlBuilder.ToString();
                        //}
                    }
                }
                catch (Exception)
                { }

            }

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

    }
}