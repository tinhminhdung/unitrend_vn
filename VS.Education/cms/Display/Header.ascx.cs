using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display
{
    public partial class Header : System.Web.UI.UserControl
    {
        string hp = "";
        int iEmptyIndex = 0;
        string nav = "";
        string Module = "";
        int _cid = -1;
        DatalinqDataContext db = new DatalinqDataContext();
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
            this.Page.Form.DefaultButton = lnksearch.UniqueID;
            if (!base.IsPostBack)
            {
                 this.txtkeyword1.Text = this.label("l_search") + "...";
                //this.txtkeyword.Text = this.label("l_search") + "...";
            }
            if (!base.IsPostBack)
            {


                if (Request["su"] != "Search")
                {
                    MoreAll.MoreAll.SetCookie("Search", "", 5000);
                    MoreAll.MoreAll.SetCookie("SearchDL", "", 5000);
                    this.txtkeyword1.Text = this.label("l_search") + "...";
                    // this.txtkeyword.Text = this.label("l_search") + "...";
                }
                else
                {
                    if (MoreAll.MoreAll.GetCookies("Search").ToString() != null)
                    {
                        this.txtkeyword1.Text = MoreAll.MoreAll.GetCookies("Search").ToString();
                        // this.txtkeyword.Text = MoreAll.MoreAll.GetCookies("Search").ToString();
                    }
                }


                #region Module
                try
                {
                    if (Request["e"] != null)
                    {
                        if (Request["e"].ToString() == "load")
                        {
                            Module = MoreAll.Other.RequestMenu(Request["hp"]);
                        }
                    }
                }
                catch (Exception)
                {
                    // Response.Redirect("/page-404.html");
                }
                #endregion

            }
        }
        protected void Text_Load(object sender, EventArgs e)
        {
            string str = this.label("l_search") + "...";
            ((TextBox)sender).Attributes["onfocus"] = "if (this.value=='" + str + "') this.value='';";
            ((TextBox)sender).Attributes["onblur"] = "if (this.value=='') this.value='" + str + "';";
        }
        protected void lnksearch_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("Search", txtkeyword.Text, 5000);
            Response.Redirect("/Search.html");
        }
        protected void lnksearch1_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("Search", txtkeyword1.Text, 5000);
            Response.Redirect("/Search.html");
        }

        protected void lnkchina_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["language"] = "CHI";
            base.Response.Redirect("/");
        }
        protected void lnkEnglish_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["language"] = "ENG";
            base.Response.Redirect("/");
        }
        protected void lnkVIE_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["language"] = "VIE";
            base.Response.Redirect("/");
        }
        protected string MenuNews()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Parent_ID=-1  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    if (item.Parent_ID == -1)
                    {
                        if (More.TangNameicid(hp) == item.ID.ToString())
                        {
                            str += "<li><a class=\"active\" href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + SupNews(item.ID.ToString()) + "</li>";
                        }
                        else
                        {
                            str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + SupNews(item.ID.ToString()) + "</li>";
                        }
                    }
                }
            }
            return str.ToString();
        }
        protected string SupNews(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.Name_Text("SELECT * FROM [Menu]  where capp='" + More.NS + "' and Lang='" + language + "'  and Parent_ID=" + id + "  and Status=1 order by Orders asc");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a></li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }

        protected string MenuPro()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status_v2(More.PR, language, "-1", "1");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    if (More.TangNameicid(hp) == item.ID.ToString())
                    {
                        str += "<li class='level1'><a class=\"active\" href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "<em class=\"open-close-1\"></em></a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                    }
                    else
                    {
                        str += "<li class='level1'><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "<em class=\"open-close-1\"></em></a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                    }
                }
            }
            return str.ToString();
        }
        protected string Menu_Pro(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status_v2(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul class='submenu1 sub03'>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li class='level2'><a href='/" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string MenuGioithieu()
        {
            string str = "";
            List<Entity.Gioithieu> dt = SGioithieu.GET_BY_ALL(language);
            if (dt.Count > 0)
            {
                foreach (Entity.Gioithieu item in dt)
                {
                    str += "<li><a href='/" + item.TangName.ToString() + ".html'>" + item.Title.ToString() + "</a></li>";
                }
            }
            return str.ToString();
        }
        protected string index()
        {
            if (Request["su"] == null && Module == "")
            {
                return "curent";
            }
            return "";
        }
        protected string sanpham()
        {
            if ((Module == "20") || Request["su"] == ("prd") || Module == "21" || Module == "22" || Request["su"] == ("Search"))
            {
                return "curent";
            }
            return "";
        }
        protected string contact()
        {
            if ((Request["su"] == "contact"))
            {
                return "curent";
            }
            return "";
        }
        protected string Hinhanh()
        {
            if ((Request["su"] == "ADetail"))
            {
                return "curent";
            }
            return "";
        }
        protected string News()
        {
            if ((Module == "1" || Module == "2") || (Request["su"] == "nws"))
            {
                return "curent";
            }
            return "";
        }
        protected void lnkthoat_Click(object sender, EventArgs e)
        {
            MoreAll.MoreAll.SetCookie("Members", "", -1);
            Response.Redirect("/");
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}