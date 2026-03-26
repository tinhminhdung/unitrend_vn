using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MoreAll;
using System.Data;
using Services;
using Entity;
using Framwork;
using Framework;

namespace VS.E_Commerce.cms.Display.Products
{
    public partial class Cart : System.Web.UI.UserControl
    {
        private string language = Captionlanguage.Language;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (System.Web.HttpContext.Current.Session["language"] != null)
        //    {
        //        this.language = System.Web.HttpContext.Current.Session["language"].ToString();
        //    }
        //    else
        //    {
        //        System.Web.HttpContext.Current.Session["language"] = this.language;
        //        this.language = System.Web.HttpContext.Current.Session["language"].ToString();
        //    }
        //    if (!base.IsPostBack)
        //    {
        //        txtPhone.Attributes.Add("placeholder", label("sochinh"));
        //        txtPhone2.Attributes.Add("placeholder", label("sochinhdp"));
        //        txtAddress.Attributes.Add("placeholder", label("diahcus"));
        //        btnCancelOrder.Text = label("huydathang");
        //        _btctnew.Text = label("muahtem");
        //        btnSendOrder.Text = label("l_order");
        //        rdcuahang.Text = label("Thanhtoann1");
        //        rdATM.Text = label("Thanhtoann3");
        //        rdCOD.Text = label("Thanhtoann4");

        //        rdChuyennhanhATM.Text = label("Thanhtoann5");
        //        rdChuyenchamATM.Text = label("Thanhtoann6");

        //        rdChuyennhanhCOD.Text = label("Thanhtoann7");
        //        rdChuyenchamCOD.Text = label("Thanhtoann8");

        //        Bind_ddlCountry();

        //        ddlstate.Items.Add(new ListItem("--" + label("chonqh") + "--", "0"));
        //        //if (Session["ddlcountry"] != null)
        //        //{
        //        //    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlcountry, Session["ddlcountry"].ToString());
        //        //}
        //        //if (Session["ddlstate"] != null)
        //        //{
        //        //    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlstate, Session["ddlstate"].ToString());
        //        //}

        //        try
        //        {
        //            if (MoreAll.MoreAll.GetCookies("Members").ToString() != null)
        //            {
        //                Fusers item = new Fusers();
        //                DataTable table = item.Detail_IDLOGIN(MoreAll.MoreAll.GetCookies("IDUser").ToString());
        //                if (table.Rows.Count > 0)
        //                {
        //                    this.txtName.Text = table.Rows[0]["vfname"].ToString();
        //                    this.txtAddress.Text = table.Rows[0]["vaddress"].ToString();
        //                    this.txtEmail.Text = table.Rows[0]["vemail"].ToString();
        //                    this.txtPhone.Text = table.Rows[0]["vphone"].ToString();
        //                    this.hfiduser.Value = table.Rows[0]["iuser_id"].ToString();

        //                    try
        //                    {
        //                        Bind_ddlCountry();
        //                        ddlcountry.SelectedValue = table.Rows[0]["Thanhpho"].ToString();
        //                    }
        //                    catch (Exception)
        //                    { }

        //                    try
        //                    {
        //                        Bind_ddlState();
        //                        ddlstate.SelectedValue = table.Rows[0]["Quanhuyen"].ToString();
        //                    }
        //                    catch (Exception)
        //                    { }
        //                }
        //            }
        //        }
        //        catch (Exception)
        //        { }


        //        txtgiohang.Text = MoreAll.Other.GioHang();
        //        LoadCartOrder();
        //        if (rdcuahang.Checked == true)
        //        {
        //            Showthanhtoan();
        //        }
        //        if (MoreAll.MoreAll.GetCookies("Members").ToString() != null)
        //        {
        //            Fusers item = new Fusers();
        //            DataTable table = item.Detailvuserun(MoreAll.MoreAll.GetCookies("Members").ToString());
        //            if (table.Rows.Count > 0)
        //            {
        //                this.txtName.Text = table.Rows[0]["vfname"].ToString();
        //                this.txtAddress.Text = table.Rows[0]["vaddress"].ToString();
        //                this.txtEmail.Text = table.Rows[0]["vemail"].ToString();
        //                this.txtPhone.Text = table.Rows[0]["vphone"].ToString();
        //                this.hfiduser.Value = table.Rows[0]["iuser_id"].ToString();
        //            }
        //        }
        //        Showtien();
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["language"] != null)
            {
                language = Session["language"].ToString();
            }
            else
            {
                Session["language"] = language;
            }

