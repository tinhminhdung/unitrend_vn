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
    public partial class Index : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
       
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region Session
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
            if (!IsPostBack)
            {
                CollectionPager1.FirstText = label("trangdau");
                CollectionPager1.LastText = label("trangcuoi");
            }
            LoadItems();
        }

        #region LoadItems
        void LoadItems()
        {
            List<Entity.News> dt = SNews.INDEX(language, "1");
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MoreNews.page());
                rpcates.DataSource = CollectionPager1.DataSourcePaged;
                rpcates.DataBind();
            }
            else lterr.Text = "<div style='color:Red; font-weight:bold; text-align:center; margin-bottom:10px; padding-top:10px'>" + this.label("I_dulieuchuadccapnhat") + "</div>";
        }
        #endregion

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}