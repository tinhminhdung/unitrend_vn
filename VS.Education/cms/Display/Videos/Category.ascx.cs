using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Videos
{
    public partial class Category : System.Web.UI.UserControl
    {
        #region string
        string cid = "";
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
        #endregion

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
            if (hp == "-1")
            {
                cid = "-1";
            }
            else
            {
                cid = More.TangNameicid(hp);
            }
            #endregion

            if (!IsPostBack)
            {
                #region MyRegion
                List<Entity.Menu> dt = SMenu.GETBYID(cid);
                if (dt.Count > 0)
                {
                    ltcatename.Text = dt[0].Name.ToString();
                }
                #endregion
            }
            LoadItems();
        }

        #region LoadItems
        void LoadItems()
        {
            List<Entity.VideoClip> dt = SVideoClip.CATEGORY(More.Sub_Menu(More.VD, cid), language, "1");
            if (dt.Count > 0)
            {
                CollectionPager1.DataSource = dt;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.BindToControl = rpcates;
                CollectionPager1.PageSize = int.Parse(MoreVideoClip.Pagevideo());
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