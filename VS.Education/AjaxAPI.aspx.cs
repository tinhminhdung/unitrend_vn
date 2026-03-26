using MoreAll;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using static VS.E_Commerce.cms.Display.Products.DetailSoSanh;
using static VS.E_Commerce.index1;

namespace VS.E_Commerce
{
    public partial class AjaxAPI : System.Web.UI.Page
    {
        private const string SessionKey = "CompareProducts";

        // Thêm sản phẩm vào danh sách so sánh
        [WebMethod]
        public static string AddToCompare(int ipid, int icid, string name, string image, string Price, string link)
        {
            List<ProductCompare> compareList = HttpContext.Current.Session[SessionKey] as List<ProductCompare> ?? new List<ProductCompare>();

            // Nếu sản phẩm thuộc nhóm khác, xóa danh sách cũ
            if (compareList.Count > 0 && compareList[0].icid != icid)
            {
                compareList.Clear();
            }

            // Kiểm tra sản phẩm đã tồn tại chưa
            if (!compareList.Any(p => p.ipid == ipid))
            {
                if (compareList.Count >= 3) // Giới hạn tối đa 3 sản phẩm
                {
                    compareList.RemoveAt(0);
                }

                compareList.Add(new ProductCompare { ipid = ipid, icid = icid, name = name, image = image, Price = Price, link = link });
            }

            HttpContext.Current.Session[SessionKey] = compareList;
            return "success";
        }

        // Xóa một sản phẩm khỏi danh sách
        [WebMethod]
        public static string RemoveFromCompare(int ipid)
        {
            List<ProductCompare> compareList = HttpContext.Current.Session[SessionKey] as List<ProductCompare>;

            if (compareList != null)
            {
                compareList.RemoveAll(p => p.ipid == ipid);
                HttpContext.Current.Session[SessionKey] = compareList;
            }

            return "success";
        }

        // Xóa toàn bộ danh sách so sánh
        [WebMethod]
        public static string ClearCompare()
        {
            HttpContext.Current.Session.Remove(SessionKey);
            return "success";
        }

        // Lấy danh sách sản phẩm để hiển thị
        [WebMethod]
        public static List<ProductCompare> GetCompareList()
        {

            return HttpContext.Current.Session[SessionKey] as List<ProductCompare> ?? new List<ProductCompare>();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object GetComparisonData()
        {
            try
            {
                // Lấy danh sách sản phẩm từ Session
                var compareList = HttpContext.Current.Session["CompareProducts"] as List<ProductCompare> ?? new List<ProductCompare>();

                if (!compareList.Any())
                {
                    return new { success = false, message = "Không có sản phẩm nào để so sánh" };
                }

                // Trích xuất danh sách ipid và kiểm tra dữ liệu hợp lệ
                var ipidList = compareList.Select(p => p.ipid).Distinct().ToList();
                if (!ipidList.Any())
                {
                    return new { success = false, message = "Danh sách sản phẩm không hợp lệ" };
                }

                // Gọi stored procedure lấy dữ liệu so sánh từ SQL
                var ss = BaseConnectionSql.ExecuteList_V1<Obj_sosanh_sanphamdetail>(
                    "get_thuoctinh_sosanh_chitiet",
                    string.Join(",", ipidList)
                );

                if (ss == null || !ss.Any())
                {
                    return new { success = false, message = "Không có dữ liệu so sánh" };
                }

                // Nhóm dữ liệu theo nhóm chính (Parent_ID = -1)
                var result = ss.Where(x => x.Parent_ID == -1)
                               .GroupBy(x => x.Name)
                               .Select(group => new
                               {
                                   Name = group.Key,
                                   Products = ss.Where(x => x.Parent_ID == group.First().id)
                                                .GroupBy(p => p.ipid)
                                                .Select(g => new
                                                {
                                                    ipid = g.Key,
                                                    Attributes = g.Select(p => new
                                                    {
                                                        Name = p.Name,
                                                        Value = p.NoiDungSoSanh ?? "-"
                                                    }).ToList()
                                                }).ToList()
                               }).ToList();

                // Trả về object trực tiếp, không cần serialize thủ công
                return new { success = true, data = result };
            }
            catch (Exception ex)
            {
                return new { success = false, message = "Lỗi hệ thống: " + ex.Message };
            }
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object GetComparisonData_V3()
        {
            try
            {
                var response = new
                {
                    success = true,
                    data = new List<object>
            {
                new
                {
                    Name = "Nhóm 1",
                    Products = new List<object>
                    {
                        new
                        {
                            ipid = "SP001",
                            Attributes = new List<object>
                            {
                                new { Name = "CPU", Value = "Intel i7" },
                                new { Name = "RAM", Value = "16GB" }
                            }
                        },
                        new
                        {
                            ipid = "SP002",
                            Attributes = new List<object>
                            {
                                new { Name = "CPU", Value = "AMD Ryzen 7" },
                                new { Name = "RAM", Value = "32GB" }
                            }
                        }
                    }
                }
            }
                };

                return new JavaScriptSerializer().Serialize(response);
            }
            catch (Exception ex)
            {
                return new { success = false, message = ex.Message };
            }
        }


        [WebMethod]
        public static string getlink()
        {
            try
            {
                return MoreAll.MoreAll.GetCookies("Link").ToString();
            }
            catch (Exception)
            {
                return "/san-pham.html";
            }
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static object GetData()
        {
            try
            {
                List<Product_search> dt = BaseConnectionSql.ExecuteList_V1<Product_search>("get_products_timkiem", "0");
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                return new { error = true, message = ex.Message };
            }
        }

        [System.Web.Services.WebMethod]
        public static List<ListItem> GetStatesByCountry(string countryId)
        {
            List<ListItem> result = new List<ListItem>();
            try
            {
                string language = HttpContext.Current.Session["language"] != null
                    ? HttpContext.Current.Session["language"].ToString()
                    : "vi";

                List<Entity.Tinhthanh> list = STinhthanh.Name_Text("SELECT * FROM Tinhthanh WHERE capp='" + More.TT + "' AND Lang='" + language + "' AND Parent_ID=" + countryId + " AND Status=1 ORDER BY Orders ASC");

                foreach (var item in list)
                {
                    result.Add(new ListItem(item.Name, item.ID.ToString()));
                }
            }
            catch (Exception ex)
            {
                // log error nếu cần
            }

            return result;
        }

    }
    public class Product_search
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string ImageURL { get; set; }
        public string TangName { get; set; }
    }
    // Định nghĩa class để lưu sản phẩm so sánh
    [Serializable]
    public class ProductCompare
    {
        public int ipid { get; set; }
        public int icid { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string Price { get; set; }
        public string link { get; set; }
    }
}