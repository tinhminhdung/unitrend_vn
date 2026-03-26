using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Services;
using MoreAll;
using VS.E_Commerce;

namespace VS.Lieugiai.cms.Admin.AdminUser
{
    public partial class AdminUser : System.Web.UI.UserControl
    {
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
            //if (MoreAll.MoreAll.GetCookie("URole") != null)
            //{
            //    string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
            //    Reset_Checkbox();
            //    if (strArray.Length > 0)
            //    {
            //        for (int i = 0; i < strArray.Length; i++)
            //        {
            //            if (strArray[i].ToString().Equals("4"))
            //            {
            //                if (!base.IsPostBack)
            //                {
            load();
            this.btnupdatenewpassword.Text = this.label("l_update");
            this.btnCancelUpdatePass.Text = this.label("l_cancel");
            this.btn_cancel.Text = this.label("l_cancel");
            this.btn_update.Text = this.label("l_insert");
            //                }
            //            }
            //        }
            //    }
            //}
        }

        void load()
        {
            List<Entity.AdminUser> str = SAdminUser.GETBYALL();
            this.rp_admins.DataSource = str;
            this.rp_admins.DataBind();
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            this.lt_info.Text = "";
            this.hd_insertnew.Value = "";
            this.pn_detail.Visible = false;
            this.pnupdatepassword.Visible = false;
            this.pn_list.Visible = true;
        }



        protected void btnupdatenewpassword_Click(object sender, EventArgs e)
        {
            if (this.txtnewpassword.Text.Trim().Length > 0)
            {
                Entity.AdminUser obj = new Entity.AdminUser();
                obj.ID = int.Parse(this.hdid.Value);
                obj.VUSER_PWD = SecurityUtilities.EncodeMD5(txtnewpassword.Text);
                SAdminUser.UPDATE_PASSWORD(obj);
                this.pnupdatepassword.Visible = false;
                this.pn_list.Visible = true;
            }
        }

        protected void Delete_Load(object sender, EventArgs e)
        {
            ((LinkButton)sender).Attributes["onclick"] = "return confirm('Xóa tài khoản vừa chọn ?')";
        }

        protected bool EnableUpdatePassword(string role)
        {
            return true;
        }

        protected string label(string id)
        {
            return Captionlanguage.GetLabel(id, this.lang);
        }

        protected void lnk_insertnewadmin_Click(object sender, EventArgs e)
        {
            //if (MoreAll.MoreAll.GetCookie("URole") != null)
            //{
            //    string[] strArray = MoreAll.MoreAll.GetCookie("URole").ToString().Trim().Split(new char[] { '|' });
            //    Reset_Checkbox();
            //    if (strArray.Length > 0)
            //    {
            //        for (int i = 0; i < strArray.Length; i++)
            //        {
            //            if (strArray[i].ToString().Equals("4"))
            //            {
            this.lt_info.Text = " - " + this.label("l_addsystemuser");
            this.hd_insertnew.Value = "insert";
            this.pn_detail.Visible = true;
            this.pn_list.Visible = false;
            this.txt_password.Enabled = true;
            this.txt_password.Text = "";
            this.txtMaNV.Text = "";
            SoDienThoai.Text = "";
            //            }
            //        }
            //    }
            //}
        }

        protected string Lock(string ilocked)
        {
            if (ilocked.Equals("0"))
            {
                return "Đang hoạt động";
            }
            return "Bị kh\x00f3a";
        }
        protected string QuantriVien(string ilocked)
        {

            if (ilocked.Equals("1"))
            {
                return "Quản trị viên";
            }
            if (ilocked.Equals("2"))
            {
                return "Sale online";
            }
            if (ilocked.Equals("3"))
            {
                return "Sale sàn TMĐT";
            }
            if (ilocked.Equals("4"))
            {
                return "Kỹ thuật viên";
            }
            if (ilocked.Equals("5"))
            {
                return "NV bán hàng trực tiếp";
            }
            if (ilocked.Equals("7"))
            {
                return "Thu ngân";
            }
            return "Chưa cập nhật";
        }
        protected string lockunlock(string locked)
        {
            if (locked.Equals("0"))
            {
                return "<img src='Resources/admin/images/key.png' border=0 />";
            }
            return "<img src='Resources/admin/images/key-locked.png' border=0 />";
        }

