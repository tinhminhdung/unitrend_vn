using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.SiteMap
{
    public partial class Sitemap : System.Web.UI.UserControl
    {
        protected string app = "";
        private string language = Captionlanguage.Language;


        private void load()
        {
            List<Entity.Menu> table = SMenu.CATE_LOADALL_NEWS(More.SM, language, "-1");
            if (table.Count > 0)
            {
                this.rpitems.DataSource = table;
                this.rpitems.DataBind();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.app = MoreAll.MoreAll.GetParamValue("u");
            if (!base.IsPostBack)
            {
                this.load();
            }
        }

        protected string sub(string cid, string type, string Link, string cssa, string target)
        {
            string app = "";
            string str2 = "";
            if (type.Equals("0"))
            {
                if (Link.IndexOf("news") > -1)
                {
                    app = More.NS;
                }
                if (Link.IndexOf("info") > -1)
                {
                    app = More.MN;
                }
                if (Link.IndexOf("shop") > -1)
                {
                    app = More.PR;
                }
                if (Link.IndexOf("videos") > -1)
                {
                    app = More.VD;
                }
                if (Link.IndexOf("photos") > -1)
                {
                    app = More.AB;
                }
                List<Entity.Menu> table = SMenu.capp_Lang_ID_Status(app, language, "-1", "1");
                if (table.Count <= 0)
                {
                    return str2;
                }
                str2 = str2 + "<ul>";
                for (int j = 0; j < table.Count; j++)
                {
                    string str3 = str2 + "<li>";
                    str2 = str3 + "<a target='" + target + "' href='" + this.link(table[j].ID.ToString(), table[j].Name.ToString(), type, Link) + "' class='" + cssa + "'>" + table[j].Name.ToString() + "</a>";
                    List<Entity.Menu> table2 = SMenu.capp_Lang_ID_Status(app, language, table[j].ID.ToString(), "1");
                    if (table.Count > 0)
                    {
                        str2 = str2 + "<ul>";
                        for (int k = 0; k < table2.Count; k++)
                        {
                            string str4 = str2;
                            str2 = str4 + "<li><a target='" + target + "' href='" + this.link(table2[k].ID.ToString(), table2[k].Name.ToString(), type, Link) + "' class='" + cssa + "1'>" + table2[k].Name.ToString() + "</a></li>";
                        }
                        str2 = str2 + "</ul>";
                    }
                    str2 = str2 + "</li>";
                }
                return (str2 + "</ul>");
            }
            if (!type.Equals("1"))
            {
                return str2;
            }
            List<Entity.Menu> table3 = SMenu.capp_Lang_ID_Status(More.SM, language, cid, "1");
            if (table3.Count <= 0)
            {
                return str2;
            }
            str2 = str2 + "<ul>";
            for (int i = 0; i < table3.Count; i++)
            {
                string str5 = str2 + "<li>";
                str2 = str5 + "<a target='" + target + "' href='" + this.link("", table3[i].Name.ToString(), type, table3[i].Link.ToString()) + "' class='" + cssa + "'>" + table3[i].Name.ToString() + "</a>";
                List<Entity.Menu> table4 = SMenu.capp_Lang_ID_Status(More.SM, language, table3[i].ID.ToString(), "1");
                if (table4.Count > 0)
                {
                    str2 = str2 + "<ul>";
                    for (int m = 0; m < table4.Count; m++)
                    {
                        string str6 = str2 + "<li>";
                        str2 = (str6 + "<a target='" + target + "' href='" + this.link(table4[m].ID.ToString(), table4[m].Name.ToString(), type, table4[m].Link.ToString()) + "' class='" + cssa + "'>" + table4[m].Name.ToString() + "</a>") + "</li>";
                    }
                    str2 = str2 + "</ul>";
                }
                str2 = str2 + "</li>";
            }
            return (str2 + "</ul>");
        }

        protected string link(string cid, string name, string type, string url)
        {
            string str = "";
            if (!cid.Equals(""))
            {
                str = "/" + cid + "/" + RewriteURL.GetRewriteURL(name);
            }
            else
            {
                str = "/homepage.aspx";
            }
            if (type.Equals("0"))
            {
                return (url + str);
            }
            return url;
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}