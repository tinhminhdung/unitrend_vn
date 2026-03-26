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
    public partial class DCategory : System.Web.UI.UserControl
    {
        #region string
        string cid = "-1";
        private string language = Captionlanguage.Language;
        #endregion
        string hp = "";
        int iEmptyIndex = 0;
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

            #endregion
            if (!IsPostBack)
            {
                #region MyRegion

                try
                {
                    List<Entity.Menu> item = SMenu.GETBYID(More.TangNameicid(hp));
                    if (item.Count > 0)
                    {
                        ltcatename.Text = item[0].Name.ToString();
                    }
                }
                catch (Exception)
                { }
                #endregion
                #region Detail_ID
                List<Entity.News> dt = SNews.CATEGORY(More.Sub_Menu(More.NS, More.TangNameicid(hp)), language, "1");
                if (dt.Count > 0)
                {
                    string iid = dt[0].inid.ToString();
                    lttitle.Text = dt[0].Title.ToString();
                    ltdesc.Text = dt[0].Brief;
                    ltcontent.Text = dt[0].Contents.ToString();
                   // ltdate.Text = MoreAll.FormatDateTime.FormatDate(dt[0].Create_Date);
                    #region Facebook
                    if (Other.Facebook().Equals("1"))
                    {
                        ltFacebook.Text = "<div class='fb-like' data-href='" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "' data-send='true' data-width='450' data-show-faces='false'></div>";
                    }
                    if (Other.Facebook().Equals("2"))
                    {
                        ltFacebook.Text = "<div class='fb-like' data-href='" + MoreAll.MoreAll.RequestUrl(Request.Url.ToString()) + "' data-send='true' data-width='450' data-show-faces='true' data-font='arial'></div>";
                    }
                    #endregion
                    #region Other
                    dt = SNews.OTHERFIRST(iid, int.Parse(MoreNews.Newsother()), language, More.TangNameicid(hp));
                    if (dt.Count > 0)
                    {
                        rpitems.DataSource = dt;
                        rpitems.DataBind();
                    }
                    else
                    {
                        rpitems.Visible = false;
                    }
                    dt = SNews.OTHERLAST(iid, int.Parse(MoreNews.Newsother()), language, More.TangNameicid(hp));
                    if (dt.Count > 0)
                    {
                        rpitems2.DataSource = dt;
                        rpitems2.DataBind();
                    }
                    else
                    {
                        rpitems2.Visible = false;
                    }
                    #endregion
                }

                #region Facebook
                if (MoreNews.Newschiase().Equals("1"))
                {
                    ltchiase.Text = "<div class='addthis_toolbox addthis_default_style '><a class='addthis_button_preferred_1'></a><a class='addthis_button_preferred_2'></a><a class='addthis_button_preferred_3'></a><a class='addthis_button_preferred_4'></a><a class='addthis_button_compact'></a><a class='addthis_counter addthis_bubble_style'></a></div><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e2a6c617ab55718'></script>";
                }
                #endregion
                #endregion
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}