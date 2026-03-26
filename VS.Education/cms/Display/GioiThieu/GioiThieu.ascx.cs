using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Display.GioiThieu
{
    public partial class GioiThieu : System.Web.UI.UserControl
    {
        #region string
        string tid = "-1";
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
            #endregion
            if (!IsPostBack)
            {
                #region MyRegion
                if (Request["hp"] == "1")
                {
                    List<Entity.Gioithieu> dt = SGioithieu.GET_BY_ALL(language);
                    if (dt.Count > 0)
                    {
                        ltcatename.Text = lttitle.Text = dt[0].Title;
                        ltdesc.Text = dt[0].Brief;
                        ltcontent.Text = dt[0].Contents;
                    }
                }
                else
                {
                    #region Detail_ID
                    List<Entity.Gioithieu> dt = SGioithieu.Name_Text("SELECT * FROM [Gioithieu]  where TangName=N'" + hp + "'");
                    if (dt.Count > 0)
                    {
                        tid = dt[0].ID.ToString();
                        ltcatename.Text = lttitle.Text = dt[0].Title;
                        ltdesc.Text = dt[0].Brief;
                        ltcontent.Text = dt[0].Contents;

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

                    }

                    #region views
                    if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.tid))
                    {
                        SGioithieu.UPDAE_VIEW_TIMES(this.tid);
                        MoreAll.MoreAll.SetCookie("views", this.tid);
                    }
                    #endregion
                    #region Facebook
                    if (MoreNews.Newschiase().Equals("1"))
                    {
                        ltchiase.Text = "<div class='addthis_toolbox addthis_default_style '><a class='addthis_button_preferred_1'></a><a class='addthis_button_preferred_2'></a><a class='addthis_button_preferred_3'></a><a class='addthis_button_preferred_4'></a><a class='addthis_button_compact'></a><a class='addthis_counter addthis_bubble_style'></a></div><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e2a6c617ab55718'></script>";
                    }
                    #endregion
                    #endregion
                }
                #endregion
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}