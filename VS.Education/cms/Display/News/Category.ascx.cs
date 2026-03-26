using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Display.News
{
    public partial class Category1 : System.Web.UI.UserControl
    {
        #region string
        string cid = "-1";
        private string language = Captionlanguage.Language;
        #endregion
        string hp = "";
        int iEmptyIndex = 0;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    #region #
        //    if (System.Web.HttpContext.Current.Session["language"] != null)
        //    {
        //        this.language = System.Web.HttpContext.Current.Session["language"].ToString();
        //    }
        //    else
        //    {
        //        System.Web.HttpContext.Current.Session["language"] = this.language;
        //        this.language = System.Web.HttpContext.Current.Session["language"].ToString();
        //    }
        //    #endregion
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
        //        CollectionPager1.FirstText = label("trangdau");
        //        CollectionPager1.LastText = label("trangcuoi");
        //        try
        //        {
        //            List<Entity.Menu> item = SMenu.GETBYID(More.TangNameicid(hp));
        //            if (item.Count > 0)
        //            {
        //                ltcatename.Text = item[0].Name.ToString();
        //            }
        //        }
        //        catch (Exception)
        //        { }
        //    }
        //    LoadItems();
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            InitLanguage();

            string slug = GetSlug();
            if (string.IsNullOrEmpty(slug))
            {
                Show404();
                return;
            }

            if (!IsPostBack)
            {
                InitPager();
                LoadCategoryName(slug);
            }

            LoadItems();
        }

        // ================= LANGUAGE =================
        private void InitLanguage()
        {
            if (Session["language"] == null)
                Session["language"] = language;

            language = Session["language"].ToString();
        }

        // ================= GET SLUG =================
        private string GetSlug()
        {
            string hpRaw = Request["hp"];

            if (string.IsNullOrEmpty(hpRaw))
                return null;

            int index = hpRaw.IndexOf("?");
            return index > -1 ? hpRaw.Substring(0, index) : hpRaw;
        }

        // ================= INIT PAGER =================
        private void InitPager()
        {
            CollectionPager1.FirstText = label("trangdau");
            CollectionPager1.LastText = label("trangcuoi");
        }

        // ================= LOAD CATEGORY =================
        private void LoadCategoryName(string slug)
        {
            try
            {
                string icid = More.TangNameicid(slug);
                var item = SMenu.GETBYID(icid);

                if (item != null && item.Count > 0)
                    ltcatename.Text = item[0].Name;
                else
                    Show404();
            }
            catch
            {
                Show404();
            }
        }


        // ================= SHOW 404 =================
        private void Show404()
        {
            Response.Clear();
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            Response.Redirect("/page-404.html");
        }

        #region LoadItems
        void LoadItems()
        {
            List<Entity.News> dt = new List<Entity.News>();
            dt = SNews.CATEGORY(More.Sub_Menu(More.NS, More.TangNameicid(hp)), language, "1");
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MoreNews.page());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else lterr.Text = "<div class='Checkdata'>" + this.label("I_dulieuchuadccapnhat") + "</div>";
        }
        #endregion

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}