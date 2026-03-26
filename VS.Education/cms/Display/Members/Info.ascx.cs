using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Framework;
using MoreAll;
using Services;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class Info : System.Web.UI.UserControl
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
            if (!base.IsPostBack)
            {
                try
                {
                    this.loadinformation();
                }
                catch (Exception) { }
            }
            string uid = "";
            string un = "";
            if (Request["uid"] != null && !Request["uid"].Equals(""))
            {
                uid = Request["uid"];
            }
            if (Request["un"] != null && !Request["un"].Equals(""))
            {
                un = Request["un"];
            }
        }
        public string Avatar(string img)
        {
            if (img.Trim().Length > 0)
            {
                return ("<img src='/Uploads/pic/avatar/" + img + "' class=admavatarimg>");
            }
            return "<img src='/Uploads/pic/avatar/no_avatar.png' class=admavatarimg>";
        }
        private void loadinformation()
        {
            try
            {
                if (MoreAll.MoreAll.GetCookies("Members").ToString() != null)
                {
                    Fusers item = new Fusers();
                    DataTable table = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
                    if (table.Rows.Count > 0)
                    {
                        this.ltnickname.Text = (table.Rows[0]["vuserun"].ToString());
                        this.ltlname.Text = table.Rows[0]["vfname"].ToString();
                        this.ltaddress.Text = table.Rows[0]["vaddress"].ToString();
                        this.ltemail.Text = table.Rows[0]["vemail"].ToString();
                        this.ltphone.Text = table.Rows[0]["vphone"].ToString();
                       // this.ltimg.Text = Avatar(table.Rows[0]["vavatar"].ToString());

                        try
                        {
                            ltdiachithanhpho.Text = Name_TT(table.Rows[0]["Thanhpho"].ToString());
                            ltquanhuyen.Text = Name_TT(table.Rows[0]["Quanhuyen"].ToString());
                            ltphuongxa.Text = Name_TT(table.Rows[0]["Phuongxa"].ToString());
                        }
                        catch (Exception)
                        { }

                    }
                }
            }
            catch (Exception)
            { }
        }
        public string Name_TT(string id)
        {
            string str = "";
            try
            {
                var db = STinhthanh.Detail(id);
                str = db[0].Name;
            }
            catch (Exception)
            { }
            return str;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}