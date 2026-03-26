using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class DCategory : System.Web.UI.UserControl
    {
        private string cid = "-1";
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
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
        //    if (Request["hp"] != null && !Request["hp"].Equals(""))
        //    {
        //        hp = Request["hp"].ToString();
        //    }
        //    iEmptyIndex = hp.IndexOf("?");
        //    if (iEmptyIndex != -1)
        //    {
        //        hp = hp.Substring(0, iEmptyIndex);
        //    }
        //    #endregion
        //    if (!IsPostBack)
        //    {
        //        List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and lang='" + language + "' and id in(" + More.Sub_Menu(More.PR, More.TangNameicid(hp)).Replace(cid, "0") + ") and Status=1  order by Orders asc");
        //        rpcates.DataSource = dt;
        //        rpcates.DataBind();

        //        List<Entity.Menu> dt1 = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.PR + "' and lang='" + language + "' and id in(" + More.TangNameicid(hp) + ") and Status=1  order by Orders asc");
        //        rpcatestop.DataSource = dt1;
        //        rpcatestop.DataBind();
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // ===== Language =====
                if (Session["language"] != null)
                    language = Session["language"].ToString();
                else
                    Session["language"] = language;

                // ===== Request hp =====
                if (Request["hp"] != null)
                    hp = Request["hp"].ToString();

                if (string.IsNullOrEmpty(hp))
                {
                    Show400(); // thiếu tham số
                    return;
                }

                int index = hp.IndexOf("?");
                if (index != -1)
                    hp = hp.Substring(0, index);

                if (!IsPostBack)
                {
                    BindMenu();
                }
            }
            catch (FormatException)
            {
                // lỗi convert dữ liệu → 400
                Show400();
            }
           
        }
        private void BindMenu()
        {
           
                string menuId = More.TangNameicid(hp);

                if (string.IsNullOrEmpty(menuId))
                {
                    Show400(); // không tìm thấy id
                    return;
                }

                string subMenu = More.Sub_Menu(More.PR, menuId);

                if (!string.IsNullOrEmpty(cid))
                    subMenu = subMenu.Replace(cid, "0");

                var dt = SMenu.Name_Text(
                    "SELECT * FROM [Menu] where capp='" + More.PR +
                    "' and lang='" + language +
                    "' and id in(" + subMenu + ") and Status=1 order by Orders asc");

                rpcates.DataSource = dt;
                rpcates.DataBind();

                var dt1 = SMenu.Name_Text(
                    "SELECT * FROM [Menu] where capp='" + More.PR +
                    "' and lang='" + language +
                    "' and id in(" + menuId + ") and Status=1 order by Orders asc");

                rpcatestop.DataSource = dt1;
                rpcatestop.DataBind();
           
        }
        private void Show400()
        {
            Response.Clear();
            Response.StatusCode = 400;
            Response.TrySkipIisCustomErrors = true;
            Response.Redirect("/page-400.html", false);
            Context.ApplicationInstance.CompleteRequest();
        }
    
        protected List<Entity.Products> NewProductInCate(string icid)
        {
            return SProducts.GetTopProductInCategory(MorePro.HomePage(), icid, More.Sub_Menu(More.PR, icid));
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}