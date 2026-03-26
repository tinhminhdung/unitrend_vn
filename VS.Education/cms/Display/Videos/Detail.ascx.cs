using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Display.Videos
{
    public partial class Detail : System.Web.UI.UserControl
    {
        #region string
        string cid = "-1";
        string iVideo = "-1";
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
            LoadItems();
            if (!IsPostBack)
            {

                #region Detail_VideoClip
                List<Entity.VideoClip> dt = SVideoClip.Name_Text("SELECT * FROM [VideoClip]  where TangName=N'" + hp + "'");
                if (dt.Count > 0)
                {
                    ltcatename.Text = More.Name(dt[0].Menu_ID.ToString());
                    iVideo = dt[0].ID.ToString();
                    string url = dt[0].Contents.ToString();
                    string FormattedUrl = MoreVideoClip.GetYouTubeID(url);
                    lttitle.Text = dt[0].Title.ToString();
                    string str = "";
                    #region LinkYoutube
                    if (dt[0].Contents.ToString().Length > 0)
                    {
                        try
                        {
                            ltcontent.Text = "<iframe width=\"" + MoreVideoClip.Width() + "\" height=\"" + MoreVideoClip.Height() + "\" src=\"https://www.youtube.com/embed/" + dt[0].Contents.ToString().Replace("http://youtu.be/", "") + "\" frameborder=\"0\" allowfullscreen></iframe>";
                        }
                        catch (Exception)
                        {
                        }
                    }

                    #endregion

                    //#region Other
                    //List<Entity.VideoClip> str1 = SVideoClip.NEWS_OTHER_FIRST(iVideo, int.Parse("7"), language);
                    //if (str1.Count > 0)
                    //{
                    //    rpcates.DataSource = str1;
                    //    rpcates.DataBind();
                    //}
                    //else
                    //{
                    //    rpcates.Visible = false;
                    //}
                    //List<Entity.VideoClip> str2 = SVideoClip.NEWS_OTHER_LAST(iVideo, int.Parse("7"), language);
                    //if (str2.Count > 0)
                    //{
                    //    rpcates.DataSource = str2;
                    //    rpcates.DataBind();
                    //}
                    //else
                    //{
                    //    rpcates.Visible = false;
                    //}
                    //#endregion

                    #region views
                    if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.iVideo))
                    {
                        SVideoClip.UPDATE_VIEWS_TIMES(this.iVideo);
                        MoreAll.MoreAll.SetCookie("views", this.iVideo);
                    }
                    #endregion
                    #region Facebook
                    if (MoreVideoClip.Videochiase().Equals("1"))
                    {
                        ltchiase.Text = "<div class='addthis_toolbox addthis_default_style '><a class='addthis_button_preferred_1'></a><a class='addthis_button_preferred_2'></a><a class='addthis_button_preferred_3'></a><a class='addthis_button_preferred_4'></a><a class='addthis_button_compact'></a><a class='addthis_counter addthis_bubble_style'></a></div><script type='text/javascript' src='http://s7.addthis.com/js/250/addthis_widget.js#pubid=xa-4e2a6c617ab55718'></script>";
                    }
                    #endregion
                }
                #endregion
            }
        }
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

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}

