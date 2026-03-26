using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Download
{
    public partial class Detail : System.Web.UI.UserControl
    {
        #region string
        string did = "-1";
        private string language = Captionlanguage.Language;
        #endregion
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
                #region Detail_ID
                List<Entity.Download> dt = SDownload.Name_Text("SELECT * FROM [Download]  where TangName=N'" + hp + "'");
                if (dt.Count > 0)
                {
                    lttitle.Text = dt[0].Title.ToString();
                    ltdesc.Text = dt[0].Brief.ToString();
                    ltcontent.Text = dt[0].Contents.ToString();
                    lttaifile.Text = "<a target=_blank href=\"/cms/display/Download/Defaul.aspx?id=" + dt[0].ID.ToString() + "\">Tải file</a>";
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