        protected void rp_admins_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string commandName = e.CommandName;
            switch (e.CommandName)
            {
                case "ChangeIsChechNghi":
                    string str3;
                    string str2 = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                    if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                    { str3 = "0"; }
                    else { str3 = "1"; }
                    SAdminUser.Name_Text("update AdminUser set IsChechNghi=" + str3 + " where id=" + str2);
                    this.load();
                    return;

            }
            if (commandName != null)
            {
                if (!(commandName == "updatepassword"))
                {
                    if (!(commandName == "Delete"))
                    {
                        string str2;
                        if (!(commandName == "ChangeStatus"))
                        {
                            if (commandName == "update")
                            {
                                this.hdid.Value = e.CommandArgument.ToString();
                                this.hd_insertnew.Value = "update";
                                this.pn_detail.Visible = true;
                                this.pn_list.Visible = false;
                                //this.txt_username.Enabled = false;
                                this.txt_password.Enabled = false;
                                //this.SoDienThoai.Enabled = false;
                                this.lt_info.Text = " - Update User";
                                List<Entity.AdminUser> table = SAdminUser.GETBYID(e.CommandArgument.ToString());
                                this.Reset_Checkbox();
                                if (table.Count > 0)
                                {
                                    this.HoVaTen.Text = table[0].HoVaTen;
                                    // this.txt_username.Text = table[0].VUSER_NAME;
                                    this.txt_password.Text = table[0].VUSER_PWD;
                                    this.txtMaNV.Text = table[0].MaNV.ToString();
                                    this.SoDienThoai.Text = table[0].SoDienThoai;

                                    WebControlsUtilities.SetSelectedIndexInDropDownList(ref this.ddlBoPhan, table[0].Vaitro.ToString());


                                    if (table[0].IsChechNghi.ToString().Equals("1"))
                                    {
                                        this.IsChechNghis.Checked = true;
                                    }
                                    else
                                    {
                                        this.IsChechNghis.Checked = false;
                                    }


                                    if (table[0].ILOCKED.ToString().Equals("0"))
                                    {
                                        this.chk_enable.Checked = true;
                                    }
                                    else
                                    {
                                        this.chk_enable.Checked = false;
                                    }



                                    string[] strArray = table[0].VROLE.ToString().Split(new char[] { '|' });
                                    if (strArray.Length > 0)
                                    {
                                        for (int i = 0; i < strArray.Length; i++)
                                        {
                                            #region MyRegion
                                            if (strArray[i].ToString().Equals("1"))
                                            {
                                                this.CheckBox1.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("2"))
                                            {
                                                this.CheckBox2.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("3"))
                                            {
                                                this.CheckBox3.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("4"))
                                            {
                                                this.CheckBox4.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("5"))
                                            {
                                                this.CheckBox5.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("6"))
                                            {
                                                this.CheckBox6.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("7"))
                                            {
                                                this.CheckBox7.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("8"))
                                            {
                                                this.CheckBox8.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("9"))
                                            {
                                                this.CheckBox9.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("10"))
                                            {
                                                this.CheckBox10.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("11"))
                                            {
                                                this.CheckBox11.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("12"))
                                            {
                                                this.CheckBox12.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("13"))
                                            {
                                                this.CheckBox13.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("14"))
                                            {
                                                this.CheckBox14.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("15"))
                                            {
                                                this.CheckBox15.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("16"))
                                            {
                                                this.CheckBox16.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("17"))
                                            {
                                                this.CheckBox17.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("18"))
                                            {
                                                this.CheckBox18.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("19"))
                                            {
                                                //this.CheckBox19.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("20"))
                                            {
                                                this.CheckBox20.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("21"))
                                            {
                                                this.CheckBox21.Checked = true;
                                            }

                                            //if (strArray[i].ToString().Equals("22"))
                                            //{
                                            //    this.CheckBox22.Checked = true;
                                            //}
                                            if (strArray[i].ToString().Equals("23"))
                                            {
                                                this.CheckBox23.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("24"))
                                            {
                                                this.CheckBox24.Checked = true;
                                            }

                                            // sản phâmnr
                                            if (strArray[i].ToString().Equals("25"))
                                            {
                                                this.CheckBox25.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("26"))
                                            {
                                                this.CheckBox26.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("27"))
                                            {
                                                this.CheckBox27.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("27"))
                                            {
                                                this.CheckBox28.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("27"))
                                            {
                                                this.CheckBox29.Checked = true;
                                            }

                                            #endregion

                                            #region check_CuocPhi
                                            if (strArray[i].ToString().Equals("50"))
                                            {
                                                this.check_CuocPhi_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("51"))
                                            {
                                                this.check_CuocPhi_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("52"))
                                            {
                                                this.check_CuocPhi_X.Checked = true;
                                            }
                                            #endregion

                                            #region check_NhaSX
                                            if (strArray[i].ToString().Equals("53"))
                                            {
                                                this.check_NhaSX_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("54"))
                                            {
                                                this.check_NhaSX_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("55"))
                                            {
                                                this.check_NhaSX_X.Checked = true;
                                            }
                                            #endregion

                                            #region check_DanhSachSP_T
                                            if (strArray[i].ToString().Equals("56"))
                                            {
                                                this.check_DanhSachSP_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("57"))
                                            {
                                                this.check_DanhSachSP_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("58"))
                                            {
                                                this.check_DanhSachSP_X.Checked = true;
                                            }
                                            #endregion

                                            #region check_TrongLuong_T
                                            if (strArray[i].ToString().Equals("59"))
                                            {
                                                this.check_TrongLuong_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("60"))
                                            {
                                                this.check_TrongLuong_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("61"))
                                            {
                                                this.check_TrongLuong_X.Checked = true;
                                            }
                                            #endregion

                                            #region check_BaoHanhSP_T
                                            if (strArray[i].ToString().Equals("62"))
                                            {
                                                this.check_BaoHanhSP_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("63"))
                                            {
                                                this.check_BaoHanhSP_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("64"))
                                            {
                                                this.check_BaoHanhSP_X.Checked = true;
                                            }
                                            #endregion

                                            //#region check_CauHinh_SP
                                            if (strArray[i].ToString().Equals("65"))
                                            {
                                                this.check_CauHinh_SP.Checked = true;
                                            }
                                            //if (strArray[i].ToString().Equals("66"))
                                            //{
                                            //    this.check_ChuyenNhom_SP.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("67"))
                                            //{
                                            //    this.check_Themexl_SP.Checked = true;
                                            //}
                                            //#endregion

                                            #region check_cart
                                            if (strArray[i].ToString().Equals("68"))
                                            {
                                                this.check_cart_Xem.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("69"))
                                            {
                                                this.check_cart_Huy.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("70"))
                                            {
                                                this.check_cart_Xoa.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("71"))
                                            {
                                                this.check_cart_Exel.Checked = true;
                                            }
                                            #endregion

                                            #region check_ThanhVien
                                            if (strArray[i].ToString().Equals("72"))
                                            {
                                                this.check_ThanhVien_Xem.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("73"))
                                            {
                                                this.check_ThanhVien_RS.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("74"))
                                            {
                                                this.check_ThanhVien_KHoa.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("75"))
                                            {
                                                this.check_ThanhVien_XTK.Checked = true;
                                            }
                                            #endregion

                                            //#region check_XuLyDon
                                            //if (strArray[i].ToString().Equals("76"))
                                            //{
                                            //    this.check_XuLyDon_Xem.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("77"))
                                            //{
                                            //    this.check_XuLyDon_Sua.Checked = true;
                                            //}
                                            //#endregion

                                            #region check_XuLyDon
                                            if (strArray[i].ToString().Equals("78"))
                                            {
                                                this.check_LienHe_X.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("79"))
                                            {
                                                this.check_LienHe_XL.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("80"))
                                            {
                                                this.check_LienHe_XOA.Checked = true;
                                            }
                                            #endregion

                                            //#region check_Tienich
                                            //if (strArray[i].ToString().Equals("81"))
                                            //{
                                            //    this.check_Tienich_XEM.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("82"))
                                            //{
                                            //    this.check_Tienich_SUA.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("83"))
                                            //{
                                            //    this.check_Tienich_XOA.Checked = true;
                                            //}
                                            //#endregion


                                            //#region check_Marketing
                                            //if (strArray[i].ToString().Equals("84"))
                                            //{
                                            //    this.check_Marketing_X.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("85"))
                                            //{
                                            //    this.check_Marketing_XL.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("86"))
                                            //{
                                            //    this.check_Marketing_XOA.Checked = true;
                                            //}
                                            //#endregion


                                            #region check_QuangCao
                                            if (strArray[i].ToString().Equals("87"))
                                            {
                                                this.check_QuangCao_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("88"))
                                            {
                                                this.check_QuangCao_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("89"))
                                            {
                                                this.check_QuangCao_X.Checked = true;
                                            }
                                            #endregion


                                            #region check_TinTuc
                                            if (strArray[i].ToString().Equals("90"))
                                            {
                                                this.check_TinTuc_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("91"))
                                            {
                                                this.check_TinTuc_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("92"))
                                            {
                                                this.check_TinTuc_X.Checked = true;
                                            }
                                            #endregion


                                            #region check_ChanTrang
                                            if (strArray[i].ToString().Equals("93"))
                                            {
                                                this.check_ChanTrang_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("94"))
                                            {
                                                this.check_ChanTrang_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("95"))
                                            {
                                                this.check_ChanTrang_X.Checked = true;
                                            }
                                            #endregion


                                            #region check_File
                                            if (strArray[i].ToString().Equals("96"))
                                            {
                                                this.check_File_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("97"))
                                            {
                                                this.check_File_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("98"))
                                            {
                                                this.check_File_X.Checked = true;
                                            }
                                            #endregion


                                            //#region check_video
                                            //if (strArray[i].ToString().Equals("99"))
                                            //{
                                            //    this.check_video_T.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("100"))
                                            //{
                                            //    this.check_video_S.Checked = true;
                                            //}
                                            //if (strArray[i].ToString().Equals("101"))
                                            //{
                                            //    this.check_video_X.Checked = true;
                                            //}
                                            //#endregion


                                            #region check_BaoGia_T
                                            if (strArray[i].ToString().Equals("102"))
                                            {
                                                this.check_BaoGia_X.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("103"))
                                            {
                                                this.check_BaoGia_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("104"))
                                            {
                                                this.check_BaoGia_XL.Checked = true;
                                            }
                                            #endregion


                                            #region check_GioiThieu_T
                                            if (strArray[i].ToString().Equals("201"))
                                            {
                                                this.check_GioiThieu_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("202"))
                                            {
                                                this.check_GioiThieu_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("203"))
                                            {
                                                this.check_GioiThieu_X.Checked = true;
                                            }
                                            #endregion

                                            #region check_TuVan_X
                                            if (strArray[i].ToString().Equals("204"))
                                            {
                                                this.check_TuVan_X.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("205"))
                                            {
                                                this.check_TuVan_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("206"))
                                            {
                                                this.check_TuVan_XL.Checked = true;
                                            }
                                            #endregion

                                            #region check_Video_T
                                            if (strArray[i].ToString().Equals("210"))
                                            {
                                                this.check_Video_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("211"))
                                            {
                                                this.check_Video_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("212"))
                                            {
                                                this.check_Video_X.Checked = true;
                                            }
                                            #endregion

                                            #region check_SoSanhSP_T
                                            if (strArray[i].ToString().Equals("213"))
                                            {
                                                this.check_SoSanhSP_T.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("214"))
                                            {
                                                this.check_SoSanhSP_S.Checked = true;
                                            }
                                            if (strArray[i].ToString().Equals("215"))
                                            {
                                                this.check_SoSanhSP_X.Checked = true;
                                            }
                                            #endregion
                                            


                                        }
                                    }
                                    if (table[0].ILOCKED.ToString().Equals("0"))
                                    {
                                        this.chk_enable.Checked = true;
                                    }
                                }
                            }
                            return;
                        }
                        string str = e.CommandArgument.ToString().Trim().Substring(0, e.CommandArgument.ToString().IndexOf("|"));
                        if (e.CommandArgument.ToString().Substring(e.CommandArgument.ToString().IndexOf("|") + 1, (e.CommandArgument.ToString().Length - e.CommandArgument.ToString().IndexOf("|")) - 1) == "1")
                        {
                            str2 = "0";
                        }
                        else
                        {
                            str2 = "1";
                        }
                        Entity.AdminUser obj = new Entity.AdminUser();
                        obj.ID = int.Parse(str);
                        obj.ILOCKED = int.Parse(str2);
                        SAdminUser.UPDATE_STATUS(obj);
                        load();
                        return;
                    }
                }


                else
                {
                    this.hdid.Value = e.CommandArgument.ToString();
                    this.pn_list.Visible = false;
                    this.pnupdatepassword.Visible = true;
                    this.lt_info.Text = " - " + this.label("l_update") + " " + this.label("lt_password");
                    return;
                }
                SAdminUser.DELETE(e.CommandArgument.ToString().Trim());
                load();
            }
        }

