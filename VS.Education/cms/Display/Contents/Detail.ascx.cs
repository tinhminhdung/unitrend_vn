using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Display.Contents
{
    public partial class Detail : System.Web.UI.UserControl
    {
        string ID = "";
        string Menu_ID = "";
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
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
            #endregion
            if (!IsPostBack)
            {
                List<Entity.MNews> dt = SMNews.Name_Text("SELECT * FROM [MNews]  where Url_Name='" + hp + "'");
                if (dt.Count > 0)
                {
                    Menu_ID = dt[0].Menu_ID.ToString();
                    ID = dt[0].ID.ToString();
                    List<Entity.Menu> item = SMenu.GETBYID(Menu_ID);
                    if (item.Count > 0)
                    {
                        ltcatename.Text = item[0].Name.ToString();
                    }
                    lttitle.Text = dt[0].Title.ToString();
                    ltdesc.Text = dt[0].Brief.ToString();
                    ltcontent.Text = dt[0].Contents.ToString();
                    //Response.Write(MoreNews.Newsother());
                    dt = SMNews.NEWS_OTHERLAST(ID, int.Parse(MoreNews.Newsother()), language, Menu_ID);
                    if (dt.Count > 0)
                    {
                        rpitems.DataSource = dt;
                        rpitems.DataBind();
                    }
                    else
                    {
                        rpitems.Visible = false;
                    }
                    dt = SMNews.NEWS_OTHERFIRST(ID, int.Parse(MoreNews.Newsother()), language, Menu_ID);
                    if (dt.Count > 0)
                    {
                        rpitems2.DataSource = dt;
                        rpitems2.DataBind();
                    }
                    else
                    {
                        rpitems2.Visible = false;
                    }
                }
                if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.ID))
                {
                    SMNews.UPDATE_VIEW_TIME(this.ID);
                    MoreAll.MoreAll.SetCookie("views", this.ID);
                }
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}