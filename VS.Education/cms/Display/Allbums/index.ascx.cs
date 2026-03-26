using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Allbums
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
            if (!IsPostBack)
            {
                List<Entity.Menu> dt = SMenu.Pages_Home(More.AB, language, "1");
                rpcates.DataSource = dt;
                rpcates.DataBind();
            }
        }

        protected List<Entity.Album> AlbumInCate(string icid)
        {
            return SAlbum.Name_Text("select top " + MoreAll.Other.Giatri("VideopageHome") + " * from  Album where News=1 and Menu_ID in (" + More.Sub_Menu(More.AB, icid) + ") and Status=1   order by Create_Date desc");
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}