        protected void Reset_Checkbox()
        {
            #region old
            this.CheckBox1.Checked = false;
            this.CheckBox2.Checked = false;
            this.CheckBox3.Checked = false;
            this.CheckBox4.Checked = false;
            this.CheckBox5.Checked = false;
            this.CheckBox6.Checked = false;
            this.CheckBox7.Checked = false;
            this.CheckBox8.Checked = false;
            this.CheckBox9.Checked = false;
            this.CheckBox10.Checked = false;
            this.CheckBox11.Checked = false;
            this.CheckBox12.Checked = false;
            this.CheckBox13.Checked = false;
            this.CheckBox14.Checked = false;
            this.CheckBox15.Checked = false;
            this.CheckBox16.Checked = false;
            this.CheckBox17.Checked = false;
            this.CheckBox18.Checked = false;
            //this.CheckBox19.Checked = false;
            this.CheckBox20.Checked = false;
            this.CheckBox21.Checked = false;

            //this.CheckBox22.Checked = false;
            this.CheckBox23.Checked = false;
            this.chk_enable.Checked = true;
            this.CheckBox24.Checked = false;

            this.CheckBox25.Checked = false;
            this.CheckBox26.Checked = false;
            this.CheckBox27.Checked = false;
            this.CheckBox28.Checked = false;
            this.CheckBox29.Checked = false;

            #endregion

            #region check_CuocPhi
            this.check_CuocPhi_T.Checked = false;
            this.check_CuocPhi_S.Checked = false;
            this.check_CuocPhi_X.Checked = false;
            #endregion

            #region check_NhaSX
            this.check_NhaSX_T.Checked = false;
            this.check_NhaSX_S.Checked = false;
            this.check_NhaSX_X.Checked = false;
            #endregion

            #region check_DanhSachSP
            this.check_DanhSachSP_T.Checked = false;
            this.check_DanhSachSP_S.Checked = false;
            this.check_DanhSachSP_X.Checked = false;
            #endregion

            #region check_TrongLuong_T
            this.check_TrongLuong_T.Checked = false;
            this.check_TrongLuong_S.Checked = false;
            this.check_TrongLuong_X.Checked = false;
            #endregion

            #region check_BaoHanhSP_T
            this.check_BaoHanhSP_T.Checked = false;
            this.check_BaoHanhSP_S.Checked = false;
            this.check_BaoHanhSP_X.Checked = false;
            #endregion

            #region check_CauHinh_SP
            this.check_CauHinh_SP.Checked = false;
            //this.check_ChuyenNhom_SP.Checked = false;
            //this.check_Themexl_SP.Checked = false;
            #endregion

            #region check_cart
            this.check_cart_Xem.Checked = false;
            this.check_cart_Huy.Checked = false;
            this.check_cart_Xoa.Checked = false;
            this.check_cart_Exel.Checked = false;
            #endregion

            #region check_ThanhVien
            this.check_ThanhVien_Xem.Checked = false;
            this.check_ThanhVien_RS.Checked = false;
            this.check_ThanhVien_KHoa.Checked = false;
            this.check_ThanhVien_XTK.Checked = false;
            #endregion

            //#region check_XuLyDon
            //this.check_XuLyDon_Xem.Checked = false;
            //this.check_XuLyDon_Sua.Checked = false;
            //#endregion

            #region check_LienHe
            this.check_LienHe_X.Checked = false;
            this.check_LienHe_XL.Checked = false;
            this.check_LienHe_XOA.Checked = false;
            #endregion

            //#region check_Tienich
            //this.check_Tienich_XEM.Checked = false;
            //this.check_Tienich_SUA.Checked = false;
            //this.check_Tienich_XOA.Checked = false;
            //#endregion

            //#region check_Marketing
            //this.check_Marketing_X.Checked = false;
            //this.check_Marketing_XL.Checked = false;
            //this.check_Marketing_XOA.Checked = false;
            //#endregion


            #region check_QuangCao
            this.check_QuangCao_T.Checked = false;
            this.check_QuangCao_S.Checked = false;
            this.check_QuangCao_X.Checked = false;
            #endregion


            #region check_TinTuc
            this.check_TinTuc_T.Checked = false;
            this.check_TinTuc_S.Checked = false;
            this.check_TinTuc_X.Checked = false;
            #endregion

            #region check_ChanTrang
            this.check_ChanTrang_T.Checked = false;
            this.check_ChanTrang_S.Checked = false;
            this.check_ChanTrang_X.Checked = false;
            #endregion


            #region check_File
            this.check_File_T.Checked = false;
            this.check_File_S.Checked = false;
            this.check_File_X.Checked = false;
            #endregion


            //#region check_video
            //this.check_video_T.Checked = false;
            //this.check_video_S.Checked = false;
            //this.check_video_X.Checked = false;
            //#endregion

            #region check_TieuChuan
            this.check_BaoGia_X.Checked = false;
            this.check_BaoGia_S.Checked = false;
            this.check_BaoGia_XL.Checked = false;
            #endregion

            #region check_GioiThieu_T
            this.check_GioiThieu_T.Checked = false;
            this.check_GioiThieu_S.Checked = false;
            this.check_GioiThieu_X.Checked = false;
            #endregion

            #region check_TuVan_S
            this.check_TuVan_X.Checked = false;
            this.check_TuVan_S.Checked = false;
            this.check_TuVan_XL.Checked = false;
            #endregion

            this.check_Video_T.Checked = false;
            this.check_Video_S.Checked = false;
            this.check_Video_X.Checked = false;

            #region check_SoSanhSP_T
            this.check_SoSanhSP_T.Checked = false;
            this.check_SoSanhSP_S.Checked = false;
            this.check_SoSanhSP_X.Checked = false;
            #endregion
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            #region old
            if (this.hd_insertnew.Value.Equals("insert"))
            {
                //if (this.txt_username.Text.Trim().Length < 1)
                //{
                //    ltmsg.Text = "Vui lòng điền đầy đủ thông tin";
                //    return;
                //}
                if (this.txtMaNV.Text.Trim().Length < 1)
                {
                    ltmsg.Text = "Vui lòng điền đầy đủ thông tin";
                    return;
                }
                if (this.HoVaTen.Text.Trim().Length < 1)
                {
                    ltmsg.Text = "Vui lòng điền đầy đủ thông tin";
                    return;
                }
                if (this.txt_password.Text.Trim().Length < 1)
                {
                    ltmsg.Text = "Vui lòng điền đầy đủ thông tin";
                    return;
                }
            }
            int locked = 1;
            if (this.chk_enable.Checked)
            {
                locked = 0;
            }
            string role = "";
            if (this.CheckBox1.Checked)
            {
                role = role + "1";
            }
            if (this.CheckBox2.Checked)
            {
                role = role + "|2";
            }
            if (this.CheckBox3.Checked)
            {
                role = role + "|3";
            }
            if (this.CheckBox4.Checked)
            {
                role = role + "|4";
            }
            if (this.CheckBox5.Checked)
            {
                role = role + "|5";
            }
            if (this.CheckBox6.Checked)
            {
                role = role + "|6";
            }
            if (this.CheckBox7.Checked)
            {
                role = role + "|7";
            }
            if (this.CheckBox8.Checked)
            {
                role = role + "|8";
            }
            if (this.CheckBox9.Checked)
            {
                role = role + "|9";
            }
            if (this.CheckBox10.Checked)
            {
                role = role + "|10";
            }
            if (this.CheckBox11.Checked)
            {
                role = role + "|11";
            }
            if (this.CheckBox12.Checked)
            {
                role = role + "|12";
            }
            if (this.CheckBox13.Checked)
            {
                role = role + "|13";
            }
            if (this.CheckBox14.Checked)
            {
                role = role + "|14";
            }
            if (this.CheckBox15.Checked)
            {
                role = role + "|15";
            }
            if (this.CheckBox16.Checked)
            {
                role = role + "|16";
            }
            if (this.CheckBox17.Checked)
            {
                role = role + "|17";
            }
            if (this.CheckBox18.Checked)
            {
                role = role + "|18";
            }
            //if (this.CheckBox19.Checked)
            //{
            //    role = role + "|19";
            //}
            if (this.CheckBox20.Checked)
            {
                role = role + "|20";
            }
            if (this.CheckBox21.Checked)
            {
                role = role + "|21";
            }
            //if (this.CheckBox22.Checked)
            //{
            //    role = role + "|22";
            //}

            if (this.CheckBox23.Checked)
            {
                role = role + "|23";
            }
            if (this.CheckBox24.Checked)
            {
                role = role + "|24";
            }

            // sản phẩm
            if (this.CheckBox25.Checked)
            {
                role = role + "|25";
            }
            if (this.CheckBox26.Checked)
            {
                role = role + "|26";
            }
            if (this.CheckBox27.Checked)
            {
                role = role + "|27";
            }

            if (this.CheckBox28.Checked)
            {
                role = role + "|28";
            }
            if (this.CheckBox29.Checked)
            {
                role = role + "|29";
            }

            #endregion

            #region cước phí
            if (this.check_CuocPhi_T.Checked)
            {
                role = role + "|50";
            }
            if (this.check_CuocPhi_S.Checked)
            {
                role = role + "|51";
            }
            if (this.check_CuocPhi_X.Checked)
            {
                role = role + "|52";
            }
            #endregion

            #region check_NhaSX
            if (this.check_NhaSX_T.Checked)
            {
                role = role + "|53";
            }
            if (this.check_NhaSX_S.Checked)
            {
                role = role + "|54";
            }
            if (this.check_NhaSX_X.Checked)
            {
                role = role + "|55";
            }
            #endregion

            #region check_DanhSachSP_T
            if (this.check_DanhSachSP_T.Checked)
            {
                role = role + "|56";
            }
            if (this.check_DanhSachSP_S.Checked)
            {
                role = role + "|57";
            }
            if (this.check_DanhSachSP_X.Checked)
            {
                role = role + "|58";
            }
            #endregion

            #region check_TrongLuong_T
            if (this.check_TrongLuong_T.Checked)
            {
                role = role + "|59";
            }
            if (this.check_TrongLuong_S.Checked)
            {
                role = role + "|60";
            }
            if (this.check_TrongLuong_X.Checked)
            {
                role = role + "|61";
            }
            #endregion

            #region check_BaoHanhSP_T
            if (this.check_BaoHanhSP_T.Checked)
            {
                role = role + "|62";
            }
            if (this.check_BaoHanhSP_S.Checked)
            {
                role = role + "|63";
            }
            if (this.check_BaoHanhSP_X.Checked)
            {
                role = role + "|64";
            }
            #endregion

            #region check_CauHinh_SP
            if (this.check_CauHinh_SP.Checked)
            {
                role = role + "|65";
            }
            //if (this.check_ChuyenNhom_SP.Checked)
            //{
            //    role = role + "|66";
            //}
            //if (this.check_Themexl_SP.Checked)
            //{
            //    role = role + "|67";
            //}
            #endregion

            #region check_cart
            if (this.check_cart_Xem.Checked)
            {
                role = role + "|68";
            }
            if (this.check_cart_Huy.Checked)
            {
                role = role + "|69";
            }
            if (this.check_cart_Xoa.Checked)
            {
                role = role + "|70";
            }
            if (this.check_cart_Exel.Checked)
            {
                role = role + "|71";
            }
            #endregion

            #region check_ThanhVien
            if (this.check_ThanhVien_Xem.Checked)
            {
                role = role + "|72";
            }
            if (this.check_ThanhVien_RS.Checked)
            {
                role = role + "|73";
            }
            if (this.check_ThanhVien_KHoa.Checked)
            {
                role = role + "|74";
            }
            if (this.check_ThanhVien_XTK.Checked)
            {
                role = role + "|75";
            }
            #endregion

            #region check_XuLyDon_Xem
            //if (this.check_XuLyDon_Xem.Checked)
            //{
            //    role = role + "|76";
            //}
            //if (this.check_XuLyDon_Sua.Checked)
            //{
            //    role = role + "|77";
            //}
            #endregion

            #region check_LienHe
            if (this.check_LienHe_X.Checked)
            {
                role = role + "|78";
            }
            if (this.check_LienHe_XL.Checked)
            {
                role = role + "|79";
            }
            if (this.check_LienHe_XOA.Checked)
            {
                role = role + "|80";
            }
            #endregion


            ////????????
            #region check_Tienich
            //if (this.check_Tienich_XEM.Checked)
            //{
            //    role = role + "|81";
            //}
            //if (this.check_Tienich_SUA.Checked)
            //{
            //    role = role + "|82";
            //}
            //if (this.check_Tienich_XOA.Checked)
            //{
            //    role = role + "|83";
            //}
            #endregion

            //#region check_Marketing
            //if (this.check_Marketing_X.Checked)
            //{
            //    role = role + "|84";
            //}
            //if (this.check_Marketing_XL.Checked)
            //{
            //    role = role + "|85";
            //}
            //if (this.check_Marketing_XOA.Checked)
            //{
            //    role = role + "|86";
            //}
            //#endregion

            #region check_QuangCao
            if (this.check_QuangCao_T.Checked)
            {
                role = role + "|87";
            }
            if (this.check_QuangCao_S.Checked)
            {
                role = role + "|88";
            }
            if (this.check_QuangCao_X.Checked)
            {
                role = role + "|89";
            }
            #endregion

            #region check_TinTuc
            if (this.check_TinTuc_T.Checked)
            {
                role = role + "|90";
            }
            if (this.check_TinTuc_S.Checked)
            {
                role = role + "|91";
            }
            if (this.check_TinTuc_X.Checked)
            {
                role = role + "|92";
            }
            #endregion


            #region check_ChanTrang
            if (this.check_ChanTrang_T.Checked)
            {
                role = role + "|93";
            }
            if (this.check_ChanTrang_S.Checked)
            {
                role = role + "|94";
            }
            if (this.check_ChanTrang_X.Checked)
            {
                role = role + "|95";
            }
            #endregion

            ////

            #region check_File
            if (this.check_File_T.Checked)
            {
                role = role + "|96";
            }
            if (this.check_File_S.Checked)
            {
                role = role + "|97";
            }
            if (this.check_File_X.Checked)
            {
                role = role + "|98";
            }
            #endregion

            //#region check_video
            //if (this.check_video_T.Checked)
            //{
            //    role = role + "|99";
            //}
            //if (this.check_video_S.Checked)
            //{
            //    role = role + "|100";
            //}
            //if (this.check_video_X.Checked)
            //{
            //    role = role + "|101";
            //}
            //#endregion

            #region check_TieuChuan
            if (this.check_BaoGia_X.Checked)
            {
                role = role + "|102";
            }
            if (this.check_BaoGia_S.Checked)
            {
                role = role + "|103";
            }
            if (this.check_BaoGia_XL.Checked)
            {
                role = role + "|104";
            }
            #endregion


            #region check_TieuChuan
            if (this.check_TuVan_X.Checked)
            {
                role = role + "|204";
            }
            if (this.check_TuVan_S.Checked)
            {
                role = role + "|205";
            }
            if (this.check_TuVan_XL.Checked)
            {
                role = role + "|206";
            }
            #endregion

            #region GioiThieu
            if (this.check_GioiThieu_T.Checked)
            {
                role = role + "|201";
            }
            if (this.check_GioiThieu_S.Checked)
            {
                role = role + "|202";
            }
            if (this.check_GioiThieu_X.Checked)
            {
                role = role + "|203";
            }
            #endregion

            #region check_Video_T
            if (this.check_Video_T.Checked)
            {
                role = role + "|210";
            }
            if (this.check_Video_S.Checked)
            {
                role = role + "|211";
            }
            if (this.check_Video_X.Checked)
            {
                role = role + "|212";
            }
            #endregion

            #region check_SoSanhSP_T
            if (this.check_SoSanhSP_T.Checked)
            {
                role = role + "|213";
            }
            if (this.check_SoSanhSP_S.Checked)
            {
                role = role + "|214";
            }
            if (this.check_SoSanhSP_X.Checked)
            {
                role = role + "|215";
            }
            #endregion

            

            #region hd_insertnew
            Entity.AdminUser obj = new Entity.AdminUser();

            if (this.hd_insertnew.Value.Trim().Equals("insert"))
            {
                //DAdminUser obj = new DAdminUser();
                obj.HoVaTen = HoVaTen.Text;
                obj.VUSER_NAME = txtMaNV.Text;
                obj.VUSER_PWD = SecurityUtilities.EncodeMD5(this.txt_password.Text.Trim());
                obj.VROLE = role;
                obj.IASSIGN = 1;
                obj.DASSIGN_DATE = DateTime.Now;
                obj.ILOCKED = (byte)Convert.ToInt32(locked);
                obj.IsChechNghi = (byte)Convert.ToInt32(IsChechNghis.Checked ? "1" : "0");
                obj.MaNV = txtMaNV.Text;
                obj.Vaitro = (byte)Convert.ToInt32(ddlBoPhan.SelectedValue);
                obj.SoDienThoai = SoDienThoai.Text;
                SAdminUser.INSERT(obj);
                this.pn_list.Visible = true;
                this.pn_detail.Visible = false;
                load();
            }
            else
            {
                //DAdminUser abc = db.DAdminUsers.SingleOrDefault(p => p.ID == int.Parse(this.hdid.Value));
                //abc.VROLE = role;
                //abc.IASSIGN = 1;
                //obj.IsChechNghi = (byte)Convert.ToInt32(IsChechNghis.Checked ? "1" : "0");
                //obj.Vaitro = (byte)Convert.ToInt32(QuantriViens.Checked ? "1" : "0");
                //obj.SoDienThoai = SoDienThoai.Text;
                //obj.MaNV = txtMaNV.Text;
                //obj.VUSER_NAME = txt_username.Text;
                //db.SubmitChanges();

                string IsChechNghi = IsChechNghis.Checked ? "1" : "0";
                string Vaitro = ddlBoPhan.SelectedValue;
                string Sql = "update AdminUser set VROLE='" + role + "',IASSIGN=1,IsChechNghi=" + IsChechNghi + ",Vaitro=" + Vaitro + ",SoDienThoai=N'" + SoDienThoai.Text + "',MaNV=N'" + txtMaNV.Text + "',HoVaTen=N'" + HoVaTen.Text + "' where id=" + hdid.Value;
                SAdminUser.Name_Text(Sql);

            }
            this.pn_list.Visible = true;
            this.pn_detail.Visible = false;
            load();
            #endregion
        }
    }
}