            if (!IsPostBack)
            {
                // Label và placeholder
                txtPhone.Attributes.Add("placeholder", label("sochinh"));
                txtPhone2.Attributes.Add("placeholder", label("sochinhdp"));
                txtAddress.Attributes.Add("placeholder", label("diahcus"));
                btnCancelOrder.Text = label("huydathang");
                _btctnew.Text = label("muahtem");
                btnSendOrder.Text = label("l_order");

                // Bind tỉnh thành
                Bind_ddlCountry();
                // ddlstate.Items.Add(new ListItem("--" + label("chonqh") + "--", "0"));

                // Lấy dữ liệu người dùng từ Cookie
                try
                {
                    string memberCookie = MoreAll.MoreAll.GetCookies("Members");
                    string idUserCookie = MoreAll.MoreAll.GetCookies("IDUser");

                    if (!string.IsNullOrEmpty(idUserCookie))
                    {
                        var item = new Fusers();
                        DataTable table = item.Detail_IDLOGIN(idUserCookie);
                        if (table.Rows.Count > 0)
                        {
                            txtName.Text = table.Rows[0]["vfname"].ToString();
                            txtAddress.Text = table.Rows[0]["vaddress"].ToString();
                            txtEmail.Text = table.Rows[0]["vemail"].ToString();
                            txtPhone.Text = table.Rows[0]["vphone"].ToString();
                            hfiduser.Value = table.Rows[0]["iuser_id"].ToString();

                            // Set selected tỉnh thành
                            ddlcountry.SelectedValue = table.Rows[0]["Thanhpho"].ToString();
                            //Bind_ddlState(); // gọi sau khi đã set selectedValue
                            ddlstate.SelectedValue = table.Rows[0]["Quanhuyen"].ToString();
                        }
                    }

                    if (!string.IsNullOrEmpty(memberCookie))
                    {
                        var item = new Fusers();
                        DataTable table = item.Detailvuserun(memberCookie);
                        if (table.Rows.Count > 0)
                        {
                            txtName.Text = table.Rows[0]["vfname"].ToString();
                            txtAddress.Text = table.Rows[0]["vaddress"].ToString();
                            txtEmail.Text = table.Rows[0]["vemail"].ToString();
                            txtPhone.Text = table.Rows[0]["vphone"].ToString();
                            hfiduser.Value = table.Rows[0]["iuser_id"].ToString();
                        }
                    }
                }
                catch (Exception) { }

                // Cập nhật giao diện
                txtgiohang.Text = MoreAll.Other.GioHang();
                LoadCartOrder();
                if (rdcuahang.Checked) Showthanhtoan();
                
            }
        }

        protected void Bind_ddlCountry()
        {
            List<Entity.Tinhthanh> list = STinhthanh.LOAD_CATESPARENT_ID(More.TT, this.language, "-1", "1");
            ddlcountry.Items.Clear();
            ddlcountry.Items.Add(new ListItem("--" + label("chontp") + "--", "0"));
            for (int i = 0; i < list.Count; i++)
            {
                ddlcountry.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
            }
            list.Clear();
            list = null;
        }
        //protected void Bind_ddlState()
        //{
        //    List<Entity.Tinhthanh> list = STinhthanh.Name_Text("SELECT * FROM [Tinhthanh]  where capp='" + More.TT + "' and Lang='" + language + "'  and Parent_ID=" + ddlcountry.SelectedValue + "  and Status=1 order by Orders asc");
        //    ddlstate.Items.Clear();
        //    ddlstate.Items.Add(new ListItem("--" + label("chonqh") + "--", "0"));
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        ddlstate.Items.Add(new ListItem(list[i].Name, list[i].ID.ToString()));
        //    }
        //    list.Clear();
        //    list = null;
        //}
        //protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Bind_ddlState();
        //    //Showtien();
        //    //if (rdcuahang.Checked == true)
        //    //{
        //    //    Showthanhtoan();
        //    //}
        //    //else if (rdATM.Checked == true)
        //    //{
        //    //    ShowthanhtoanATM();
        //    //}
        //    //else if (rdCOD.Checked == true)
        //    //{
        //    //    ShowthanhtoanCOD();
        //    //}
        //    Session["ddlcountry"] = ddlcountry.SelectedValue;
        //    // Cập nhật lại panel state nếu cần
        //    UpdatePanelState.Update(); // Cập nhật thủ công khi dùng UpdateMode="Conditional"

        //}
        protected void ItemDataBound_RP(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemIndex != -1) && (e.Item.ItemType != ListItemType.Separator))
            {
                Label lb_tt = (Label)e.Item.FindControl("lb_tt");
                lb_tt.Text = (e.Item.ItemIndex + 1).ToString();
            }
        }
        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.language);
        }
        private void LoadCartOrder()
        {
            if (Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    Repeater2.DataSource = dtcart;
                    Repeater2.DataBind();
                    string inumofproducts = "";
                    string totalvnd = "";
                    string totalcan = "";
                    if (dtcart.Rows.Count > 0)
                    {
                        double num = 0.0;
                        int num2 = 0;
                        double can = 0.0;
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                            can += Convert.ToDouble(dtcart.Rows[i]["Tongsocan"].ToString());
                            num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                        }
                        totalvnd = num.ToString();
                        inumofproducts = num2.ToString();
                        totalcan = can.ToString();
                    }
                    hdtongtien.Value = totalvnd.ToString();
                    this.ltTotalOrder.Text = MorePro.FormatMoney_Cart_Total(totalvnd.ToString());
                    this.lttrongluong.Text = totalcan.ToString();
                    hdtongGram.Value = totalcan.ToString();

                    this.ltProdinCart.Text = inumofproducts;
                    float total = 0;
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        total += Convert.ToSingle(dtcart.Rows[i]["Money"]);
                    }

                    this.pnmessage.Visible = false;
                    this.pnOrder.Visible = true;
                }
                else
                {
                    this.pnOrder.Visible = false;
                    this.pnmessage.Visible = true;
                }
            }
            else
            {
                this.pnOrder.Visible = false;
                this.pnmessage.Visible = true;
            }
        }
        protected void lnkorder_Click(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Request.Cookies["Members"] != null)
            //{
            LoadCartOrder();
            Showthanhtoan();
            //}
            //else
            //{
            //    Response.Redirect("/Dang-nhap.aspx");
            //}
        }
        protected void lnkdeletecart_Click(object sender, EventArgs e)
        {
            Session["cart"] = null;
            base.Response.Redirect("/Message.html");
        }
        protected bool Test()
        {
            try
            {
                Double Tongtien = Convert.ToInt32(Session["Tongthanhtoan"].ToString());
                Double Gram = Convert.ToInt32(ShowGram());
                if (Tongtien == 0)
                {
                    //   lblMsg.Text = "Hiện giỏ hàng không có sản phẩm !"; return false;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + label("gh1") + "!');", true); return false;
                }
                else if (Tongtien <= 100000)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + label("gh2") + " !');", true); return false;
                    //  lblMsg.Text = " Trị giá đơn hàng tối thiểu lớn hơn 50.000 VNĐ !"; return false;
                }
                if (Gram == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + label("Tbrgam") + " !');", true); return false;
                    //  lblMsg.Text = " Trị giá đơn hàng tối thiểu lớn hơn 50.000 VNĐ !"; return false;
                }
            }
            catch (Exception)
            {
                Response.Redirect("/gio-hang.html");
            }
            return true;
        }
        protected void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (Test() == true)
            {
                if (this.txtName.Text.Length < 1)
                {
                    this.lblMsg.Text = label("ttdh1") + "!!!";
                }
                else if (this.txtAddress.Text.Length < 1)
                {
                    this.lblMsg.Text = label("ttdh2") + "!!!";
                }
                else if (this.txtPhone.Text.Length < 1)
                {
                    this.lblMsg.Text = label("ttdh3") + "!!!";
                }
                //else if (this.txtEmail.Text.Length < 1)
                //{
                //    this.lblMsg.Text = label("ttdh4") + "!!!";
                //}
                //else if (!ValidateUtilities.IsValidEmail(this.txtEmail.Text.Trim()))
                //{
                //    this.lblMsg.Text = label("ttdh5") + "!!!";
                //}
                else
                {
                    if (MorePro.SenEmailPro().Equals("1"))
                    {
                        try
                        {
                            Senmail();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    ThanhtoanGiohang();
                }
            }
        }
        protected void ThanhtoanGiohang()
        {
            // 1. them gio hang
            string inumofproducts = "0";
            string totalvnd = "0";
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            if (dtcart.Rows.Count > 0)
            {
                double num = 0.0;
                int num2 = 0;
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                    num2 += Convert.ToInt32(dtcart.Rows[i]["Quantity"].ToString());
                }
                totalvnd = num.ToString();
                inumofproducts = num2.ToString();
            }
            // 2. them chi tiet gio hang
            Carts obj = new Carts();
            #region MyRegion
            string chuoi = "";
            string chuoi1 = "";
            string chuoi2 = "";
            string hinhthuc = "0";
            string nhanhhaycham = "0";

            if (rdcuahang.Checked)
            {
                hinhthuc = "0";
                chuoi2 = rdcuahang.Text;
            }
            else if (rdATM.Checked)
            {
                chuoi2 = rdATM.Text;
            }
            else if (rdCOD.Checked)
            {
                chuoi2 = rdCOD.Text;
            }
            else if (rdCOD2.Checked)
            {
                chuoi2 = rdCOD2.Text;
            }


            obj.Name = this.txtName.Text.Trim();
            obj.Address = this.txtAddress.Text.Trim();
            obj.Phone = this.txtPhone.Text.Trim();
            obj.Email = this.txtEmail.Text.Trim();
            obj.Contents = this.txtnoidung.Text.Trim();
            obj.Create_Date = Convert.ToDateTime(DateTime.Now.ToString());
            obj.Money = int.Parse(totalvnd);
            obj.lang = language;
            obj.Status = 0;
            #endregion

            string cdate = DateTime.Now.ToString();
            string edate = DateTime.Now.AddYears(10).ToString();
            DateTime dcreatedate = Convert.ToDateTime(cdate.ToString());
            DateTime denddate = Convert.ToDateTime(edate.ToString());
            // denddate = dcreatedate.AddDays((double)Convert.ToInt32(MoreAll.Other.Giatri("xoadonhang")));
            string selectedStateId = hdnStateValue.Value;

            int cartid = FCarts.Insert(this.txtName.Text.Trim(), this.txtAddress.Text.Trim() + "/" + Name_TT(selectedStateId) + "/" + Name_TT(ddlcountry.SelectedValue), this.txtPhone.Text.Trim(), this.txtEmail.Text.Trim(), this.txtnoidung.Text.Trim(), denddate.ToString(), totalvnd, language, "0", hfiduser.Value, (totalvnd), chuoi1, chuoi2, txtPhone2.Text, lttrongluong.Text, ltthanhtoan.Text, ddlstate.SelectedValue, hinhthuc, nhanhhaycham);//Chietkhau(totalvnd)
            CartDetail oj = new CartDetail();
            if (Session["cart"] != null)
            {
                for (int i = 0; i < dtcart.Rows.Count; i++)
                {
                    #region MyRegion
                    oj.ID_Cart = int.Parse(cartid.ToString());
                    oj.ipid = int.Parse(dtcart.Rows[i]["PID"].ToString());
                    oj.Price = Convert.ToSingle(dtcart.Rows[i]["Price"].ToString());
                    oj.Quantity = int.Parse(dtcart.Rows[i]["Quantity"].ToString());
                    oj.Money = Convert.ToSingle(dtcart.Rows[i]["Money"].ToString());
                    oj.Ghichu = dtcart.Rows[i]["Ghichu"].ToString();
                    oj.Trongluong = dtcart.Rows[i]["Trongluong"].ToString();
                    oj.Trongluong = dtcart.Rows[i]["Trongluong"].ToString();
                    oj.Donvitinh = Donvitinh(dtcart.Rows[i]["PID"].ToString());
                    #endregion
                    SCartDetail.CartDetail_Insert(oj);
                }
            }

            System.Web.HttpContext.Current.Session["cart"] = null;
            base.Response.Redirect("/Ordersucess.html");
        }

        protected void Senmail()
        {
            string chuoi = "";
            string chuoi2 = "";
            if (rdcuahang.Checked == true)
            {
                chuoi2 += rdcuahang.Text;
            }
            else if (rdATM.Checked == true)
            {

                chuoi2 += rdATM.Text;
            }
            else if (rdCOD.Checked == true)
            {
                chuoi2 += rdCOD.Text;
            }

            System.Text.StringBuilder strb = new System.Text.StringBuilder();
            strb.AppendLine("<div style=\"width:100%; padding:10px; line-height:22px;\"> ");
            strb.AppendLine("<div style=\"font-size:18px;  font-weight:bold;text-align:center; color:#F00;text-decoration:underline;text-transform:uppercase;\">Thông tin đặt hàng</div> ");
            strb.AppendLine("<div style=\"font-weight:bold; color:#666; padding-top:10px; text-align:center;text-decoration:none;\"> Cảm ơn quý khách hàng đã đặt hàng tại Website: " + MoreAll.MoreAll.RequestUrl(Request.Url.Authority) + "/</div>");
            strb.AppendLine("<div style=\" color:#666; padding-top:10px\"> ");
            strb.AppendLine("<div style=\"font-size:14px; text-decoration:underline; font-weight:bold; padding-bottom:5px;text-transform:uppercase; text-decoration:underline;\">Thông tin khách hàng</div> ");
            strb.AppendLine(" <table cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%\"> ");
            strb.AppendLine(" <tr> ");
            strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;font-weight:bold; width:20%\">Họ tên khách hàng:</td> ");
            strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + this.txtName.Text.Trim() + "</td> ");
            strb.AppendLine("</tr> ");
            strb.AppendLine("<tr> ");
            strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; font-weight:bold;height:22px;\">Địa chỉ:</td>");
            strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + this.txtAddress.Text.Trim() + " / " + Name_TT(ddlstate.SelectedValue) + " / " + Name_TT(ddlcountry.SelectedValue) + "</td>");
            strb.AppendLine("</tr>");
            strb.AppendLine("<tr>");
            strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; font-weight:bold;height:22px;\">Điện thoại:</td>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + this.txtPhone.Text.Trim() + "</td>");
            strb.AppendLine("</tr>");
            strb.AppendLine(" <tr>");
            strb.AppendLine("  <td style=\"border-bottom:dotted 1px #d6d6d6;font-weight:bold; height:22px;\">Email:</td>");
            strb.AppendLine(" <td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\">" + this.txtEmail.Text.Trim() + "</td>");
            strb.AppendLine("</tr>");
            strb.AppendLine("<tr>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6;font-weight:bold; height:22px;\">Ngày Đặt hàng:</td>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\"> " + DateTime.Now + "</td>");
            strb.AppendLine("</tr>");
            strb.AppendLine("<tr>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6;font-weight:bold; height:22px;\">Nội dung:</td>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\"> " + this.txtnoidung.Text.Trim() + "</td>");
            strb.AppendLine("</tr>");
            strb.AppendLine("<tr>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6;font-weight:bold; height:22px;\">Phương thức thanh toán và vận chuyển:</td>");
            strb.AppendLine("<td style=\"border-bottom:dotted 1px #d6d6d6; height:22px;\"> " + chuoi2 + "</td>");
            strb.AppendLine("</tr>");

            strb.AppendLine("</table>");
            strb.AppendLine("<div style=\"font-size:14px; text-decoration:underline; font-weight:bold; padding-bottom:5px; padding-top:10px;\">Thông đặt hàng</div>");
            strb.AppendLine("<table cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border:solid 1px #d6d6d6\">");
            strb.AppendLine("<tr>");
            strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; background-color:#999;color:#FFF; height:22px;\">Tên</td>");
            strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; background-color:#999; color:#FFF; height:22px;\">Số lượng</td>");
            strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; background-color:#999; color:#FFF; height:22px;\">Giá</td>");
            strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; background-color:#999; color:#FFF; height:22px;\">Đơn Vị tính</td>");
            strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; background-color:#999; color:#FFF; height:22px;\">Trọng lượng</td>");
            strb.AppendLine(" <td align=\"center\" style=\"background-color:#999; color:#FFF; height:22px;\">Thành tiền</td>");
            strb.AppendLine("</tr>");
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)System.Web.HttpContext.Current.Session["cart"];
            if (Session["cart"] != null)
            {
                if (dtcart.Rows.Count > 0)
                {
                    for (int i = 0; i < dtcart.Rows.Count; i++)
                    {
                        strb.AppendLine("<tr>");
                        strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; color:black; height:22px;\">" + Name_Product(dtcart.Rows[i]["PID"].ToString(), i) + "</td>");
                        strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; color:black; height:22px;\">" + dtcart.Rows[i]["Quantity"].ToString() + "</td>");
                        strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; color:black; height:22px;\">" + MorePro.FormatMoney_Cart_Total(dtcart.Rows[i]["Price"].ToString()) + "</td>");
                        strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; color:black; height:22px;\">" + Donvitinh(dtcart.Rows[i]["PID"].ToString()) + "</td>");
                        strb.AppendLine(" <td align=\"center\" style=\"border-right:solid 1px #d6d6d6; color:black; height:22px;\">" + dtcart.Rows[i]["Trongluong"].ToString() + " Gram</td>");
                        strb.AppendLine(" <td align=\"center\" style=\"color:black; height:22px;\">" + MorePro.FormatMoney_Cart_Total(dtcart.Rows[i]["Money"].ToString()) + "</td>");
                        strb.AppendLine("</tr>");
                    }
                }
            }
            strb.AppendLine("</table>");
            strb.AppendLine("</div>");
            strb.AppendLine("</div>");

            strb.AppendLine("<div style=\"font-weight:bold; color:#eb1c24; padding-top:10px; text-align:left;text-decoration:none;\">Tổng tiền: " + ltTotalOrder.Text + "</div>");
            strb.AppendLine("<div style=\"font-weight:bold; color:#eb1c24; padding-top:10px; text-align:left;text-decoration:none;\">Tổng trọng lượng:  " + lttrongluong.Text + "</div>");
            strb.AppendLine("<div style=\"font-weight:bold; color:#eb1c24; padding-top:10px; text-align:left;text-decoration:none;\">Tổng tiền cần thanh toán:  " + ltthanhtoan.Text + "</div>");
            strb.AppendLine("<div style=\"font-weight:bold; color:#eb1c24; padding-top:10px; text-align:left;text-decoration:none;\">Lưu ý: (Tiền Hàng + Phí vận chuyển)</div>");

            string email = Email.email();
            string password = Email.password();
            int port = Convert.ToInt32(Email.port());
            string host = Email.host();
            try
            {
                MailUtilities.SendMail("Thông tin đặt hàng từ website:" + "/", email, password, txtEmail.Text, host, port, "Thông tin đặt hàng", strb.ToString());
            }
            catch (Exception)
            { }

            try
            {
                MailUtilities.SendMail("Thông tin đặt hàng từ website:" + "/", email, password, MorePro.emailpro(), host, port, "Thông tin đặt hàng", strb.ToString());
            }
            catch (Exception)
            { }
        }

        public string Name_Product(string pid, int i)
        {
            DataTable dt = new DataTable();
            SProducts.Detail_ID(dt, pid);
            return dt.Rows[0]["Name"].ToString();
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
        protected void btnEditCart_Click(object sender, EventArgs e)
        {
            this.pnOrder.Visible = false;
            this.pnmessage.Visible = false;
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('X\x00f3a sản phẩm n\x00e0y?')";
        }

        protected void Empty_Load(object sender, EventArgs e)
        {
            ((Button)sender).Attributes["onclick"] = "return confirm('Hủy bỏ giỏ h\x00e0ng?')";
        }

        //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    {
        //        DataTable dtcart = new DataTable();
        //        string str = e.CommandName.ToString();
        //        string pid = e.CommandArgument.ToString();
        //        string str3 = str;
        //        if (str3 != null)
        //        {
        //            if (str3 == "Giam")
        //            {
        //                if ((HttpContext.Current.Request.Form[pid] != null) && ValidateUtilities.IsValidInt(HttpContext.Current.Request.Form[pid].ToString().Trim()))
        //                {
        //                    dtcart = (DataTable)HttpContext.Current.Session["cart"];
        //                    SessionCarts.Cart_Updatequantity(ref dtcart, pid, HttpContext.Current.Request.Form[pid].ToString().Trim());
        //                    HttpContext.Current.Session["cart"] = dtcart;

        //                }
        //            }
        //            if (str3 == "delete")
        //            {
        //                dtcart = (DataTable)HttpContext.Current.Session["cart"];
        //                SessionCarts.ShoppingCart_RemoveProduct(e.CommandArgument.ToString());
        //                Response.Redirect("/gio-hang.html");
        //                HttpContext.Current.Session["cart"] = dtcart;

        //            }
        //            if (str3 == "update")
        //            {
        //                if ((HttpContext.Current.Request.Form[pid] != null) && ValidateUtilities.IsValidInt(HttpContext.Current.Request.Form[pid].ToString().Trim()))
        //                {
        //                    dtcart = (DataTable)HttpContext.Current.Session["cart"];
        //                    SessionCarts.Cart_Updatequantity(ref dtcart, pid, HttpContext.Current.Request.Form[pid].ToString().Trim());
        //                    HttpContext.Current.Session["cart"] = dtcart;

        //                }
        //            }
        //        }
        //        LoadCartOrder();
        //        Showthanhtoan();
        //    }
        //}

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string command = e.CommandName;
            string pid = e.CommandArgument.ToString();

            if (command == "delete")
            {
                SessionCarts.ShoppingCart_RemoveProduct(pid);
                Response.Redirect("/gio-hang.html");
                return; // Không cần xử lý tiếp
            }

            string newQtyStr = HttpContext.Current.Request.Form[pid];
            if (string.IsNullOrEmpty(newQtyStr) || !ValidateUtilities.IsValidInt(newQtyStr))
                return;

            DataTable dtcart = (DataTable)Session["cart"];
            string currentQtyStr = dtcart.Select("PID='" + pid + "'")[0]["Quantity"].ToString();

            // Không làm gì nếu số lượng không thay đổi
            if (newQtyStr == currentQtyStr)
                return;

            SessionCarts.Cart_Updatequantity(ref dtcart, pid, newQtyStr);
            Session["cart"] = dtcart;

            Response.Redirect("/gio-hang.html");
        }

        protected void txtxQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox Quantity = (TextBox)sender;
            var b = (HiddenField)Quantity.FindControl("hiID");
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)HttpContext.Current.Session["cart"];
            SessionCarts.Cart_Updatequantity(ref dtcart, b.Value, Quantity.Text);
            LoadCartOrder();
            Showthanhtoan();

        }
        protected void txtghichu_TextChanged(object sender, EventArgs e)
        {
            TextBox ghichu = (TextBox)sender;
            var b = (HiddenField)ghichu.FindControl("hiID");
            DataTable dtcart = new DataTable();
            dtcart = (DataTable)HttpContext.Current.Session["cart"];
            SessionCarts.Cart_UpdateGhichu(ref dtcart, b.Value, ghichu.Text);
            LoadCartOrder();
            Showthanhtoan();
        }

        protected void btnCancelOrder_Click(object sender, EventArgs e)
        {
            this.btndelete_Click(sender, e);
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            System.Web.HttpContext.Current.Session["cart"] = null;
            base.Response.Redirect("/Message.html");
        }

        protected void _btctnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }

        protected void btnext_Click(object sender, EventArgs e)
        {
            Response.Redirect("/");
        }
        protected string Code(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Code.ToString();
            }
            return str.ToString();
        }
        public string Tietkiem(string ID)
        {
            string Width = "";
            List<Entity.Products> str = SProducts.GetById(ID);
            if (str.Count >= 1)
            {
                if (str[0].Price.ToString() == "" || str[0].OldPrice.ToString() == "")
                {
                }
                else if (Convert.ToDouble(str[0].OldPrice.ToString()) > Convert.ToDouble(str[0].Price.ToString()))
                {
                    double cu = Convert.ToDouble(str[0].OldPrice.ToString());
                    double hientai = Convert.ToDouble(str[0].Price.ToString());
                    double Tong = (((cu - hientai)));
                    Tong = System.Math.Round(Tong, 0);
                    Width += MorePro.Detail_Price(Tong.ToString());
                }
            }
            return Width.ToString();
        }
        protected string Donvitinh(string id)
        {
            string str = "";
            List<Entity.Products> str1 = SProducts.GetById(id);
            if (str1.Count > 0)
            {
                str = str1[0].Noidung3.ToString();
            }
            return str.ToString();
        }
        protected string Trongluong(string id)
        {
            string str = "";
            List<Entity.Products> table = SProducts.GetById(id);
            if (table.Count > 0)
            {
                List<Entity.Menu> dt = SMenu.Detail(table[0].Noidung2);
                if (dt.Count > 0)
                {
                    str = dt[0].Name.ToString();
                }
            }
            return str.ToString();
        }

        protected void lnkprint_Click(object sender, EventArgs e)
        {
            string chuoi1 = "";
            string chuoi2 = "";
            if (rdcuahang.Checked == true)
            {
                chuoi2 += rdcuahang.Checked;
            }
            else if (rdATM.Checked == true)
            {
                chuoi2 += rdATM.Checked;
            }
            else if (rdCOD.Checked == true)
            {
                chuoi2 += rdCOD.Checked;
            }
            Session["Print"] = txtName.Text.Trim() + ";" + txtAddress.Text.Trim() + "/" + Name_TT(ddlstate.SelectedValue) + "/" + Name_TT(ddlcountry.SelectedValue) + ";" + txtPhone.Text.Trim() + ";" + txtEmail.Text.Trim() + ";" + txtnoidung.Text.Trim() + ";" + chuoi1 + ";" + chuoi2;
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('Time OutAlert'); window.location='" + Request.ApplicationPath + "/display/products/Cartdetail.aspx';", true);
            // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "alert('" + label("gh2") + " !');", true); return false; 
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.open('/cms/display/products/Cartdetail.aspx', '_blank');", true); return false; 
            Response.Write("<script type=\"text/javascript\">window.open('/cms/display/products/Cartdetail.aspx', '_blank');</script>");
            //Response.Redirect("/cms/display/products/Cartdetail.aspx");
        }

     
        public void Showthanhtoan()
        {
            if (Session["cart"] != null)
            {
                DataTable dtcart = (DataTable)Session["cart"];
                if (dtcart.Rows.Count > 0)
                {
                    double Phivanchuyen = 0;
                    double num = 0;
                    if (dtcart.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtcart.Rows.Count; i++)
                        {
                            num += Convert.ToDouble(dtcart.Rows[i]["money"].ToString());
                        }
                    }
                    if (rdCOD.Checked == true)
                    {
                    }
                    if (rdATM.Checked == true)
                    {
                    }
                    lttthanhtoan.Text = "";
                    Double Tongthanhtoan = num + Phivanchuyen;
                    Session["Tongthanhtoan"] = Tongthanhtoan.ToString();
                    ltthanhtoan.Text = MorePro.FormatMoney_Cart_Total(Tongthanhtoan.ToString());
                }
            }
        }




        public string ShowGram()
        {
            double Tinh = 0;
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
            return Tinh.ToString();
        }
    }
}