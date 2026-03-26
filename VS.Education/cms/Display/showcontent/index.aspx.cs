using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Entity;
using Services;

namespace VS.E_Commerce.cms.Display.showcontent
{
    public partial class index : System.Web.UI.Page
    {
        #region string
        private string idl = "-1";
        private string language = Captionlanguage.Language;
       
        
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
            if (Request["idl"] != null && !Request["idl"].Equals(""))
            {
                idl = Request["idl"];
            } 
            #endregion
            if (!base.IsPostBack)
            {
                #region onlyitems
                List<Entity.onlyitems> table = SOnlyitems.GET_BY_ID(idl);
                if (table.Count > 0)
                {
                    if (table[0].display.ToString().Equals("1"))
                    {
                        this.lttitle.Text = table[0].vtitle.ToString() + "<br><br>";
                        this.lttitle.Visible = true;
                    }
                    else
                    {
                        this.lttitle.Visible = false;
                    }
                    this.ltcontent.Text = table[0].vcontent.ToString();
                    this.Page.Title = table[0].vtitle.ToString() + "";
                } 
                #endregion
            }
        }
    }
}