using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using Framework;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class Resetpassword : System.Web.UI.UserControl
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
            this.Page.Form.DefaultButton = btnresets.UniqueID;
            if (!IsPostBack)
            {
                RequiredFieldValidator8.Text = label("thanhvien4");
                RequiredFieldValidator4.Text = label("thanhvien3");
                btnresets.Text = label("thanhvien5");
                #region UpdatePanel
                this.Page.Form.Enctype = "multipart/form-data";
                ScriptManager.GetCurrent(Page).RegisterPostBackControl(btnresets);
                #endregion
            }
        }
        protected void btnregisters_Click(object sender, EventArgs e)
        {
            Fusers item = new Fusers();
            System.Threading.Thread.Sleep(1000);
            if (item.Detailemail(this.txtemail.Text.Trim().ToLower()).Rows.Count < 1)
            {
                this.ltmsg.Text = "Email của bạn không tồn tại trong hệ thống";
            }
            else
            {
                try
                {
                    string hash = DateTime.Now.Ticks.ToString();
                    item.Update_validatekey_byemail(this.txtemail.Text.Trim().ToLower(), hash);
                    string title = "";
                    string body = "";
                    title = "Cập nhật lại mật khẩu!";
                    body = ("C\x00e1m ơn bạn đ\x00e3 tham gia đăng k\x00fd tại website của chúng tôi!<br><br>") + "Vui l\x00f2ng nhấn v\x00e0o li\x00ean kết sau để thực hiện việc cập nhật mật khẩu.<br><br>";
                    string str4 = "http://" + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/xac-nhan/" + hash + "/password.aspx";
                    string str9 = body;
                    body = str9 + "<a href='" + str4 + "'  target='_blank'>" + str4 + "</a>";

                    string email = Email.email();
                    string password = Email.password();
                    int port = Convert.ToInt32(Email.port());
                    string host = Email.host();

                    System.Threading.Thread.Sleep(1000);

                    MailUtilities.SendMail("Cập nhật lại mật khẩu! ", email, password, this.txtemail.Text, host, Convert.ToInt32(port), title, body);
                    this.MultiView1.ActiveViewIndex = 1;
                    this.ltresult.Text = "Email x\x00e1c nhận đ\x00e3 được gởi đến t\x00e0i khoản Email của bạn. <br>Vui l\x00f2ng check Email để x\x00e1c nhận";
                }
                catch (Exception)
                {
                    this.ltresult.Text = "Có lỗi xảy ra khi gửi mail";
                }
            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}