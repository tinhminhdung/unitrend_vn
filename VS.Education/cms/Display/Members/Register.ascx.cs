using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Framework;
using Services;
using Entity;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class Register : System.Web.UI.UserControl
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
                Bind_ddlCountry();
                ddlstate.Items.Add(new ListItem("--Chọn Quận / Huyện", "0"));
                ddlcity.Items.Add(new ListItem("--Chọn Phường / Xã", "0"));

                new DataTable();
                this.btnregister.Text = this.label("l_register");
                this.btncancel.Text = this.label("l_redo");
            }
        }
        protected void Bind_ddlCountry()
        {
            List<Entity.Tinhthanh> list = STinhthanh.LOAD_CATESPARENT_ID(More.TT, this.language, "-1", "1");
            ddlcountry.Items.Clear();
            ddlcountry.Items.Add(new ListItem("--Chọn Tỉnh / Thành Phố--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlcountry.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }
        protected void Bind_ddlState()
        {
            List<Entity.Tinhthanh> list = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='" + More.TT + "' and Lang='" + language + "'  and Parent_ID=" + ddlcountry.SelectedValue + "  and Status=1 order by Orders asc");
            ddlstate.Items.Clear();
            ddlstate.Items.Add(new ListItem("--Chọn Quận / Huyện--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlstate.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }
        protected void Bind_ddlCity()
        {
            List<Entity.Tinhthanh> list = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='" + More.TT + "' and Lang='" + language + "'  and Parent_ID=" + ddlstate.SelectedValue + "  and Status=1 order by Orders asc");
            ddlcity.Items.Clear();
            ddlcity.Items.Add(new ListItem("--Chọn Phường / Xã--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlcity.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }

        protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlState();
            // txt_add.Focus();
        }
        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bind_ddlCity();
            // txt_add.Focus();
        }
        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.txtemail.Text = "";
            this.txtlastname.Text = "";
            this.txt_add.Text = "";
            this.txt_phone.Text = "";
            this.ltmsg.Text = "";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Fusers item = new Fusers();
                if (item.DetailPhone(this.txt_phone.Text.Trim().ToLower()).Rows.Count > 0)
                {
                    this.ltmsg.Text = "Điện thoại đã được sử dụng bởi một t\x00e0i khoản kh\x00e1c";
                }
                else if (item.Detailemail(this.txtemail.Text.Trim().ToLower()).Rows.Count > 0)
                {
                    this.ltmsg.Text = "Email đã được sử dụng bởi một t\x00e0i khoản kh\x00e1c";
                }
                else
                {
                    string validatekey = DateTime.Now.Ticks.ToString();
                    Entity.users obj = new Entity.users();
                    obj.vuserun = this.txt_phone.Text.Trim();
                    obj.vuserpwd = this.txtpassword.Text;
                    obj.vfname = this.txtlastname.Text;
                    obj.vlname = this.txtlastname.Text;
                    obj.igender = 0;// ddlgioithinh.SelectedValue;
                    obj.dbirthday = DateTime.Now;// txtngaysinh.Text;
                    obj.vidcard = "0";
                    obj.vaddress = this.txt_add.Text;
                    obj.vphone = this.txt_phone.Text.Trim();
                    obj.vemail = this.txtemail.Text.Trim().ToLower();
                    obj.iregionid = 0;
                    obj.vavatar = "";//vimg.Replace("/Uploads/pic/avatar/", "");
                    obj.vavatartitle = "";
                    obj.dcreatedate = DateTime.Now;
                    obj.dlastvisited = DateTime.Now;
                    obj.vvalidatekey = validatekey;
                    obj.istatus = int.Parse("1");
                    obj.lang = language;

                    obj.Thanhpho = ddlcountry.SelectedValue;
                    obj.Quanhuyen = ddlstate.SelectedValue;
                    obj.Phuongxa = ddlcity.SelectedValue;

                    obj.Tencongty = txttencongty.Text;
                    obj.Diachicongty = txtdiachicongty.Text;
                    obj.Dienthoaicongty = txtdiachicongty.Text;
                    obj.Masothuecongty = txtmasothuecongty.Text;

                    Susers.INSERT(obj);
                    this.MultiView1.ActiveViewIndex = 1;
                }
            }
            catch (Exception) { }
        }
        protected bool checkspace(string text)
        {
            string[] arrtxt = text.Split(' ');
            if (arrtxt.Count() > 1)
            {
                return true;
            }
            return false;
        }
        public bool ContainsUnicodeCharacter(string input)
        {
            const int MaxAnsiCode = 255;
            return input.Any(c => c > MaxAnsiCode);
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}