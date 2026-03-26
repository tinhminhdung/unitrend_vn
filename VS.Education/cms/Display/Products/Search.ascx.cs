using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Search : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;

        string keyword = "";

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
            if (!IsPostBack)
            {
                CollectionPager1.FirstText = label("trangdau");
                CollectionPager1.LastText = label("trangcuoi");

            }
            if (MoreAll.MoreAll.GetCookies("Search").ToString() != null)
            {
                LoadItems();
            }
            else
            {
                Response.Redirect("/");
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        void LoadItems()
        {
            string keywords = "";
            if (keywords != null || keywords != "")
            {
                keywords = MoreAll.MoreAll.GetCookies("Search").ToString();
            }
            List<Entity.Products> dt = new List<Entity.Products>();
            dt = SProducts.SearchNews(keywords, language);
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MorePro.Pages());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else
            {
                lterr.Text += "<div class='ttimkiem'><p style='margin-top: 0.33em'>" + label("Tkiem") + "<span style='color:Red;'> <b>" + keywords + "</b></span> " + label("Tkiem1") + ".</p><p style='margin-top: 1em'>" + label("Tkiem2") + ":</p><ul style='margin: 0px 0px 2em 1.3em'> <li>" + label("Tkiem3") + ". </li><li>" + label("Tkiem4") + ". </li><li>" + label("Tkiem5") + ".</li></ul></div>";
            }
        }
    }
}