using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using Entity;

namespace VS.E_Commerce.cms.Display.CheckDonHang
{
    public partial class Detail : System.Web.UI.UserControl
    {
        string ID_Cart = "";
        public int i = 1;
        private string lang = Captionlanguage.Language;
        DatalinqDataContext db = new DatalinqDataContext();
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
            if (HttpContext.Current.Request.QueryString["ID_Cart"] != null)
            {
                this.ID_Cart = HttpContext.Current.Request.QueryString["ID_Cart"].ToString();
            }
            if (!base.IsPostBack)
            {
                if (HttpContext.Current.Request.Cookies["IDUser"] != null)
                {
                    if (MoreAll.MoreAll.GetCookies("IDUser").ToString() != null)
                    {
                        List<Carts> tble = SCarts.Name_Text("select top 1 * from Carts  WHERE IDUser=" + MoreAll.MoreAll.GetCookies("IDUser").ToString() + " order by Create_Date desc");
                        if (tble.Count > 0)
                        {
                            this.Repeater1.DataSource = tble;
                            this.Repeater1.DataBind();
                        }
                        List<Carts> table1 = SCarts.Name_Text("select * from Carts  WHERE IDUser=" + MoreAll.MoreAll.GetCookies("IDUser").ToString() + "");
                        if (table1.Count > 0)
                        {
                            this.rpcart.DataSource = table1;
                            this.rpcart.DataBind();

                            lttongq.Text = lttong.Text = MoreAll.MorePro.Detail_Price(table1[0].Money.ToString());

                            string submn = "0";
                            for (int i = 0; i < table1.Count; i++)
                            {
                                submn = submn + "," + table1[i].ID.ToString();
                            }
                            List<CartDetail> table = SCartDetail.Name_Text("SELECT pc.*,p.Name as tensp,p.Images as anhsanpham,p.icid,p.Code FROM CartDetail AS pc left join products  as p ON pc.ipid = p.ipid WHERE pc.ID_Cart in (" + submn + ")");
                            if (table.Count > 0)
                            {
                                this.rpcartdetail.DataSource = table;
                                this.rpcartdetail.DataBind();
                            }
                        }
                        else lterr.Text = "<div style='color:Red; font-weight:bold; text-align:center; margin-bottom:10px; padding-top:10px'>There are currently no products to be purchased</div>";
                    }
                }
                else lterr.Text = "<div style='color:Red; font-weight:bold; text-align:center; margin-bottom:10px; padding-top:10px'>There are currently no products to be purchased</div>";
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected string Anh(string id)
        {
            string str = "";
            List<Entity.CartDetail> dt1 = SCartDetail.GetDetail(id);
            if (dt1.Count > 0)
            {
                List<Entity.Products> dt = SProducts.GetById(dt1[0].ipid.ToString());
                if (dt.Count > 0)
                {
                    str += MoreAll.MoreImage.Image_width_height(dt[0].ImagesSmall.ToString(), "70", "");
                }
            }
            return str.ToString();
        }
        protected string Ten(string id)
        {
            string str = "";
            List<Entity.CartDetail> dt1 = SCartDetail.GetDetail(id);
            if (dt1.Count > 0)
            {
                List<Entity.Products> dt = SProducts.GetById(dt1[0].ipid.ToString());
                if (dt.Count > 0)
                {
                    str += dt[0].Name.ToString();
                }
            }
            return str.ToString();
        }

        protected string Nhom(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].icid.ToString();
            }
            return str.ToString();
        }

    }
}