using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Videos
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
            }
        }

        protected string VideoTabVideo()
        {
            string str = "";
            List<Entity.VideoClip> dt = SVideoClip.Name_Text("SELECT top 1 * FROM VideoClip WHERE lang='" + language + "' AND Status=1 order by Create_Date desc");
            if (dt.Count > 0)
            {
                foreach (var item in dt)
                {
                    str += "<iframe id=\"main-video\"  src=\"https://www.youtube.com/embed/" + item.Contents + "\" frameborder=\"0\" allowfullscreen></iframe>";
                    str += " <div class=\"video-details\">";
                    str += " <p class=\"video-title\">" + item.Title + "</p>";
                    str += " <p class=\"video-description\">" + item.Brief + "</p>";
                    str += " </div>";
                }
            }
            return str;
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}