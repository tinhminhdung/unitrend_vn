<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminUser.ascx.cs" Inherits="VS.Lieugiai.cms.Admin.AdminUser.AdminUser" %>
<asp:Literal ID="lt_info" Visible="false" runat="server"></asp:Literal>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="pn_list" runat="server" Width="100%">
            <div class="list_item">
                <asp:Repeater ID="rp_admins" runat="server" OnItemCommand="rp_admins_ItemCommand">
                    <ItemTemplate>
                        <tr style="background-color: #f1f1f1; text-align: center" height="40">
                            <td>
                                <%#DataBinder.Eval(Container.DataItem,"MaNV")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem,"HoVaTen")%>
                            </td>
                            <td align="center">
                                <%#QuantriVien(Eval("Vaitro").ToString())%>
                            </td>
                            <td align="center">
                                <%#DataBinder.Eval(Container.DataItem,"DASSIGN_DATE")%>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="ChangeIsChechNghi" Visible="true" CommandArgument='<%#Eval("ID")+"|"+Eval("IsChechNghi")%>'
                                    runat="server" ID="Linkbutton3"> <%#lockunlock(Eval("IsChechNghi").ToString())%></asp:LinkButton>
                            </td>
                            <td align="center">
                                <%#Lock(Eval("ilocked").ToString())%>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="update" Visible="true" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server" ID="Linkbutton5" NAME="Linkbutton1">Phân quyền</asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton ID="LinkButton2" runat="server" Visible="true" CommandName='updatepassword'
                                    CommandArgument='<%#Eval("ID")%>'>Đổi mật khẩu</asp:LinkButton>
                            </td>
                            <td align="center">
                                <asp:LinkButton CommandName="ChangeStatus" Visible="true" CommandArgument='<%#Eval("ID")+"|"+Eval("ILOCKED")%>'
                                    runat="server" ID="Linkbutton1"> <%#lockunlock(Eval("ILOCKED").ToString())%></asp:LinkButton>
                                <span style='enable: <%#EnableUpdatePassword(Eval("ID").ToString())%>'></span>
                            </td>
                            <td align="center">
                                <asp:LinkButton OnLoad="Delete_Load" Visible="true" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"ID")%>'
                                    runat="server" ID="Linkbutton4"><img src="/Resources/admin/images/del.png" />
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <table border="0" width="100%" cellpadding="0" style="border-collapse: collapse">
                            <tr bgcolor="#C4C4C4" height="22">
                                <td class="header">Mã NV
                                </td>
                                <td class="header">Họ và tên
                                </td>
                                <td class="header">Vai trò
                                </td>

                                <td class="header">Ngày kích hoạt
                                </td>
                                <td class="header">Nghỉ làm
                                </td>
                                <td class="header">
                                    <%=label("l_status")%>
                                </td>

                                <td class="header">Phân quyền
                                </td>
                                <td class="header">Đổi mật khẩu
                                </td>
                                <td class="header">Khóa TK
                                </td>
                                <td class="header">Xóa TK
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <FooterTemplate>
                        </TABLE>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <table style="border-collapse: collapse" cellpadding="0" width="100%" border="0">
                <tr height="20">
                    <td></td>
                </tr>
                <tr height="25" bgcolor="WhiteSmoke">
                    <td>
                        <asp:LinkButton ID="lnk_insertnewadmin" runat="server" Font-Bold="True" OnClick="lnk_insertnewadmin_Click">[<%=label("l_addsystemuser")%>]</asp:LinkButton>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pn_detail" runat="server"  Visible="false" Width="100%">
            <div class='frm-add'>
                <input id="id" style="width: 24px; height: 22px" type="hidden" size="1" name="Hidden1"
                    runat="server">
                <input id="hd_insertnew" style="width: 24px; height: 22px" type="hidden" size="1"
                    name="Hidden1" runat="server">
                <div style="text-align: center">
                    <asp:Label ID="ltmsg" runat="server" Font-Bold="True" ForeColor="Red" Visible="True"></asp:Label>
                </div>
                <table style="border-collapse: collapse" cellpadding="3" width="100%" border="0">

                    <tr>
                        <td style="width: 350px"></td>
                        <td style="width: 103px">
                            <strong>Mã nhân viên: </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txtMaNV" CssClass="txt_css" runat="server" Width="300px"></asp:TextBox>
                            <b>
                                <asp:CheckBox ID="IsChechNghis" runat="server" Text="Nghỉ làm" /></b>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <strong>Tên nhân viên: </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="HoVaTen" CssClass="txt_css" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td style="width: 350px"></td>
                        <td style="width: 103px">
                            <strong>Số điện thoại: </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="SoDienThoai" CssClass="txt_css" runat="server" Width="300px"></asp:TextBox>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <strong>Bộ phận: </strong>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlBoPhan" runat="server" CssClass="txt" Style="height: 30px; width: 306px;">
                                <asp:ListItem Value="1">Quản trị viên</asp:ListItem>
                                <asp:ListItem Value="2">Sale online</asp:ListItem>
                                <asp:ListItem Value="3">Sale sàn TMĐT</asp:ListItem>
                                <asp:ListItem Value="4">Kỹ thuật viên</asp:ListItem>
                                <asp:ListItem Value="5">NV bán hàng trực tiếp</asp:ListItem>
                                <asp:ListItem Value="6">Kế toán</asp:ListItem>
                                <asp:ListItem Value="7">Thu ngân</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>

                    <tr>
                        <td></td>
                        <td>
                            <strong><%=label("lt_password")%>: </strong>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_password" CssClass="txt_css" runat="server" Width="300px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr style="border-block: dashed 1px rgb(145, 141, 141)">
                        <td></td>
                        <td style="height: 14px" colspan="2" class="aaaaaaa">
                            <div style="clear: both; height: 20px;"></div>
                            <div><b style="color: red">CÀI ĐẶT HỆ THỐNG</b></div>
                            <table id="tbl_Item" class="table table-bordered" style="width: 60%">
                                <tbody>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Cấu hình: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Thêm, Sửa, Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Cước phí vận chuyển: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_CuocPhi_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_CuocPhi_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_CuocPhi_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Thông tin chân trang: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_ChanTrang_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_ChanTrang_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_ChanTrang_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>


                                </tbody>
                            </table>
                            <div style="clear: both; height: 20px;"></div>
                            <div style="clear: both"></div>
                            <div><b style="color: red">QUẢN LÝ SẢN PHẨM</b></div>
                            <div style="clear: both; height: 20px;"></div>
                            <table id="tbl_Item" class="table table-bordered" style="width: 60%">
                                <tbody>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Phân loại sản phẩm: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_DanhSachSP_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_DanhSachSP_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_DanhSachSP_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Thuộc tính so sánh: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_SoSanhSP_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_SoSanhSP_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_SoSanhSP_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                     <tr>
                                        <td style="width: 35%">
                                            <b>- Nhà sản xuất: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_NhaSX_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_NhaSX_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_NhaSX_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Trọng lượng: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TrongLuong_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TrongLuong_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TrongLuong_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Bảo hành: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_BaoHanhSP_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_BaoHanhSP_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_BaoHanhSP_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Danh sách sản phẩm: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="CheckBox25" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="CheckBox26" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="CheckBox27" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Cấu hình: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_CauHinh_SP" runat="server" Text="Được cấu hình" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div style="clear: both; height: 20px;"></div>
                            <div><b style="color: red">QUẢN LÝ ĐƠN HÀNG</b></div>

                            <table id="tbl_Item" class="table table-bordered" style="width: 101%">
                                <tbody>
                                    <tr>
                                        <td style="width: 12%">
                                            <b>- Đơn đặt hàng : </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 53%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 78%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_cart_Xem" runat="server" Text="Xem" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="CheckBox23" runat="server" Text="Duyệt" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_cart_Huy" runat="server" Text="Hủy" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_cart_Xoa" runat="server" Text="Xóa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_cart_Exel" runat="server" Text="Xuất Exel" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                    </tbody>
                                </table>
                                     <table id="tbl_Item" class="table table-bordered" style="width: 61%">
     <tbody>

                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Yêu cầu báo giá: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_BaoGia_X" runat="server" Text="Xem" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_BaoGia_S" runat="server" Text="Xóa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_BaoGia_XL" runat="server" Text="Xử lý" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                     <tr>
                                        <td style="width: 35%">
                                            <b>- Yêu cầu tư vấn: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TuVan_X" runat="server" Text="Xem" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TuVan_S" runat="server" Text="Xóa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TuVan_XL" runat="server" Text="Xử lý" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div style="clear: both; height: 20px;"></div>

                            <div style="clear: both"></div>
                            <div><b style="color: red">MODUL QUẢN LÝ </b></div>

                            <table id="tbl_Item" class="table table-bordered" style="width: 75%">
                                <tbody>
                                    <tr>
                                        <td style="width: 27%">
                                            <b>- Quản lý thành viên: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 9.5%">
                                                            <asp:CheckBox ID="check_ThanhVien_Xem" runat="server" Text="Xem" />
                                                        </td>
                                                        <td style="width: 9%">
                                                            <asp:CheckBox ID="check_ThanhVien_RS" runat="server" Text="Reset pass" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_ThanhVien_KHoa" runat="server" Text="Khóa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_ThanhVien_XTK" runat="server" Text="Xóa TK" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                </tbody>
                            </table>

                            <div style="clear: both; height: 20px;"></div>
                            <div><b style="color: red">THÔNG TIN TIỆN ÍCH</b></div>

                            <table id="tbl_Item" class="table table-bordered" style="width: 60%">
                                <tbody>
                                    <tr>
                                        <td style="width: 27%">
                                            <b>- Liên hệ: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_LienHe_X" runat="server" Text="Xem" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_LienHe_XL" runat="server" Text="Xử lý" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_LienHe_XOA" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Hình ảnh quảng cáo: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_QuangCao_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_QuangCao_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_QuangCao_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>


                                </tbody>

                                </tbody>
                            </table>


                            <div style="clear: both; height: 20px"></div>
                            <div><b style="color: red">QUẢN LÝ THƯ VIỆN</b></div>

                            <table id="tbl_Item" class="table table-bordered" style="width: 60%">
                                <tbody>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Tin tức: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TinTuc_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TinTuc_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_TinTuc_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Video: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_Video_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_Video_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_Video_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Giới thiệu: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_GioiThieu_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_GioiThieu_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_GioiThieu_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 35%">
                                            <b>- Tài liệu - Download: </b>
                                        </td>
                                        <td style="width: 5%"></td>
                                        <td style="width: 75%">
                                            <table id="tbl_Item_11" class="table table-bordered" style="width: 100%">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_File_T" runat="server" Text="Thêm mới" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_File_S" runat="server" Text="Sửa" />
                                                        </td>
                                                        <td style="width: 10%">
                                                            <asp:CheckBox ID="check_File_X" runat="server" Text="Xóa" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div style="display: none">
                                <asp:CheckBox ID="CheckBox3" Visible="false" runat="server" Text="Thông tin Sản phẩm" /><br />
                                <asp:CheckBox ID="CheckBox28" Visible="false" ForeColor="Red" runat="server" Text="Vị trí Kho Sản phẩm" /><br />
                                <asp:CheckBox ID="CheckBox29" Visible="false" ForeColor="Red" runat="server" Text="Sửa - Vị trí Kho Sản phẩm" /><br />

                                <asp:CheckBox ID="CheckBox16" runat="server" Text="Quản lý menu chính" /><br />
                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Thông tin Tin tức" /><br />

                                <asp:CheckBox ID="CheckBox15" runat="server" Text="Quản trị giỏ hàng" /><br />
                                <asp:CheckBox ID="CheckBox24" runat="server" ForeColor="Red" Text="Thêm nhanh đặt hàng" /><br />

                                <asp:CheckBox ID="CheckBox4" runat="server" Text="Tài khoản hệ thống" /><br />
                                <asp:CheckBox ID="CheckBox5" runat="server" Text="Thông tin Liên hệ" /><br />
                                <asp:CheckBox ID="CheckBox6" runat="server" Text="Hình ảnh Quảng cáo" /><br />

                                <asp:CheckBox ID="CheckBox13" runat="server" Text="PhotoAlbum" /><br />
                                <asp:CheckBox ID="CheckBox7" runat="server" Text="Thư viện Download File" /><br />
                                <asp:CheckBox ID="CheckBox8" runat="server" Text="Video - Clip" /><br />
                                <asp:CheckBox ID="CheckBox9" runat="server" Text="Tiện ích -Yahoo" /><br />
                                <asp:CheckBox ID="CheckBox10" runat="server" Text="Thông tin - Dịch vụ" /><br />
                                <asp:CheckBox ID="CheckBox11" runat="server" Text="Thông tin - Giới thiệu" /><br />
                                <asp:CheckBox ID="CheckBox12" runat="server" Text="Marketing" /><br />
                                <asp:CheckBox ID="CheckBox21" runat="server" Text="Biểu đồ thống kê" />

                                <asp:CheckBox ID="CheckBox20" Visible="false" runat="server" Text="Hệ thống xuất bản" />
                                <asp:CheckBox ID="CheckBox14" Visible="false" runat="server" Text="Bình chọn" />
                                <asp:CheckBox ID="CheckBox17" Visible="false" runat="server" Text="Site map" />
                                <asp:CheckBox ID="CheckBox18" Visible="false" runat="server" Text="Quản lý liên hệ" />
                            </div>




                        </td>
                        <td style="height: 14px"></td>
                        <td style="height: 14px"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <strong>
                                <%=label("lt_enable")%></strong>
                        </td>
                        <td style="height: 1px">
                            <asp:CheckBox ID="chk_enable" runat="server"></asp:CheckBox>
                        </td>
                        <td style="height: 1px"></td>
                        <td style="height: 1px"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                        <td style="height: 4px">
                            <asp:Button ID="btn_update" runat="server" OnClick="btn_update_Click"></asp:Button>
                            <asp:Button ID="btn_cancel" runat="server" OnClick="btn_cancel_Click"></asp:Button>
                        </td>
                        <td style="height: 4px"></td>
                        <td style="height: 4px"></td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnupdatepassword" runat="server" Visible="False">
            <div class='frm-add'>
                <table class="all" border="0" width="100%" cellpadding="0" cellspacing="0">
                    <tr align="center">
                        <td style="width: 200px">
                            <%=label("lt_newpassword")%>
                        </td>
                        <td></td>
                        <td align="left">
                            <asp:TextBox ID="txtnewpassword" runat="server" CssClass="txt_css" Width="279px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 200px; height: 40px;"></td>
                        <td style="height: 40px"></td>
                        <td align="left" style="height: 40px">
                            <asp:Button ID="btnupdatenewpassword" runat="server" OnClick="btnupdatenewpassword_Click" />
                            <asp:Button ID="btnCancelUpdatePass" runat="server" OnClick="btn_cancel_Click" />
                        </td>
                    </tr>
                    <input id="hdid" runat="server" style="width: 36px" type="hidden" />
                </table>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>


<style>
    .aaaaaaa table tr td {
        padding-top: 0px !important;
        padding-bottom: 0px !important;
    }

    .frm-add table tr td {
        border-bottom: none;
    }

    table#tbl_Item {
        margin-left: 27px;
    }
</style>
