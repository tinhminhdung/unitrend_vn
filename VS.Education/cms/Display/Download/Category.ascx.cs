using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Net;
using System.Data.SqlClient;
using VS.E_Commerce.cms.Display.Products;

namespace VS.E_Commerce.cms.Display.Download
{
    public partial class Category : System.Web.UI.UserControl
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

            if (MoreAll.MoreAll.GetCookies("SearchDL").ToString() != null)
            {
                this.txtkeywordDL.Text = MoreAll.MoreAll.GetCookies("SearchDL").ToString();
            }
            if (!IsPostBack)
            {

                LoadCategories();

                CollectionPager1.FirstText = label("trangdau");
                CollectionPager1.LastText = label("trangcuoi");
            }
            LoadItems();

        }
        void LoadItems()
        {
            // Xóa dữ liệu cũ
            rpcates.DataSource = null;
            rpcates.DataBind();

            lterr.Text = ""; // Xóa thông báo lỗi cũ

            List<Entity.Download> dt = new List<Entity.Download>();
            string sqlQuery = "SELECT * FROM Download WHERE lang = N'" + language + "'";

            // Nếu có lọc theo danh mục
            if (ddlcategories.SelectedValue != "-1")
            {
                sqlQuery += " AND icid = " + ddlcategories.SelectedValue;
            }

            // Nếu có nhập từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(txtkeywordDL.Text))
            {
                sqlQuery += " AND (title LIKE N'%" + txtkeywordDL.Text.Replace("'", "''") + "%' OR search LIKE N'%" + txtkeywordDL.Text.Replace("'", "''") + "%')";
            }
            sqlQuery += " order by Create_Date desc " ;
            // Thực thi truy vấn
            dt = SDownload.Name_Text(sqlQuery);

            if (dt.Count > 0)
            {
                // Hiển thị phân trang nếu có dữ liệu
                CollectionPager1.Visible = true;
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MoreAll.MoreDownload.Pagedownload());

                // Hiển thị dữ liệu
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();

            }
            else
            {
                // Ẩn phân trang khi không có dữ liệu
                CollectionPager1.Visible = false;
                lterr.Text = "<div class='Checkdata'>" + this.label("I_dulieuchuadccapnhat") + "</div>";
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("SearchDL", txtkeywordDL.Text, 5000);
            LoadItems();
        }
        protected void LoadCategories()
        {
            if (Request["id"] != null && !Request["id"].Equals(""))
            {
                ddlcategories.SelectedValue = Request["id"];
            }
            int str = 0;
            List<Entity.Menu> dt = SMenu.LOAD_CATESPARENT_ID(More.TL, this.language, "-1", "1");
            for (int i = 0; i < dt.Count; i++)
            {
                if (dt[i].Parent_ID.ToString() == "-1")
                {
                    ddlcategories.Items.Insert(str, new ListItem(dt[i].Name.ToString(), dt[i].ID.ToString()));
                    str = str + 1;
                }
            }
            this.ddlcategories.Items.Insert(0, new ListItem("Tất cả tài liệu - Phần mềm", "-1"));
            this.ddlcategories.DataBind();
        }
        protected string Image_cate(string icid)
        {
            string str = "";
            List<objCombox> list1 = BaseConnectionSql.objCombox_Text("select Name, Images as Code from Menu where id='" + icid + "'");
            if (list1.Count > 0)
            {
                if (list1[0].Code != "")
                    str += "<img src=\"" + list1[0].Code + "\" style=\"border:1px solid #9EC3CB;width:73px;height:auto\">";
            }
            return str;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        protected static string getKichThuoc(string Url)
        {
            // Kiểm tra nếu Url không có http hoặc https (tức là đường dẫn tương đối)
            if (!Url.StartsWith("http://") && !Url.StartsWith("https://"))
            {
                // Lấy tên miền hiện tại
                string domain = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

                // Ghép tên miền với đường dẫn
                Url = domain + Url;
            }

            long fileSize = GetFileSize(Url);
            if (fileSize > 0)
            {
                return FormatSize(fileSize);
            }
            return "";
        }

        protected static long GetFileSize(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "HEAD";

                using (WebResponse response = request.GetResponse())
                {
                    return response.ContentLength; // Trả về kích thước file
                }
            }
            catch
            {
                return -1; // Lỗi khi lấy kích thước
            }
        }
        protected static string FormatSize(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            int order = 0;
            double len = bytes;

            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }

       
    }
}