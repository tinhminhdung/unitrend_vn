using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using System.Data;
using Framework;
using Entity;

namespace VS.E_Commerce.cms.Display
{
    public partial class Footer : System.Web.UI.UserControl
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
                tbEmailNewsletter.Attributes.Add("placeholder", label("Emailcb"));
                bttheodoi.Text = label("l_register");
                RequiredFieldValidator4.Text = label("Emailtb");


                List<Entity.Menu> dt = SMenu.capp_Lang_Parent_ID_Status(More.IF, language, "-1", "1");
                rpcates.DataSource = dt;
                rpcates.DataBind();
                this.ltfootercontent.Text = FooTer(language);
            }
        }
        protected List<Entity.Nfooter> FooterInCate(string icid)
        {
            return SNfooter.CATEGORY(More.Sub_Menu(More.IF, icid), language, "1");
        }
        protected void bttheodoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (SMarketing.Name_Text("select * from Marketing where Email='" + this.tbEmailNewsletter.Text.Trim().ToLower() + "'").Count > 0)
                {
                    Response.Write("<script> alert('" + label("emailtt") + "') </script>");
                    this.tbEmailNewsletter.Text = "";
                }
                else
                {
                    #region Marketing
                    Marketing ob = new Marketing();
                    ob.Name = "Kh\x00e1ch h\x00e0ng nhận th\x00f4ng b\x00e1o qua email";
                    ob.Email = tbEmailNewsletter.Text;
                    ob.Phone = "";
                    ob.Address = "";
                    ob.dcreatedate = DateTime.Now;
                    ob.istatus = 0;
                    if (SMarketing.INSERT(ob) == true)
                    {
                        Response.Write("<script> alert('" + label("thanhcontemail") + "') </script>");
                    }
                    #endregion
                    this.tbEmailNewsletter.Text = "";
                }
            }
            catch (Exception)
            { }

        }
        public static string FooTer(string language)
        {
            string Pages = "";
            List<Entity.Setting> str = SSetting.GETBYALL(language);
            if (str.Count >= 1)
            {
                foreach (Entity.Setting its in str)
                {
                    if (its.Properties == "FooTer")
                    {
                        Pages = its.Value;
                    }
                }
            }
            return Pages.ToString();
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}