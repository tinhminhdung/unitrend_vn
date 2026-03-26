using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using Entity;
using System.Data;

namespace VS.E_Commerce.cms.Display.CheckDonHang
{
    public partial class Listcart : System.Web.UI.UserControl
    {
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
            rdcuahang.Text = label("Thanhtoann1");
            rdATM.Text = label("Thanhtoann3");
            rdCOD.Text = label("Thanhtoann4");

            rdChuyennhanhATM.Text = label("Thanhtoann5");
            rdChuyenchamATM.Text = label("Thanhtoann6");

            rdChuyennhanhCOD.Text = label("Thanhtoann7");
            rdChuyenchamCOD.Text = label("Thanhtoann8");

            if (!base.IsPostBack)
            {
                ShowProducts();

            }
        }

        private void ShowProducts()
        {
            List<Entity.Carts> table = SCarts.Name_Text("select * from Carts  WHERE IDUser=" + MoreAll.MoreAll.GetCookies("IDUser").ToString() + " order by Create_Date desc");
            if (table.Count > 0)
            {
                rp_items.DataSource = table;
                rp_items.DataBind();
            }



        }
        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa đơn hàng này ?')";
        }

        protected void Pass_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('" + this.label("l_process") + "?')";
        }

        protected void rp_items_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string str = e.CommandName.Trim();
            string ID = e.CommandArgument.ToString();
            string str4 = str;
            if (str4 != null)
            {
                if (!(str4 == "Delete"))
                {
                    if (str4 == "Check")
                    {
                        List<Entity.CartDetail> strid = SCartDetail.Name_Text("select * from CartDetail where ID_Cart=" + ID + "  ");
                        if (strid.Count > 0)
                        {
                            for (int i = 0; i < strid.Count; i++)
                            {
                                List<Entity.Products> dt = SProducts.Name_Text("select * from Products where ipid=" + strid[i].ipid + "  ");
                                if (dt.Count > 0)
                                {
                                    for (int j = 0; j < dt.Count; j++)
                                    {
                                        if (dt[j].ipid.ToString() == strid[i].ipid.ToString())
                                        {
                                            double hientai = Convert.ToDouble(dt[j].Quantity.ToString());
                                            if (hientai.ToString().Length > 0)
                                            {
                                                double cu = Convert.ToDouble(strid[i].Quantity.ToString());
                                                double Tong = (cu - hientai);
                                                Tong = System.Math.Round(Tong, 0);
                                                SProducts.Name_Text("update products set Quantity=" + Tong.ToString().Replace("-", "") + " where ipid=" + strid[i].ipid.ToString() + " ");
                                            }
                                        }
                                    }
                                }
                            }

                        }
                        SCarts.UpdateStatus(ID, "1");

                    }
                    else if (str4 == "Chitiet")
                    {
                        hdgiohang.Value = e.CommandArgument.ToString();
                        List<Entity.Carts> st = SCarts.Name_Text("select * from Carts where ID=" + e.CommandArgument.ToString() + "  ");
                        if (st.Count > 0)
                        {
                            hdtinhthanh.Value = st[0].Tinhthanh.ToString();
                        }
                        showtrangthai(e.CommandArgument.ToString());
                        Loadcart(e.CommandArgument.ToString());
                        
                        this.MultiView1.ActiveViewIndex = 1;
                    }
                    //Chitiet
                    else if (str4 == "UnCheck")
                    {
                        SCarts.UpdateStatus(ID, "0");
                    }
                }
                else
                {
                    SCartDetail.Delete_by_CartID(e.CommandArgument.ToString());
                    SCarts.Carts_Delete(e.CommandArgument.ToString());
                }

            }
            this.ShowProducts();
        }

        protected void UnPass_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('" + this.label("l_cancel") + "?')";
        }

        protected bool Visible(string status)
        {
            if (status.Equals("1"))
            {
                return false;
            }
            return true;
        }

        protected bool Visible_(string status)
        {
            if (status.Equals("0"))
            {
                return false;
            }
            return true;
        }
        void Loadcart(string id)
        {
            List<CartDetail> table = SCartDetail.Detail_ID_Cart(id);
            if (table.Count > 0)
            {
                this.rpcartdetail.DataSource = table;
                this.rpcartdetail.DataBind();
            }
            show();
        }
        protected void ItemDataBound_RP(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemIndex != -1) && (e.Item.ItemType != ListItemType.Separator))
            {
                Label lb_tt = (Label)e.Item.FindControl("lb_tt");
                lb_tt.Text = (e.Item.ItemIndex + 1).ToString();
            }
        }
        protected string Soluong(string id)
        {
            string totalvnd = "0";
            List<Entity.CartDetail> cartdetail = SCartDetail.Detail_ID_Cart(id);
            if (cartdetail.Count > 0)
            {
                if (cartdetail.Count > 0)
                {
                    double num = 0.0;
                    for (int i = 0; i < cartdetail.Count; i++)
                    {
                        num += Convert.ToDouble(cartdetail[i].Quantity.ToString());
                    }
                    totalvnd = num.ToString();
                }
            }
            return totalvnd;
        }

        protected string CreateDate(string id)
        {
            string str = "";
            List<Entity.Carts> dt = SCarts.Carts_GetById(id);
            if (dt.Count > 0)
            {
                str += MoreAll.MoreAll.FormatDate(dt[0].Create_Date.ToString());
            }
            return str.ToString();
        }
        protected string Quantity(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Quantity.ToString();
            }
            return str.ToString();
        }
        protected string Code(string id)
        {
            string str = "";
            List<Entity.CartDetail> dt1 = SCartDetail.GetDetail(id);
            if (dt1.Count > 0)
            {
                List<Entity.Products> dt = SProducts.GetById(dt1[0].ipid.ToString());
                if (dt.Count > 0)
                {
                    str += dt[0].Code.ToString();
                }
            }
            return str.ToString();
        }
        protected string Price(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += MoreAll.MorePro.FormatMoney(dt[0].Price.ToString());
            }
            return str.ToString();
        }

        protected string Images(string id)
        {
            string str = "";
            List<Entity.CartDetail> dt1 = SCartDetail.GetDetail(id);
            if (dt1.Count > 0)
            {
                List<Entity.Products> dt = SProducts.GetById(dt1[0].ipid.ToString());
                if (dt.Count > 0)
                {
                    str += "<img src='" + dt[0].ImagesSmall.ToString() + "' style='width: 50px; height: auto;' />";
                }
            }
            return str.ToString();
        }
        protected string Name(string id)
        {
            string str = "";
            List<Entity.CartDetail> dt1 = SCartDetail.GetDetail(id);
            if (dt1.Count > 0)
            {
                List<Entity.Products> dt = SProducts.GetById(dt1[0].ipid.ToString());
                if (dt.Count > 0)
                {
                    str += "<a  target=_blank href='/" + dt[0].TangName + ".html'>" + dt[0].Name.ToString() + "</a>";
                }

            }
            return str.ToString();
        }
        public string Status(string enable)
        {
            List<Entity.Carts> dt = SCarts.Name_Text("select * from Carts  WHERE ID=" + enable + "");
            if (dt.Count > 0)
            {
                if (dt[0].Status.ToString().Equals("0"))
                {
                    return "<b style=\"color:#fd7603\">Chưa duyệt</b>";
                }
                return "<b style=\"color:Red\">Đã duyệt</b>";
            }
            return "";
        }
        protected void rpcartdetail_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "update":
                    try
                    {
                        List<Entity.CartDetail> tble = SCartDetail.Name_Text("select * from CartDetail  WHERE ID=" + e.CommandArgument.ToString() + "");
                        if (tble.Count > 0)
                        {
                            List<Entity.Products> dtdetail = SProducts.GetById(tble[0].ipid.ToString());
                            if (dtdetail.Count > 0)
                            {
                                TextBox Quantity = (TextBox)e.Item.FindControl("txtxQuantity");
                                double Quantitys = Convert.ToDouble(Quantity.Text);
                                double Price = Convert.ToDouble(dtdetail[0].Price.ToString());
                                double Trongluong = Convert.ToDouble(dtdetail[0].Noidung2.ToString());
                                double Tong = (Quantitys * Price);
                                double Can = (Quantitys * Trongluong);
                                SCartDetail.Name_Text("update CartDetail set Money=" + Tong + ",Quantity=" + Quantitys + ",Trongluong=" + Can + " where id=" + e.CommandArgument.ToString() + "");
                                hdgiohang.Value = tble[0].ID_Cart.ToString();
                                List<Entity.Carts> st = SCarts.Name_Text("select * from Carts where ID=" + tble[0].ID_Cart.ToString() + "  ");
                                if (st.Count > 0)
                                {
                                    hdtinhthanh.Value = st[0].Tinhthanh.ToString();
                                }
                                
                                showtrangthai(tble[0].ID_Cart.ToString());
                                Loadcart(tble[0].ID_Cart.ToString());
                                
                            }
                            List<Entity.CartDetail> tbleg = SCartDetail.Name_Text("select * from CartDetail  WHERE ID_Cart=" + tble[0].ID_Cart.ToString() + "");
                            if (tbleg.Count > 0)
                            {
                                double submn = 0.0;
                                for (int i = 0; i < tbleg.Count; i++)
                                {
                                    submn += Convert.ToDouble(tbleg[i].Money.ToString());
                                }
                                SCarts.Name_Text("update Carts set Money=" + submn + ",Chietkhau=0 where id=" + tble[0].ID_Cart.ToString() + "");// + Chietkhau(submn.ToString()) + 
                            }
                        }
                    }
                    catch (Exception)
                    { }
                    break;
                case "delete":
                    try
                    {
                        List<Entity.CartDetail> sdt = SCartDetail.Name_Text("select * from CartDetail  WHERE ID=" + e.CommandArgument.ToString() + "");
                        if (sdt.Count > 0)
                        {
                            Session["CartDetail"] = sdt[0].ID_Cart.ToString();
                        }
                        SCartDetail.Name_Text("DELETE FROM [CartDetail]  where id=" + e.CommandArgument.ToString() + "");
                        List<Entity.CartDetail> item = SCartDetail.Name_Text("select * from CartDetail  WHERE ID_Cart=" + Session["CartDetail"].ToString() + "");
                        if (item.Count > 0)
                        {
                            double submn = 0.0;
                            for (int i = 0; i < item.Count; i++)
                            {
                                submn += Convert.ToDouble(item[i].Money.ToString());
                            }
                            SCarts.Name_Text("update Carts set Money=" + submn + ",Chietkhau=0 where id=" + Session["CartDetail"].ToString() + "");//" + Chietkhau(submn.ToString()) + "
                        }
                        else
                        {
                            SCarts.Name_Text("update Carts set Money=0,Chietkhau=0 where id=" + Session["CartDetail"].ToString() + "");
                        }
                        Session["CartDetail"] = null;
                        hdgiohang.Value = sdt[0].ID_Cart.ToString();
                        List<Entity.Carts> st = SCarts.Name_Text("select * from Carts where ID=" + sdt[0].ID_Cart.ToString() + "  ");
                        if (st.Count > 0)
                        {
                            hdtinhthanh.Value = st[0].Tinhthanh.ToString();
                        }
                        showtrangthai(sdt[0].ID_Cart.ToString());
                        Loadcart(sdt[0].ID_Cart.ToString());
                        
                    }
                    catch (Exception)
                    { }
                    break;
            }
        }
        protected void txtxQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox Quantity = (TextBox)sender;
            var b = (HiddenField)Quantity.FindControl("hiID");
            List<Entity.CartDetail> tble = SCartDetail.Name_Text("select * from CartDetail  WHERE ID=" + b.Value + "");
            if (tble.Count > 0)
            {
                List<Entity.Products> dtdetail = SProducts.GetById(tble[0].ipid.ToString());
                if (dtdetail.Count > 0)
                {
                    double Data1 = 0;
                    double Quantitys = Convert.ToDouble(Quantity.Text);
                    double Price = 0;
                    if (Quantitys.ToString().Length > 0)
                    {
                        Price += Convert.ToSingle(dtdetail[0].Price);
                    }
                    double Tong = (Quantitys * Price);
                    double Trongluong = Convert.ToDouble(dtdetail[0].Noidung2.ToString());
                    double Can = (Quantitys * Trongluong);

                    SCartDetail.Name_Text("update CartDetail set Money=" + Tong + ",Quantity=" + Quantitys + ",Trongluong=" + Can + "  where id=" + b.Value + "");


                    hdgiohang.Value = tble[0].ID_Cart.ToString();
                    List<Entity.Carts> st = SCarts.Name_Text("select * from Carts where ID=" + tble[0].ID_Cart.ToString() + "  ");
                    if (st.Count > 0)
                    {
                        hdtinhthanh.Value = st[0].Tinhthanh.ToString();
                    }
                    showtrangthai(tble[0].ID_Cart.ToString());
                    Loadcart(tble[0].ID_Cart.ToString());
                    show();

                }
                List<Entity.CartDetail> tbleg = SCartDetail.Name_Text("select * from CartDetail  WHERE ID_Cart=" + tble[0].ID_Cart.ToString() + "");
                if (tbleg.Count > 0)
                {
                    double submn = 0.0;
                    for (int i = 0; i < tbleg.Count; i++)
                    {
                        submn += Convert.ToDouble(tbleg[i].Money.ToString());
                    }
                    SCarts.Name_Text("update Carts set Money=" + submn + ",Chietkhau=0 where id=" + tble[0].ID_Cart.ToString() + "");// + Chietkhau(submn.ToString()) + 
                }
            }
        }
        protected bool Anhien(string enable)
        {
            List<Entity.Carts> dt = SCarts.Name_Text("select * from Carts  WHERE ID=" + enable + "");
            if (dt.Count > 0)
            {
                if (dt[0].Status.ToString().Equals("0"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        protected bool Anhien2(string enable)
        {
            List<Entity.Carts> dt = SCarts.Name_Text("select * from Carts  WHERE ID=" + enable + "");
            if (dt.Count > 0)
            {
                if (dt[0].Status.ToString().Equals("0"))
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        protected bool EnableUnLock(string enable)
        {
            List<Entity.Carts> dt = SCarts.Name_Text("select * from Carts  WHERE ID=" + enable + "");
            if (dt.Count > 0)
            {
                if (dt[0].Status.ToString().Equals("0"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }
        protected void rdATM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdATM.Checked == true)
            {
                PlATM.Visible = true;
                PlCODE.Visible = false;
                ShowthanhtoanATM();
            }
        }

        protected void rdChuyennhanhATM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdATM.Checked == true)
            {
                ShowthanhtoanATM();
            }
        }

        protected void rdChuyenchamATM_CheckedChanged(object sender, EventArgs e)
        {
            if (rdATM.Checked == true)
            {
                ShowthanhtoanATM();
            }
        }

        public void ShowthanhtoanATM()
        {
            double Soluong = 0.0;
            double Gram = Convert.ToInt32(lttrongluong.Text);
            double Phivanchuyen = 0;
            double num = int.Parse(hdtongtien.Value);
            if (rdChuyennhanhATM.Checked == true)
            {
                Phivanchuyen = Convert.ToDouble(ATMNhanh.Value);
            }
            else if (rdChuyenchamATM.Checked == true)
            {
                Phivanchuyen = Convert.ToDouble(ATMCham.Value);
            }
            Double Tongthanhtoan = num + Phivanchuyen;

            ltthanhtoan.Text = MorePro.FormatMoney_Cart_Total(Tongthanhtoan.ToString());
            Session["Tongthanhtoan"] = Tongthanhtoan.ToString();
            Capnhat();
        }

        protected void rdCOD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCOD.Checked == true)
            {
                PlCODE.Visible = true;
                PlATM.Visible = false;
                ShowthanhtoanCOD();
            }
        }

        protected void rdChuyennhanhCOD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCOD.Checked == true)
            {
                ShowthanhtoanCOD();
            }
        }

        protected void rdChuyenchamCOD_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCOD.Checked == true)
            {
                ShowthanhtoanCOD();
            }
        }
        public void ShowthanhtoanCOD()
        {
            string inumofproducts = "";
            string totalvnd = "";
            double Phivanchuyen = 0;
            double num = int.Parse(hdtongtien.Value);
            if (rdChuyennhanhCOD.Checked == true)
            {
                Phivanchuyen = Convert.ToDouble(CodeNhanh.Value);
            }
            else if (rdChuyenchamCOD.Checked == true)
            {
                Phivanchuyen = Convert.ToDouble(CodeCham.Value);
            }
            Double Tongthanhtoan = num + Phivanchuyen;
            ltthanhtoan.Text = MorePro.FormatMoney_Cart_Total(Tongthanhtoan.ToString());
            Session["Tongthanhtoan"] = Tongthanhtoan.ToString();
            Capnhat();
        }
        protected void rdcuahang_CheckedChanged(object sender, EventArgs e)
        {
            if (rdcuahang.Checked == true)
            {
                PlCODE.Visible = false;
                PlATM.Visible = false;
                Showthanhtoan();
            }
            else if (rdATM.Checked == true)
            {
                ShowthanhtoanATM();
            }
            else if (rdCOD.Checked == true)
            {
                ShowthanhtoanCOD();
            }
        }
        public void Showthanhtoan()
        {
            
            double Phivanchuyen = 0;
            double num1 = int.Parse(hdtongtien.Value);
            if (rdCOD.Checked == true)
            {
                if (rdChuyennhanhCOD.Checked == true)
                {
                    Phivanchuyen = Convert.ToDouble(CodeNhanh.Value);
                }
                else if (rdChuyenchamCOD.Checked == true)
                {
                    Phivanchuyen = Convert.ToDouble(CodeCham.Value);
                }
            }
            if (rdATM.Checked == true)
            {
                if (rdChuyennhanhATM.Checked == true)
                {
                    Phivanchuyen = Convert.ToDouble(ATMNhanh.Value);
                }
                else if (rdChuyenchamATM.Checked == true)
                {
                    Phivanchuyen = Convert.ToDouble(ATMCham.Value);
                }
            }
            Double Tongthanhtoan = num1 + Phivanchuyen;
            Session["Tongthanhtoan"] = Tongthanhtoan.ToString();
            ltthanhtoan.Text = MorePro.FormatMoney_Cart_Total(Tongthanhtoan.ToString());
            Capnhat();
        }

        void Showtien()
        {
            if (hdtinhthanh.Value != "")
            {
                List<Entity.Tinhthanh> dt = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh] WHERE Parent_ID =" + hdtinhthanh.Value + " and Name=N'" + ShowGram() + "'");
                if (dt.Count > 0)
                {
                    txtatmlnhanh.Text = MorePro.FormatMoney_Cart(ShowNhanhCham(Convert.ToInt32(dt[0].Noidung1))) + "đ";
                    ltatmlcham.Text = MorePro.FormatMoney_Cart(ShowNhanhCham(Convert.ToInt32(dt[0].Noidung2))) + "đ";
                    ltcodenhanh.Text = MorePro.FormatMoney_Cart(ShowNhanhCham(Convert.ToInt32(dt[0].Noidung3))) + "đ";
                    ltcodecham.Text = MorePro.FormatMoney_Cart(ShowNhanhCham(Convert.ToInt32(dt[0].Noidung4))) + "đ";

                    ATMNhanh.Value = ShowNhanhCham(Convert.ToInt32(dt[0].Noidung1));
                    ATMCham.Value = ShowNhanhCham(Convert.ToInt32(dt[0].Noidung2));
                    CodeNhanh.Value = ShowNhanhCham(Convert.ToInt32(dt[0].Noidung3));
                    CodeCham.Value = ShowNhanhCham(Convert.ToInt32(dt[0].Noidung4));
                }
                else
                {
                    txtatmlnhanh.Text = label("Giatrikhong");
                    ltatmlcham.Text = label("Giatrikhong");
                    ltcodenhanh.Text = label("Giatrikhong");
                    ltcodecham.Text = label("Giatrikhong");
                    ATMNhanh.Value = "0";
                    ATMCham.Value = "0";
                    CodeNhanh.Value = "0";
                    CodeCham.Value = "0";
                }
            }
        }

        public string ShowNhanhCham(Double Phivanchuyen)
        {
            double Tinh = 0;
            if (hdtongGram.Value != "")
            {
                double hientai = Convert.ToDouble(hdtongGram.Value);
                if (hientai >= 0 && hientai <= 50)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 50 && hientai <= 100)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 100 && hientai <= 250)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 250 && hientai <= 500)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 500 && hientai <= 1000)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 1000 && hientai <= 1500)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 1500 && hientai <= 2000)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 2000 && hientai <= 2500)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 2500 && hientai <= 3000)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 3000 && hientai <= 3500)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 3500 && hientai <= 4000)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 4000 && hientai <= 4500)
                {
                    Tinh = Phivanchuyen;
                }
                else if (hientai >= 4500 && hientai <= 5000)
                {
                    Tinh = Phivanchuyen;
                }
            }
            return Tinh.ToString();

        }
        public string ShowGram()
        {
            double Tinh = 0;
            if (hdtongGram.Value != "")
            {

                double hientai = Convert.ToDouble(hdtongGram.Value);
                if (hientai >= 0 && hientai <= 50)
                {
                    Tinh = 50;
                }
                else if (hientai >= 50 && hientai <= 100)
                {
                    Tinh = 100;
                }
                else if (hientai >= 100 && hientai <= 250)
                {
                    Tinh = 250;
                }
                else if (hientai >= 250 && hientai <= 500)
                {
                    Tinh = 500;
                }
                else if (hientai >= 500 && hientai <= 1000)
                {
                    Tinh = 1000;
                }
                else if (hientai >= 1000 && hientai <= 1500)
                {
                    Tinh = 1500;
                }
                else if (hientai >= 1500 && hientai <= 2000)
                {
                    Tinh = 2000;
                }
                else if (hientai >= 2000 && hientai <= 2500)
                {
                    Tinh = 2500;
                }
                else if (hientai >= 2500 && hientai <= 3000)
                {
                    Tinh = 3000;
                }
                else if (hientai >= 3000 && hientai <= 3500)
                {
                    Tinh = 3500;
                }
                else if (hientai >= 3500 && hientai <= 4000)
                {
                    Tinh = 4000;
                }
                else if (hientai >= 4000 && hientai <= 4500)
                {
                    Tinh = 4500;
                }
                else if (hientai >= 4500 && hientai <= 5000)
                {
                    Tinh = 5000;
                }
                else if (hientai >= 5000)
                {
                    Tinh = 1;
                }
            }
            return Tinh.ToString();
        }

        void showtrangthai(string id)
        {
           

            List<Entity.Carts> table = SCarts.Name_Text("select * from Carts where ID=" + id + "  ");
            if (table.Count > 0)
            {
                string chuoi2 = "";
                string hinhthuc = "0";
                string nhanhhaycham = "0";
                if (table[0].hinhthuc == 0)
                {
                    rdcuahang.Checked = true;
                }
                else if (table[0].hinhthuc == 1)
                {
                    rdATM.Checked = true;
                    PlATM.Visible = true;
                    PlCODE.Visible = false;
                    if (rdATM.Checked == true)
                    {
                        hinhthuc = "1";
                        if (table[0].nhanhhaycham == 0)
                        {
                            rdChuyennhanhATM.Checked = true;
                            if (rdChuyennhanhATM.Checked == true)
                            {
                                nhanhhaycham = "0";
                                chuoi2 += rdATM.Text + "-" + rdChuyennhanhATM.Text;
                            }
                        }
                        if (table[0].nhanhhaycham == 1)
                        {
                            rdChuyenchamATM.Checked = true;
                            if (rdChuyenchamATM.Checked == true)
                            {
                                nhanhhaycham = "1";
                                chuoi2 += rdATM.Text + "-" + rdChuyenchamATM.Text;
                            }
                        }
                    }
                }
                else if (table[0].hinhthuc == 2)
                {

                    rdCOD.Checked = true;
                    PlATM.Visible = false;
                    PlCODE.Visible = true;
                    if (rdCOD.Checked == true)
                    {
                        hinhthuc = "2";
                        if (table[0].nhanhhaycham == 0)
                        {
                            rdChuyennhanhCOD.Checked = true;
                            if (rdChuyennhanhCOD.Checked == true)
                            {
                                nhanhhaycham = "0";
                                chuoi2 += rdCOD.Text + "-" + rdChuyennhanhCOD.Text;
                            }
                        }
                        if (table[0].nhanhhaycham == 1)
                        {
                            rdChuyenchamCOD.Checked = true;
                            if (rdChuyenchamCOD.Checked == true)
                            {
                                nhanhhaycham = "1";
                                chuoi2 += rdCOD.Text + "-" + rdChuyenchamCOD.Text;
                            }
                        }
                    }
                }
            }

        }

        void show()
        {
            List<CartDetail> table1 = SCartDetail.Detail_ID_Cart(hdgiohang.Value);
            if (table1.Count > 0)
            {
                string inumofproducts = "";
                string totalvnd = "";
                string totalcan = "";
                if (table1.Count > 0)
                {
                    double num = 0.0;
                    int num2 = 0;
                    double can = 0.0;
                    for (int i = 0; i < table1.Count; i++)
                    {
                        num += Convert.ToDouble(table1[i].Money.ToString());
                        can += Convert.ToDouble(table1[i].Trongluong.ToString());
                        num2 += Convert.ToInt32(table1[i].Quantity.ToString());
                    }
                    totalvnd = num.ToString();
                    inumofproducts = num2.ToString();
                    totalcan = can.ToString();
                }
                hdtongtien.Value = totalvnd.ToString();
                this.ltTotalOrder.Text = MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
                this.lttrongluong.Text = totalcan.ToString();
                hdtongGram.Value = totalcan.ToString();
                Showthanhtoan();
                Showtien();
                Capnhat();
            }
        }
        void Capnhat()
        {
            List<CartDetail> table1 = SCartDetail.Detail_ID_Cart(hdgiohang.Value);
            if (table1.Count > 0)
            {
                string chuoi2 = "";
                string hinhthuc = "0";
                string nhanhhaycham = "0";
                if (rdcuahang.Checked == true)
                {
                    hinhthuc = "0";
                    chuoi2 += rdcuahang.Text;
                }
                else if (rdATM.Checked == true)
                {
                    hinhthuc = "1";
                    if (rdChuyennhanhATM.Checked == true)
                    {
                        nhanhhaycham = "0";
                        chuoi2 += rdATM.Text + "-" + rdChuyennhanhATM.Text;
                    }
                    else if (rdChuyenchamATM.Checked == true)
                    {
                        nhanhhaycham = "1";
                        chuoi2 += rdATM.Text + "-" + rdChuyenchamATM.Text;
                    }
                }
                else if (rdCOD.Checked == true)
                {
                    hinhthuc = "2";
                    if (rdChuyennhanhCOD.Checked == true)
                    {
                        nhanhhaycham = "0";
                        chuoi2 += rdCOD.Text + "-" + rdChuyennhanhCOD.Text;
                    }
                    else if (rdChuyenchamCOD.Checked == true)
                    {
                        nhanhhaycham = "1";
                        chuoi2 += rdCOD.Text + "-" + rdChuyenchamCOD.Text;
                    }
                }
                SCarts.Name_Text("update Carts set Money=" + ltthanhtoan.Text.Replace(",", "").Replace("đ", "").Replace("d", "") + ",TongTienthanhtoan='" + ltthanhtoan.Text + "',Tongtrongluong='" + lttrongluong.Text + "',hinhthuc=" + hinhthuc + ",nhanhhaycham=" + nhanhhaycham + " where id=" + table1[0].ID_Cart.ToString() + "");// + Chietkhau(submn.ToString()) + 
            }
        }
    }
}