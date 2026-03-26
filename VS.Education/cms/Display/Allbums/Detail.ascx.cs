using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;

namespace VS.E_Commerce.cms.Display.Allbums
{
    public partial class Detail : System.Web.UI.UserControl
    {
        #region string
        string cid = "-1";
        string iphoto = "-1";
        private string language = Captionlanguage.Language;
        string hp = "";
        int iEmptyIndex = 0;
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
                List<Entity.Album> items = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName=N'" + hp + "'");
                if (items.Count > 0)
                {
                    ltcatename.Text = More.Name(items[0].Menu_ID.ToString());
                    iphoto = items[0].ID.ToString();
                    lttitle.Text = items[0].Title.ToString();

                    //List<Entity.Album_Images> str = SAlbum_Images.GET_DETAIL_BY_MENUALB(items[0].ID.ToString());
                    //RpMax.DataSource = str;
                    //RpMax.DataBind();

                    //RpMin.DataSource = str;
                    //RpMin.DataBind();

                    #region views
                    if (MoreAll.MoreAll.GetCookies("views").Equals("") || !MoreAll.MoreAll.GetCookies("views").Equals(this.iphoto))
                    {
                        SAlbum.Name_Text("update Album set Views=Views + 1 where ID=" + iphoto + "");
                        MoreAll.MoreAll.SetCookie("views", this.iphoto);
                    }
                    #endregion
                }
            }
        }
        public string ViewslideMax()
        {
            string bReturn = "";
            List<Entity.Album> dbPro = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName=N'" + hp + "'");
            if (dbPro.Count > 0)
            {
                string[] strArray = dbPro[0].Anhnhieu.ToString().Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    bReturn += "<li><img alt='" + dbPro[0].Title.ToString() + "' src=\"" + strArray[i].ToString() + "\"/></li>";
                }
            }
            return bReturn;
        }

        public string ViewslideMin()
        {
            string bReturn = "";
            List<Entity.Album> dbPro = SAlbum.Name_Text("SELECT * FROM [Album]  where TangName=N'" + hp + "'");
            if (dbPro.Count > 0)
            {
                string[] strArray = dbPro[0].Anhnhieu.ToString().Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    bReturn += "<li><img alt='" + dbPro[0].Title.ToString() + "' src=\"" + strArray[i].ToString().Replace("uploads", "uploads/_thumbs") + "\"/></li>";
                }
            }
            return bReturn;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}