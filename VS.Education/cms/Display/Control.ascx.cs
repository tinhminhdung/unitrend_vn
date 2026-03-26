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
    public partial class Control : System.Web.UI.UserControl
    {
        #region string
        private string language = Captionlanguage.Language;
        #endregion
        string hp = "";
        string ipid = "0";
        int iEmptyIndex = 0;
        public string Case = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DatalinqDataContext db = new DatalinqDataContext();
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
            if (Request["ipid"] != null && !Request["ipid"].Equals(""))
            {
                ipid = Request["ipid"].ToString();
            }
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

            try
            {
                if (Request["e"] != null)
                {
                    string chuoi = "";
                    try
                    {
                        List<Entity.Products> dt = SProducts.Name_Text("SELECT * FROM [Products]  where ipid= " + ipid + "");
                        if (dt.Count > 0)
                        {
                            Case = "21";
                            chuoi = "21";
                        }
                    }
                    catch (Exception)
                    {}
                    if(chuoi!="21")
                    {
                        if (Request["e"].ToString() == "load")
                        {
                            Case = MoreAll.Other.RequestMenu(Request["hp"]);
                        }
                    }    
                  
                }
                //if (Request["e"] != null)
                //{
                //    if (Request["e"].ToString() == "load")
                //    {

                //        var Giatri1 = db.Menus.Where(s => s.TangName == Request["hp"].ToString()).ToList();
                //        var Giatri2 = db.Menus.Where(s => s.TangName == Giatri1[0].TangName).FirstOrDefault();
                //        if (Giatri1.Count > 0 || Giatri2 != null)
                //        {
                //            Case = Giatri1 != null ? Giatri2.Module.ToString() : Giatri1[0].Module.ToString();
                //        }
                //    }
                //}
            }
            catch (Exception)
            { 
                //Response.Redirect("/page-404.html");
            }

        }

        protected string MenuPro()
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, "-1", "1");
            if (dt.Count > 0)
            {
                foreach (Entity.Menu item in dt)
                {
                    string img = "";
                    if (item.Images.ToString().Length > 0)
                    {
                        img += "<img src=\"" + item.Images.ToString() + "\" alt=\"" + item.Name.ToString() + "\">&nbsp;&nbsp;";
                    }
                    //if (More.TangNameicid(hp) == item.ID.ToString())
                    //{
                    //    str += "<li><a class=\"active\" href='" + item.TangName.ToString() + ".html'>" + img + "<span class=\"mc_title\">" + item.Name.ToString() + "<i class=\"fa fa-chevron-right hidden-md\"></i></span></a>" + Menu_Pro(item.ID.ToString()) + "<div class=\"clear\"></div></li>";
                    //}
                    //else
                    //{
                    str += "<li><a  href='" + item.TangName.ToString() + ".html'>" + img + "<span class=\"mc_title\">" + item.Name.ToString() + "<i class=\"fa fa-chevron-right hidden-md\"></i></span></a>" + Menu_Pro(item.ID.ToString()) + "<div class=\"clear\"></div></li>";
                    //}
                }
            }
            return str.ToString();
        }
        protected string Menu_Pro(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    string img = "";
                    if (item.Images.ToString().Length > 0)
                    {
                        img += "<img src=\"" + item.Images.ToString() + "\" alt=\"" + item.Name.ToString() + "\">&nbsp;&nbsp;";
                    }
                    str += "<li><a  href='" + item.TangName.ToString() + ".html'>" + img + "<span class=\"mc_title\">" + item.Name.ToString() + "<i class=\"fa fa-chevron-right hidden-md\"></i></span></a>" + Menu_Pro(item.ID.ToString()) + "<div class=\"clear\"></div></li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string Menu_Pro3(string id)
        {
            string str = "";
            List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.PR, language, id, "1");
            if (dt.Count > 0)
            {
                str += "<ul>";
                foreach (Entity.Menu item in dt)
                {
                    str += "<li><a href='" + item.TangName.ToString() + ".html'>" + item.Name.ToString() + "</a>" + Menu_Pro(item.ID.ToString()) + "</li>";
                }
                str += "</ul>";
            }
            return str.ToString();
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}