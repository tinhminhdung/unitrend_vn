using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Text;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Index : System.Web.UI.UserControl
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
                List<Entity.Menu> dt = SMenu.Pages_Home(More.PR, language, "1");
                rpcates.DataSource = dt;
                rpcates.DataBind();
            }
        }

        protected List<Entity.Products> NewProductInCate(string icid)
        {
            return SProducts.GetTopProductInCategory(MorePro.HomePage(), icid, More.Sub_Menu(More.PR, icid));
        }
        protected string Menu_Pro(string id)
        {
            StringBuilder str = new StringBuilder();
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                int count = dt.Count;
                int index = 0;

                foreach (Entity.Menu item in dt)
                {
                    index++;
                    str.Append("<span class='menusspcpn'><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</span>");

                    if (index < count) // Chỉ thêm " | " nếu chưa phải phần tử cuối
                    {
                        str.Append(" | ");
                    }
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