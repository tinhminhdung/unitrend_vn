using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Services;
using Framework;
using Entity;
using System.Text;

namespace VS.E_Commerce.cms.Display
{
    public partial class Lefmenu : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        #endregion
        public string Case = "";
        public string ipid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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
            #region Requesthp
            if (Request["hp"] != null && !Request["hp"].Equals(""))
            {
                hp = Request["hp"].ToString();
            }
            iEmptyIndex = hp.IndexOf("?");
            if (iEmptyIndex != -1)
            {
                hp = hp.Substring(0, iEmptyIndex);
            }
            if (Request["ipid"] != null && !Request["ipid"].Equals(""))
            {
                ipid = Request["ipid"].ToString();
            }
            #endregion
            if (!base.IsPostBack)
            {
                #region rpdaxem
                try
                {
                    if (Request.Cookies["ViewedPids"] != null)
                    {
                        string viewedPids = Request.Cookies["ViewedPids"].Value;
                        List<string> pidList = viewedPids.Split(',').Where(pid => !string.IsNullOrWhiteSpace(pid)).ToList();

                        if (pidList.Count > 0)
                        {
                            string pidQuery = string.Join(",", pidList.Select(pid => int.TryParse(pid, out _) ? pid : "0")); // Ensure only numeric IDs
                            string query = $"SELECT TOP 10 * FROM [Products] WHERE ipid IN ({pidQuery}) order by Create_Date desc";

                            List<Entity.Products> daxem = SProducts.Name_Text(query);

                            if (daxem.Count > 0)
                            {
                                rpdaxem.DataSource = daxem;
                                rpdaxem.DataBind();
                            }
                        }
                    }

                }
                catch (Exception)
                { }

                #endregion

                #region Module
                try
                {
                    if (Request["e"] != null)
                    {
                        string chuoi = "";
                        try
                        {
                            string ipid = Request["ipid"].ToString();
                            List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid= " + ipid + "");
                            if (dt.Count > 0)
                            {
                                Case = "21";
                                chuoi = "21";
                            }
                        }
                        catch (Exception)
                        { }
                        if (chuoi != "21")
                        {
                            if (Request["e"].ToString() == "load")
                            {
                                Case = MoreAll.Other.RequestMenu(Request["hp"]);
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    // Response.Redirect("/page-404.html");
                }
                #endregion

                #region sanphamlienquan
                if (Case == "20" || Case == "21" || Case == "23")
                {
                    List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where TangName=N'" + hp + "'");
                    if (dt.Count > 0)
                    {
                        string pid = dt[0].ipid.ToString();
                        var lienquan = BaseConnectionSql.ExecuteList_V1<Entity.Products>("get_sanphamlienquan_ipid", pid);/// chưa có thủ tục. truy vấn 2 bảng sản phẩm và bảng liên quan nhé
                        if (lienquan.Count > 0)
                        {
                            rplienquan.DataSource = lienquan;
                            rplienquan.DataBind();
                        }
                    }
                }
                #endregion
            }
        }

        protected string Videolst()
        {
            StringBuilder str = new StringBuilder();
            List<Entity.VideoClip> dt = SVideoClip.Name_Text("SELECT * FROM VideoClip WHERE lang='" + language + "' AND Status=1 order by Create_Date desc");
            if (dt.Count > 0)
            {
                str.Append("<script>var videos = [");
                for (int i = 0; i < dt.Count; i++)
                {
                    var item = dt[i];
                    str.Append($"{{ id: \"{item.Contents}\", title: \"{item.Title}\", desc: \"{item.Brief}\" }}");
                    // Chỉ thêm dấu phẩy nếu không phải phần tử cuối cùng
                    if (i < dt.Count - 1)
                    {
                        str.Append(",");
                    }
                }
                str.Append("];</script>");
            }
            return str.ToString();
        }

        protected string MenuNews()
        {
            string str = "";
            List<Entity.News> dt = SNews.Name_Text("SELECT top " + MoreNews.page2() + " * FROM [News] where Status=1 order by NEWID()  ");
            if (dt.Count > 0)
            {
                foreach (Entity.News item in dt)
                {
                    str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Title.ToString() + "</a></li>";
                }
            }
            return str.ToString();
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}