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
using Framwork;
using FlexCel.XlsAdapter;
using FlexCel.Core;
using System.Web.Security;

namespace VS.E_Commerce.cms.Admin.ProductsCarts
{
    public partial class Cart : System.Web.UI.UserControl
    {
        private string status = "1";
        private string lang = Captionlanguage.Language;
        public string ShowXoa = "0";
        public string ShowHuy = "0";
        public string ShowDuyet = "0";
        public string ShowExel = "0";
        public string st = "";
        public string str = "";
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

            this.Page.Form.DefaultButton = btnshow.UniqueID;
            if (MoreAll.MoreAll.GetCookie("URole") != null)
            {
                string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                if (strArray.Length > 0)
                {
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        if (strArray[i].ToString().Equals("69"))
                        {
                            ShowHuy = "1";
                        }
                        if (strArray[i].ToString().Equals("70"))
                        {
                            ShowXoa = "1";
                        }
                        if (strArray[i].ToString().Equals("71"))
                        {
                            ShowExel = "1";
                        }
                        if (strArray[i].ToString().Equals("23"))
                        {
                            ShowDuyet = "1";
                        }
                    }
                }
            }


            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                ddlstatus.SelectedValue = Request["st"];
            }

            this.DropDownList3.Items.Clear();
            for (int i = 2015; i < (DateTime.Now.Year + 1); i++)
            {
                this.DropDownList3.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.DropDownList3, DateTime.Now.Year.ToString());

            if (Request["ngay"] != null && !Request["ngay"].Equals(""))
            {
                DropDownList1.SelectedValue = Request["ngay"];
            }
            //else
            //{
            //    DropDownList1.SelectedValue = MoreAll.MoreAll.Date_ngay(DateTime.Now);
            //}
            if (Request["thang"] != null && !Request["thang"].Equals(""))
            {
                DropDownList2.SelectedValue = Request["thang"];
            }
            //else
            //{
            //    DropDownList2.SelectedValue = ThangDate(DateTime.Now);
            //}
            if (Request["nam"] != null && !Request["nam"].Equals(""))
            {
                DropDownList3.SelectedValue = Request["nam"];
            }
            //else
            //{
            //    DropDownList3.SelectedValue = MoreAll.MoreAll.Date_ngay(DateTime.Now);
            //}



            if (Request["st"] != null && !Request["st"].Equals(""))
            {
                st = Request["st"].ToString();
            }

            str += " and year(Create_Date)=" + DropDownList3.SelectedValue + "";
            if (Request["thang"] != null && !Request["thang"].Equals("0"))
            {
                str += " and month(Create_Date)=" + Request["thang"] + "";
            }
            if (Request["ngay"] != null && !Request["ngay"].Equals("0"))
            {
                str += " and day(Create_Date)=" + Request["ngay"] + "";
            }

            this.btnshow.Text = this.label("lt_display");
            this.MultiView1.ActiveViewIndex = 0;

            if (!base.IsPostBack)
            {
                if (MoreAll.MoreAll.GetCookie("URole") != null)
                {
                    string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
                    if (strArray.Length > 0)
                    {
                        for (int i = 0; i < strArray.Length; i++)
                        {
                            if (strArray[i].ToString().Equals("68"))
                            {
                                this.ShowProducts();
                            }
                        }
                    }
                }

            }


        }
        public string ThangDate(object date)
        {
            return (Convert.ToDateTime(date).ToString("MM"));
        }
        private void ShowProducts()
        {
            //try
            //{

            // Literal1.Text = str;

            if (st == "" || st == "-1")
            {
                List<Carts> dt = SCarts.p_cartslist_countKO(str, txtkeyword.Text);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rp_items;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rp_items.DataSource = CollectionPager1.DataSourcePaged;
                rp_items.DataBind();
            }
            else
            {
                List<Carts> dt = SCarts.p_cartslist_count(str, ddlstatus.SelectedValue, txtkeyword.Text);
                CollectionPager1.DataSource = dt;
                CollectionPager1.BindToControl = rp_items;
                CollectionPager1.MaxPages = 10000;
                CollectionPager1.PageSize = 10;
                rp_items.DataSource = CollectionPager1.DataSourcePaged;
                rp_items.DataBind();
            }
            // }
            //  catch (Exception) { }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            this.MultiView1.ActiveViewIndex = 0;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            // try
            {
                if (this.txttitle.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn tiêu đề";
                }
                else if (this.txtTo.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn Email đến";
                }
                else if (!ValidateUtilities.IsValidEmail(this.txtTo.Text))
                {
                    this.lblmsg.Text = "Email không hợp lệ";
                }
                else if (this.txtContent.Text.Length < 1)
                {
                    this.lblmsg.Text = "Chèn nội dung";
                }
                else
                {
                    string email = Email.email();
                    string password = Email.password();
                    int port = Convert.ToInt32(Email.port());
                    string host = Email.host();
                    MailUtilities.SendMail(this.txttoname.Text.Trim(), email, password, this.txtTo.Text, host, port, this.txttitle.Text.Trim(), this.txtContent.Text.Trim());
                    this.MultiView1.ActiveViewIndex = 0;
                }
            }
            //catch (Exception)
            //{
            //    this.lblmsg.Text = "Hệ thống Email của bạn có thể chưa điền hoặc chưa điền đúng hoặc chưa đúng thông tài khoản Gmail mà chúng tôi yêu cầu";
            //}
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            this.ShowProducts();
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa đơn hàng này ?')";
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
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
                        try
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
                        }
                        catch (Exception)
                        { }
                        SCarts.UpdateStatus(ID, "1");
                    }
                    else if (str4 == "UnCheck")
                    {
                        SCarts.UpdateStatus(ID, "0");
                    }
                    else if (str4 == "SendMail")
                    {
                        List<Entity.CartDetail> table = new List<Entity.CartDetail>();
                        table = SCartDetail.Detail_ID_Cart(e.CommandArgument.ToString());
                        if (table.Count > 0)
                        {
                            List<Carts> table2 = SCarts.Carts_GetById(table[0].ID_Cart.ToString());
                            if (table2.Count > 0)
                            {
                                this.txtTo.Text = table2[0].Email.ToString();
                                this.txttoname.Text = table2[0].Name.ToString();
                                string str3 = ("Th\x00e2n ch\x00e0o bạn: " + this.txttoname.Text.Trim() + "<br>") + "Bạn c\x00f3 đặt h\x00e0ng tại c\x00f4ng ty của ch\x00fang t\x00f4i như sau: <br>";
                                DataTable table3 = new DataTable();
                                FCartDetail db = new FCartDetail();
                                db.CartDetail_List_Cart_Pro(table3, ID);
                                if (table3.Rows.Count > 0)
                                {
                                    string str5 = str3;
                                    str3 = str5 + "<table  border='0' width='100%' cellpadding='3' style='border-collapse: collapse' id='table1'><tr height='22' bgcolor='Gainsboro'><td>" + this.label("l_producttitle") + "&nbsp;</td><td align='right'>" + this.label("lprice") + "</td><td align='right'>" + this.label("lquantity") + "&nbsp;</td><td align='right'>" + this.label("l_tomoney") + "&nbsp;</td></tr>";
                                    for (int i = 0; i < table3.Rows.Count; i++)
                                    {
                                        string str6 = str3;
                                        str3 = str6 + "<tr height='22'><td>" + table3.Rows[i]["Name"].ToString() + "&nbsp;</td><td align='right' width='100'>" + MorePro.FormatMoney(table3.Rows[i]["Price"].ToString()) + "&nbsp;</td><td align='right' width='100'>" + table3.Rows[i]["Quantity"].ToString() + "&nbsp;</td><td align='right'  width='100'>" + MorePro.FormatMoney(table3.Rows[i]["Money"].ToString()) + "&nbsp;</td></tr>";
                                    }
                                    #region Tong Gia Tien
                                    string Tong = "0";
                                    if (table3.Rows.Count > 0)
                                    {
                                        double num = 0.0;
                                        for (int i = 0; i < table3.Rows.Count; i++)
                                        {
                                            num += Convert.ToDouble(table3.Rows[i]["Money"].ToString());
                                        }
                                        Tong = num.ToString();
                                    }
                                    #endregion
                                    str3 = str3 + "<tr height='22' align=right><td colspan='4'>" + MorePro.FormatMoney(Tong.ToString()) + "</td></tr>";
                                    str3 = str3 + "</table><br /><br /><br /><br /><br />";
                                }
                                this.txtContent.Text = str3;
                            }
                        }
                        this.MultiView1.ActiveViewIndex = 1;
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

        protected void btxoa_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < rp_items.Items.Count; i++)
                {
                    CheckBox chk = (CheckBox)rp_items.Items[i].FindControl("chkid");
                    HiddenField id = (HiddenField)rp_items.Items[i].FindControl("hiID");
                    if (chk.Checked)
                    {
                        SCartDetail.Delete_by_CartID(id.Value);
                        SCarts.Carts_Delete(id.Value);
                    }
                }
                ShowProducts();
            }
            catch (Exception) { }
        }



        protected void Export_Click(object sender, EventArgs e)
        {
            XlsFile xls = new XlsFile(1, true);
            TFlxFormat fmt;
            //Xét column width
            xls.SetColWidth(1, 15000);
            xls.SetColWidth(2, 10000);
            xls.SetColWidth(3, 5000);
            xls.SetColWidth(4, 4000);
            xls.SetColWidth(5, 4000);
            xls.SetColWidth(6, 4000);
            xls.SetColWidth(7, 4000);
            //Hàng 1
            xls.SetCellValue(1, 1, "Tên sản phẩm");
            xls.SetCellValue(1, 2, "Mã sản phẩm");
            xls.SetCellValue(1, 3, "Số lượng tồn");
            xls.SetCellValue(1, 4, "Số lượng bán");
            xls.SetCellValue(1, 5, "Giá bán");
            xls.SetCellValue(1, 6, "Ngày bán");
            xls.SetCellValue(1, 7, "Đơn vị");
            for (int i = 1; i <= 7; i++)
            {
                fmt = xls.GetCellVisibleFormatDef(1, i);
                fmt.VAlignment = TVFlxAlignment.center;
                fmt.HAlignment = THFlxAlignment.center;
                fmt.Font.Style = TFlxFontStyles.Bold;
                xls.SetCellFormat(1, i, xls.AddFormat(fmt));
            }
            //Hàng 1 cột 9,10
            string Sql = "";
            if (Request["st"] == "0")
            {
                Sql += " and istatus=0";
            }
            if (Request["st"] == "-1")
            {
                Sql += "";
            }
            if (Request["st"] == "1")
            {
                Sql += " and istatus=1";
            }
            if (DropDownList1.SelectedValue != "0")
            {
                Sql += " and day(Create_Date)=" + DropDownList1.SelectedValue + "";
            }
            if (DropDownList2.SelectedValue != "0")
            {
                Sql += " and  month(Create_Date)=" + DropDownList2.SelectedValue + "";
            }
            if (DropDownList3.SelectedValue != "0")
            {
                Sql += " and  year(Create_Date)=" + DropDownList3.SelectedValue + "";
            }
            List<Entity.Carts> table = new List<Entity.Carts>();
            table = SCarts.Name_Text("select * from Carts where lang= '" + lang + "'  " + Sql.ToString() + " order by Create_Date desc");
            if (table.Count > 0)
            {
                string submn = "0";
                for (int i = 0; i < table.Count; i++)
                {
                    submn = submn + "," + table[i].ID.ToString();
                }
                List<CartDetail> catlist = SCartDetail.Name_Text("select * from CartDetail where   ID_Cart in (" + submn + ") order by ID desc");
                if (catlist.Count > 0)
                {
                    for (int i = 0; i < catlist.Count(); i++)
                    {
                        //Dòng thứ 2 A của tên sản phẩm--(2, 1) --> 2 là donng thu 2, 1 là cot thu 1
                        fmt = xls.GetCellVisibleFormatDef(i + 2, 1);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 1, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 1, Name(catlist[i].ipid.ToString()));

                        //Dòng thứ 2 B của catId sản phẩm
                        fmt = xls.GetCellVisibleFormatDef(i + 2, 2);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 2, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 2, Code(catlist[i].ipid.ToString()));

                        //Dòng thứ 2 C của catId sản phẩm
                        fmt = xls.GetCellVisibleFormatDef(i + 2, 3);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 3, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 3, Quantity(catlist[i].ipid.ToString()));

                        //Dòng thứ 2 D của proOriginalPrice sản phẩm
                        fmt = xls.GetCellVisibleFormatDef(i + 2, 4);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 4, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 4, catlist[i].Quantity);


                        fmt = xls.GetCellVisibleFormatDef(i + 2, 5);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 5, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 5, catlist[i].Price);


                        fmt = xls.GetCellVisibleFormatDef(i + 2, 6);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 6, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 6, table[0].Create_Date.ToString());


                        Double soluong = catlist[i].Quantity;
                        Double can = int.Parse(SoCan(catlist[i].ipid.ToString()));
                        Double tongs = soluong * can;
                        fmt = xls.GetCellVisibleFormatDef(i + 2, 7);
                        fmt.VAlignment = TVFlxAlignment.top;
                        fmt.HAlignment = THFlxAlignment.left;
                        xls.SetCellFormat(i + 2, 7, xls.AddFormat(fmt));
                        xls.SetCellValue(i + 2, 7, tongs + "/" + Donvi(catlist[i].ipid.ToString()));

                    }
                }
            }


            xls.Save(Server.MapPath("uploads/excel/") + "Cart.xls");
            HttpResponse response = HttpContext.Current.Response;
            response.ClearContent();
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "Attachment; filename=Cart.xls");
            response.TransmitFile(Server.MapPath("uploads/excel/") + "Cart.xls");
            response.End();
        }

        protected string SoCan(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Noidung2.ToString();
            }
            return str.ToString();
        }
        protected string Donvi(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Noidung3.ToString();
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
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Code.ToString();
            }
            return str.ToString();
        }
        protected string Name(string id)
        {
            string str = "";
            List<Entity.Products> dt = SProducts.GetById(id);
            if (dt.Count > 0)
            {
                str += dt[0].Name.ToString();
            }
            return str.ToString();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowProducts();
            Response.Redirect("admin.aspx?u=carts&st=" + ddlstatus.SelectedValue + "&ngay=" + DropDownList1.SelectedValue + "&thang=" + DropDownList2.SelectedValue + "&nam=" + DropDownList3.SelectedValue + "");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowProducts();
            Response.Redirect("admin.aspx?u=carts&st=" + ddlstatus.SelectedValue + "&ngay=" + DropDownList1.SelectedValue + "&thang=" + DropDownList2.SelectedValue + "&nam=" + DropDownList3.SelectedValue + "");
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowProducts();
            Response.Redirect("admin.aspx?u=carts&st=" + ddlstatus.SelectedValue + "&ngay=" + DropDownList1.SelectedValue + "&thang=" + DropDownList2.SelectedValue + "&nam=" + DropDownList3.SelectedValue + "");
        }
        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ShowProducts();
            Response.Redirect("admin.aspx?u=carts&st=" + ddlstatus.SelectedValue + "&ngay=" + DropDownList1.SelectedValue + "&thang=" + DropDownList2.SelectedValue + "&nam=" + DropDownList3.SelectedValue + "");
        }
    }
}