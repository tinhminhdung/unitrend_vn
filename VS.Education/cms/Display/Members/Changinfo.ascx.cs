using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Framework;
using System.IO;
using Services;

namespace VS.E_Commerce.cms.Display.Members
{
    public partial class Changinfo : System.Web.UI.UserControl
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
                btnsave.Text = label("login7");
                try
                {
                    this.loadinformation();
                    LoadInfo();
                }
                catch (Exception)
                { }
            }
        }
        private void loadinformation()
        {
            try
            {
                Fusers item = new Fusers();
                DataTable table = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
                if (table.Rows.Count > 0)
                {
                    hdid.Value = table.Rows[0]["iuser_id"].ToString();
                    this.txtname.Text = table.Rows[0]["vfname"].ToString();
                    this.txtname.Text = table.Rows[0]["vlname"].ToString();
                    this.txtaddress.Text = table.Rows[0]["vaddress"].ToString();
                    this.txtbirthday.Text = ((DateTime)table.Rows[0]["dbirthday"]).ToString("yyyy-MM-dd");
                    this.txtphone.Text = table.Rows[0]["vphone"].ToString();
                }
            }
            catch (Exception) { }
        }
        private void LoadInfo()
        {
            try
            {
                Fusers item = new Fusers();
                DataTable table = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
                if (table.Rows.Count > 0)
                {
                    if (table.Rows[0]["vavatar"].ToString().Length < 1)
                    {
                        this.ltimg.Text = "<img src='/Uploads/pic/avatar/no_avatar.png' class=admavatarimg>";
                    }
                    else
                    {
                        this.ltimg.Text = "<img src='/Uploads/pic/avatar/" + table.Rows[0]["vavatar"].ToString() + "' class=admavatarimg>";
                    }
                    this.hdimg.Value = table.Rows[0]["vavatar"].ToString();
                }
            }
            catch (Exception) { }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.flavatar.HasFile)
                {
                    if ((this.flavatar.PostedFile.ContentLength / 0x400) > 0x400)
                    {
                        this.ltmsg.Text = "Cập nhật với dung lượng 1 M";
                        return;
                    }
                    ServerInfoUtlitities utlitities = new ServerInfoUtlitities();
                    string extension = Path.GetExtension(Path.GetFileName(this.flavatar.PostedFile.FileName));
                    if (this.hdimg.Value.Length > 0)
                    {
                        try
                        {
                            File.Delete(utlitities.APPL_PHYSICAL_PATH + "/Uploads/pic/avatar/" + this.hdimg.Value);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    string str = DateTime.Now.Ticks.ToString() + extension;
                    this.hdimg.Value = str;
                    try
                    {
                        this.flavatar.PostedFile.SaveAs(utlitities.APPL_PHYSICAL_PATH + "/Uploads/pic/avatar/" + str);
                    }
                    catch (Exception)
                    {
                    }
                }
                if (MoreAll.MoreAll.GetCookies("Members").ToString() != null)
                {
                    Fusers item = new Fusers();
                    DataTable dts = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
                    if (dts.Rows.Count > 0)
                    {
                        Entity.users obj = new Entity.users();
                        obj.vuserun = dts.Rows[0]["vuserun"].ToString();
                        obj.vavatar = this.hdimg.Value;
                        obj.vavatartitle = "";
                        Susers.users_update_updateavatar(obj);
                    }
                }
                this.ltmsg.Text = "";
                Entity.users data = new Entity.users();
                data.iuser_id = int.Parse(hdid.Value);
                data.vuserun = MoreAll.MoreAll.GetCookies("Members").ToString();
                data.vfname = this.txtname.Text;
                data.vlname = this.txtname.Text;
                data.igender = int.Parse("0");
                data.dbirthday = Convert.ToDateTime(this.txtbirthday.Text);
                data.vaddress = this.txtaddress.Text;
                data.vphone = this.txtphone.Text;
                data.vavatartitle = "";
                Susers.users_update(data);
                ltmsg.Text = "Thông tin đã được thay đổi";
                LoadInfo();

            }
            catch (Exception)
            { }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
    }
}