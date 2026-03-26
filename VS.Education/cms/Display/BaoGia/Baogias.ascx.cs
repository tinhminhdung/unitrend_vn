using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using Entity;
using MoreAll;
using System.IO;
using VS.E_Commerce.cms.Display.News;

namespace VS.E_Commerce.cms.Display.BaoGia
{
    public partial class Baogias : System.Web.UI.UserControl
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

            }
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }

        protected void btgui_Click(object sender, EventArgs e)
        {
            #region image
            string vimg = "";
            string path = "";
            if ((this.flimage.FileName.Trim().Length > 0) && (this.flimage.PostedFile.ContentLength > 0))
            {
                path = Path.GetFileName(this.flimage.PostedFile.FileName);
                string str6 = "";
                str6 = Path.GetExtension(path).ToLower();
                vimg = "/Uploads/pic/advs/" + DateTime.Now.Ticks.ToString() + str6;
                flimage.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg);
            }
            #endregion

            #region image
            string vimg2 = "";
            string path2 = "";
            if ((this.flimage2.FileName.Trim().Length > 0) && (this.flimage2.PostedFile.ContentLength > 0))
            {
                path2 = Path.GetFileName(this.flimage2.PostedFile.FileName);
                string str62 = "";
                str62 = Path.GetExtension(path2).ToLower();
                vimg2 = "/Uploads/pic/advs/" + DateTime.Now.Ticks.ToString() + str62;
                flimage2.PostedFile.SaveAs(AppDomain.CurrentDomain.BaseDirectory + vimg2);
            }
            #endregion

            if (LinkSP.Text == "" || TenKH.Text == "" || DiaChi.Text == "" || DienThoai.Text == "" || Email.Text == "" || ModelSP.Text == "")
            {
                ltmsg.Text = "Vui lòng điền đầy đủ thông tin.";
                return;
            }

            string mabagias = "BG/" + DateTime.Now.ToString("yyddmmhhss");
            #region Contacts
            Entity.BaoGia obj = new Entity.BaoGia();
            obj.vtitle = LinkSP.Text;
            obj.vname = TenKH.Text;
            obj.vaddress = DiaChi.Text;
            obj.vphone = DienThoai.Text;
            obj.vemail = Email.Text;
            obj.vcontent = ModelSP.Text;
            obj.File1 = vimg;
            obj.File2 = vimg2;
            obj.dcreatedate = DateTime.Now;
            obj.lang = language;
            obj.istatus = 0;
            obj.MaBaoGia = mabagias;
            if (SBaoGia.INSERT(obj) == true)
            {
                this.ltmsg.Text = "Gửi yêu cầu thành công.";
                lttenkhachhang.Text = TenKH.Text;
                ltMaBaoGia.Text = mabagias;


                MultiView1.ActiveViewIndex = 1;
            }
            #endregion
            this.LinkSP.Text = "";
            this.TenKH.Text = "";
            this.DiaChi.Text = "";
            this.DienThoai.Text = "";
            this.Email.Text = "";
            this.ModelSP.Text = "";
        }

        protected void btxoayeucau_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bao-gia.html");
        }
    }
}